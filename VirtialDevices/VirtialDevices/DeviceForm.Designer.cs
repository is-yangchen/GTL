namespace VirtialDevices
{
    partial class DeviceForm
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
            this.deviceLogPanel = new System.Windows.Forms.Panel();
            this.deviceButton = new System.Windows.Forms.Button();
            this.runButton = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.logPanel = new System.Windows.Forms.Panel();
            this.deviceLogListView = new System.Windows.Forms.ListView();
            this.typeColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.timeColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.deviceColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.dataColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label18 = new System.Windows.Forms.Label();
            this.baicPanel = new System.Windows.Forms.Panel();
            this.serielIDTextBox = new System.Windows.Forms.TextBox();
            this.identifyIDTextBox = new System.Windows.Forms.TextBox();
            this.controlIPTextBox = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.deviceCodeTextBox = new System.Windows.Forms.TextBox();
            this.deviceNameTextBox = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.deviceIPTextBox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.deleteDeviceButton = new System.Windows.Forms.Button();
            this.insertDeviceButton = new System.Windows.Forms.Button();
            this.faultStateButton = new System.Windows.Forms.Button();
            this.stopStateButton = new System.Windows.Forms.Button();
            this.normalStateButton = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.sampleTimeTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.currentStateLabel = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.deviceNameLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.deviceLogPanel.SuspendLayout();
            this.logPanel.SuspendLayout();
            this.baicPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.deviceLogPanel);
            this.panel1.Controls.Add(this.logPanel);
            this.panel1.Controls.Add(this.baicPanel);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(597, 346);
            this.panel1.TabIndex = 0;
            // 
            // deviceLogPanel
            // 
            this.deviceLogPanel.Controls.Add(this.deviceButton);
            this.deviceLogPanel.Controls.Add(this.runButton);
            this.deviceLogPanel.Controls.Add(this.button1);
            this.deviceLogPanel.Location = new System.Drawing.Point(3, 310);
            this.deviceLogPanel.Name = "deviceLogPanel";
            this.deviceLogPanel.Size = new System.Drawing.Size(588, 31);
            this.deviceLogPanel.TabIndex = 4;
            // 
            // deviceButton
            // 
            this.deviceButton.Location = new System.Drawing.Point(410, 3);
            this.deviceButton.Name = "deviceButton";
            this.deviceButton.Size = new System.Drawing.Size(75, 23);
            this.deviceButton.TabIndex = 2;
            this.deviceButton.Text = "特定信息";
            this.deviceButton.UseVisualStyleBackColor = true;
            this.deviceButton.Click += new System.EventHandler(this.deviceButton_Click);
            // 
            // runButton
            // 
            this.runButton.Location = new System.Drawing.Point(20, 3);
            this.runButton.Name = "runButton";
            this.runButton.Size = new System.Drawing.Size(75, 23);
            this.runButton.TabIndex = 1;
            this.runButton.Text = "运行";
            this.runButton.UseVisualStyleBackColor = true;
            this.runButton.Click += new System.EventHandler(this.runButton_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(491, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "退出";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // logPanel
            // 
            this.logPanel.Controls.Add(this.deviceLogListView);
            this.logPanel.Controls.Add(this.label18);
            this.logPanel.Location = new System.Drawing.Point(3, 176);
            this.logPanel.Name = "logPanel";
            this.logPanel.Size = new System.Drawing.Size(588, 128);
            this.logPanel.TabIndex = 3;
            // 
            // deviceLogListView
            // 
            this.deviceLogListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.typeColumnHeader,
            this.timeColumnHeader,
            this.deviceColumnHeader,
            this.dataColumnHeader});
            this.deviceLogListView.Location = new System.Drawing.Point(22, 30);
            this.deviceLogListView.Name = "deviceLogListView";
            this.deviceLogListView.Size = new System.Drawing.Size(544, 95);
            this.deviceLogListView.TabIndex = 1;
            this.deviceLogListView.UseCompatibleStateImageBehavior = false;
            this.deviceLogListView.View = System.Windows.Forms.View.Details;
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
            this.dataColumnHeader.Width = 378;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(20, 14);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(65, 12);
            this.label18.TabIndex = 0;
            this.label18.Text = "数据履历：";
            // 
            // baicPanel
            // 
            this.baicPanel.Controls.Add(this.serielIDTextBox);
            this.baicPanel.Controls.Add(this.identifyIDTextBox);
            this.baicPanel.Controls.Add(this.controlIPTextBox);
            this.baicPanel.Controls.Add(this.label11);
            this.baicPanel.Controls.Add(this.label10);
            this.baicPanel.Controls.Add(this.label9);
            this.baicPanel.Controls.Add(this.deviceCodeTextBox);
            this.baicPanel.Controls.Add(this.deviceNameTextBox);
            this.baicPanel.Controls.Add(this.label8);
            this.baicPanel.Controls.Add(this.label7);
            this.baicPanel.Controls.Add(this.deviceIPTextBox);
            this.baicPanel.Controls.Add(this.label6);
            this.baicPanel.Controls.Add(this.deleteDeviceButton);
            this.baicPanel.Controls.Add(this.insertDeviceButton);
            this.baicPanel.Controls.Add(this.faultStateButton);
            this.baicPanel.Controls.Add(this.stopStateButton);
            this.baicPanel.Controls.Add(this.normalStateButton);
            this.baicPanel.Controls.Add(this.label5);
            this.baicPanel.Controls.Add(this.label4);
            this.baicPanel.Controls.Add(this.sampleTimeTextBox);
            this.baicPanel.Controls.Add(this.label3);
            this.baicPanel.Controls.Add(this.currentStateLabel);
            this.baicPanel.Controls.Add(this.label2);
            this.baicPanel.Controls.Add(this.deviceNameLabel);
            this.baicPanel.Controls.Add(this.label1);
            this.baicPanel.Location = new System.Drawing.Point(3, 3);
            this.baicPanel.Name = "baicPanel";
            this.baicPanel.Size = new System.Drawing.Size(589, 167);
            this.baicPanel.TabIndex = 0;
            // 
            // serielIDTextBox
            // 
            this.serielIDTextBox.Location = new System.Drawing.Point(393, 141);
            this.serielIDTextBox.Name = "serielIDTextBox";
            this.serielIDTextBox.Size = new System.Drawing.Size(165, 21);
            this.serielIDTextBox.TabIndex = 24;
            this.serielIDTextBox.Text = "a";
            // 
            // identifyIDTextBox
            // 
            this.identifyIDTextBox.Location = new System.Drawing.Point(393, 115);
            this.identifyIDTextBox.Name = "identifyIDTextBox";
            this.identifyIDTextBox.Size = new System.Drawing.Size(165, 21);
            this.identifyIDTextBox.TabIndex = 23;
            this.identifyIDTextBox.Text = "a";
            // 
            // controlIPTextBox
            // 
            this.controlIPTextBox.Location = new System.Drawing.Point(393, 88);
            this.controlIPTextBox.Name = "controlIPTextBox";
            this.controlIPTextBox.Size = new System.Drawing.Size(165, 21);
            this.controlIPTextBox.TabIndex = 22;
            this.controlIPTextBox.Text = "127.0.0.1";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(323, 141);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(53, 12);
            this.label11.TabIndex = 21;
            this.label11.Text = "序列号：";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(323, 116);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(53, 12);
            this.label10.TabIndex = 20;
            this.label10.Text = "识别码：";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(321, 91);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(65, 12);
            this.label9.TabIndex = 19;
            this.label9.Text = "上位机IP：";
            // 
            // deviceCodeTextBox
            // 
            this.deviceCodeTextBox.Location = new System.Drawing.Point(129, 142);
            this.deviceCodeTextBox.Name = "deviceCodeTextBox";
            this.deviceCodeTextBox.ReadOnly = true;
            this.deviceCodeTextBox.Size = new System.Drawing.Size(172, 21);
            this.deviceCodeTextBox.TabIndex = 18;
            // 
            // deviceNameTextBox
            // 
            this.deviceNameTextBox.Location = new System.Drawing.Point(129, 116);
            this.deviceNameTextBox.Name = "deviceNameTextBox";
            this.deviceNameTextBox.Size = new System.Drawing.Size(172, 21);
            this.deviceNameTextBox.TabIndex = 17;
            this.deviceNameTextBox.Text = "a";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(90, 145);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(41, 12);
            this.label8.TabIndex = 16;
            this.label8.Text = "代码：";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(90, 119);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(41, 12);
            this.label7.TabIndex = 15;
            this.label7.Text = "名称：";
            // 
            // deviceIPTextBox
            // 
            this.deviceIPTextBox.Location = new System.Drawing.Point(129, 88);
            this.deviceIPTextBox.Name = "deviceIPTextBox";
            this.deviceIPTextBox.Size = new System.Drawing.Size(172, 21);
            this.deviceIPTextBox.TabIndex = 14;
            this.deviceIPTextBox.Text = "127.0.0.1";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(94, 91);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(29, 12);
            this.label6.TabIndex = 13;
            this.label6.Text = "IP：";
            // 
            // deleteDeviceButton
            // 
            this.deleteDeviceButton.Location = new System.Drawing.Point(468, 52);
            this.deleteDeviceButton.Name = "deleteDeviceButton";
            this.deleteDeviceButton.Size = new System.Drawing.Size(75, 23);
            this.deleteDeviceButton.TabIndex = 12;
            this.deleteDeviceButton.Text = "移除仪器";
            this.deleteDeviceButton.UseVisualStyleBackColor = true;
            // 
            // insertDeviceButton
            // 
            this.insertDeviceButton.Location = new System.Drawing.Point(374, 52);
            this.insertDeviceButton.Name = "insertDeviceButton";
            this.insertDeviceButton.Size = new System.Drawing.Size(75, 23);
            this.insertDeviceButton.TabIndex = 11;
            this.insertDeviceButton.Text = "插入仪器";
            this.insertDeviceButton.UseVisualStyleBackColor = true;
            // 
            // faultStateButton
            // 
            this.faultStateButton.Location = new System.Drawing.Point(282, 52);
            this.faultStateButton.Name = "faultStateButton";
            this.faultStateButton.Size = new System.Drawing.Size(75, 23);
            this.faultStateButton.TabIndex = 10;
            this.faultStateButton.Text = "故障";
            this.faultStateButton.UseVisualStyleBackColor = true;
            // 
            // stopStateButton
            // 
            this.stopStateButton.Location = new System.Drawing.Point(189, 52);
            this.stopStateButton.Name = "stopStateButton";
            this.stopStateButton.Size = new System.Drawing.Size(75, 23);
            this.stopStateButton.TabIndex = 9;
            this.stopStateButton.Text = "停止";
            this.stopStateButton.UseVisualStyleBackColor = true;
            // 
            // normalStateButton
            // 
            this.normalStateButton.Location = new System.Drawing.Point(92, 52);
            this.normalStateButton.Name = "normalStateButton";
            this.normalStateButton.Size = new System.Drawing.Size(75, 23);
            this.normalStateButton.TabIndex = 8;
            this.normalStateButton.Text = "正常运行";
            this.normalStateButton.UseVisualStyleBackColor = true;
            this.normalStateButton.Click += new System.EventHandler(this.normalStateButton_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(21, 82);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 12);
            this.label5.TabIndex = 7;
            this.label5.Text = "参数设定：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(21, 57);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 6;
            this.label4.Text = "状态测试：";
            // 
            // sampleTimeTextBox
            // 
            this.sampleTimeTextBox.Location = new System.Drawing.Point(391, 25);
            this.sampleTimeTextBox.Name = "sampleTimeTextBox";
            this.sampleTimeTextBox.Size = new System.Drawing.Size(100, 21);
            this.sampleTimeTextBox.TabIndex = 5;
            this.sampleTimeTextBox.Text = "2";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(290, 29);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(95, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "采样时间（S）：";
            // 
            // currentStateLabel
            // 
            this.currentStateLabel.AutoSize = true;
            this.currentStateLabel.Location = new System.Drawing.Point(91, 28);
            this.currentStateLabel.Name = "currentStateLabel";
            this.currentStateLabel.Size = new System.Drawing.Size(41, 12);
            this.currentStateLabel.TabIndex = 3;
            this.currentStateLabel.Text = "label3";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "当前状态：";
            // 
            // deviceNameLabel
            // 
            this.deviceNameLabel.AutoSize = true;
            this.deviceNameLabel.Location = new System.Drawing.Point(64, 4);
            this.deviceNameLabel.Name = "deviceNameLabel";
            this.deviceNameLabel.Size = new System.Drawing.Size(41, 12);
            this.deviceNameLabel.TabIndex = 1;
            this.deviceNameLabel.Text = "label2";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "仪器名：";
            // 
            // DeviceForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(621, 370);
            this.Controls.Add(this.panel1);
            this.Name = "DeviceForm";
            this.Text = "仪器信息";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.DeviceForm_FormClosing);
            this.Load += new System.EventHandler(this.DeviceForm_Load);
            this.panel1.ResumeLayout(false);
            this.deviceLogPanel.ResumeLayout(false);
            this.logPanel.ResumeLayout(false);
            this.logPanel.PerformLayout();
            this.baicPanel.ResumeLayout(false);
            this.baicPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel baicPanel;
        private System.Windows.Forms.Panel logPanel;
        private System.Windows.Forms.Panel deviceLogPanel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label deviceNameLabel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label currentStateLabel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox sampleTimeTextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button deleteDeviceButton;
        private System.Windows.Forms.Button insertDeviceButton;
        private System.Windows.Forms.Button faultStateButton;
        private System.Windows.Forms.Button stopStateButton;
        private System.Windows.Forms.Button normalStateButton;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox deviceIPTextBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox deviceNameTextBox;
        private System.Windows.Forms.TextBox deviceCodeTextBox;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox controlIPTextBox;
        private System.Windows.Forms.TextBox identifyIDTextBox;
        private System.Windows.Forms.TextBox serielIDTextBox;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.ListView deviceLogListView;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button runButton;
        private System.Windows.Forms.ColumnHeader typeColumnHeader;
        private System.Windows.Forms.ColumnHeader timeColumnHeader;
        private System.Windows.Forms.ColumnHeader deviceColumnHeader;
        private System.Windows.Forms.ColumnHeader dataColumnHeader;
        private System.Windows.Forms.Button deviceButton;
    }
}