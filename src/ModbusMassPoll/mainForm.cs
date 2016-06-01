using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Globalization;
using System.Diagnostics;
using System.Xml.Linq;

using System.IO;
using System.IO.Ports;

using System.Net;
using System.Net.Sockets;
using FtdAdapter;
using Modbus.Data;
using Modbus.Device;
using Modbus.Utility;


namespace ModbusMassPoll
{
    public partial class mainForm : Form
    {
        Thread seqThread;
        bool seqThreadStop = false;
        bool seqThreadPause = true;

        ModbusMaster master = null;
        SerialPort serialPort = null;
        TcpClient tcpClient = null;

        int ScanRate = 5000;

        int Register = 0;
        int Quantity = 0;
        int StartAddr = 0;
        int StopAddr = 0;
        int UnitsCount = 0;
        int Function = 0;

        string version = "";
        int CurrentSlave = 0;

        
        const string default_project_filename = "default.xml";




        public mainForm()
        {
            InitializeComponent();


            System.Reflection.Assembly assembly = System.Reflection.Assembly.GetExecutingAssembly();
            FileVersionInfo fvi = FileVersionInfo.GetVersionInfo(assembly.Location);
            version = fvi.FileVersion;

            string builddate = Properties.Resources.BuildDate;
            int i = builddate.IndexOf(' ');
            i = i < 0 ? 0 : i;
            builddate = builddate.Substring(i).Trim(); //Remove name of the day

            this.Text += " " + version + " (" + builddate + ")";

            DataGridSetup();
            SequencerSetup();

            seqThreadStop = false;
            seqThread = new Thread(Sequencer_Worker);
            seqThread.Start();
        }


        private bool Connect(bool QuickConnect = false)
        {
            ConnectionSetup cs = new ConnectionSetup();
            string connection_text = "";

            if (QuickConnect == false)
            {
                DialogResult dr = cs.ShowDialog();

                if (dr != DialogResult.OK)
                {
                    return false;
                }
            }

            try
            {
                if (cs.IsOverSerialPort)
                {
                    serialPort = cs.GetSerialPort();
                    master = null;
                    serialPort.Open();
                    master = ModbusSerialMaster.CreateRtu(serialPort);

                    connection_text = string.Format("{0} @ {1} Baud", serialPort, serialPort.BaudRate);
                }
                else if (cs.IsOverTCP)
                {
                    master = null;
                    tcpClient = cs.GetTcpClient();
                    tcpClient.ReceiveTimeout = 1000;
                    master = ModbusIpMaster.CreateIp(tcpClient);

                    connection_text = string.Format("{0}:{1}", cs.TcpAddress, cs.TcpPort);
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Unable to connect", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            


            master.Transport.Retries = 0;

            disconnectToolStripMenuItem.Enabled = true;
            connectToolStripMenuItem.Enabled = false;
            quickConnectToolStripMenuItem.Enabled = false;

            gbModbusSetup.Enabled = false;

            CurrentSlave = 0;
            seqThreadPause = false;

            statusLabel.Text = "Connected to " + connection_text;

            return true;
        }

        private void Disconnect()
        {
            seqThreadPause = false;

            if (master != null)
            {
                master.Dispose();
                master = null;
            }

            if (serialPort != null)
            {
                if (serialPort.IsOpen) serialPort.Close();
                serialPort.Dispose();
                serialPort = null;
            }

            if (tcpClient != null)
            {
                tcpClient.Close();
                tcpClient = null;
            }

            disconnectToolStripMenuItem.Enabled = false;
            connectToolStripMenuItem.Enabled = true;
            quickConnectToolStripMenuItem.Enabled = true;
            
            gbModbusSetup.Enabled = true;

            statusLabel.Text = "Disconnected";

            CurrentSlave = 0;
        }


        private void DataGridSetup()
        {
            CurrentSlave = 0;

            Register = (int)numAddress.Value;
            Quantity = (int)numQuantity.Value;

            StartAddr = (int)numSlaveStart.Value;
            StopAddr = (int)numSlaveStop.Value;

            if (StopAddr < StartAddr)
            {
                StopAddr = StartAddr;
                numSlaveStop.Value = StartAddr;
            }

            Function = cbFunction.SelectedIndex;


            dataGrid.Columns.Clear();

            dataGrid.Columns.Add("colSlaveAddr", "Address");
            dataGrid.Columns.Add("colRequests", "Requests");
            dataGrid.Columns.Add("colErrors", "Errors");

            for (int i = 0; i < Quantity; i++)
            {
                int reg = i + Register;
                dataGrid.Columns.Add("col" + reg.ToString(), reg.ToString());
            }


            UnitsCount = StopAddr - StartAddr + 1;


            for (int i = 0; i < UnitsCount; i++)
            {
                dataGrid.Rows.Add(StartAddr + i, 0, 0);
            }
        }

        private void SequencerSetup()
        {
            ScanRate = (int)numScanRate.Value;
        }


        #region Events

        private void connectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Connect();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox1 ab = new AboutBox1();

            ab.ShowDialog();
        }

       

        private void disconnectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Disconnect();

        }

        private void quickConnectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Connect(true);
        }



        private void numModbusSetup_ValueChanged(object sender, EventArgs e)
        {
            DataGridSetup();
        }

        private void cbFunction_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataGridSetup();
        }

        private void numSlaveStart_ValueChanged(object sender, EventArgs e)
        {
            DataGridSetup();
        }

        private void numPollTime_ValueChanged(object sender, EventArgs e)
        {
            SequencerSetup();
        }

        private void resetCountersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dataGrid.Rows.Count; i++)
            {
                dataGrid.Rows[i].Cells[1].Value = 0;
                dataGrid.Rows[i].Cells[2].Value = 0;
                CurrentSlave = 0;
            }
        }


        private void mainForm_Load(object sender, EventArgs e)
        {
            LoadProject(default_project_filename);
        }


        private void mainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveProject();

            Disconnect();

            seqThreadStop = true;
            seqThread.Join();
        }


        #endregion





        private void Sequencer_Worker()
        {
            while (seqThreadStop == false)
            {
                if (master != null)
                {
                    byte slaveId = (byte)(StartAddr + CurrentSlave);
                    ushort startAddress = (ushort)Register;
                    ushort numInputs = (ushort)Quantity;

                    //datagridview was resized
                    if (dataGrid.Rows.Count - 1 < CurrentSlave)
                    {
                        CurrentSlave = 0;
                    }

                    int requests = (int)dataGrid.Rows[CurrentSlave].Cells[1].Value;
                    int errors = (int)dataGrid.Rows[CurrentSlave].Cells[2].Value;

                    requests++;

                    try
                    {
                        // write three registers
                        ushort[] inputs = null;
                        bool[] bools = null;

                        switch (Function)
                        {
                            case 0:
                                bools = master.ReadCoils(slaveId, startAddress, numInputs);
                                break;
                            case 1:
                                bools = master.ReadInputs(slaveId, startAddress, numInputs);
                                break;
                            case 2:
                                inputs = master.ReadHoldingRegisters(slaveId, startAddress, numInputs);
                                break;
                            case 3:
                                inputs = master.ReadInputRegisters(slaveId, startAddress, numInputs);
                                break;
                        }


                        if (bools != null)
                        {
                            for (int i = 0; i < numInputs; i++)
                            {
                                dataGrid.Rows[CurrentSlave].Cells[i + 3].Value = bools[i] ? "1" : "0";
                            }
                        }
                        else if (inputs != null)
                        {
                            for (int i = 0; i < numInputs; i++)
                            {
                                dataGrid.Rows[CurrentSlave].Cells[i + 3].Value = (short)(inputs[i]);
                            }
                        }

                    }
                    catch (Exception ex)
                    {
                        errors++;
                    }

                    dataGrid.Rows[CurrentSlave].Cells[1].Value = requests;
                    dataGrid.Rows[CurrentSlave].Cells[2].Value = errors;


                    CurrentSlave++;

                    if ((CurrentSlave + StartAddr) > StopAddr)
                    {
                        CurrentSlave = 0;
                    }

                    Thread.Sleep(ScanRate);
                }


                while (seqThreadPause)
                {
                    Thread.Sleep(100);
                }
            }
        }



      


        public void LoadProject(string filename)
        {
            bool LoadFailed = true;
            
            try
            {
                if (File.Exists(filename))
                {
                    XElement project = XElement.Load(filename);

                    numSlaveStart.Value = int.Parse(project.Element("startaddr").Value);
                    numSlaveStop.Value = int.Parse(project.Element("stopaddr").Value);

                    numAddress.Value = int.Parse(project.Element("register").Value);
                    numQuantity.Value = int.Parse(project.Element("quantity").Value);

                    cbFunction.SelectedIndex = int.Parse(project.Element("function").Value);

                    numScanRate.Value = int.Parse(project.Element("scanrate").Value);


                    if (project.Element("maximazed").Value == "1")
                    {
                        this.WindowState = FormWindowState.Maximized;
                    }
                    else
                    {
                        this.Width = int.Parse(project.Element("width").Value);
                        this.Height = int.Parse(project.Element("height").Value);
                    }
                    

                    LoadFailed = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Unable to load old settings", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if (LoadFailed)
            {
                LoadDefaults();
            }

            DataGridSetup();
        }



        private void LoadDefaults()
        {
            //Load default values
            numSlaveStart.Value = 150;
            numSlaveStop.Value = 150;

            numAddress.Value = 6060;
            numQuantity.Value = 12;

            cbFunction.SelectedIndex = 3;

            numScanRate.Value = 1000;
        }

        public void SaveProject()
        {
            XElement project = new XElement("masspollproject");

            project.SetAttributeValue("version", version);

            project.Add(new XElement("scanrate", ScanRate));

            project.Add(new XElement("startaddr", StartAddr));
            project.Add(new XElement("stopaddr", StopAddr));
            project.Add(new XElement("function", Function));
            project.Add(new XElement("register", Register));
            project.Add(new XElement("quantity", Quantity));

            project.Add(new XElement("width", this.Width));
            project.Add(new XElement("height", this.Height));
            project.Add(new XElement("maximazed", (this.WindowState == FormWindowState.Maximized) ? "1" : "0"));

            project.Save(default_project_filename);
        }


        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadDefaults();
        }
    }
}
