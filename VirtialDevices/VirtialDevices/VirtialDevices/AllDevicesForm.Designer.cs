namespace VirtialDevices
{
    partial class VirtualDevicesForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.panel1 = new System.Windows.Forms.Panel();
            this.buttonPanel = new System.Windows.Forms.Panel();
            this.exitButton = new System.Windows.Forms.Button();
            this.stopAllButton = new System.Windows.Forms.Button();
            this.logPanel = new System.Windows.Forms.Panel();
            this.logsListView = new System.Windows.Forms.ListView();
            this.typeColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.timeColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.deviceColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.dataColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label2 = new System.Windows.Forms.Label();
            this.devicesPanel = new System.Windows.Forms.Panel();
            this.deviceListView = new System.Windows.Forms.ListView();
            this.deviceTypeColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.deviceNameColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.deviceStateColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.createDeviceButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.logTimer = new System.Windows.Forms.Timer(this.components);
            this.panel1.SuspendLayout();
            this.buttonPanel.SuspendLayout();
            this.logPanel.SuspendLayout();
            this.devicesPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.buttonPanel);
            this.panel1.Controls.Add(this.logPanel);
            this.panel1.Controls.Add(this.devicesPanel);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(940, 498);
            this.panel1.TabIndex = 0;
            // 
            // buttonPanel
            // 
            this.buttonPanel.Controls.Add(this.exitButton);
            this.buttonPanel.Controls.Add(this.stopAllButton);
            this.buttonPanel.Location = new System.Drawing.Point(3, 441);
            this.buttonPanel.Name = "buttonPanel";
            this.buttonPanel.Size = new System.Drawing.Size(934, 54);
            this.buttonPanel.TabIndex = 2;
            // 
            // exitButton
            // 
            this.exitButton.Location = new System.Drawing.Point(832, 19);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(75, 23);
            this.exitButton.TabIndex = 1;
            this.exitButton.Text = "退出";
            this.exitButton.UseVisualStyleBackColor = true;
            this.exitButton.Click += new System.EventHandler(this.exitButton_Click);
            // 
            // stopAllButton
            // 
            this.stopAllButton.Location = new System.Drawing.Point(32, 19);
            this.stopAllButton.Name = "stopAllButton";
            this.stopAllButton.Size = new System.Drawing.Size(75, 23);
            this.stopAllButton.TabIndex = 0;
            this.stopAllButton.Text = "全部停止";
            this.stopAllButton.UseVisualStyleBackColor = true;
            this.stopAllButton.Click += new System.EventHandler(this.stopAllButton_Click);
            // 
            // logPanel
            // 
            this.logPanel.Controls.Add(this.logsListView);
            this.logPanel.Controls.Add(this.label2);
            this.logPanel.Location = new System.Drawing.Point(492, 3);
            this.logPanel.Name = "logPanel";
            this.logPanel.Size = new System.Drawing.Size(445, 432);
            this.logPanel.TabIndex = 1;
            // 
            // logsListView
            // 
            this.logsListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.typeColumnHeader,
            this.timeColumnHeader,
            this.deviceColumnHeader,
            this.dataColumnHeader});
            this.logsListView.Location = new System.Drawing.Point(22, 57);
            this.logsListView.Name = "logsListView";
            this.logsListView.Size = new System.Drawing.Size(409, 364);
            this.logsListView.TabIndex = 1;
            this.logsListView.UseCompatibleStateImageBehavior = false;
            this.logsListView.View = System.Windows.Forms.View.Details;
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
            this.dataColumnHeader.Width = 243;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "数据履历";
            // 
            // devicesPanel
            // 
            this.devicesPanel.Controls.Add(this.deviceListView);
            this.devicesPanel.Controls.Add(this.createDeviceButton);
            this.devicesPanel.Controls.Add(this.label1);
            this.devicesPanel.Location = new System.Drawing.Point(3, 3);
            this.devicesPanel.Name = "devicesPanel";
            this.devicesPanel.Size = new System.Drawing.Size(483, 432);
            this.devicesPanel.TabIndex = 0;
            // 
            // deviceListView
            // 
            this.deviceListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.deviceTypeColumnHeader,
            this.deviceNameColumnHeader,
            this.deviceStateColumnHeader});
            this.deviceListView.FullRowSelect = true;
            this.deviceListView.Location = new System.Drawing.Point(18, 57);
            this.deviceListView.MultiSelect = false;
            this.deviceListView.Name = "deviceListView";
            this.deviceListView.Size = new System.Drawing.Size(453, 364);
            this.deviceListView.TabIndex = 2;
            this.deviceListView.UseCompatibleStateImageBehavior = false;
            this.deviceListView.View = System.Windows.Forms.View.Details;
            this.deviceListView.SelectedIndexChanged += new System.EventHandler(this.deviceListView_SelectedIndexChanged);
            this.deviceListView.DoubleClick += new System.EventHandler(this.deviceListView_DoubleClick);
            this.deviceListView.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.deviceListView_MouseDoubleClick);
            // 
            // deviceTypeColumnHeader
            // 
            this.deviceTypeColumnHeader.Text = "类型";
            // 
            // deviceNameColumnHeader
            // 
            this.deviceNameColumnHeader.Text = "名称";
            // 
            // deviceStateColumnHeader
            // 
            this.deviceStateColumnHeader.Text = "状态";
            this.deviceStateColumnHeader.Width = 329;
            // 
            // createDeviceButton
            // 
            this.createDeviceButton.Location = new System.Drawing.Point(396, 18);
            this.createDeviceButton.Name = "createDeviceButton";
            this.createDeviceButton.Size = new System.Drawing.Size(75, 23);
            this.createDeviceButton.TabIndex = 1;
            this.createDeviceButton.Text = "新建仪器";
            this.createDeviceButton.UseVisualStyleBackColor = true;
            this.createDeviceButton.Click += new System.EventHandler(this.createDeviceButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "仪器列表";
            // 
            // logTimer
            // 
            this.logTimer.Interval = 1000;
            this.logTimer.Tick += new System.EventHandler(this.logTimer_Tick);
            // 
            // VirtualDevicesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(964, 522);
            this.Controls.Add(this.panel1);
            this.Name = "VirtualDevicesForm";
            this.Text = "虚拟仪器";
            this.Load += new System.EventHandler(this.VirtualDevicesForm_Load);
            this.panel1.ResumeLayout(false);
            this.buttonPanel.ResumeLayout(false);
            this.logPanel.ResumeLayout(false);
            this.logPanel.PerformLayout();
            this.devicesPanel.ResumeLayout(false);
            this.devicesPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel devicesPanel;
        private System.Windows.Forms.Panel logPanel;
        private System.Windows.Forms.Panel buttonPanel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button createDeviceButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button stopAllButton;
        private System.Windows.Forms.Button exitButton;
        private System.Windows.Forms.ListView logsListView;
        private System.Windows.Forms.Timer logTimer;
        private System.Windows.Forms.ColumnHeader typeColumnHeader;
        private System.Windows.Forms.ColumnHeader timeColumnHeader;
        private System.Windows.Forms.ColumnHeader deviceColumnHeader;
        private System.Windows.Forms.ColumnHeader dataColumnHeader;
        private System.Windows.Forms.ListView deviceListView;
        private System.Windows.Forms.ColumnHeader deviceTypeColumnHeader;
        private System.Windows.Forms.ColumnHeader deviceNameColumnHeader;
        private System.Windows.Forms.ColumnHeader deviceStateColumnHeader;
    }
}

