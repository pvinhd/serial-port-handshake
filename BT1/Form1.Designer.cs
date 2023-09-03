namespace BT1
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
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.m_lsbReadSerial = new System.Windows.Forms.ListBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.btnSend1 = new System.Windows.Forms.Button();
            this.m_staticInfo = new System.Windows.Forms.Label();
            this.btnPOS = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.btnVEL = new System.Windows.Forms.Button();
            this.btnMOV = new System.Windows.Forms.Button();
            this.btnSTT = new System.Windows.Forms.Button();
            this.cBtnLedCheck1 = new System.Windows.Forms.CheckBox();
            this.cBtnGPIO1 = new System.Windows.Forms.CheckBox();
            this.cBtnGPIO2 = new System.Windows.Forms.CheckBox();
            this.cBtnLedCheck2 = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // serialPort1
            // 
            this.serialPort1.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.serialPort1_DataReceived);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.m_lsbReadSerial);
            this.groupBox1.Location = new System.Drawing.Point(4, 8);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(507, 173);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Receive Data";
            // 
            // m_lsbReadSerial
            // 
            this.m_lsbReadSerial.FormattingEnabled = true;
            this.m_lsbReadSerial.ItemHeight = 16;
            this.m_lsbReadSerial.Location = new System.Drawing.Point(0, 16);
            this.m_lsbReadSerial.Name = "m_lsbReadSerial";
            this.m_lsbReadSerial.Size = new System.Drawing.Size(501, 164);
            this.m_lsbReadSerial.TabIndex = 5;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.comboBox2);
            this.groupBox2.Controls.Add(this.comboBox1);
            this.groupBox2.Controls.Add(this.button1);
            this.groupBox2.Location = new System.Drawing.Point(532, 24);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(259, 156);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Static";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(24, 76);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "Baudrate";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "Name";
            // 
            // comboBox2
            // 
            this.comboBox2.AutoCompleteCustomSource.AddRange(new string[] {
            "2400",
            "4800",
            "9600",
            "19200"});
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Items.AddRange(new object[] {
            "2400",
            "4800",
            "9600",
            "19200"});
            this.comboBox2.Location = new System.Drawing.Point(144, 76);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(108, 24);
            this.comboBox2.TabIndex = 1;
            this.comboBox2.Text = "9600";
            this.comboBox2.SelectedIndexChanged += new System.EventHandler(this.comboBox2_SelectedIndexChanged);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(144, 28);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(108, 24);
            this.comboBox1.TabIndex = 1;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(144, 118);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(109, 32);
            this.button1.TabIndex = 0;
            this.button1.Text = "Open";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.textBox1);
            this.groupBox3.Controls.Add(this.btnSend1);
            this.groupBox3.Location = new System.Drawing.Point(4, 194);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(506, 84);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Send Data";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(18, 22);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(377, 40);
            this.textBox1.TabIndex = 1;
            // 
            // btnSend1
            // 
            this.btnSend1.Location = new System.Drawing.Point(410, 21);
            this.btnSend1.Name = "btnSend1";
            this.btnSend1.Size = new System.Drawing.Size(90, 42);
            this.btnSend1.TabIndex = 0;
            this.btnSend1.Text = "SEND";
            this.btnSend1.UseVisualStyleBackColor = true;
            this.btnSend1.Click += new System.EventHandler(this.btnSend1_Click);
            // 
            // m_staticInfo
            // 
            this.m_staticInfo.AutoSize = true;
            this.m_staticInfo.Location = new System.Drawing.Point(12, 281);
            this.m_staticInfo.Name = "m_staticInfo";
            this.m_staticInfo.Size = new System.Drawing.Size(40, 16);
            this.m_staticInfo.TabIndex = 3;
            this.m_staticInfo.Text = "Static";
            // 
            // btnPOS
            // 
            this.btnPOS.Location = new System.Drawing.Point(532, 200);
            this.btnPOS.Name = "btnPOS";
            this.btnPOS.Size = new System.Drawing.Size(154, 54);
            this.btnPOS.TabIndex = 4;
            this.btnPOS.Text = "POSITION";
            this.btnPOS.UseVisualStyleBackColor = true;
            this.btnPOS.Click += new System.EventHandler(this.btnPOS_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(692, 203);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(154, 54);
            this.button2.TabIndex = 5;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(532, 260);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(154, 54);
            this.button3.TabIndex = 5;
            this.button3.Text = "button2";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // btnVEL
            // 
            this.btnVEL.Location = new System.Drawing.Point(692, 203);
            this.btnVEL.Name = "btnVEL";
            this.btnVEL.Size = new System.Drawing.Size(154, 54);
            this.btnVEL.TabIndex = 5;
            this.btnVEL.Text = "VELOCITY";
            this.btnVEL.UseVisualStyleBackColor = true;
            this.btnVEL.Click += new System.EventHandler(this.btnVEL_Click);
            // 
            // btnMOV
            // 
            this.btnMOV.Location = new System.Drawing.Point(532, 260);
            this.btnMOV.Name = "btnMOV";
            this.btnMOV.Size = new System.Drawing.Size(154, 54);
            this.btnMOV.TabIndex = 5;
            this.btnMOV.Text = "MOVEL";
            this.btnMOV.UseVisualStyleBackColor = true;
            this.btnMOV.Click += new System.EventHandler(this.btnMOV_Click);
            // 
            // btnSTT
            // 
            this.btnSTT.Location = new System.Drawing.Point(692, 260);
            this.btnSTT.Name = "btnSTT";
            this.btnSTT.Size = new System.Drawing.Size(154, 54);
            this.btnSTT.TabIndex = 5;
            this.btnSTT.Text = "STATUS";
            this.btnSTT.UseVisualStyleBackColor = true;
            this.btnSTT.Click += new System.EventHandler(this.btnSTT_Click);
            // 
            // cBtnLedCheck1
            // 
            this.cBtnLedCheck1.AutoSize = true;
            this.cBtnLedCheck1.Location = new System.Drawing.Point(807, 51);
            this.cBtnLedCheck1.Name = "cBtnLedCheck1";
            this.cBtnLedCheck1.Size = new System.Drawing.Size(59, 20);
            this.cBtnLedCheck1.TabIndex = 6;
            this.cBtnLedCheck1.Text = "Led1";
            this.cBtnLedCheck1.UseVisualStyleBackColor = true;
            // 
            // cBtnGPIO1
            // 
            this.cBtnGPIO1.AutoSize = true;
            this.cBtnGPIO1.Location = new System.Drawing.Point(807, 77);
            this.cBtnGPIO1.Name = "cBtnGPIO1";
            this.cBtnGPIO1.Size = new System.Drawing.Size(68, 20);
            this.cBtnGPIO1.TabIndex = 6;
            this.cBtnGPIO1.Text = "GPIO1";
            this.cBtnGPIO1.UseVisualStyleBackColor = true;
            // 
            // cBtnGPIO2
            // 
            this.cBtnGPIO2.AutoSize = true;
            this.cBtnGPIO2.Location = new System.Drawing.Point(807, 130);
            this.cBtnGPIO2.Name = "cBtnGPIO2";
            this.cBtnGPIO2.Size = new System.Drawing.Size(68, 20);
            this.cBtnGPIO2.TabIndex = 6;
            this.cBtnGPIO2.Text = "GPIO2";
            this.cBtnGPIO2.UseVisualStyleBackColor = true;
            // 
            // cBtnLedCheck2
            // 
            this.cBtnLedCheck2.AutoSize = true;
            this.cBtnLedCheck2.Location = new System.Drawing.Point(807, 104);
            this.cBtnLedCheck2.Name = "cBtnLedCheck2";
            this.cBtnLedCheck2.Size = new System.Drawing.Size(59, 20);
            this.cBtnLedCheck2.TabIndex = 6;
            this.cBtnLedCheck2.Text = "Led2";
            this.cBtnLedCheck2.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(925, 342);
            this.Controls.Add(this.cBtnLedCheck2);
            this.Controls.Add(this.cBtnGPIO2);
            this.Controls.Add(this.cBtnGPIO1);
            this.Controls.Add(this.cBtnLedCheck1);
            this.Controls.Add(this.btnMOV);
            this.Controls.Add(this.btnSTT);
            this.Controls.Add(this.btnVEL);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.btnPOS);
            this.Controls.Add(this.m_staticInfo);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button btnSend1;
        private System.Windows.Forms.Label m_staticInfo;
        private System.Windows.Forms.Button btnPOS;
        private System.Windows.Forms.ListBox m_lsbReadSerial;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button btnVEL;
        private System.Windows.Forms.Button btnMOV;
        private System.Windows.Forms.Button btnSTT;
        private System.Windows.Forms.CheckBox cBtnLedCheck1;
        private System.Windows.Forms.CheckBox cBtnGPIO1;
        private System.Windows.Forms.CheckBox cBtnGPIO2;
        private System.Windows.Forms.CheckBox cBtnLedCheck2;
    }
}

