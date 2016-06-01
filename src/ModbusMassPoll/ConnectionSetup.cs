using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Windows.Forms;
using System.IO;
using System.IO.Ports;
using System.Xml.Linq;

namespace ModbusMassPoll
{
    


    public partial class ConnectionSetup : Form
    {
        int serialTimeout = 1000;
        int tcpPort = 502;

        const string settings_filename = "connection.xml";

        public bool IsOverSerialPort
        {
            get
            {
                return (cbType.SelectedIndex == 0);
            }
        }

        public bool IsOverTCP
        {
            get
            {
                return (cbType.SelectedIndex == 1);
            }
        }

        public string TcpAddress
        {
            get
            {
                return cbAddress.Text;
            }
        }

        public int TcpPort
        {
            get
            {
                return tcpPort;
            }
        }

        public void LoadSettings()
        {
            bool LoadFailed = true;

            try
            {
                if (File.Exists(settings_filename))
                {
                    XElement settings = XElement.Load(settings_filename);
                    XElement serialport = settings.Element("serialport");
                    XElement tcpclient = settings.Element("tcpclient");
                    XElement history = tcpclient.Element("history");

                    cbType.SelectedIndex = int.Parse(settings.Element("type").Value);

                    cbSerialPort.SelectedItem = serialport.Element("portname").Value;
                    cbSerialBaud.SelectedItem = serialport.Element("baudrate").Value;
                    cbSerialParity.SelectedIndex = int.Parse(serialport.Element("parity").Value);
                    cbSerialStopBits.SelectedIndex = int.Parse(serialport.Element("stopbits").Value);
                    cbSerialBits.SelectedIndex = int.Parse(serialport.Element("bits").Value);

                    serialTimeout = int.Parse(serialport.Element("timeout").Value);
                    tbSerialTimeout.Text = serialTimeout.ToString();

                    
                    tcpPort = int.Parse(tcpclient.Element("port").Value);
                    tbPort.Text = tcpPort.ToString();
                    cbAddress.Text = tcpclient.Element("hostname").Value;

                    if (history != null)
                    {
                        IEnumerable<XElement> history_hosts = history.Elements("hostname");

                        foreach (XElement xe in history_hosts)
                        {
                            cbAddress.Items.Add(xe.Value);
                        }
                    }



                    tbConnTimeout.Text = "3000";

                    LoadFailed = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Unable to load old settings", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if (LoadFailed)
            {

                //Load default values
                cbType.SelectedIndex = 0;

                cbSerialPort.SelectedItem = "COM1";
                cbSerialBaud.SelectedItem = "9600 Baud";
                cbSerialParity.SelectedIndex = 0;
                cbSerialStopBits.SelectedIndex = 0;
                cbSerialBits.SelectedIndex = 1;
                tbSerialTimeout.Text = "1000";

                cbAddress.Text = "127.0.0.1";
                cbAddress.Items.Add("127.0.0.1");

                tbPort.Text = "502";
                tbConnTimeout.Text = "3000";
            }
        }


        public void SaveSettings()
        {
            int.TryParse(tbSerialTimeout.Text, out serialTimeout);
            int.TryParse(tbPort.Text, out tcpPort);
            

            XElement settings = new XElement("settings");

            settings.Add(new XElement("type", cbType.SelectedIndex));

            XElement serialport = new XElement("serialport");
            serialport.Add(new XElement("portname", cbSerialPort.Text));
            serialport.Add(new XElement("baudrate", cbSerialBaud.Text));
            serialport.Add(new XElement("parity", cbSerialParity.SelectedIndex));
            serialport.Add(new XElement("stopbits", cbSerialStopBits.SelectedIndex));
            serialport.Add(new XElement("bits", cbSerialBits.SelectedIndex));
            serialport.Add(new XElement("timeout", serialTimeout));


            XElement tcpclient = new XElement("tcpclient");
            tcpclient.Add(new XElement("hostname", cbAddress.Text));
            tcpclient.Add(new XElement("port", tcpPort));

            XElement history = new XElement("history");

            if (cbAddress.Items.Contains(cbAddress.Text) == false)
            {
                cbAddress.Items.Add(cbAddress.Text);
            }

            foreach (string it in cbAddress.Items)
            {
                history.Add(new XElement("hostname", it));
            }

            tcpclient.Add(history);

            settings.Add(serialport);
            settings.Add(tcpclient);
            settings.Save(settings_filename);
        }


        public SerialPort GetSerialPort()
        {
            SerialPort port = new System.IO.Ports.SerialPort(cbSerialPort.Text);

            port.BaudRate = int.Parse(cbSerialBaud.Text.Split(' ')[0].Trim());
            port.DataBits = int.Parse(cbSerialBits.Text.Split(' ')[0].Trim());
            port.StopBits = (cbSerialStopBits.SelectedIndex == 0) ? StopBits.One : StopBits.Two;
            port.Parity = Parity.None;

            if (cbSerialParity.SelectedIndex == 1)
            {
                port.Parity = Parity.Odd;
            }
            else if (cbSerialParity.SelectedIndex == 2)
            {
                port.Parity = Parity.Even;
            }
            
            return port;
        }

        public ConnectionSetup()
        {
            InitializeComponent();

            for (int i = 1; i < 255; i++)
            {
                cbSerialPort.Items.Add(string.Format("COM{0}", i));
            }

            LoadSettings();
        }

        public TcpClient GetTcpClient()
        {
            string hostname = cbAddress.Text;
            int port = int.Parse(tbPort.Text);

            TcpClient client = new TcpClient(hostname, port);
            
            return client;
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void cbType_SelectedIndexChanged(object sender, EventArgs e)

        {
            gbSerial.Enabled = (cbType.SelectedIndex == 0);
            gbSerialMode.Enabled = (cbType.SelectedIndex == 0);
            gbSerialTimeout.Enabled = (cbType.SelectedIndex == 0);

            gbTCP.Enabled = (cbType.SelectedIndex == 1);

        }


        private void ConnectionSetup_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.DialogResult == DialogResult.OK)
            {
                SaveSettings();
            }
        }
    }
}
