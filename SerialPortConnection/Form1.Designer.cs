namespace SerialPortConnection
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.encSend = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.cbParity = new System.Windows.Forms.ComboBox();
            this.cbStop = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.cbDataBits = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cbBaudRate = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnSend = new System.Windows.Forms.Button();
            this.txtSend = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtSecond = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbTimeSend = new System.Windows.Forms.CheckBox();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.rbRcvStr = new System.Windows.Forms.RadioButton();
            this.rbRcv16 = new System.Windows.Forms.RadioButton();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.radio1 = new System.Windows.Forms.RadioButton();
            this.rdSendStr = new System.Windows.Forms.RadioButton();
            this.btnSwitch = new System.Windows.Forms.Button();
            this.cbSerial = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtSendView = new System.Windows.Forms.RichTextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtReceiveEnc = new System.Windows.Forms.RichTextBox();
            this.txtReceive = new System.Windows.Forms.RichTextBox();
            this.groupBox9 = new System.Windows.Forms.GroupBox();
            this.carUnencCtrl = new System.Windows.Forms.RadioButton();
            this.carEncCtrl = new System.Windows.Forms.RadioButton();
            this.carCtrlStop = new System.Windows.Forms.PictureBox();
            this.carCtrlBack = new System.Windows.Forms.PictureBox();
            this.carCtrlFront = new System.Windows.Forms.PictureBox();
            this.carCtrlRight = new System.Windows.Forms.PictureBox();
            this.carCtrlLeft = new System.Windows.Forms.PictureBox();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.tmSend = new System.Windows.Forms.Timer(this.components);
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tsSpNum = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsBaudRate = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsDataBits = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsStopBits = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsParity = new System.Windows.Forms.ToolStripStatusLabel();
            this.restrTimer = new System.Windows.Forms.Timer(this.components);
            this.activate = new System.Windows.Forms.Button();
            this.getControl = new System.Windows.Forms.Button();
            this.clrRestr = new System.Windows.Forms.Button();
            this.stopGenerate = new System.Windows.Forms.Button();
            this.generateSKG = new System.Windows.Forms.Button();
            this.handOver = new System.Windows.Forms.Button();
            this.getVersion = new System.Windows.Forms.Button();
            this.xAxis = new System.Windows.Forms.TextBox();
            this.landing = new System.Windows.Forms.Button();
            this.zAxis = new System.Windows.Forms.TextBox();
            this.freeControl = new System.Windows.Forms.Button();
            this.yAxis = new System.Windows.Forms.TextBox();
            this.yaw = new System.Windows.Forms.TextBox();
            this.moveControl = new System.Windows.Forms.Button();
            this.selfReturn = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.button3 = new System.Windows.Forms.Button();
            this.qTextSend = new System.Windows.Forms.TextBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.button2 = new System.Windows.Forms.Button();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.label25 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.backMove = new System.Windows.Forms.PictureBox();
            this.forwardMove = new System.Windows.Forms.PictureBox();
            this.rightMove = new System.Windows.Forms.PictureBox();
            this.leftMove = new System.Windows.Forms.PictureBox();
            this.label21 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.downMove = new System.Windows.Forms.PictureBox();
            this.upMove = new System.Windows.Forms.PictureBox();
            this.rightYaw = new System.Windows.Forms.PictureBox();
            this.leftYaw = new System.Windows.Forms.PictureBox();
            this.movStop = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.label17 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.unencCtrl = new System.Windows.Forms.RadioButton();
            this.encCtrl = new System.Windows.Forms.RadioButton();
            this.platformTrans = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox8.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox9.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.carCtrlStop)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.carCtrlBack)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.carCtrlFront)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.carCtrlRight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.carCtrlLeft)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.backMove)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.forwardMove)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rightMove)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.leftMove)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.downMove)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.upMove)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rightYaw)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.leftYaw)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Controls.Add(this.encSend);
            this.groupBox1.Controls.Add(this.btnSave);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Controls.Add(this.btnSend);
            this.groupBox1.Controls.Add(this.txtSend);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtSecond);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.cbTimeSend);
            this.groupBox1.Controls.Add(this.groupBox8);
            this.groupBox1.Controls.Add(this.groupBox7);
            this.groupBox1.Controls.Add(this.btnSwitch);
            this.groupBox1.Controls.Add(this.cbSerial);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(10, 10);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(6);
            this.groupBox1.Size = new System.Drawing.Size(594, 376);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "串口参数";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(14, 440);
            this.textBox1.Margin = new System.Windows.Forms.Padding(6);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(396, 35);
            this.textBox1.TabIndex = 35;
            this.textBox1.Visible = false;
            // 
            // encSend
            // 
            this.encSend.Location = new System.Drawing.Point(426, 440);
            this.encSend.Margin = new System.Windows.Forms.Padding(6);
            this.encSend.Name = "encSend";
            this.encSend.Size = new System.Drawing.Size(150, 46);
            this.encSend.TabIndex = 34;
            this.encSend.Text = "加密发送";
            this.encSend.UseVisualStyleBackColor = true;
            this.encSend.Visible = false;
            this.encSend.Click += new System.EventHandler(this.encSend_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(414, 28);
            this.btnSave.Margin = new System.Windows.Forms.Padding(6);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(150, 42);
            this.btnSave.TabIndex = 32;
            this.btnSave.Text = "保存设置";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label9.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.label9.Location = new System.Drawing.Point(12, 492);
            this.label9.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(442, 24);
            this.label9.TabIndex = 31;
            this.label9.Text = "(16进制时，用空格或“，”将字节隔开)";
            this.label9.Visible = false;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.cbParity);
            this.groupBox3.Controls.Add(this.cbStop);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.cbDataBits);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.cbBaudRate);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Location = new System.Drawing.Point(18, 78);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(6);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(6);
            this.groupBox3.Size = new System.Drawing.Size(556, 142);
            this.groupBox3.TabIndex = 30;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "串口设置";
            // 
            // cbParity
            // 
            this.cbParity.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbParity.FormattingEnabled = true;
            this.cbParity.Items.AddRange(new object[] {
            "无",
            "奇校验",
            "偶校验"});
            this.cbParity.Location = new System.Drawing.Point(404, 88);
            this.cbParity.Margin = new System.Windows.Forms.Padding(6);
            this.cbParity.Name = "cbParity";
            this.cbParity.Size = new System.Drawing.Size(132, 32);
            this.cbParity.TabIndex = 29;
            // 
            // cbStop
            // 
            this.cbStop.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbStop.FormattingEnabled = true;
            this.cbStop.Items.AddRange(new object[] {
            "1",
            "1.5",
            "2"});
            this.cbStop.Location = new System.Drawing.Point(122, 88);
            this.cbStop.Margin = new System.Windows.Forms.Padding(6);
            this.cbStop.Name = "cbStop";
            this.cbStop.Size = new System.Drawing.Size(122, 32);
            this.cbStop.TabIndex = 28;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label8.Location = new System.Drawing.Point(276, 94);
            this.label8.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(124, 28);
            this.label8.TabIndex = 27;
            this.label8.Text = "校验位：";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.Location = new System.Drawing.Point(16, 94);
            this.label7.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(124, 28);
            this.label7.TabIndex = 27;
            this.label7.Text = "停止位：";
            // 
            // cbDataBits
            // 
            this.cbDataBits.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDataBits.FormattingEnabled = true;
            this.cbDataBits.Items.AddRange(new object[] {
            "5",
            "6",
            "7",
            "8"});
            this.cbDataBits.Location = new System.Drawing.Point(404, 36);
            this.cbDataBits.Margin = new System.Windows.Forms.Padding(6);
            this.cbDataBits.Name = "cbDataBits";
            this.cbDataBits.Size = new System.Drawing.Size(132, 32);
            this.cbDataBits.TabIndex = 26;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.Location = new System.Drawing.Point(278, 42);
            this.label6.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(124, 28);
            this.label6.TabIndex = 25;
            this.label6.Text = "数据位：";
            // 
            // cbBaudRate
            // 
            this.cbBaudRate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbBaudRate.FormattingEnabled = true;
            this.cbBaudRate.Items.AddRange(new object[] {
            "300",
            "600",
            "1200",
            "2400",
            "4800",
            "9600",
            "19200",
            "38400",
            "115200"});
            this.cbBaudRate.Location = new System.Drawing.Point(122, 36);
            this.cbBaudRate.Margin = new System.Windows.Forms.Padding(6);
            this.cbBaudRate.Name = "cbBaudRate";
            this.cbBaudRate.Size = new System.Drawing.Size(122, 32);
            this.cbBaudRate.TabIndex = 24;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(16, 42);
            this.label5.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(110, 28);
            this.label5.TabIndex = 23;
            this.label5.Text = "波特率:";
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(456, 310);
            this.btnSend.Margin = new System.Windows.Forms.Padding(6);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(120, 50);
            this.btnSend.TabIndex = 22;
            this.btnSend.Text = "发送";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // txtSend
            // 
            this.txtSend.Location = new System.Drawing.Point(12, 314);
            this.txtSend.Margin = new System.Windows.Forms.Padding(6);
            this.txtSend.Name = "txtSend";
            this.txtSend.Size = new System.Drawing.Size(440, 35);
            this.txtSend.TabIndex = 21;
            this.txtSend.TextChanged += new System.EventHandler(this.txtSend_TextChanged);
            this.txtSend.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSend_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(488, 550);
            this.label3.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 24);
            this.label3.TabIndex = 19;
            this.label3.Text = "秒";
            this.label3.Visible = false;
            // 
            // txtSecond
            // 
            this.txtSecond.Location = new System.Drawing.Point(368, 544);
            this.txtSecond.Margin = new System.Windows.Forms.Padding(6);
            this.txtSecond.Name = "txtSecond";
            this.txtSecond.Size = new System.Drawing.Size(84, 35);
            this.txtSecond.TabIndex = 18;
            this.txtSecond.Visible = false;
            this.txtSecond.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSecond_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(218, 554);
            this.label2.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(130, 24);
            this.label2.TabIndex = 17;
            this.label2.Text = "时间间隔：";
            this.label2.Visible = false;
            // 
            // cbTimeSend
            // 
            this.cbTimeSend.AutoSize = true;
            this.cbTimeSend.Location = new System.Drawing.Point(14, 554);
            this.cbTimeSend.Margin = new System.Windows.Forms.Padding(6);
            this.cbTimeSend.Name = "cbTimeSend";
            this.cbTimeSend.Size = new System.Drawing.Size(186, 28);
            this.cbTimeSend.TabIndex = 16;
            this.cbTimeSend.Text = "定时发送数据";
            this.cbTimeSend.UseVisualStyleBackColor = true;
            this.cbTimeSend.Visible = false;
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.rbRcvStr);
            this.groupBox8.Controls.Add(this.rbRcv16);
            this.groupBox8.Location = new System.Drawing.Point(292, 230);
            this.groupBox8.Margin = new System.Windows.Forms.Padding(6);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Padding = new System.Windows.Forms.Padding(6);
            this.groupBox8.Size = new System.Drawing.Size(284, 72);
            this.groupBox8.TabIndex = 15;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "接收数据格式";
            // 
            // rbRcvStr
            // 
            this.rbRcvStr.AutoSize = true;
            this.rbRcvStr.Checked = true;
            this.rbRcvStr.Location = new System.Drawing.Point(144, 28);
            this.rbRcvStr.Margin = new System.Windows.Forms.Padding(6);
            this.rbRcvStr.Name = "rbRcvStr";
            this.rbRcvStr.Size = new System.Drawing.Size(113, 28);
            this.rbRcvStr.TabIndex = 2;
            this.rbRcvStr.TabStop = true;
            this.rbRcvStr.Text = "字符串";
            this.rbRcvStr.UseVisualStyleBackColor = true;
            // 
            // rbRcv16
            // 
            this.rbRcv16.AutoSize = true;
            this.rbRcv16.Location = new System.Drawing.Point(18, 28);
            this.rbRcv16.Margin = new System.Windows.Forms.Padding(6);
            this.rbRcv16.Name = "rbRcv16";
            this.rbRcv16.Size = new System.Drawing.Size(113, 28);
            this.rbRcv16.TabIndex = 1;
            this.rbRcv16.Text = "16进制";
            this.rbRcv16.UseVisualStyleBackColor = true;
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.radio1);
            this.groupBox7.Controls.Add(this.rdSendStr);
            this.groupBox7.Location = new System.Drawing.Point(12, 230);
            this.groupBox7.Margin = new System.Windows.Forms.Padding(6);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Padding = new System.Windows.Forms.Padding(6);
            this.groupBox7.Size = new System.Drawing.Size(268, 74);
            this.groupBox7.TabIndex = 14;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "发送数据格式";
            // 
            // radio1
            // 
            this.radio1.AutoSize = true;
            this.radio1.Checked = true;
            this.radio1.Location = new System.Drawing.Point(18, 30);
            this.radio1.Margin = new System.Windows.Forms.Padding(6);
            this.radio1.Name = "radio1";
            this.radio1.Size = new System.Drawing.Size(113, 28);
            this.radio1.TabIndex = 7;
            this.radio1.TabStop = true;
            this.radio1.Text = "16进制";
            this.radio1.UseVisualStyleBackColor = true;
            // 
            // rdSendStr
            // 
            this.rdSendStr.AutoSize = true;
            this.rdSendStr.Location = new System.Drawing.Point(146, 30);
            this.rdSendStr.Margin = new System.Windows.Forms.Padding(6);
            this.rdSendStr.Name = "rdSendStr";
            this.rdSendStr.Size = new System.Drawing.Size(113, 28);
            this.rdSendStr.TabIndex = 6;
            this.rdSendStr.Text = "字符串";
            this.rdSendStr.UseVisualStyleBackColor = true;
            // 
            // btnSwitch
            // 
            this.btnSwitch.Location = new System.Drawing.Point(254, 28);
            this.btnSwitch.Margin = new System.Windows.Forms.Padding(6);
            this.btnSwitch.Name = "btnSwitch";
            this.btnSwitch.Size = new System.Drawing.Size(150, 42);
            this.btnSwitch.TabIndex = 9;
            this.btnSwitch.Text = "打开串口";
            this.btnSwitch.UseVisualStyleBackColor = true;
            this.btnSwitch.Click += new System.EventHandler(this.btnSwitch_Click);
            // 
            // cbSerial
            // 
            this.cbSerial.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSerial.FormattingEnabled = true;
            this.cbSerial.Items.AddRange(new object[] {
            "COM9"});
            this.cbSerial.Location = new System.Drawing.Point(106, 28);
            this.cbSerial.Margin = new System.Windows.Forms.Padding(6);
            this.cbSerial.Name = "cbSerial";
            this.cbSerial.Size = new System.Drawing.Size(120, 32);
            this.cbSerial.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(20, 36);
            this.label1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 28);
            this.label1.TabIndex = 7;
            this.label1.Text = "串口：";
            // 
            // txtSendView
            // 
            this.txtSendView.Location = new System.Drawing.Point(22, 130);
            this.txtSendView.Margin = new System.Windows.Forms.Padding(6);
            this.txtSendView.Name = "txtSendView";
            this.txtSendView.ReadOnly = true;
            this.txtSendView.Size = new System.Drawing.Size(526, 282);
            this.txtSendView.TabIndex = 35;
            this.txtSendView.Text = "";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtSendView);
            this.groupBox2.Controls.Add(this.txtReceiveEnc);
            this.groupBox2.Controls.Add(this.txtReceive);
            this.groupBox2.Location = new System.Drawing.Point(1270, 46);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(6);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(6);
            this.groupBox2.Size = new System.Drawing.Size(590, 698);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "密钥生成显示";
            // 
            // txtReceiveEnc
            // 
            this.txtReceiveEnc.Location = new System.Drawing.Point(22, 428);
            this.txtReceiveEnc.Margin = new System.Windows.Forms.Padding(6);
            this.txtReceiveEnc.Name = "txtReceiveEnc";
            this.txtReceiveEnc.ReadOnly = true;
            this.txtReceiveEnc.Size = new System.Drawing.Size(526, 220);
            this.txtReceiveEnc.TabIndex = 1;
            this.txtReceiveEnc.Text = "";
            // 
            // txtReceive
            // 
            this.txtReceive.Location = new System.Drawing.Point(22, 40);
            this.txtReceive.Margin = new System.Windows.Forms.Padding(6);
            this.txtReceive.Name = "txtReceive";
            this.txtReceive.ReadOnly = true;
            this.txtReceive.Size = new System.Drawing.Size(552, 636);
            this.txtReceive.TabIndex = 0;
            this.txtReceive.Text = "";
            // 
            // groupBox9
            // 
            this.groupBox9.Controls.Add(this.carUnencCtrl);
            this.groupBox9.Controls.Add(this.carEncCtrl);
            this.groupBox9.Controls.Add(this.carCtrlStop);
            this.groupBox9.Controls.Add(this.carCtrlBack);
            this.groupBox9.Controls.Add(this.carCtrlFront);
            this.groupBox9.Controls.Add(this.carCtrlRight);
            this.groupBox9.Controls.Add(this.carCtrlLeft);
            this.groupBox9.Location = new System.Drawing.Point(618, 182);
            this.groupBox9.Margin = new System.Windows.Forms.Padding(6);
            this.groupBox9.Name = "groupBox9";
            this.groupBox9.Padding = new System.Windows.Forms.Padding(6);
            this.groupBox9.Size = new System.Drawing.Size(634, 426);
            this.groupBox9.TabIndex = 36;
            this.groupBox9.TabStop = false;
            this.groupBox9.Text = "小车控制";
            this.groupBox9.Visible = false;
            // 
            // carUnencCtrl
            // 
            this.carUnencCtrl.AutoSize = true;
            this.carUnencCtrl.Checked = true;
            this.carUnencCtrl.Location = new System.Drawing.Point(196, 40);
            this.carUnencCtrl.Margin = new System.Windows.Forms.Padding(6);
            this.carUnencCtrl.Name = "carUnencCtrl";
            this.carUnencCtrl.Size = new System.Drawing.Size(113, 28);
            this.carUnencCtrl.TabIndex = 6;
            this.carUnencCtrl.TabStop = true;
            this.carUnencCtrl.Text = "未启用";
            this.carUnencCtrl.UseVisualStyleBackColor = true;
            // 
            // carEncCtrl
            // 
            this.carEncCtrl.AutoSize = true;
            this.carEncCtrl.Location = new System.Drawing.Point(32, 40);
            this.carEncCtrl.Margin = new System.Windows.Forms.Padding(6);
            this.carEncCtrl.Name = "carEncCtrl";
            this.carEncCtrl.Size = new System.Drawing.Size(89, 28);
            this.carEncCtrl.TabIndex = 5;
            this.carEncCtrl.TabStop = true;
            this.carEncCtrl.Text = "启用";
            this.carEncCtrl.UseVisualStyleBackColor = true;
            // 
            // carCtrlStop
            // 
            this.carCtrlStop.Image = global::SerialPortConnection.Properties.Resources.蓝停止;
            this.carCtrlStop.Location = new System.Drawing.Point(272, 226);
            this.carCtrlStop.Margin = new System.Windows.Forms.Padding(6);
            this.carCtrlStop.Name = "carCtrlStop";
            this.carCtrlStop.Size = new System.Drawing.Size(94, 60);
            this.carCtrlStop.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.carCtrlStop.TabIndex = 4;
            this.carCtrlStop.TabStop = false;
            // 
            // carCtrlBack
            // 
            this.carCtrlBack.Image = global::SerialPortConnection.Properties.Resources.后蓝;
            this.carCtrlBack.Location = new System.Drawing.Point(272, 312);
            this.carCtrlBack.Margin = new System.Windows.Forms.Padding(6);
            this.carCtrlBack.Name = "carCtrlBack";
            this.carCtrlBack.Size = new System.Drawing.Size(94, 60);
            this.carCtrlBack.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.carCtrlBack.TabIndex = 3;
            this.carCtrlBack.TabStop = false;
            // 
            // carCtrlFront
            // 
            this.carCtrlFront.Image = global::SerialPortConnection.Properties.Resources.前蓝;
            this.carCtrlFront.Location = new System.Drawing.Point(272, 144);
            this.carCtrlFront.Margin = new System.Windows.Forms.Padding(6);
            this.carCtrlFront.Name = "carCtrlFront";
            this.carCtrlFront.Size = new System.Drawing.Size(94, 60);
            this.carCtrlFront.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.carCtrlFront.TabIndex = 2;
            this.carCtrlFront.TabStop = false;
            // 
            // carCtrlRight
            // 
            this.carCtrlRight.Image = global::SerialPortConnection.Properties.Resources.右蓝;
            this.carCtrlRight.Location = new System.Drawing.Point(390, 226);
            this.carCtrlRight.Margin = new System.Windows.Forms.Padding(6);
            this.carCtrlRight.Name = "carCtrlRight";
            this.carCtrlRight.Size = new System.Drawing.Size(94, 60);
            this.carCtrlRight.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.carCtrlRight.TabIndex = 1;
            this.carCtrlRight.TabStop = false;
            // 
            // carCtrlLeft
            // 
            this.carCtrlLeft.Image = global::SerialPortConnection.Properties.Resources.左蓝;
            this.carCtrlLeft.Location = new System.Drawing.Point(150, 226);
            this.carCtrlLeft.Margin = new System.Windows.Forms.Padding(6);
            this.carCtrlLeft.Name = "carCtrlLeft";
            this.carCtrlLeft.Size = new System.Drawing.Size(94, 60);
            this.carCtrlLeft.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.carCtrlLeft.TabIndex = 0;
            this.carCtrlLeft.TabStop = false;
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(1742, 754);
            this.btnExit.Margin = new System.Windows.Forms.Padding(6);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(118, 46);
            this.btnExit.TabIndex = 10;
            this.btnExit.Text = "退出";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(1604, 756);
            this.btnClear.Margin = new System.Windows.Forms.Padding(6);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(118, 46);
            this.btnClear.TabIndex = 10;
            this.btnClear.Text = "清空";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // tmSend
            // 
            this.tmSend.Interval = 3;
            this.tmSend.Tick += new System.EventHandler(this.tmSend_Tick);
            // 
            // serialPort1
            // 
            this.serialPort1.ReceivedBytesThreshold = 32;
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsSpNum,
            this.tsBaudRate,
            this.tsDataBits,
            this.tsStopBits,
            this.tsParity});
            this.statusStrip1.Location = new System.Drawing.Point(0, 826);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(2, 0, 28, 0);
            this.statusStrip1.Size = new System.Drawing.Size(1876, 36);
            this.statusStrip1.TabIndex = 12;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tsSpNum
            // 
            this.tsSpNum.Name = "tsSpNum";
            this.tsSpNum.Size = new System.Drawing.Size(188, 31);
            this.tsSpNum.Text = "串口号：未指定|";
            // 
            // tsBaudRate
            // 
            this.tsBaudRate.Name = "tsBaudRate";
            this.tsBaudRate.Size = new System.Drawing.Size(170, 31);
            this.tsBaudRate.Text = "波特率:未指定|";
            // 
            // tsDataBits
            // 
            this.tsDataBits.Name = "tsDataBits";
            this.tsDataBits.Size = new System.Drawing.Size(170, 31);
            this.tsDataBits.Text = "数据位:未指定|";
            // 
            // tsStopBits
            // 
            this.tsStopBits.Name = "tsStopBits";
            this.tsStopBits.Size = new System.Drawing.Size(170, 31);
            this.tsStopBits.Text = "停止位:未指定|";
            // 
            // tsParity
            // 
            this.tsParity.Name = "tsParity";
            this.tsParity.Size = new System.Drawing.Size(170, 31);
            this.tsParity.Text = "停止位:未指定|";
            // 
            // restrTimer
            // 
            this.restrTimer.Interval = 300;
            this.restrTimer.Tick += new System.EventHandler(this.restrTimer_Tick);
            // 
            // activate
            // 
            this.activate.Location = new System.Drawing.Point(234, 92);
            this.activate.Margin = new System.Windows.Forms.Padding(6);
            this.activate.Name = "activate";
            this.activate.Size = new System.Drawing.Size(150, 46);
            this.activate.TabIndex = 40;
            this.activate.Text = "激活";
            this.activate.UseVisualStyleBackColor = true;
            this.activate.Click += new System.EventHandler(this.activate_Click);
            // 
            // getControl
            // 
            this.getControl.Location = new System.Drawing.Point(398, 94);
            this.getControl.Margin = new System.Windows.Forms.Padding(6);
            this.getControl.Name = "getControl";
            this.getControl.Size = new System.Drawing.Size(150, 46);
            this.getControl.TabIndex = 41;
            this.getControl.Text = "获取控制";
            this.getControl.UseVisualStyleBackColor = true;
            this.getControl.Click += new System.EventHandler(this.getControl_Click);
            // 
            // clrRestr
            // 
            this.clrRestr.Location = new System.Drawing.Point(402, 36);
            this.clrRestr.Margin = new System.Windows.Forms.Padding(6);
            this.clrRestr.Name = "clrRestr";
            this.clrRestr.Size = new System.Drawing.Size(150, 46);
            this.clrRestr.TabIndex = 38;
            this.clrRestr.Text = "ClrRestart";
            this.clrRestr.UseVisualStyleBackColor = true;
            this.clrRestr.Click += new System.EventHandler(this.clrRestr_Click);
            // 
            // stopGenerate
            // 
            this.stopGenerate.Location = new System.Drawing.Point(210, 36);
            this.stopGenerate.Margin = new System.Windows.Forms.Padding(6);
            this.stopGenerate.Name = "stopGenerate";
            this.stopGenerate.Size = new System.Drawing.Size(150, 46);
            this.stopGenerate.TabIndex = 37;
            this.stopGenerate.Text = "Stop";
            this.stopGenerate.UseVisualStyleBackColor = true;
            this.stopGenerate.Click += new System.EventHandler(this.stopGenerate_Click);
            // 
            // generateSKG
            // 
            this.generateSKG.Location = new System.Drawing.Point(20, 36);
            this.generateSKG.Margin = new System.Windows.Forms.Padding(6);
            this.generateSKG.Name = "generateSKG";
            this.generateSKG.Size = new System.Drawing.Size(150, 46);
            this.generateSKG.TabIndex = 36;
            this.generateSKG.Text = "Start SKG";
            this.generateSKG.UseVisualStyleBackColor = true;
            this.generateSKG.Click += new System.EventHandler(this.button1_Click);
            // 
            // handOver
            // 
            this.handOver.Location = new System.Drawing.Point(70, 154);
            this.handOver.Margin = new System.Windows.Forms.Padding(6);
            this.handOver.Name = "handOver";
            this.handOver.Size = new System.Drawing.Size(150, 46);
            this.handOver.TabIndex = 42;
            this.handOver.Text = "起飞";
            this.handOver.UseVisualStyleBackColor = true;
            this.handOver.Click += new System.EventHandler(this.handOver_Click);
            // 
            // getVersion
            // 
            this.getVersion.Location = new System.Drawing.Point(70, 94);
            this.getVersion.Margin = new System.Windows.Forms.Padding(6);
            this.getVersion.Name = "getVersion";
            this.getVersion.Size = new System.Drawing.Size(150, 46);
            this.getVersion.TabIndex = 39;
            this.getVersion.Text = "版本查询";
            this.getVersion.UseVisualStyleBackColor = true;
            this.getVersion.Click += new System.EventHandler(this.getVersion_Click);
            // 
            // xAxis
            // 
            this.xAxis.Location = new System.Drawing.Point(68, 274);
            this.xAxis.Margin = new System.Windows.Forms.Padding(6);
            this.xAxis.Name = "xAxis";
            this.xAxis.Size = new System.Drawing.Size(144, 35);
            this.xAxis.TabIndex = 46;
            // 
            // landing
            // 
            this.landing.Location = new System.Drawing.Point(236, 154);
            this.landing.Margin = new System.Windows.Forms.Padding(6);
            this.landing.Name = "landing";
            this.landing.Size = new System.Drawing.Size(150, 46);
            this.landing.TabIndex = 43;
            this.landing.Text = "降落";
            this.landing.UseVisualStyleBackColor = true;
            this.landing.Click += new System.EventHandler(this.landing_Click);
            // 
            // zAxis
            // 
            this.zAxis.Location = new System.Drawing.Point(68, 346);
            this.zAxis.Margin = new System.Windows.Forms.Padding(6);
            this.zAxis.Name = "zAxis";
            this.zAxis.Size = new System.Drawing.Size(144, 35);
            this.zAxis.TabIndex = 49;
            // 
            // freeControl
            // 
            this.freeControl.Location = new System.Drawing.Point(472, 22);
            this.freeControl.Margin = new System.Windows.Forms.Padding(6);
            this.freeControl.Name = "freeControl";
            this.freeControl.Size = new System.Drawing.Size(150, 46);
            this.freeControl.TabIndex = 44;
            this.freeControl.Text = "释放控制";
            this.freeControl.UseVisualStyleBackColor = true;
            this.freeControl.Visible = false;
            this.freeControl.Click += new System.EventHandler(this.freeControl_Click);
            // 
            // yAxis
            // 
            this.yAxis.Location = new System.Drawing.Point(376, 274);
            this.yAxis.Margin = new System.Windows.Forms.Padding(6);
            this.yAxis.Name = "yAxis";
            this.yAxis.Size = new System.Drawing.Size(144, 35);
            this.yAxis.TabIndex = 48;
            // 
            // yaw
            // 
            this.yaw.Location = new System.Drawing.Point(376, 346);
            this.yaw.Margin = new System.Windows.Forms.Padding(6);
            this.yaw.Name = "yaw";
            this.yaw.Size = new System.Drawing.Size(144, 35);
            this.yaw.TabIndex = 50;
            // 
            // moveControl
            // 
            this.moveControl.Location = new System.Drawing.Point(398, 214);
            this.moveControl.Margin = new System.Windows.Forms.Padding(6);
            this.moveControl.Name = "moveControl";
            this.moveControl.Size = new System.Drawing.Size(150, 46);
            this.moveControl.TabIndex = 51;
            this.moveControl.Text = "移动";
            this.moveControl.UseVisualStyleBackColor = true;
            this.moveControl.Click += new System.EventHandler(this.moveControl_Click);
            // 
            // selfReturn
            // 
            this.selfReturn.Location = new System.Drawing.Point(310, 22);
            this.selfReturn.Margin = new System.Windows.Forms.Padding(6);
            this.selfReturn.Name = "selfReturn";
            this.selfReturn.Size = new System.Drawing.Size(150, 46);
            this.selfReturn.TabIndex = 45;
            this.selfReturn.Text = "自动返航";
            this.selfReturn.UseVisualStyleBackColor = true;
            this.selfReturn.Visible = false;
            this.selfReturn.Click += new System.EventHandler(this.selfReturn_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.button3);
            this.groupBox4.Controls.Add(this.qTextSend);
            this.groupBox4.Controls.Add(this.generateSKG);
            this.groupBox4.Controls.Add(this.stopGenerate);
            this.groupBox4.Controls.Add(this.clrRestr);
            this.groupBox4.Location = new System.Drawing.Point(10, 474);
            this.groupBox4.Margin = new System.Windows.Forms.Padding(6);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(6);
            this.groupBox4.Size = new System.Drawing.Size(590, 158);
            this.groupBox4.TabIndex = 13;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "密钥生成控制";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(402, 100);
            this.button3.Margin = new System.Windows.Forms.Padding(6);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(150, 46);
            this.button3.TabIndex = 40;
            this.button3.Text = "量化参数设置";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click_1);
            // 
            // qTextSend
            // 
            this.qTextSend.Location = new System.Drawing.Point(20, 100);
            this.qTextSend.Margin = new System.Windows.Forms.Padding(6);
            this.qTextSend.Name = "qTextSend";
            this.qTextSend.Size = new System.Drawing.Size(336, 35);
            this.qTextSend.TabIndex = 39;
            this.qTextSend.TextChanged += new System.EventHandler(this.qTextSend_TextChanged);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.button2);
            this.groupBox5.Controls.Add(this.groupBox6);
            this.groupBox5.Controls.Add(this.movStop);
            this.groupBox5.Controls.Add(this.button1);
            this.groupBox5.Controls.Add(this.label17);
            this.groupBox5.Controls.Add(this.label16);
            this.groupBox5.Controls.Add(this.label15);
            this.groupBox5.Controls.Add(this.label14);
            this.groupBox5.Controls.Add(this.label13);
            this.groupBox5.Controls.Add(this.label12);
            this.groupBox5.Controls.Add(this.label11);
            this.groupBox5.Controls.Add(this.label10);
            this.groupBox5.Controls.Add(this.unencCtrl);
            this.groupBox5.Controls.Add(this.encCtrl);
            this.groupBox5.Controls.Add(this.getVersion);
            this.groupBox5.Controls.Add(this.selfReturn);
            this.groupBox5.Controls.Add(this.xAxis);
            this.groupBox5.Controls.Add(this.moveControl);
            this.groupBox5.Controls.Add(this.landing);
            this.groupBox5.Controls.Add(this.handOver);
            this.groupBox5.Controls.Add(this.yaw);
            this.groupBox5.Controls.Add(this.getControl);
            this.groupBox5.Controls.Add(this.yAxis);
            this.groupBox5.Controls.Add(this.activate);
            this.groupBox5.Controls.Add(this.freeControl);
            this.groupBox5.Controls.Add(this.zAxis);
            this.groupBox5.Location = new System.Drawing.Point(620, 24);
            this.groupBox5.Margin = new System.Windows.Forms.Padding(6);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Padding = new System.Windows.Forms.Padding(6);
            this.groupBox5.Size = new System.Drawing.Size(634, 782);
            this.groupBox5.TabIndex = 52;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "无人机控制";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(236, 214);
            this.button2.Margin = new System.Windows.Forms.Padding(6);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(150, 46);
            this.button2.TabIndex = 64;
            this.button2.Text = "StopHotPoint";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.label25);
            this.groupBox6.Controls.Add(this.label24);
            this.groupBox6.Controls.Add(this.label23);
            this.groupBox6.Controls.Add(this.label22);
            this.groupBox6.Controls.Add(this.backMove);
            this.groupBox6.Controls.Add(this.forwardMove);
            this.groupBox6.Controls.Add(this.rightMove);
            this.groupBox6.Controls.Add(this.leftMove);
            this.groupBox6.Controls.Add(this.label21);
            this.groupBox6.Controls.Add(this.label20);
            this.groupBox6.Controls.Add(this.label19);
            this.groupBox6.Controls.Add(this.label18);
            this.groupBox6.Controls.Add(this.downMove);
            this.groupBox6.Controls.Add(this.upMove);
            this.groupBox6.Controls.Add(this.rightYaw);
            this.groupBox6.Controls.Add(this.leftYaw);
            this.groupBox6.Location = new System.Drawing.Point(26, 424);
            this.groupBox6.Margin = new System.Windows.Forms.Padding(6);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Padding = new System.Windows.Forms.Padding(6);
            this.groupBox6.Size = new System.Drawing.Size(582, 346);
            this.groupBox6.TabIndex = 36;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "无人机遥控模拟";
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(422, 284);
            this.label25.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(58, 24);
            this.label25.TabIndex = 15;
            this.label25.Text = "后移";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(422, 70);
            this.label24.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(58, 24);
            this.label24.TabIndex = 14;
            this.label24.Text = "前移";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(518, 128);
            this.label23.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(58, 24);
            this.label23.TabIndex = 13;
            this.label23.Text = "右移";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(332, 128);
            this.label22.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(58, 24);
            this.label22.TabIndex = 12;
            this.label22.Text = "左移";
            // 
            // backMove
            // 
            this.backMove.BackColor = System.Drawing.SystemColors.Control;
            this.backMove.Image = global::SerialPortConnection.Properties.Resources.后蓝;
            this.backMove.Location = new System.Drawing.Point(402, 218);
            this.backMove.Margin = new System.Windows.Forms.Padding(6);
            this.backMove.Name = "backMove";
            this.backMove.Size = new System.Drawing.Size(94, 60);
            this.backMove.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.backMove.TabIndex = 11;
            this.backMove.TabStop = false;
            this.backMove.Click += new System.EventHandler(this.backMove_Click);
            this.backMove.MouseDown += new System.Windows.Forms.MouseEventHandler(this.backMove_MouseDown);
            this.backMove.MouseEnter += new System.EventHandler(this.backMove_MouseEnter);
            this.backMove.MouseLeave += new System.EventHandler(this.backMove_MouseLeave);
            this.backMove.MouseUp += new System.Windows.Forms.MouseEventHandler(this.backMove_MouseUp);
            // 
            // forwardMove
            // 
            this.forwardMove.BackColor = System.Drawing.SystemColors.Control;
            this.forwardMove.Image = global::SerialPortConnection.Properties.Resources.前蓝;
            this.forwardMove.Location = new System.Drawing.Point(402, 100);
            this.forwardMove.Margin = new System.Windows.Forms.Padding(6);
            this.forwardMove.Name = "forwardMove";
            this.forwardMove.Size = new System.Drawing.Size(94, 60);
            this.forwardMove.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.forwardMove.TabIndex = 10;
            this.forwardMove.TabStop = false;
            this.forwardMove.Click += new System.EventHandler(this.forwardMove_Click);
            this.forwardMove.MouseDown += new System.Windows.Forms.MouseEventHandler(this.forwardMove_MouseDown);
            this.forwardMove.MouseEnter += new System.EventHandler(this.forwardMove_MouseEnter);
            this.forwardMove.MouseLeave += new System.EventHandler(this.forwardMove_MouseLeave);
            this.forwardMove.MouseUp += new System.Windows.Forms.MouseEventHandler(this.forwardMove_MouseUp);
            // 
            // rightMove
            // 
            this.rightMove.BackColor = System.Drawing.SystemColors.Control;
            this.rightMove.Image = global::SerialPortConnection.Properties.Resources.右蓝;
            this.rightMove.Location = new System.Drawing.Point(496, 160);
            this.rightMove.Margin = new System.Windows.Forms.Padding(6);
            this.rightMove.Name = "rightMove";
            this.rightMove.Size = new System.Drawing.Size(94, 60);
            this.rightMove.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.rightMove.TabIndex = 9;
            this.rightMove.TabStop = false;
            this.rightMove.Click += new System.EventHandler(this.rightMove_Click);
            this.rightMove.MouseDown += new System.Windows.Forms.MouseEventHandler(this.rightMove_MouseDown);
            this.rightMove.MouseEnter += new System.EventHandler(this.rightMove_MouseEnter);
            this.rightMove.MouseLeave += new System.EventHandler(this.rightMove_MouseLeave);
            this.rightMove.MouseUp += new System.Windows.Forms.MouseEventHandler(this.rightMove_MouseUp);
            // 
            // leftMove
            // 
            this.leftMove.BackColor = System.Drawing.SystemColors.Control;
            this.leftMove.Image = global::SerialPortConnection.Properties.Resources.左蓝;
            this.leftMove.Location = new System.Drawing.Point(308, 158);
            this.leftMove.Margin = new System.Windows.Forms.Padding(6);
            this.leftMove.Name = "leftMove";
            this.leftMove.Size = new System.Drawing.Size(94, 60);
            this.leftMove.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.leftMove.TabIndex = 8;
            this.leftMove.TabStop = false;
            this.leftMove.Click += new System.EventHandler(this.leftMove_Click);
            this.leftMove.MouseDown += new System.Windows.Forms.MouseEventHandler(this.leftMove_MouseDown);
            this.leftMove.MouseEnter += new System.EventHandler(this.leftMove_MouseEnter);
            this.leftMove.MouseLeave += new System.EventHandler(this.leftMove_MouseLeave);
            this.leftMove.MouseUp += new System.Windows.Forms.MouseEventHandler(this.leftMove_MouseUp);
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(112, 286);
            this.label21.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(58, 24);
            this.label21.TabIndex = 7;
            this.label21.Text = "下降";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(112, 70);
            this.label20.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(58, 24);
            this.label20.TabIndex = 6;
            this.label20.Text = "上升";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(208, 128);
            this.label19.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(58, 24);
            this.label19.TabIndex = 5;
            this.label19.Text = "右旋";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(18, 128);
            this.label18.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(58, 24);
            this.label18.TabIndex = 4;
            this.label18.Text = "左旋";
            // 
            // downMove
            // 
            this.downMove.BackColor = System.Drawing.SystemColors.Control;
            this.downMove.Image = global::SerialPortConnection.Properties.Resources.下蓝;
            this.downMove.Location = new System.Drawing.Point(96, 220);
            this.downMove.Margin = new System.Windows.Forms.Padding(6);
            this.downMove.Name = "downMove";
            this.downMove.Size = new System.Drawing.Size(94, 60);
            this.downMove.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.downMove.TabIndex = 3;
            this.downMove.TabStop = false;
            this.downMove.Click += new System.EventHandler(this.downMove_Click);
            this.downMove.MouseDown += new System.Windows.Forms.MouseEventHandler(this.downMove_MouseDown);
            this.downMove.MouseEnter += new System.EventHandler(this.downMove_MouseEnter);
            this.downMove.MouseLeave += new System.EventHandler(this.downMove_MouseLeave);
            this.downMove.MouseUp += new System.Windows.Forms.MouseEventHandler(this.downMove_MouseUp);
            // 
            // upMove
            // 
            this.upMove.BackColor = System.Drawing.SystemColors.Control;
            this.upMove.Image = global::SerialPortConnection.Properties.Resources.上蓝;
            this.upMove.Location = new System.Drawing.Point(96, 100);
            this.upMove.Margin = new System.Windows.Forms.Padding(6);
            this.upMove.Name = "upMove";
            this.upMove.Size = new System.Drawing.Size(94, 60);
            this.upMove.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.upMove.TabIndex = 2;
            this.upMove.TabStop = false;
            this.upMove.Click += new System.EventHandler(this.upMove_Click);
            this.upMove.MouseDown += new System.Windows.Forms.MouseEventHandler(this.upMove_MouseDown);
            this.upMove.MouseEnter += new System.EventHandler(this.upMove_MouseEnter);
            this.upMove.MouseLeave += new System.EventHandler(this.upMove_MouseLeave);
            this.upMove.MouseUp += new System.Windows.Forms.MouseEventHandler(this.upMove_MouseUp);
            // 
            // rightYaw
            // 
            this.rightYaw.BackColor = System.Drawing.SystemColors.Control;
            this.rightYaw.Image = global::SerialPortConnection.Properties.Resources.右旋蓝;
            this.rightYaw.Location = new System.Drawing.Point(190, 160);
            this.rightYaw.Margin = new System.Windows.Forms.Padding(6);
            this.rightYaw.Name = "rightYaw";
            this.rightYaw.Size = new System.Drawing.Size(94, 60);
            this.rightYaw.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.rightYaw.TabIndex = 1;
            this.rightYaw.TabStop = false;
            this.rightYaw.Click += new System.EventHandler(this.rightYaw_Click);
            this.rightYaw.MouseDown += new System.Windows.Forms.MouseEventHandler(this.rightYaw_MouseDown);
            this.rightYaw.MouseEnter += new System.EventHandler(this.rightYaw_MouseEnter);
            this.rightYaw.MouseLeave += new System.EventHandler(this.rightYaw_MouseLeave);
            this.rightYaw.MouseUp += new System.Windows.Forms.MouseEventHandler(this.rightYaw_MouseUp);
            // 
            // leftYaw
            // 
            this.leftYaw.BackColor = System.Drawing.SystemColors.Control;
            this.leftYaw.Image = global::SerialPortConnection.Properties.Resources.左旋蓝;
            this.leftYaw.Location = new System.Drawing.Point(4, 160);
            this.leftYaw.Margin = new System.Windows.Forms.Padding(6);
            this.leftYaw.Name = "leftYaw";
            this.leftYaw.Size = new System.Drawing.Size(94, 60);
            this.leftYaw.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.leftYaw.TabIndex = 0;
            this.leftYaw.TabStop = false;
            this.leftYaw.Click += new System.EventHandler(this.leftYaw_Click);
            this.leftYaw.MouseDown += new System.Windows.Forms.MouseEventHandler(this.leftYaw_MouseDown);
            this.leftYaw.MouseEnter += new System.EventHandler(this.leftYaw_MouseEnter);
            this.leftYaw.MouseLeave += new System.EventHandler(this.leftYaw_MouseLeave);
            this.leftYaw.MouseUp += new System.Windows.Forms.MouseEventHandler(this.leftYaw_MouseUp);
            // 
            // movStop
            // 
            this.movStop.Location = new System.Drawing.Point(398, 154);
            this.movStop.Margin = new System.Windows.Forms.Padding(6);
            this.movStop.Name = "movStop";
            this.movStop.Size = new System.Drawing.Size(150, 46);
            this.movStop.TabIndex = 63;
            this.movStop.Text = "悬停";
            this.movStop.UseVisualStyleBackColor = true;
            this.movStop.Click += new System.EventHandler(this.movStop_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(70, 214);
            this.button1.Margin = new System.Windows.Forms.Padding(6);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(150, 46);
            this.button1.TabIndex = 62;
            this.button1.Text = "HotPoint";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("宋体", 12F);
            this.label17.Location = new System.Drawing.Point(532, 348);
            this.label17.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(95, 33);
            this.label17.TabIndex = 61;
            this.label17.Text = "deg/s";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("宋体", 15F);
            this.label16.Location = new System.Drawing.Point(230, 346);
            this.label16.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(77, 40);
            this.label16.TabIndex = 60;
            this.label16.Text = "m/s";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("宋体", 15F);
            this.label15.Location = new System.Drawing.Point(538, 272);
            this.label15.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(77, 40);
            this.label15.TabIndex = 59;
            this.label15.Text = "m/s";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("宋体", 15F);
            this.label14.Location = new System.Drawing.Point(228, 272);
            this.label14.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(77, 40);
            this.label14.TabIndex = 58;
            this.label14.Text = "m/s";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("宋体", 10F);
            this.label13.Location = new System.Drawing.Point(300, 352);
            this.label13.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(66, 27);
            this.label13.TabIndex = 57;
            this.label13.Text = "自旋";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("宋体", 10F);
            this.label12.Location = new System.Drawing.Point(-2, 352);
            this.label12.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(53, 27);
            this.label12.TabIndex = 56;
            this.label12.Text = "Z轴";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("宋体", 10F);
            this.label11.Location = new System.Drawing.Point(302, 282);
            this.label11.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(53, 27);
            this.label11.TabIndex = 55;
            this.label11.Text = "Y轴";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("宋体", 10F);
            this.label10.Location = new System.Drawing.Point(-2, 278);
            this.label10.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(53, 27);
            this.label10.TabIndex = 20;
            this.label10.Text = "X轴";
            // 
            // unencCtrl
            // 
            this.unencCtrl.AutoSize = true;
            this.unencCtrl.Location = new System.Drawing.Point(186, 46);
            this.unencCtrl.Margin = new System.Windows.Forms.Padding(6);
            this.unencCtrl.Name = "unencCtrl";
            this.unencCtrl.Size = new System.Drawing.Size(113, 28);
            this.unencCtrl.TabIndex = 53;
            this.unencCtrl.Text = "未启用";
            this.unencCtrl.UseVisualStyleBackColor = true;
            this.unencCtrl.Visible = false;
            // 
            // encCtrl
            // 
            this.encCtrl.AutoSize = true;
            this.encCtrl.Checked = true;
            this.encCtrl.Location = new System.Drawing.Point(26, 46);
            this.encCtrl.Margin = new System.Windows.Forms.Padding(6);
            this.encCtrl.Name = "encCtrl";
            this.encCtrl.Size = new System.Drawing.Size(89, 28);
            this.encCtrl.TabIndex = 52;
            this.encCtrl.TabStop = true;
            this.encCtrl.Text = "启用";
            this.encCtrl.UseVisualStyleBackColor = true;
            // 
            // platformTrans
            // 
            this.platformTrans.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.platformTrans.FormattingEnabled = true;
            this.platformTrans.Items.AddRange(new object[] {
            "小车",
            "无人机"});
            this.platformTrans.Location = new System.Drawing.Point(168, 398);
            this.platformTrans.Margin = new System.Windows.Forms.Padding(6);
            this.platformTrans.Name = "platformTrans";
            this.platformTrans.Size = new System.Drawing.Size(132, 32);
            this.platformTrans.TabIndex = 65;
            this.platformTrans.SelectedIndexChanged += new System.EventHandler(this.platformTrans_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 10.5F);
            this.label4.Location = new System.Drawing.Point(24, 402);
            this.label4.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(124, 28);
            this.label4.TabIndex = 66;
            this.label4.Text = "平台选择";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1876, 862);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.groupBox9);
            this.Controls.Add(this.platformTrans);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.statusStrip1);
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "用户";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox8.ResumeLayout(false);
            this.groupBox8.PerformLayout();
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox9.ResumeLayout(false);
            this.groupBox9.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.carCtrlStop)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.carCtrlBack)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.carCtrlFront)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.carCtrlRight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.carCtrlLeft)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.backMove)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.forwardMove)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rightMove)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.leftMove)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.downMove)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.upMove)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rightYaw)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.leftYaw)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox cbSerial;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSwitch;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.GroupBox groupBox8;
        private System.Windows.Forms.RadioButton rbRcvStr;
        private System.Windows.Forms.RadioButton rbRcv16;
        private System.Windows.Forms.RadioButton rdSendStr;
        //private System.Windows.Forms.RadioButton rdse;
        private System.Windows.Forms.TextBox txtSecond;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox cbTimeSend;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtSend;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.RadioButton radio1;
        private System.Windows.Forms.RichTextBox txtReceive;
        private System.Windows.Forms.Timer tmSend;
        private System.Windows.Forms.ComboBox cbBaudRate;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cbDataBits;
        private System.Windows.Forms.Label label6;
        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.ComboBox cbStop;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cbParity;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel tsSpNum;
        private System.Windows.Forms.ToolStripStatusLabel tsBaudRate;
        private System.Windows.Forms.ToolStripStatusLabel tsDataBits;
        private System.Windows.Forms.ToolStripStatusLabel tsStopBits;
        private System.Windows.Forms.ToolStripStatusLabel tsParity;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button encSend;
        private System.Windows.Forms.RichTextBox txtReceiveEnc;
        private System.Windows.Forms.RichTextBox txtSendView;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Timer restrTimer;
        private System.Windows.Forms.Button activate;
        private System.Windows.Forms.Button getControl;
        private System.Windows.Forms.Button clrRestr;
        private System.Windows.Forms.Button stopGenerate;
        private System.Windows.Forms.Button generateSKG;
        private System.Windows.Forms.Button handOver;
        private System.Windows.Forms.Button getVersion;
        private System.Windows.Forms.TextBox xAxis;
        private System.Windows.Forms.Button landing;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.TextBox zAxis;
        private System.Windows.Forms.Button freeControl;
        private System.Windows.Forms.TextBox yAxis;
        private System.Windows.Forms.TextBox yaw;
        private System.Windows.Forms.Button moveControl;
        private System.Windows.Forms.Button selfReturn;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.RadioButton unencCtrl;
        private System.Windows.Forms.RadioButton encCtrl;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button movStop;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.PictureBox backMove;
        private System.Windows.Forms.PictureBox forwardMove;
        private System.Windows.Forms.PictureBox rightMove;
        private System.Windows.Forms.PictureBox leftMove;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.PictureBox downMove;
        private System.Windows.Forms.PictureBox upMove;
        private System.Windows.Forms.PictureBox rightYaw;
        private System.Windows.Forms.PictureBox leftYaw;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TextBox qTextSend;
        private System.Windows.Forms.ComboBox platformTrans;
        private System.Windows.Forms.GroupBox groupBox9;
        private System.Windows.Forms.PictureBox carCtrlBack;
        private System.Windows.Forms.PictureBox carCtrlFront;
        private System.Windows.Forms.PictureBox carCtrlRight;
        private System.Windows.Forms.PictureBox carCtrlLeft;
        private System.Windows.Forms.PictureBox carCtrlStop;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RadioButton carUnencCtrl;
        private System.Windows.Forms.RadioButton carEncCtrl;
    }
}

