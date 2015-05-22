namespace CentralControl
{
    partial class AutoDispenDeviceForm
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.basicPanel = new System.Windows.Forms.Panel();
            this.isVirtualCheckBox = new System.Windows.Forms.CheckBox();
            this.serialIDTextBox = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.codeTextBox = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.identifyIDTextBox = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.deviceIPTextBox = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.deviceNameTextBox = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.localIPTextBox = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.deviceNameLabel = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.s = new System.Windows.Forms.Panel();
            this.stateComboBox = new System.Windows.Forms.ComboBox();
            this.yiJiaZhuListView = new System.Windows.Forms.ListView();
            this.yiJiaZhuLabel = new System.Windows.Forms.Label();
            this.dianJi4TextBox = new System.Windows.Forms.TextBox();
            this.dianJi3TextBox = new System.Windows.Forms.TextBox();
            this.dianJi2TextBox = new System.Windows.Forms.TextBox();
            this.dianJi1TextBox = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.autoButton = new System.Windows.Forms.Button();
            this.stopButton = new System.Windows.Forms.Button();
            this.startButton = new System.Windows.Forms.Button();
            this.resetButton = new System.Windows.Forms.Button();
            this.sendButton = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.capacityLabel = new System.Windows.Forms.Label();
            this.volumeLabel = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.refreshTimer = new System.Windows.Forms.Timer(this.components);
            this.panel1.SuspendLayout();
            this.basicPanel.SuspendLayout();
            this.s.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.basicPanel);
            this.panel1.Controls.Add(this.s);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Location = new System.Drawing.Point(12, 11);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(602, 534);
            this.panel1.TabIndex = 0;
            // 
            // basicPanel
            // 
            this.basicPanel.Controls.Add(this.isVirtualCheckBox);
            this.basicPanel.Controls.Add(this.serialIDTextBox);
            this.basicPanel.Controls.Add(this.label11);
            this.basicPanel.Controls.Add(this.codeTextBox);
            this.basicPanel.Controls.Add(this.label10);
            this.basicPanel.Controls.Add(this.identifyIDTextBox);
            this.basicPanel.Controls.Add(this.label9);
            this.basicPanel.Controls.Add(this.deviceIPTextBox);
            this.basicPanel.Controls.Add(this.label12);
            this.basicPanel.Controls.Add(this.deviceNameTextBox);
            this.basicPanel.Controls.Add(this.label13);
            this.basicPanel.Controls.Add(this.localIPTextBox);
            this.basicPanel.Controls.Add(this.label14);
            this.basicPanel.Controls.Add(this.label15);
            this.basicPanel.Controls.Add(this.deviceNameLabel);
            this.basicPanel.Controls.Add(this.label18);
            this.basicPanel.Location = new System.Drawing.Point(3, 3);
            this.basicPanel.Name = "basicPanel";
            this.basicPanel.Size = new System.Drawing.Size(596, 136);
            this.basicPanel.TabIndex = 1;
            this.basicPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.basicPanel_Paint);
            // 
            // isVirtualCheckBox
            // 
            this.isVirtualCheckBox.AutoSize = true;
            this.isVirtualCheckBox.Location = new System.Drawing.Point(152, 18);
            this.isVirtualCheckBox.Name = "isVirtualCheckBox";
            this.isVirtualCheckBox.Size = new System.Drawing.Size(72, 16);
            this.isVirtualCheckBox.TabIndex = 22;
            this.isVirtualCheckBox.Text = "虚拟仪器";
            this.isVirtualCheckBox.UseVisualStyleBackColor = true;
            // 
            // serialIDTextBox
            // 
            this.serialIDTextBox.Location = new System.Drawing.Point(402, 102);
            this.serialIDTextBox.Name = "serialIDTextBox";
            this.serialIDTextBox.Size = new System.Drawing.Size(167, 21);
            this.serialIDTextBox.TabIndex = 21;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(343, 105);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(53, 12);
            this.label11.TabIndex = 20;
            this.label11.Text = "序列号：";
            // 
            // codeTextBox
            // 
            this.codeTextBox.Location = new System.Drawing.Point(152, 102);
            this.codeTextBox.Name = "codeTextBox";
            this.codeTextBox.Size = new System.Drawing.Size(162, 21);
            this.codeTextBox.TabIndex = 19;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(91, 105);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(41, 12);
            this.label10.TabIndex = 18;
            this.label10.Text = "代码：";
            // 
            // identifyIDTextBox
            // 
            this.identifyIDTextBox.Location = new System.Drawing.Point(402, 75);
            this.identifyIDTextBox.Name = "identifyIDTextBox";
            this.identifyIDTextBox.Size = new System.Drawing.Size(167, 21);
            this.identifyIDTextBox.TabIndex = 17;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(343, 78);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(53, 12);
            this.label9.TabIndex = 16;
            this.label9.Text = "识别码：";
            // 
            // deviceIPTextBox
            // 
            this.deviceIPTextBox.Location = new System.Drawing.Point(152, 43);
            this.deviceIPTextBox.Name = "deviceIPTextBox";
            this.deviceIPTextBox.Size = new System.Drawing.Size(162, 21);
            this.deviceIPTextBox.TabIndex = 15;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(91, 47);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(53, 12);
            this.label12.TabIndex = 14;
            this.label12.Text = "仪器IP：";
            // 
            // deviceNameTextBox
            // 
            this.deviceNameTextBox.Location = new System.Drawing.Point(152, 75);
            this.deviceNameTextBox.Name = "deviceNameTextBox";
            this.deviceNameTextBox.Size = new System.Drawing.Size(162, 21);
            this.deviceNameTextBox.TabIndex = 13;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(91, 78);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(41, 12);
            this.label13.TabIndex = 12;
            this.label13.Text = "名称：";
            // 
            // localIPTextBox
            // 
            this.localIPTextBox.Location = new System.Drawing.Point(402, 44);
            this.localIPTextBox.Name = "localIPTextBox";
            this.localIPTextBox.Size = new System.Drawing.Size(167, 21);
            this.localIPTextBox.TabIndex = 11;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(343, 47);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(53, 12);
            this.label14.TabIndex = 10;
            this.label14.Text = "本地IP：";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(20, 47);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(65, 12);
            this.label15.TabIndex = 7;
            this.label15.Text = "仪器信息：";
            // 
            // deviceNameLabel
            // 
            this.deviceNameLabel.AutoSize = true;
            this.deviceNameLabel.Location = new System.Drawing.Point(84, 21);
            this.deviceNameLabel.Name = "deviceNameLabel";
            this.deviceNameLabel.Size = new System.Drawing.Size(41, 12);
            this.deviceNameLabel.TabIndex = 1;
            this.deviceNameLabel.Text = "label2";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(20, 21);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(53, 12);
            this.label18.TabIndex = 0;
            this.label18.Text = "仪器名：";
            // 
            // s
            // 
            this.s.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.s.Controls.Add(this.stateComboBox);
            this.s.Controls.Add(this.yiJiaZhuListView);
            this.s.Controls.Add(this.yiJiaZhuLabel);
            this.s.Controls.Add(this.dianJi4TextBox);
            this.s.Controls.Add(this.dianJi3TextBox);
            this.s.Controls.Add(this.dianJi2TextBox);
            this.s.Controls.Add(this.dianJi1TextBox);
            this.s.Controls.Add(this.label8);
            this.s.Controls.Add(this.label7);
            this.s.Controls.Add(this.label6);
            this.s.Controls.Add(this.label5);
            this.s.Controls.Add(this.label4);
            this.s.Controls.Add(this.label3);
            this.s.Location = new System.Drawing.Point(3, 306);
            this.s.Name = "s";
            this.s.Size = new System.Drawing.Size(595, 215);
            this.s.TabIndex = 1;
            // 
            // stateComboBox
            // 
            this.stateComboBox.FormattingEnabled = true;
            this.stateComboBox.Location = new System.Drawing.Point(174, 43);
            this.stateComboBox.Name = "stateComboBox";
            this.stateComboBox.Size = new System.Drawing.Size(100, 20);
            this.stateComboBox.TabIndex = 13;
            // 
            // yiJiaZhuListView
            // 
            this.yiJiaZhuListView.GridLines = true;
            this.yiJiaZhuListView.Location = new System.Drawing.Point(348, 43);
            this.yiJiaZhuListView.Name = "yiJiaZhuListView";
            this.yiJiaZhuListView.Size = new System.Drawing.Size(223, 151);
            this.yiJiaZhuListView.TabIndex = 12;
            this.yiJiaZhuListView.UseCompatibleStateImageBehavior = false;
            this.yiJiaZhuListView.View = System.Windows.Forms.View.Details;
            // 
            // yiJiaZhuLabel
            // 
            this.yiJiaZhuLabel.AutoSize = true;
            this.yiJiaZhuLabel.Location = new System.Drawing.Point(348, 16);
            this.yiJiaZhuLabel.Name = "yiJiaZhuLabel";
            this.yiJiaZhuLabel.Size = new System.Drawing.Size(41, 12);
            this.yiJiaZhuLabel.TabIndex = 11;
            this.yiJiaZhuLabel.Text = "label9";
            // 
            // dianJi4TextBox
            // 
            this.dianJi4TextBox.Location = new System.Drawing.Point(174, 151);
            this.dianJi4TextBox.Name = "dianJi4TextBox";
            this.dianJi4TextBox.Size = new System.Drawing.Size(100, 21);
            this.dianJi4TextBox.TabIndex = 10;
            // 
            // dianJi3TextBox
            // 
            this.dianJi3TextBox.Location = new System.Drawing.Point(174, 124);
            this.dianJi3TextBox.Name = "dianJi3TextBox";
            this.dianJi3TextBox.Size = new System.Drawing.Size(100, 21);
            this.dianJi3TextBox.TabIndex = 9;
            // 
            // dianJi2TextBox
            // 
            this.dianJi2TextBox.Location = new System.Drawing.Point(174, 97);
            this.dianJi2TextBox.Name = "dianJi2TextBox";
            this.dianJi2TextBox.Size = new System.Drawing.Size(100, 21);
            this.dianJi2TextBox.TabIndex = 8;
            // 
            // dianJi1TextBox
            // 
            this.dianJi1TextBox.Location = new System.Drawing.Point(174, 70);
            this.dianJi1TextBox.Name = "dianJi1TextBox";
            this.dianJi1TextBox.Size = new System.Drawing.Size(100, 21);
            this.dianJi1TextBox.TabIndex = 7;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(68, 155);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(71, 12);
            this.label8.TabIndex = 5;
            this.label8.Text = "电机4电流：";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(68, 128);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(71, 12);
            this.label7.TabIndex = 4;
            this.label7.Text = "电机3电流：";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(68, 102);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(71, 12);
            this.label6.TabIndex = 3;
            this.label6.Text = "电机2电流：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(68, 75);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(71, 12);
            this.label5.TabIndex = 2;
            this.label5.Text = "电机1电流：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(68, 48);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 12);
            this.label4.TabIndex = 1;
            this.label4.Text = "状态：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(26, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 12);
            this.label3.TabIndex = 0;
            this.label3.Text = "仪器信息显示：";
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.autoButton);
            this.panel2.Controls.Add(this.stopButton);
            this.panel2.Controls.Add(this.startButton);
            this.panel2.Controls.Add(this.resetButton);
            this.panel2.Controls.Add(this.sendButton);
            this.panel2.Controls.Add(this.textBox2);
            this.panel2.Controls.Add(this.textBox1);
            this.panel2.Controls.Add(this.capacityLabel);
            this.panel2.Controls.Add(this.volumeLabel);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Location = new System.Drawing.Point(3, 153);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(596, 136);
            this.panel2.TabIndex = 0;
            // 
            // autoButton
            // 
            this.autoButton.Location = new System.Drawing.Point(349, 100);
            this.autoButton.Name = "autoButton";
            this.autoButton.Size = new System.Drawing.Size(75, 23);
            this.autoButton.TabIndex = 10;
            this.autoButton.Text = "自动";
            this.autoButton.UseVisualStyleBackColor = true;
            this.autoButton.Click += new System.EventHandler(this.autoButton_Click);
            // 
            // stopButton
            // 
            this.stopButton.Location = new System.Drawing.Point(254, 100);
            this.stopButton.Name = "stopButton";
            this.stopButton.Size = new System.Drawing.Size(75, 23);
            this.stopButton.TabIndex = 9;
            this.stopButton.Text = "急停";
            this.stopButton.UseVisualStyleBackColor = true;
            this.stopButton.Click += new System.EventHandler(this.stopButton_Click);
            // 
            // startButton
            // 
            this.startButton.Location = new System.Drawing.Point(161, 100);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(75, 23);
            this.startButton.TabIndex = 8;
            this.startButton.Text = "开始";
            this.startButton.UseVisualStyleBackColor = true;
            this.startButton.Click += new System.EventHandler(this.startButton_Click);
            // 
            // resetButton
            // 
            this.resetButton.Location = new System.Drawing.Point(71, 100);
            this.resetButton.Name = "resetButton";
            this.resetButton.Size = new System.Drawing.Size(75, 23);
            this.resetButton.TabIndex = 7;
            this.resetButton.Text = "复位";
            this.resetButton.UseVisualStyleBackColor = true;
            this.resetButton.Click += new System.EventHandler(this.resetButton_Click);
            // 
            // sendButton
            // 
            this.sendButton.Location = new System.Drawing.Point(315, 51);
            this.sendButton.Name = "sendButton";
            this.sendButton.Size = new System.Drawing.Size(75, 23);
            this.sendButton.TabIndex = 6;
            this.sendButton.Text = "发送";
            this.sendButton.UseVisualStyleBackColor = true;
            this.sendButton.Click += new System.EventHandler(this.sendButton_Click);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(175, 52);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(100, 21);
            this.textBox2.TabIndex = 5;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(175, 25);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 21);
            this.textBox1.TabIndex = 4;
            // 
            // capacityLabel
            // 
            this.capacityLabel.AutoSize = true;
            this.capacityLabel.Location = new System.Drawing.Point(69, 58);
            this.capacityLabel.Name = "capacityLabel";
            this.capacityLabel.Size = new System.Drawing.Size(41, 12);
            this.capacityLabel.TabIndex = 3;
            this.capacityLabel.Text = "label4";
            // 
            // volumeLabel
            // 
            this.volumeLabel.AutoSize = true;
            this.volumeLabel.Location = new System.Drawing.Point(69, 31);
            this.volumeLabel.Name = "volumeLabel";
            this.volumeLabel.Size = new System.Drawing.Size(41, 12);
            this.volumeLabel.TabIndex = 2;
            this.volumeLabel.Text = "label3";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(25, 78);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "命令：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "发送：";
            // 
            // refreshTimer
            // 
            this.refreshTimer.Interval = 1000;
            this.refreshTimer.Tick += new System.EventHandler(this.refreshTimer_Tick);
            // 
            // AutoDispenDeviceForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(626, 556);
            this.Controls.Add(this.panel1);
            this.Name = "AutoDispenDeviceForm";
            this.Text = "全自动培养皿分装仪";
            this.Load += new System.EventHandler(this.AutoDispenDeviceForm_Load);
            this.panel1.ResumeLayout(false);
            this.basicPanel.ResumeLayout(false);
            this.basicPanel.PerformLayout();
            this.s.ResumeLayout(false);
            this.s.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label capacityLabel;
        private System.Windows.Forms.Label volumeLabel;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button sendButton;
        private System.Windows.Forms.Button autoButton;
        private System.Windows.Forms.Button stopButton;
        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.Button resetButton;
        private System.Windows.Forms.Panel s;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox dianJi4TextBox;
        private System.Windows.Forms.TextBox dianJi3TextBox;
        private System.Windows.Forms.TextBox dianJi2TextBox;
        private System.Windows.Forms.TextBox dianJi1TextBox;
        private System.Windows.Forms.Label yiJiaZhuLabel;
        private System.Windows.Forms.ListView yiJiaZhuListView;
        private System.Windows.Forms.Timer refreshTimer;
        private System.Windows.Forms.ComboBox stateComboBox;
        private System.Windows.Forms.Panel basicPanel;
        private System.Windows.Forms.CheckBox isVirtualCheckBox;
        private System.Windows.Forms.TextBox serialIDTextBox;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox codeTextBox;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox identifyIDTextBox;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox deviceIPTextBox;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox deviceNameTextBox;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox localIPTextBox;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label deviceNameLabel;
        private System.Windows.Forms.Label label18;
    }
}