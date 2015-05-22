namespace DeviceDemo
{
    partial class DeviceDemo
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
            this.BaseInfo = new System.Windows.Forms.Panel();
            this.Runbutton = new System.Windows.Forms.Button();
            this.CCIPtextBox = new System.Windows.Forms.TextBox();
            this.serielIDtextBox = new System.Windows.Forms.TextBox();
            this.IdentifyIDtextBox = new System.Windows.Forms.TextBox();
            this.DeviceNametextBox = new System.Windows.Forms.TextBox();
            this.DeviceCodetextBox = new System.Windows.Forms.TextBox();
            this.DeviceIPtestBox = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.DataInfo = new System.Windows.Forms.Panel();
            this.DishtextBox = new System.Windows.Forms.TextBox();
            this.StacktextBox = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.Current2textBox = new System.Windows.Forms.TextBox();
            this.Current1textBox = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.MessageTextBox = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.Current4textBox = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.Current3textBox = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.Sendbutton = new System.Windows.Forms.Button();
            this.label13 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.BaseInfo.SuspendLayout();
            this.DataInfo.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // BaseInfo
            // 
            this.BaseInfo.Controls.Add(this.Runbutton);
            this.BaseInfo.Controls.Add(this.CCIPtextBox);
            this.BaseInfo.Controls.Add(this.serielIDtextBox);
            this.BaseInfo.Controls.Add(this.IdentifyIDtextBox);
            this.BaseInfo.Controls.Add(this.DeviceNametextBox);
            this.BaseInfo.Controls.Add(this.DeviceCodetextBox);
            this.BaseInfo.Controls.Add(this.DeviceIPtestBox);
            this.BaseInfo.Controls.Add(this.label8);
            this.BaseInfo.Controls.Add(this.label6);
            this.BaseInfo.Controls.Add(this.label5);
            this.BaseInfo.Controls.Add(this.label4);
            this.BaseInfo.Controls.Add(this.label3);
            this.BaseInfo.Controls.Add(this.label2);
            this.BaseInfo.Controls.Add(this.label1);
            this.BaseInfo.Location = new System.Drawing.Point(12, 12);
            this.BaseInfo.Name = "BaseInfo";
            this.BaseInfo.Size = new System.Drawing.Size(564, 158);
            this.BaseInfo.TabIndex = 0;
            // 
            // Runbutton
            // 
            this.Runbutton.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Runbutton.Location = new System.Drawing.Point(477, 50);
            this.Runbutton.Name = "Runbutton";
            this.Runbutton.Size = new System.Drawing.Size(75, 72);
            this.Runbutton.TabIndex = 14;
            this.Runbutton.Text = "运行";
            this.Runbutton.UseVisualStyleBackColor = true;
            this.Runbutton.Click += new System.EventHandler(this.Runbutton_Click);
            // 
            // CCIPtextBox
            // 
            this.CCIPtextBox.Location = new System.Drawing.Point(306, 41);
            this.CCIPtextBox.Name = "CCIPtextBox";
            this.CCIPtextBox.Size = new System.Drawing.Size(155, 21);
            this.CCIPtextBox.TabIndex = 13;
            // 
            // serielIDtextBox
            // 
            this.serielIDtextBox.Location = new System.Drawing.Point(306, 111);
            this.serielIDtextBox.Name = "serielIDtextBox";
            this.serielIDtextBox.Size = new System.Drawing.Size(155, 21);
            this.serielIDtextBox.TabIndex = 12;
            // 
            // IdentifyIDtextBox
            // 
            this.IdentifyIDtextBox.Location = new System.Drawing.Point(306, 77);
            this.IdentifyIDtextBox.Name = "IdentifyIDtextBox";
            this.IdentifyIDtextBox.Size = new System.Drawing.Size(155, 21);
            this.IdentifyIDtextBox.TabIndex = 11;
            // 
            // DeviceNametextBox
            // 
            this.DeviceNametextBox.Location = new System.Drawing.Point(74, 77);
            this.DeviceNametextBox.Name = "DeviceNametextBox";
            this.DeviceNametextBox.Size = new System.Drawing.Size(155, 21);
            this.DeviceNametextBox.TabIndex = 10;
            // 
            // DeviceCodetextBox
            // 
            this.DeviceCodetextBox.Location = new System.Drawing.Point(74, 114);
            this.DeviceCodetextBox.Name = "DeviceCodetextBox";
            this.DeviceCodetextBox.ReadOnly = true;
            this.DeviceCodetextBox.Size = new System.Drawing.Size(155, 21);
            this.DeviceCodetextBox.TabIndex = 9;
            // 
            // DeviceIPtestBox
            // 
            this.DeviceIPtestBox.Location = new System.Drawing.Point(74, 41);
            this.DeviceIPtestBox.Name = "DeviceIPtestBox";
            this.DeviceIPtestBox.Size = new System.Drawing.Size(155, 21);
            this.DeviceIPtestBox.TabIndex = 8;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("微软雅黑", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label8.Location = new System.Drawing.Point(249, 112);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(51, 20);
            this.label8.TabIndex = 7;
            this.label8.Text = "序列号";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("微软雅黑", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.Location = new System.Drawing.Point(249, 78);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(51, 20);
            this.label6.TabIndex = 5;
            this.label6.Text = "识别码";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("微软雅黑", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(27, 112);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(37, 20);
            this.label5.TabIndex = 4;
            this.label5.Text = "代码";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("微软雅黑", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(236, 42);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 20);
            this.label4.TabIndex = 3;
            this.label4.Text = "上位机IP";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(27, 75);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "名称";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(42, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(22, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "IP";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(13, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "设备信息";
            // 
            // DataInfo
            // 
            this.DataInfo.Controls.Add(this.DishtextBox);
            this.DataInfo.Controls.Add(this.StacktextBox);
            this.DataInfo.Controls.Add(this.label10);
            this.DataInfo.Controls.Add(this.label9);
            this.DataInfo.Controls.Add(this.label7);
            this.DataInfo.Location = new System.Drawing.Point(13, 176);
            this.DataInfo.Name = "DataInfo";
            this.DataInfo.Size = new System.Drawing.Size(244, 144);
            this.DataInfo.TabIndex = 1;
            // 
            // DishtextBox
            // 
            this.DishtextBox.Location = new System.Drawing.Point(82, 95);
            this.DishtextBox.Name = "DishtextBox";
            this.DishtextBox.Size = new System.Drawing.Size(155, 21);
            this.DishtextBox.TabIndex = 16;
            // 
            // StacktextBox
            // 
            this.StacktextBox.Location = new System.Drawing.Point(82, 52);
            this.StacktextBox.Name = "StacktextBox";
            this.StacktextBox.Size = new System.Drawing.Size(155, 21);
            this.StacktextBox.TabIndex = 15;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label10.Location = new System.Drawing.Point(14, 11);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(106, 21);
            this.label10.TabIndex = 9;
            this.label10.Text = "仪器设置信息";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("微软雅黑", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label9.Location = new System.Drawing.Point(1, 93);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(79, 20);
            this.label9.TabIndex = 8;
            this.label9.Text = "单孔分装量";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("微软雅黑", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.Location = new System.Drawing.Point(2, 53);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(79, 20);
            this.label7.TabIndex = 6;
            this.label7.Text = "堆栈孔板数";
            // 
            // Current2textBox
            // 
            this.Current2textBox.Location = new System.Drawing.Point(73, 66);
            this.Current2textBox.Name = "Current2textBox";
            this.Current2textBox.Size = new System.Drawing.Size(155, 21);
            this.Current2textBox.TabIndex = 14;
            // 
            // Current1textBox
            // 
            this.Current1textBox.Location = new System.Drawing.Point(73, 39);
            this.Current1textBox.Name = "Current1textBox";
            this.Current1textBox.Size = new System.Drawing.Size(155, 21);
            this.Current1textBox.TabIndex = 13;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("微软雅黑", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label12.Location = new System.Drawing.Point(22, 64);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(45, 20);
            this.label12.TabIndex = 11;
            this.label12.Text = "电流2";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("微软雅黑", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label11.Location = new System.Drawing.Point(22, 37);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(45, 20);
            this.label11.TabIndex = 10;
            this.label11.Text = "电流1";
            // 
            // MessageTextBox
            // 
            this.MessageTextBox.Location = new System.Drawing.Point(12, 326);
            this.MessageTextBox.Multiline = true;
            this.MessageTextBox.Name = "MessageTextBox";
            this.MessageTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.MessageTextBox.Size = new System.Drawing.Size(564, 128);
            this.MessageTextBox.TabIndex = 2;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.Current4textBox);
            this.panel1.Controls.Add(this.label15);
            this.panel1.Controls.Add(this.Current3textBox);
            this.panel1.Controls.Add(this.label14);
            this.panel1.Controls.Add(this.Sendbutton);
            this.panel1.Controls.Add(this.label13);
            this.panel1.Controls.Add(this.Current1textBox);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.Current2textBox);
            this.panel1.Controls.Add(this.label12);
            this.panel1.Location = new System.Drawing.Point(265, 176);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(311, 144);
            this.panel1.TabIndex = 3;
            // 
            // Current4textBox
            // 
            this.Current4textBox.Location = new System.Drawing.Point(73, 120);
            this.Current4textBox.Name = "Current4textBox";
            this.Current4textBox.Size = new System.Drawing.Size(155, 21);
            this.Current4textBox.TabIndex = 20;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("微软雅黑", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label15.Location = new System.Drawing.Point(22, 118);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(45, 20);
            this.label15.TabIndex = 19;
            this.label15.Text = "电流4";
            // 
            // Current3textBox
            // 
            this.Current3textBox.Location = new System.Drawing.Point(73, 93);
            this.Current3textBox.Name = "Current3textBox";
            this.Current3textBox.Size = new System.Drawing.Size(155, 21);
            this.Current3textBox.TabIndex = 18;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("微软雅黑", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label14.Location = new System.Drawing.Point(22, 91);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(45, 20);
            this.label14.TabIndex = 17;
            this.label14.Text = "电流3";
            // 
            // Sendbutton
            // 
            this.Sendbutton.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Sendbutton.Location = new System.Drawing.Point(234, 42);
            this.Sendbutton.Name = "Sendbutton";
            this.Sendbutton.Size = new System.Drawing.Size(65, 96);
            this.Sendbutton.TabIndex = 16;
            this.Sendbutton.Text = "发送";
            this.Sendbutton.UseVisualStyleBackColor = true;
            this.Sendbutton.Click += new System.EventHandler(this.Sendbutton_Click);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label13.Location = new System.Drawing.Point(22, 11);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(106, 21);
            this.label13.TabIndex = 15;
            this.label13.Text = "仪器数据信息";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // timer2
            // 
            this.timer2.Enabled = true;
            this.timer2.Interval = 1000;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // DeviceDemo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(590, 471);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.MessageTextBox);
            this.Controls.Add(this.DataInfo);
            this.Controls.Add(this.BaseInfo);
            this.Name = "DeviceDemo";
            this.Text = "DeviceDemo";
            this.BaseInfo.ResumeLayout(false);
            this.BaseInfo.PerformLayout();
            this.DataInfo.ResumeLayout(false);
            this.DataInfo.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel BaseInfo;
        private System.Windows.Forms.Panel DataInfo;
        private System.Windows.Forms.TextBox MessageTextBox;
        private System.Windows.Forms.TextBox CCIPtextBox;
        private System.Windows.Forms.TextBox serielIDtextBox;
        private System.Windows.Forms.TextBox IdentifyIDtextBox;
        private System.Windows.Forms.TextBox DeviceNametextBox;
        private System.Windows.Forms.TextBox DeviceCodetextBox;
        private System.Windows.Forms.TextBox DeviceIPtestBox;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox DishtextBox;
        private System.Windows.Forms.TextBox StacktextBox;
        private System.Windows.Forms.TextBox Current2textBox;
        private System.Windows.Forms.TextBox Current1textBox;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button Runbutton;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button Sendbutton;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox Current3textBox;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.TextBox Current4textBox;
        private System.Windows.Forms.Label label15;
    }
}

