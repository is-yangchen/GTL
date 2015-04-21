namespace CentralControl
{
    partial class ControlForm
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
            this.buttonAllPanel = new System.Windows.Forms.Panel();
            this.searchButton = new System.Windows.Forms.Button();
            this.exitAllButton = new System.Windows.Forms.Button();
            this.logAllPanel = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.logAllListView = new System.Windows.Forms.ListView();
            this.typeColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.timeColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.deviceColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.dataColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.onlineListPanel = new System.Windows.Forms.Panel();
            this.onlineAllListView = new System.Windows.Forms.ListView();
            this.deviceTypeColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.deviceNameColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.deviceCodeColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.isVirtColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label1 = new System.Windows.Forms.Label();
            this.deviceTimer = new System.Windows.Forms.Timer(this.components);
            this.logTimer = new System.Windows.Forms.Timer(this.components);
            this.panel1.SuspendLayout();
            this.buttonAllPanel.SuspendLayout();
            this.logAllPanel.SuspendLayout();
            this.onlineListPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.buttonAllPanel);
            this.panel1.Controls.Add(this.logAllPanel);
            this.panel1.Controls.Add(this.onlineListPanel);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(825, 455);
            this.panel1.TabIndex = 0;
            // 
            // buttonAllPanel
            // 
            this.buttonAllPanel.Controls.Add(this.searchButton);
            this.buttonAllPanel.Controls.Add(this.exitAllButton);
            this.buttonAllPanel.Location = new System.Drawing.Point(3, 421);
            this.buttonAllPanel.Name = "buttonAllPanel";
            this.buttonAllPanel.Size = new System.Drawing.Size(819, 31);
            this.buttonAllPanel.TabIndex = 2;
            // 
            // searchButton
            // 
            this.searchButton.Location = new System.Drawing.Point(16, 4);
            this.searchButton.Name = "searchButton";
            this.searchButton.Size = new System.Drawing.Size(75, 23);
            this.searchButton.TabIndex = 1;
            this.searchButton.Text = "查询";
            this.searchButton.UseVisualStyleBackColor = true;
            this.searchButton.Click += new System.EventHandler(this.searchButton_Click);
            // 
            // exitAllButton
            // 
            this.exitAllButton.Location = new System.Drawing.Point(722, 4);
            this.exitAllButton.Name = "exitAllButton";
            this.exitAllButton.Size = new System.Drawing.Size(75, 23);
            this.exitAllButton.TabIndex = 0;
            this.exitAllButton.Text = "退出";
            this.exitAllButton.UseVisualStyleBackColor = true;
            this.exitAllButton.Click += new System.EventHandler(this.exitAllButton_Click);
            // 
            // logAllPanel
            // 
            this.logAllPanel.Controls.Add(this.label2);
            this.logAllPanel.Controls.Add(this.logAllListView);
            this.logAllPanel.Location = new System.Drawing.Point(442, 3);
            this.logAllPanel.Name = "logAllPanel";
            this.logAllPanel.Size = new System.Drawing.Size(380, 412);
            this.logAllPanel.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(26, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "数据履历：";
            // 
            // logAllListView
            // 
            this.logAllListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.typeColumnHeader,
            this.timeColumnHeader,
            this.deviceColumnHeader,
            this.dataColumnHeader});
            this.logAllListView.Location = new System.Drawing.Point(15, 37);
            this.logAllListView.Name = "logAllListView";
            this.logAllListView.Size = new System.Drawing.Size(343, 364);
            this.logAllListView.TabIndex = 0;
            this.logAllListView.UseCompatibleStateImageBehavior = false;
            this.logAllListView.View = System.Windows.Forms.View.Details;
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
            this.dataColumnHeader.Width = 177;
            // 
            // onlineListPanel
            // 
            this.onlineListPanel.Controls.Add(this.onlineAllListView);
            this.onlineListPanel.Controls.Add(this.label1);
            this.onlineListPanel.Location = new System.Drawing.Point(0, 3);
            this.onlineListPanel.Name = "onlineListPanel";
            this.onlineListPanel.Size = new System.Drawing.Size(436, 412);
            this.onlineListPanel.TabIndex = 0;
            // 
            // onlineAllListView
            // 
            this.onlineAllListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.deviceTypeColumnHeader,
            this.deviceNameColumnHeader,
            this.deviceCodeColumnHeader,
            this.isVirtColumnHeader});
            this.onlineAllListView.FullRowSelect = true;
            this.onlineAllListView.Location = new System.Drawing.Point(19, 37);
            this.onlineAllListView.Name = "onlineAllListView";
            this.onlineAllListView.Size = new System.Drawing.Size(402, 364);
            this.onlineAllListView.TabIndex = 1;
            this.onlineAllListView.UseCompatibleStateImageBehavior = false;
            this.onlineAllListView.View = System.Windows.Forms.View.Details;
            this.onlineAllListView.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.onlineAllListView_MouseDoubleClick);
            // 
            // deviceTypeColumnHeader
            // 
            this.deviceTypeColumnHeader.Text = "类型";
            // 
            // deviceNameColumnHeader
            // 
            this.deviceNameColumnHeader.Text = "名称";
            // 
            // deviceCodeColumnHeader
            // 
            this.deviceCodeColumnHeader.Text = "代号";
            // 
            // isVirtColumnHeader
            // 
            this.isVirtColumnHeader.Text = "是否虚拟";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "在线仪器：";
            // 
            // deviceTimer
            // 
            this.deviceTimer.Interval = 500;
            this.deviceTimer.Tick += new System.EventHandler(this.deviceTimer_Tick);
            // 
            // logTimer
            // 
            this.logTimer.Interval = 1000;
            this.logTimer.Tick += new System.EventHandler(this.logTimer_Tick);
            // 
            // ControlForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(849, 479);
            this.Controls.Add(this.panel1);
            this.Name = "ControlForm";
            this.Text = "仪器中控程序";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ControlForm_FormClosing);
            this.Load += new System.EventHandler(this.ControlForm_Load);
            this.panel1.ResumeLayout(false);
            this.buttonAllPanel.ResumeLayout(false);
            this.logAllPanel.ResumeLayout(false);
            this.logAllPanel.PerformLayout();
            this.onlineListPanel.ResumeLayout(false);
            this.onlineListPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel onlineListPanel;
        private System.Windows.Forms.Panel logAllPanel;
        private System.Windows.Forms.Panel buttonAllPanel;
        private System.Windows.Forms.Button exitAllButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListView logAllListView;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button searchButton;
        private System.Windows.Forms.ColumnHeader typeColumnHeader;
        private System.Windows.Forms.ColumnHeader timeColumnHeader;
        private System.Windows.Forms.ColumnHeader deviceColumnHeader;
        private System.Windows.Forms.ColumnHeader dataColumnHeader;
        private System.Windows.Forms.ListView onlineAllListView;
        private System.Windows.Forms.ColumnHeader deviceTypeColumnHeader;
        private System.Windows.Forms.ColumnHeader deviceNameColumnHeader;
        private System.Windows.Forms.ColumnHeader deviceCodeColumnHeader;
        private System.Windows.Forms.ColumnHeader isVirtColumnHeader;
        private System.Windows.Forms.Timer deviceTimer;
        private System.Windows.Forms.Timer logTimer;
    }
}

