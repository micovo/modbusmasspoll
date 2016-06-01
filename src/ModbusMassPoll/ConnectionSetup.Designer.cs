namespace ModbusMassPoll
{
    partial class ConnectionSetup
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbType = new System.Windows.Forms.ComboBox();
            this.gbSerial = new System.Windows.Forms.GroupBox();
            this.gbSerialFlow = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.checkBox4 = new System.Windows.Forms.CheckBox();
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.cbSerialStopBits = new System.Windows.Forms.ComboBox();
            this.cbSerialParity = new System.Windows.Forms.ComboBox();
            this.cbSerialBits = new System.Windows.Forms.ComboBox();
            this.cbSerialBaud = new System.Windows.Forms.ComboBox();
            this.cbSerialPort = new System.Windows.Forms.ComboBox();
            this.buttonOK = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.gbSerialMode = new System.Windows.Forms.GroupBox();
            this.radioASCII = new System.Windows.Forms.RadioButton();
            this.radioRTU = new System.Windows.Forms.RadioButton();
            this.gbSerialTimeout = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbSerialTimeout = new System.Windows.Forms.TextBox();
            this.gbTCP = new System.Windows.Forms.GroupBox();
            this.radioIP6 = new System.Windows.Forms.RadioButton();
            this.radioIP4 = new System.Windows.Forms.RadioButton();
            this.label6 = new System.Windows.Forms.Label();
            this.tbConnTimeout = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tbPort = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cbAddress = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.gbSerial.SuspendLayout();
            this.gbSerialFlow.SuspendLayout();
            this.gbSerialMode.SuspendLayout();
            this.gbSerialTimeout.SuspendLayout();
            this.gbTCP.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbType);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(288, 47);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Connection";
            // 
            // cbType
            // 
            this.cbType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbType.FormattingEnabled = true;
            this.cbType.Items.AddRange(new object[] {
            "Serial Port",
            "Modbus TCP/IP"});
            this.cbType.Location = new System.Drawing.Point(9, 19);
            this.cbType.Name = "cbType";
            this.cbType.Size = new System.Drawing.Size(270, 21);
            this.cbType.TabIndex = 0;
            this.cbType.SelectedIndexChanged += new System.EventHandler(this.cbType_SelectedIndexChanged);
            // 
            // gbSerial
            // 
            this.gbSerial.Controls.Add(this.gbSerialFlow);
            this.gbSerial.Controls.Add(this.cbSerialStopBits);
            this.gbSerial.Controls.Add(this.cbSerialParity);
            this.gbSerial.Controls.Add(this.cbSerialBits);
            this.gbSerial.Controls.Add(this.cbSerialBaud);
            this.gbSerial.Controls.Add(this.cbSerialPort);
            this.gbSerial.Location = new System.Drawing.Point(12, 65);
            this.gbSerial.Name = "gbSerial";
            this.gbSerial.Size = new System.Drawing.Size(288, 171);
            this.gbSerial.TabIndex = 1;
            this.gbSerial.TabStop = false;
            this.gbSerial.Text = "Serial Settings";
            // 
            // gbSerialFlow
            // 
            this.gbSerialFlow.Controls.Add(this.label1);
            this.gbSerialFlow.Controls.Add(this.textBox1);
            this.gbSerialFlow.Controls.Add(this.checkBox4);
            this.gbSerialFlow.Controls.Add(this.checkBox3);
            this.gbSerialFlow.Controls.Add(this.checkBox2);
            this.gbSerialFlow.Controls.Add(this.checkBox1);
            this.gbSerialFlow.Location = new System.Drawing.Point(107, 58);
            this.gbSerialFlow.Name = "gbSerialFlow";
            this.gbSerialFlow.Size = new System.Drawing.Size(172, 103);
            this.gbSerialFlow.TabIndex = 6;
            this.gbSerialFlow.TabStop = false;
            this.gbSerialFlow.Text = "Flow Control";
            this.gbSerialFlow.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(49, 72);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(115, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "[ms] RTS disable delay";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(9, 69);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(38, 20);
            this.textBox1.TabIndex = 4;
            this.textBox1.Text = "1";
            // 
            // checkBox4
            // 
            this.checkBox4.AutoSize = true;
            this.checkBox4.Checked = true;
            this.checkBox4.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox4.Location = new System.Drawing.Point(9, 46);
            this.checkBox4.Name = "checkBox4";
            this.checkBox4.Size = new System.Drawing.Size(84, 17);
            this.checkBox4.TabIndex = 3;
            this.checkBox4.Text = "RTS Toggle";
            this.checkBox4.UseVisualStyleBackColor = true;
            // 
            // checkBox3
            // 
            this.checkBox3.AutoSize = true;
            this.checkBox3.Checked = true;
            this.checkBox3.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox3.Location = new System.Drawing.Point(117, 23);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new System.Drawing.Size(49, 17);
            this.checkBox3.TabIndex = 2;
            this.checkBox3.Text = "DTR";
            this.checkBox3.UseVisualStyleBackColor = true;
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(64, 23);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(47, 17);
            this.checkBox2.TabIndex = 1;
            this.checkBox2.Text = "CTS";
            this.checkBox2.UseVisualStyleBackColor = true;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(9, 23);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(49, 17);
            this.checkBox1.TabIndex = 0;
            this.checkBox1.Text = "DSR";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // cbSerialStopBits
            // 
            this.cbSerialStopBits.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSerialStopBits.FormattingEnabled = true;
            this.cbSerialStopBits.Items.AddRange(new object[] {
            "1 Stop Bit",
            "2 Stop Bits"});
            this.cbSerialStopBits.Location = new System.Drawing.Point(9, 140);
            this.cbSerialStopBits.Name = "cbSerialStopBits";
            this.cbSerialStopBits.Size = new System.Drawing.Size(90, 21);
            this.cbSerialStopBits.TabIndex = 5;
            // 
            // cbSerialParity
            // 
            this.cbSerialParity.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSerialParity.FormattingEnabled = true;
            this.cbSerialParity.Items.AddRange(new object[] {
            "None Parity",
            "Odd Parity",
            "Even Parity"});
            this.cbSerialParity.Location = new System.Drawing.Point(9, 110);
            this.cbSerialParity.Name = "cbSerialParity";
            this.cbSerialParity.Size = new System.Drawing.Size(90, 21);
            this.cbSerialParity.TabIndex = 4;
            // 
            // cbSerialBits
            // 
            this.cbSerialBits.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSerialBits.FormattingEnabled = true;
            this.cbSerialBits.Items.AddRange(new object[] {
            "7 Data bits",
            "8 Data bits"});
            this.cbSerialBits.Location = new System.Drawing.Point(9, 80);
            this.cbSerialBits.Name = "cbSerialBits";
            this.cbSerialBits.Size = new System.Drawing.Size(90, 21);
            this.cbSerialBits.TabIndex = 3;
            // 
            // cbSerialBaud
            // 
            this.cbSerialBaud.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSerialBaud.FormattingEnabled = true;
            this.cbSerialBaud.Items.AddRange(new object[] {
            "300 Baud",
            "600 Baud",
            "1200 Baud",
            "2400 Baud",
            "4800 Baud",
            "9600 Baud",
            "14400 Baud",
            "19200 Baud",
            "38400 Baud",
            "56000 Baud",
            "57600 Baud",
            "115200 Baud",
            "128000 Baud",
            "230400 Baud",
            "256000 Baud"});
            this.cbSerialBaud.Location = new System.Drawing.Point(9, 49);
            this.cbSerialBaud.Name = "cbSerialBaud";
            this.cbSerialBaud.Size = new System.Drawing.Size(90, 21);
            this.cbSerialBaud.TabIndex = 2;
            // 
            // cbSerialPort
            // 
            this.cbSerialPort.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSerialPort.FormattingEnabled = true;
            this.cbSerialPort.Location = new System.Drawing.Point(9, 19);
            this.cbSerialPort.Name = "cbSerialPort";
            this.cbSerialPort.Size = new System.Drawing.Size(270, 21);
            this.cbSerialPort.TabIndex = 1;
            // 
            // buttonOK
            // 
            this.buttonOK.Location = new System.Drawing.Point(356, 12);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(75, 23);
            this.buttonOK.TabIndex = 2;
            this.buttonOK.Text = "OK";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(356, 41);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 3;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // gbSerialMode
            // 
            this.gbSerialMode.Controls.Add(this.radioASCII);
            this.gbSerialMode.Controls.Add(this.radioRTU);
            this.gbSerialMode.Location = new System.Drawing.Point(311, 141);
            this.gbSerialMode.Name = "gbSerialMode";
            this.gbSerialMode.Size = new System.Drawing.Size(120, 42);
            this.gbSerialMode.TabIndex = 4;
            this.gbSerialMode.TabStop = false;
            this.gbSerialMode.Text = "Mode";
            this.gbSerialMode.Visible = false;
            // 
            // radioASCII
            // 
            this.radioASCII.AutoSize = true;
            this.radioASCII.Location = new System.Drawing.Point(63, 17);
            this.radioASCII.Name = "radioASCII";
            this.radioASCII.Size = new System.Drawing.Size(52, 17);
            this.radioASCII.TabIndex = 1;
            this.radioASCII.Text = "ASCII";
            this.radioASCII.UseVisualStyleBackColor = true;
            // 
            // radioRTU
            // 
            this.radioRTU.AutoSize = true;
            this.radioRTU.Checked = true;
            this.radioRTU.Location = new System.Drawing.Point(9, 17);
            this.radioRTU.Name = "radioRTU";
            this.radioRTU.Size = new System.Drawing.Size(48, 17);
            this.radioRTU.TabIndex = 0;
            this.radioRTU.TabStop = true;
            this.radioRTU.Text = "RTU";
            this.radioRTU.UseVisualStyleBackColor = true;
            // 
            // gbSerialTimeout
            // 
            this.gbSerialTimeout.Controls.Add(this.label2);
            this.gbSerialTimeout.Controls.Add(this.tbSerialTimeout);
            this.gbSerialTimeout.Location = new System.Drawing.Point(311, 189);
            this.gbSerialTimeout.Name = "gbSerialTimeout";
            this.gbSerialTimeout.Size = new System.Drawing.Size(120, 47);
            this.gbSerialTimeout.TabIndex = 5;
            this.gbSerialTimeout.TabStop = false;
            this.gbSerialTimeout.Text = "Response Timeout";
            this.gbSerialTimeout.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(88, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(26, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "[ms]";
            // 
            // tbSerialTimeout
            // 
            this.tbSerialTimeout.Location = new System.Drawing.Point(9, 18);
            this.tbSerialTimeout.Name = "tbSerialTimeout";
            this.tbSerialTimeout.Size = new System.Drawing.Size(72, 20);
            this.tbSerialTimeout.TabIndex = 0;
            // 
            // gbTCP
            // 
            this.gbTCP.Controls.Add(this.radioIP6);
            this.gbTCP.Controls.Add(this.radioIP4);
            this.gbTCP.Controls.Add(this.label6);
            this.gbTCP.Controls.Add(this.tbConnTimeout);
            this.gbTCP.Controls.Add(this.label5);
            this.gbTCP.Controls.Add(this.tbPort);
            this.gbTCP.Controls.Add(this.label4);
            this.gbTCP.Controls.Add(this.cbAddress);
            this.gbTCP.Controls.Add(this.label3);
            this.gbTCP.Location = new System.Drawing.Point(12, 242);
            this.gbTCP.Name = "gbTCP";
            this.gbTCP.Size = new System.Drawing.Size(419, 115);
            this.gbTCP.TabIndex = 6;
            this.gbTCP.TabStop = false;
            this.gbTCP.Text = "Remote Modbus Server";
            // 
            // radioIP6
            // 
            this.radioIP6.AutoSize = true;
            this.radioIP6.Enabled = false;
            this.radioIP6.Location = new System.Drawing.Point(361, 83);
            this.radioIP6.Name = "radioIP6";
            this.radioIP6.Size = new System.Drawing.Size(47, 17);
            this.radioIP6.TabIndex = 2;
            this.radioIP6.Text = "IPv6";
            this.radioIP6.UseVisualStyleBackColor = true;
            // 
            // radioIP4
            // 
            this.radioIP4.AutoSize = true;
            this.radioIP4.Checked = true;
            this.radioIP4.Enabled = false;
            this.radioIP4.Location = new System.Drawing.Point(308, 83);
            this.radioIP4.Name = "radioIP4";
            this.radioIP4.Size = new System.Drawing.Size(47, 17);
            this.radioIP4.TabIndex = 7;
            this.radioIP4.TabStop = true;
            this.radioIP4.Text = "IPv4";
            this.radioIP4.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Enabled = false;
            this.label6.Location = new System.Drawing.Point(241, 87);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(26, 13);
            this.label6.TabIndex = 6;
            this.label6.Text = "[ms]";
            this.label6.Visible = false;
            // 
            // tbConnTimeout
            // 
            this.tbConnTimeout.Enabled = false;
            this.tbConnTimeout.Location = new System.Drawing.Point(147, 84);
            this.tbConnTimeout.Name = "tbConnTimeout";
            this.tbConnTimeout.Size = new System.Drawing.Size(90, 20);
            this.tbConnTimeout.TabIndex = 5;
            this.tbConnTimeout.Text = "3000";
            this.tbConnTimeout.Visible = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Enabled = false;
            this.label5.Location = new System.Drawing.Point(147, 68);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(88, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Connect Timeout";
            this.label5.Visible = false;
            // 
            // tbPort
            // 
            this.tbPort.Location = new System.Drawing.Point(9, 84);
            this.tbPort.Name = "tbPort";
            this.tbPort.Size = new System.Drawing.Size(90, 20);
            this.tbPort.TabIndex = 3;
            this.tbPort.Text = "502";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 68);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Server Port";
            // 
            // cbAddress
            // 
            this.cbAddress.FormattingEnabled = true;
            this.cbAddress.Location = new System.Drawing.Point(9, 38);
            this.cbAddress.Name = "cbAddress";
            this.cbAddress.Size = new System.Drawing.Size(401, 21);
            this.cbAddress.TabIndex = 1;
            this.cbAddress.Text = "127.0.0.1";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(130, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "IP Address or Node Name";
            // 
            // ConnectionSetup
            // 
            this.AcceptButton = this.buttonOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(443, 370);
            this.Controls.Add(this.gbTCP);
            this.Controls.Add(this.gbSerialTimeout);
            this.Controls.Add(this.gbSerialMode);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.gbSerial);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ConnectionSetup";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Connection Setup";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ConnectionSetup_FormClosing);
            this.groupBox1.ResumeLayout(false);
            this.gbSerial.ResumeLayout(false);
            this.gbSerialFlow.ResumeLayout(false);
            this.gbSerialFlow.PerformLayout();
            this.gbSerialMode.ResumeLayout(false);
            this.gbSerialMode.PerformLayout();
            this.gbSerialTimeout.ResumeLayout(false);
            this.gbSerialTimeout.PerformLayout();
            this.gbTCP.ResumeLayout(false);
            this.gbTCP.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cbType;
        private System.Windows.Forms.GroupBox gbSerial;
        private System.Windows.Forms.ComboBox cbSerialParity;
        private System.Windows.Forms.ComboBox cbSerialBits;
        private System.Windows.Forms.ComboBox cbSerialBaud;
        private System.Windows.Forms.ComboBox cbSerialPort;
        private System.Windows.Forms.GroupBox gbSerialFlow;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.CheckBox checkBox4;
        private System.Windows.Forms.CheckBox checkBox3;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.ComboBox cbSerialStopBits;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.GroupBox gbSerialMode;
        private System.Windows.Forms.RadioButton radioASCII;
        private System.Windows.Forms.RadioButton radioRTU;
        private System.Windows.Forms.GroupBox gbSerialTimeout;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbSerialTimeout;
        private System.Windows.Forms.GroupBox gbTCP;
        private System.Windows.Forms.RadioButton radioIP6;
        private System.Windows.Forms.RadioButton radioIP4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tbConnTimeout;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbPort;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbAddress;
        private System.Windows.Forms.Label label3;
    }
}