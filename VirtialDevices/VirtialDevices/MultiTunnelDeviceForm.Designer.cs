namespace VirtialDevices
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.shengChengButton = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.setButton = new System.Windows.Forms.Button();
            this.upperTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.stateComboBox = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lowerTextBox = new System.Windows.Forms.TextBox();
            this.dealTImeTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.codeTextBox = new System.Windows.Forms.TextBox();
            this.currentTmpTextBox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.placeFlagComboBox = new System.Windows.Forms.ComboBox();
            this.daoRuButton = new System.Windows.Forms.Button();
            this.detectModelComboBox = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.shuJuOpenFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dataGridView);
            this.panel1.Controls.Add(this.shengChengButton);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.daoRuButton);
            this.panel1.Controls.Add(this.detectModelComboBox);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(602, 480);
            this.panel1.TabIndex = 0;
            // 
            // dataGridView
            // 
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridView.Location = new System.Drawing.Point(14, 214);
            this.dataGridView.MultiSelect = false;
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.RowHeadersWidth = 30;
            this.dataGridView.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dataGridView.RowTemplate.Height = 23;
            this.dataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dataGridView.Size = new System.Drawing.Size(575, 244);
            this.dataGridView.TabIndex = 20;
            this.dataGridView.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_CellEndEdit);
            this.dataGridView.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.dataGridView_CellValidating);
            // 
            // shengChengButton
            // 
            this.shengChengButton.Location = new System.Drawing.Point(342, 185);
            this.shengChengButton.Name = "shengChengButton";
            this.shengChengButton.Size = new System.Drawing.Size(75, 23);
            this.shengChengButton.TabIndex = 19;
            this.shengChengButton.Text = "生成";
            this.shengChengButton.UseVisualStyleBackColor = true;
            this.shengChengButton.Click += new System.EventHandler(this.shengChengButton_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.setButton);
            this.groupBox1.Controls.Add(this.upperTextBox);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.stateComboBox);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.lowerTextBox);
            this.groupBox1.Controls.Add(this.dealTImeTextBox);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.codeTextBox);
            this.groupBox1.Controls.Add(this.currentTmpTextBox);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.placeFlagComboBox);
            this.groupBox1.Location = new System.Drawing.Point(14, 8);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(575, 171);
            this.groupBox1.TabIndex = 18;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "设置";
            // 
            // setButton
            // 
            this.setButton.Location = new System.Drawing.Point(415, 135);
            this.setButton.Name = "setButton";
            this.setButton.Size = new System.Drawing.Size(75, 23);
            this.setButton.TabIndex = 14;
            this.setButton.Text = "设定";
            this.setButton.UseVisualStyleBackColor = true;
            this.setButton.Click += new System.EventHandler(this.setButton_Click);
            // 
            // upperTextBox
            // 
            this.upperTextBox.Location = new System.Drawing.Point(214, 65);
            this.upperTextBox.Name = "upperTextBox";
            this.upperTextBox.Size = new System.Drawing.Size(84, 21);
            this.upperTextBox.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "运行出错标志:";
            // 
            // stateComboBox
            // 
            this.stateComboBox.FormattingEnabled = true;
            this.stateComboBox.Items.AddRange(new object[] {
            "正常",
            "出错"});
            this.stateComboBox.Location = new System.Drawing.Point(101, 29);
            this.stateComboBox.Name = "stateComboBox";
            this.stateComboBox.Size = new System.Drawing.Size(100, 20);
            this.stateComboBox.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "波长范围:";
            // 
            // lowerTextBox
            // 
            this.lowerTextBox.Location = new System.Drawing.Point(101, 65);
            this.lowerTextBox.Name = "lowerTextBox";
            this.lowerTextBox.Size = new System.Drawing.Size(84, 21);
            this.lowerTextBox.TabIndex = 3;
            // 
            // dealTImeTextBox
            // 
            this.dealTImeTextBox.Location = new System.Drawing.Point(416, 104);
            this.dealTImeTextBox.Name = "dealTImeTextBox";
            this.dealTImeTextBox.Size = new System.Drawing.Size(100, 21);
            this.dealTImeTextBox.TabIndex = 13;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 107);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "当前温度:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(333, 107);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(77, 12);
            this.label7.TabIndex = 12;
            this.label7.Text = "处理时间(S);";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(191, 68);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(17, 12);
            this.label4.TabIndex = 5;
            this.label4.Text = "至";
            // 
            // codeTextBox
            // 
            this.codeTextBox.Location = new System.Drawing.Point(416, 65);
            this.codeTextBox.Name = "codeTextBox";
            this.codeTextBox.Size = new System.Drawing.Size(140, 21);
            this.codeTextBox.TabIndex = 11;
            // 
            // currentTmpTextBox
            // 
            this.currentTmpTextBox.Location = new System.Drawing.Point(101, 107);
            this.currentTmpTextBox.Name = "currentTmpTextBox";
            this.currentTmpTextBox.Size = new System.Drawing.Size(100, 21);
            this.currentTmpTextBox.TabIndex = 7;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(333, 68);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(59, 12);
            this.label6.TabIndex = 10;
            this.label6.Text = "孔板条码:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(333, 32);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(71, 12);
            this.label5.TabIndex = 8;
            this.label5.Text = "是否放孔板:";
            // 
            // placeFlagComboBox
            // 
            this.placeFlagComboBox.FormattingEnabled = true;
            this.placeFlagComboBox.Items.AddRange(new object[] {
            "是",
            "否"});
            this.placeFlagComboBox.Location = new System.Drawing.Point(416, 29);
            this.placeFlagComboBox.Name = "placeFlagComboBox";
            this.placeFlagComboBox.Size = new System.Drawing.Size(72, 20);
            this.placeFlagComboBox.TabIndex = 9;
            // 
            // daoRuButton
            // 
            this.daoRuButton.Location = new System.Drawing.Point(429, 185);
            this.daoRuButton.Name = "daoRuButton";
            this.daoRuButton.Size = new System.Drawing.Size(75, 23);
            this.daoRuButton.TabIndex = 17;
            this.daoRuButton.Text = "导入";
            this.daoRuButton.UseVisualStyleBackColor = true;
            this.daoRuButton.Click += new System.EventHandler(this.daoRuButton_Click);
            // 
            // detectModelComboBox
            // 
            this.detectModelComboBox.FormattingEnabled = true;
            this.detectModelComboBox.Items.AddRange(new object[] {
            "OD",
            "荧光",
            "化学发光"});
            this.detectModelComboBox.Location = new System.Drawing.Point(114, 187);
            this.detectModelComboBox.Name = "detectModelComboBox";
            this.detectModelComboBox.Size = new System.Drawing.Size(121, 20);
            this.detectModelComboBox.TabIndex = 15;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(44, 190);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(59, 12);
            this.label8.TabIndex = 14;
            this.label8.Text = "检测模式:";
            // 
            // shuJuOpenFileDialog
            // 
            this.shuJuOpenFileDialog.FileName = "openFileDialog1";
            // 
            // MultiTunnelDeviceForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(626, 504);
            this.Controls.Add(this.panel1);
            this.Name = "MultiTunnelDeviceForm";
            this.Text = "多通道高速代谢性能分析仪";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MultiTunnelDeviceForm_FormClosing);
            this.Load += new System.EventHandler(this.MultiTunnelDeviceForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox stateComboBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox lowerTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox upperTextBox;
        private System.Windows.Forms.TextBox currentTmpTextBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox placeFlagComboBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox codeTextBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox dealTImeTextBox;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox detectModelComboBox;
        private System.Windows.Forms.Button daoRuButton;
        private System.Windows.Forms.OpenFileDialog shuJuOpenFileDialog;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button setButton;
        private System.Windows.Forms.Button shengChengButton;
        private System.Windows.Forms.DataGridView dataGridView;
    }
}