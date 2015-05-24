namespace CentralControl
{
    partial class MultiTunnelDeviceForm
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
            this.panel3 = new System.Windows.Forms.Panel();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.kongBanTiaoMaTextBox = new System.Windows.Forms.TextBox();
            this.youWuKongBanTextBox = new System.Windows.Forms.TextBox();
            this.dangQianWenDuTextBox = new System.Windows.Forms.TextBox();
            this.boChangFanWeiTextBox = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.zhuangTaiTextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.runButton = new System.Windows.Forms.Button();
            this.jianCeMoShiComboBox = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(603, 485);
            this.panel1.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.dataGridView);
            this.panel3.Controls.Add(this.kongBanTiaoMaTextBox);
            this.panel3.Controls.Add(this.youWuKongBanTextBox);
            this.panel3.Controls.Add(this.dangQianWenDuTextBox);
            this.panel3.Controls.Add(this.boChangFanWeiTextBox);
            this.panel3.Controls.Add(this.label8);
            this.panel3.Controls.Add(this.label7);
            this.panel3.Controls.Add(this.label6);
            this.panel3.Controls.Add(this.label5);
            this.panel3.Controls.Add(this.zhuangTaiTextBox);
            this.panel3.Controls.Add(this.label4);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Location = new System.Drawing.Point(3, 78);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(600, 404);
            this.panel3.TabIndex = 1;
            // 
            // dataGridView
            // 
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridView.Location = new System.Drawing.Point(12, 147);
            this.dataGridView.MultiSelect = false;
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.RowHeadersWidth = 30;
            this.dataGridView.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dataGridView.RowTemplate.Height = 23;
            this.dataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dataGridView.Size = new System.Drawing.Size(575, 244);
            this.dataGridView.TabIndex = 21;
            // 
            // kongBanTiaoMaTextBox
            // 
            this.kongBanTiaoMaTextBox.Location = new System.Drawing.Point(399, 117);
            this.kongBanTiaoMaTextBox.Name = "kongBanTiaoMaTextBox";
            this.kongBanTiaoMaTextBox.Size = new System.Drawing.Size(100, 21);
            this.kongBanTiaoMaTextBox.TabIndex = 10;
            // 
            // youWuKongBanTextBox
            // 
            this.youWuKongBanTextBox.Location = new System.Drawing.Point(399, 90);
            this.youWuKongBanTextBox.Name = "youWuKongBanTextBox";
            this.youWuKongBanTextBox.Size = new System.Drawing.Size(100, 21);
            this.youWuKongBanTextBox.TabIndex = 9;
            // 
            // dangQianWenDuTextBox
            // 
            this.dangQianWenDuTextBox.Location = new System.Drawing.Point(154, 117);
            this.dangQianWenDuTextBox.Name = "dangQianWenDuTextBox";
            this.dangQianWenDuTextBox.Size = new System.Drawing.Size(100, 21);
            this.dangQianWenDuTextBox.TabIndex = 8;
            // 
            // boChangFanWeiTextBox
            // 
            this.boChangFanWeiTextBox.Location = new System.Drawing.Point(154, 90);
            this.boChangFanWeiTextBox.Name = "boChangFanWeiTextBox";
            this.boChangFanWeiTextBox.Size = new System.Drawing.Size(100, 21);
            this.boChangFanWeiTextBox.TabIndex = 7;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(296, 121);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(65, 12);
            this.label8.TabIndex = 6;
            this.label8.Text = "孔板条码：";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(58, 122);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 12);
            this.label7.TabIndex = 5;
            this.label7.Text = "当前温度：";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(296, 94);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(77, 12);
            this.label6.TabIndex = 4;
            this.label6.Text = "有无放孔板：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(58, 94);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 12);
            this.label5.TabIndex = 3;
            this.label5.Text = "波长范围：";
            // 
            // zhuangTaiTextBox
            // 
            this.zhuangTaiTextBox.Location = new System.Drawing.Point(154, 53);
            this.zhuangTaiTextBox.Name = "zhuangTaiTextBox";
            this.zhuangTaiTextBox.Size = new System.Drawing.Size(100, 21);
            this.zhuangTaiTextBox.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(58, 57);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(89, 12);
            this.label4.TabIndex = 1;
            this.label4.Text = "运行出错标志：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(29, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 12);
            this.label3.TabIndex = 0;
            this.label3.Text = "检测结果显示：";
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.runButton);
            this.panel2.Controls.Add(this.jianCeMoShiComboBox);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(600, 72);
            this.panel2.TabIndex = 0;
            this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
            // 
            // runButton
            // 
            this.runButton.Location = new System.Drawing.Point(284, 32);
            this.runButton.Name = "runButton";
            this.runButton.Size = new System.Drawing.Size(75, 23);
            this.runButton.TabIndex = 3;
            this.runButton.Text = "运行";
            this.runButton.UseVisualStyleBackColor = true;
            this.runButton.Click += new System.EventHandler(this.runButton_Click);
            // 
            // jianCeMoShiComboBox
            // 
            this.jianCeMoShiComboBox.FormattingEnabled = true;
            this.jianCeMoShiComboBox.Items.AddRange(new object[] {
            "OD",
            "荧光",
            "化学发光"});
            this.jianCeMoShiComboBox.Location = new System.Drawing.Point(127, 34);
            this.jianCeMoShiComboBox.Name = "jianCeMoShiComboBox";
            this.jianCeMoShiComboBox.Size = new System.Drawing.Size(121, 20);
            this.jianCeMoShiComboBox.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(56, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "检测模式：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "设定：";
            // 
            // timer1
            // 
            this.timer1.Interval = 5000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // MultiTunnelDeviceForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(627, 509);
            this.Controls.Add(this.panel1);
            this.Name = "MultiTunnelDeviceForm";
            this.Text = "多通道高速代谢性能分析仪";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MultiTunnelDeviceForm_FormClosing);
            this.Load += new System.EventHandler(this.MultiTunnelDeviceForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox jianCeMoShiComboBox;
        private System.Windows.Forms.Button runButton;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox zhuangTaiTextBox;
        private System.Windows.Forms.TextBox kongBanTiaoMaTextBox;
        private System.Windows.Forms.TextBox youWuKongBanTextBox;
        private System.Windows.Forms.TextBox dangQianWenDuTextBox;
        private System.Windows.Forms.TextBox boChangFanWeiTextBox;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.Timer timer1;
    }
}