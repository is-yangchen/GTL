namespace VirtialDevices
{
    partial class DuoTongDaoShuJuShengChengForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.zengLiangTextBox = new System.Windows.Forms.TextBox();
            this.shengChengButton = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.cunChuButton = new System.Windows.Forms.Button();
            this.luJingLabel = new System.Windows.Forms.Label();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.label4 = new System.Windows.Forms.Label();
            this.qiShiZhiTextBox = new System.Windows.Forms.TextBox();
            this.fanHuiButton = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.fanHuiButton);
            this.panel1.Controls.Add(this.qiShiZhiTextBox);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.luJingLabel);
            this.panel1.Controls.Add(this.cunChuButton);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.shengChengButton);
            this.panel1.Controls.Add(this.zengLiangTextBox);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.comboBox1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(499, 213);
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "数据模型：";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "固定值",
            "递增"});
            this.comboBox1.Location = new System.Drawing.Point(99, 20);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 20);
            this.comboBox1.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(27, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "递增量：";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // zengLiangTextBox
            // 
            this.zengLiangTextBox.Location = new System.Drawing.Point(99, 53);
            this.zengLiangTextBox.Name = "zengLiangTextBox";
            this.zengLiangTextBox.Size = new System.Drawing.Size(121, 21);
            this.zengLiangTextBox.TabIndex = 3;
            // 
            // shengChengButton
            // 
            this.shengChengButton.Location = new System.Drawing.Point(33, 157);
            this.shengChengButton.Name = "shengChengButton";
            this.shengChengButton.Size = new System.Drawing.Size(75, 23);
            this.shengChengButton.TabIndex = 4;
            this.shengChengButton.Text = "生成";
            this.shengChengButton.UseVisualStyleBackColor = true;
            this.shengChengButton.Click += new System.EventHandler(this.shengChengButton_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(29, 91);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 5;
            this.label3.Text = "存储文件：";
            // 
            // cunChuButton
            // 
            this.cunChuButton.Location = new System.Drawing.Point(103, 85);
            this.cunChuButton.Name = "cunChuButton";
            this.cunChuButton.Size = new System.Drawing.Size(75, 23);
            this.cunChuButton.TabIndex = 6;
            this.cunChuButton.Text = "选择路径";
            this.cunChuButton.UseVisualStyleBackColor = true;
            this.cunChuButton.Click += new System.EventHandler(this.cunChuButton_Click);
            // 
            // luJingLabel
            // 
            this.luJingLabel.AutoSize = true;
            this.luJingLabel.Location = new System.Drawing.Point(31, 118);
            this.luJingLabel.Name = "luJingLabel";
            this.luJingLabel.Size = new System.Drawing.Size(0, 12);
            this.luJingLabel.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(271, 24);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 8;
            this.label4.Text = "起始值：";
            // 
            // qiShiZhiTextBox
            // 
            this.qiShiZhiTextBox.Location = new System.Drawing.Point(330, 20);
            this.qiShiZhiTextBox.Name = "qiShiZhiTextBox";
            this.qiShiZhiTextBox.Size = new System.Drawing.Size(112, 21);
            this.qiShiZhiTextBox.TabIndex = 9;
            // 
            // fanHuiButton
            // 
            this.fanHuiButton.Location = new System.Drawing.Point(381, 157);
            this.fanHuiButton.Name = "fanHuiButton";
            this.fanHuiButton.Size = new System.Drawing.Size(75, 23);
            this.fanHuiButton.TabIndex = 10;
            this.fanHuiButton.Text = "返回";
            this.fanHuiButton.UseVisualStyleBackColor = true;
            this.fanHuiButton.Click += new System.EventHandler(this.fanHuiButton_Click);
            // 
            // DuoTongDaoShuJuShengChengForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(523, 237);
            this.Controls.Add(this.panel1);
            this.Name = "DuoTongDaoShuJuShengChengForm";
            this.Text = "多通道高速代谢性能分析仪数据生成";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.DuoTongDaoShuJuShengChengForm_FormClosing);
            this.Load += new System.EventHandler(this.DuoTongDaoShuJuShengChengForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox zengLiangTextBox;
        private System.Windows.Forms.Button shengChengButton;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button cunChuButton;
        private System.Windows.Forms.Label luJingLabel;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox qiShiZhiTextBox;
        private System.Windows.Forms.Button fanHuiButton;
    }
}