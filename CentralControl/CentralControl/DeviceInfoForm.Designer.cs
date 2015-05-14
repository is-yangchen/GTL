namespace CentralControl
{
    partial class DeviceInfoForm
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.buttonPanel = new System.Windows.Forms.Panel();
            this.infoButton = new System.Windows.Forms.Button();
            this.exitButton = new System.Windows.Forms.Button();
            this.logPanel = new System.Windows.Forms.Panel();
            this.logListView = new System.Windows.Forms.ListView();
            this.typeColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.timeColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.deviceColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.dataColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label15 = new System.Windows.Forms.Label();
            this.basicPanel = new System.Windows.Forms.Panel();
            this.isVirtualCheckBox = new System.Windows.Forms.CheckBox();
            this.serialIDTextBox = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.codeTextBox = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.identifyIDTextBox = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.deviceIPTextBox = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.deviceNameTextBox = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.localIPTextBox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.setSampleTimeButton = new System.Windows.Forms.Button();
            this.sampleTimeTextBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.currentStatusLabel = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.deviceNameLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.buttonPanel.SuspendLayout();
            this.logPanel.SuspendLayout();
            this.basicPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.buttonPanel);
            this.panel1.Controls.Add(this.logPanel);
            this.panel1.Controls.Add(this.basicPanel);
            this.panel1.Location = new System.Drawing.Point(12, 13);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(602, 376);
            this.panel1.TabIndex = 0;
            // 
            // buttonPanel
            // 
            this.buttonPanel.Controls.Add(this.infoButton);
            this.buttonPanel.Controls.Add(this.exitButton);
            this.buttonPanel.Location = new System.Drawing.Point(3, 335);
            this.buttonPanel.Name = "buttonPanel";
            this.buttonPanel.Size = new System.Drawing.Size(596, 31);
            this.buttonPanel.TabIndex = 4;
            // 
            // infoButton
            // 
            this.infoButton.Location = new System.Drawing.Point(21, 4);
            this.infoButton.Name = "infoButton";
            this.infoButton.Size = new System.Drawing.Size(75, 25);
            this.infoButton.TabIndex = 1;
            this.infoButton.Text = "特定信息";
            this.infoButton.UseVisualStyleBackColor = true;
            this.infoButton.Click += new System.EventHandler(this.infoButton_Click);
            // 
            // exitButton
            // 
            this.exitButton.Location = new System.Drawing.Point(505, 3);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(75, 25);
            this.exitButton.TabIndex = 0;
            this.exitButton.Text = "退出";
            this.exitButton.UseVisualStyleBackColor = true;
            this.exitButton.Click += new System.EventHandler(this.exitButton_Click);
            // 
            // logPanel
            // 
            this.logPanel.Controls.Add(this.logListView);
            this.logPanel.Controls.Add(this.label15);
            this.logPanel.Location = new System.Drawing.Point(3, 172);
            this.logPanel.Name = "logPanel";
            this.logPanel.Size = new System.Drawing.Size(596, 157);
            this.logPanel.TabIndex = 3;
            // 
            // logListView
            // 
            this.logListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.typeColumnHeader,
            this.timeColumnHeader,
            this.deviceColumnHeader,
            this.dataColumnHeader});
            this.logListView.Location = new System.Drawing.Point(19, 28);
            this.logListView.Name = "logListView";
            this.logListView.Size = new System.Drawing.Size(561, 125);
            this.logListView.TabIndex = 1;
            this.logListView.UseCompatibleStateImageBehavior = false;
            this.logListView.View = System.Windows.Forms.View.Details;
            // 
            // typeColumnHeader
            // 
            this.typeColumnHeader.Text = "接收/发送";
            this.typeColumnHeader.Width = 66;
            // 
            // timeColumnHeader
            // 
            this.timeColumnHeader.Text = "时间";
            this.timeColumnHeader.Width = 36;
            // 
            // deviceColumnHeader
            // 
            this.deviceColumnHeader.Text = "仪器代号";
            // 
            // dataColumnHeader
            // 
            this.dataColumnHeader.Text = "数据";
            this.dataColumnHeader.Width = 377;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(17, 11);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(67, 13);
            this.label15.TabIndex = 0;
            this.label15.Text = "数据履历：";
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
            this.basicPanel.Controls.Add(this.label8);
            this.basicPanel.Controls.Add(this.deviceNameTextBox);
            this.basicPanel.Controls.Add(this.label7);
            this.basicPanel.Controls.Add(this.localIPTextBox);
            this.basicPanel.Controls.Add(this.label6);
            this.basicPanel.Controls.Add(this.setSampleTimeButton);
            this.basicPanel.Controls.Add(this.sampleTimeTextBox);
            this.basicPanel.Controls.Add(this.label5);
            this.basicPanel.Controls.Add(this.label4);
            this.basicPanel.Controls.Add(this.currentStatusLabel);
            this.basicPanel.Controls.Add(this.label2);
            this.basicPanel.Controls.Add(this.deviceNameLabel);
            this.basicPanel.Controls.Add(this.label1);
            this.basicPanel.Location = new System.Drawing.Point(3, 3);
            this.basicPanel.Name = "basicPanel";
            this.basicPanel.Size = new System.Drawing.Size(596, 165);
            this.basicPanel.TabIndex = 0;
            // 
            // isVirtualCheckBox
            // 
            this.isVirtualCheckBox.AutoSize = true;
            this.isVirtualCheckBox.Location = new System.Drawing.Point(265, 8);
            this.isVirtualCheckBox.Name = "isVirtualCheckBox";
            this.isVirtualCheckBox.Size = new System.Drawing.Size(74, 17);
            this.isVirtualCheckBox.TabIndex = 22;
            this.isVirtualCheckBox.Text = "虚拟仪器";
            this.isVirtualCheckBox.UseVisualStyleBackColor = true;
            // 
            // serialIDTextBox
            // 
            this.serialIDTextBox.Location = new System.Drawing.Point(401, 129);
            this.serialIDTextBox.Name = "serialIDTextBox";
            this.serialIDTextBox.Size = new System.Drawing.Size(167, 20);
            this.serialIDTextBox.TabIndex = 21;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(342, 133);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(55, 13);
            this.label11.TabIndex = 20;
            this.label11.Text = "序列号：";
            // 
            // codeTextBox
            // 
            this.codeTextBox.Location = new System.Drawing.Point(151, 129);
            this.codeTextBox.Name = "codeTextBox";
            this.codeTextBox.ReadOnly = true;
            this.codeTextBox.Size = new System.Drawing.Size(162, 20);
            this.codeTextBox.TabIndex = 19;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(90, 133);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(43, 13);
            this.label10.TabIndex = 18;
            this.label10.Text = "代码：";
            // 
            // identifyIDTextBox
            // 
            this.identifyIDTextBox.Location = new System.Drawing.Point(401, 100);
            this.identifyIDTextBox.Name = "identifyIDTextBox";
            this.identifyIDTextBox.Size = new System.Drawing.Size(167, 20);
            this.identifyIDTextBox.TabIndex = 17;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(342, 104);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(55, 13);
            this.label9.TabIndex = 16;
            this.label9.Text = "识别码：";
            // 
            // deviceIPTextBox
            // 
            this.deviceIPTextBox.Location = new System.Drawing.Point(151, 66);
            this.deviceIPTextBox.Name = "deviceIPTextBox";
            this.deviceIPTextBox.Size = new System.Drawing.Size(162, 20);
            this.deviceIPTextBox.TabIndex = 15;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(90, 70);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 13);
            this.label8.TabIndex = 14;
            this.label8.Text = "仪器IP：";
            // 
            // deviceNameTextBox
            // 
            this.deviceNameTextBox.Location = new System.Drawing.Point(151, 100);
            this.deviceNameTextBox.Name = "deviceNameTextBox";
            this.deviceNameTextBox.Size = new System.Drawing.Size(162, 20);
            this.deviceNameTextBox.TabIndex = 13;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(90, 104);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(43, 13);
            this.label7.TabIndex = 12;
            this.label7.Text = "名称：";
            // 
            // localIPTextBox
            // 
            this.localIPTextBox.Location = new System.Drawing.Point(401, 67);
            this.localIPTextBox.Name = "localIPTextBox";
            this.localIPTextBox.Size = new System.Drawing.Size(167, 20);
            this.localIPTextBox.TabIndex = 11;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(342, 70);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "本地IP：";
            // 
            // setSampleTimeButton
            // 
            this.setSampleTimeButton.Location = new System.Drawing.Point(479, 36);
            this.setSampleTimeButton.Name = "setSampleTimeButton";
            this.setSampleTimeButton.Size = new System.Drawing.Size(75, 25);
            this.setSampleTimeButton.TabIndex = 9;
            this.setSampleTimeButton.Text = "设定";
            this.setSampleTimeButton.UseVisualStyleBackColor = true;
            // 
            // sampleTimeTextBox
            // 
            this.sampleTimeTextBox.Location = new System.Drawing.Point(364, 38);
            this.sampleTimeTextBox.Name = "sampleTimeTextBox";
            this.sampleTimeTextBox.Size = new System.Drawing.Size(100, 20);
            this.sampleTimeTextBox.TabIndex = 8;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(19, 70);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(67, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "仪器信息：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(263, 41);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(98, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "采样时间（S）：";
            // 
            // currentStatusLabel
            // 
            this.currentStatusLabel.AutoSize = true;
            this.currentStatusLabel.Location = new System.Drawing.Point(90, 41);
            this.currentStatusLabel.Name = "currentStatusLabel";
            this.currentStatusLabel.Size = new System.Drawing.Size(35, 13);
            this.currentStatusLabel.TabIndex = 3;
            this.currentStatusLabel.Text = "label3";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "当前状态：";
            // 
            // deviceNameLabel
            // 
            this.deviceNameLabel.AutoSize = true;
            this.deviceNameLabel.Location = new System.Drawing.Point(76, 13);
            this.deviceNameLabel.Name = "deviceNameLabel";
            this.deviceNameLabel.Size = new System.Drawing.Size(35, 13);
            this.deviceNameLabel.TabIndex = 1;
            this.deviceNameLabel.Text = "label2";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "仪器名：";
            // 
            // DeviceInfoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(626, 400);
            this.Controls.Add(this.panel1);
            this.Name = "DeviceInfoForm";
            this.Text = "仪器信息";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.DeviceInfoForm_FormClosing);
            this.Load += new System.EventHandler(this.DeviceInfoForm_Load);
            this.panel1.ResumeLayout(false);
            this.buttonPanel.ResumeLayout(false);
            this.logPanel.ResumeLayout(false);
            this.logPanel.PerformLayout();
            this.basicPanel.ResumeLayout(false);
            this.basicPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel basicPanel;
        private System.Windows.Forms.Panel logPanel;
        private System.Windows.Forms.Panel buttonPanel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label deviceNameLabel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label currentStatusLabel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox sampleTimeTextBox;
        private System.Windows.Forms.Button setSampleTimeButton;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox localIPTextBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox deviceNameTextBox;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox deviceIPTextBox;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox identifyIDTextBox;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox codeTextBox;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox serialIDTextBox;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.ListView logListView;
        private System.Windows.Forms.Button exitButton;
        private System.Windows.Forms.CheckBox isVirtualCheckBox;
        private System.Windows.Forms.ColumnHeader typeColumnHeader;
        private System.Windows.Forms.ColumnHeader timeColumnHeader;
        private System.Windows.Forms.ColumnHeader deviceColumnHeader;
        private System.Windows.Forms.ColumnHeader dataColumnHeader;
        private System.Windows.Forms.Button infoButton;
    }
}