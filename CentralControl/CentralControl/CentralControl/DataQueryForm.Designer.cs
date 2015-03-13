namespace CentralControl
{
    partial class DataQueryForm
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
            this.exitButton = new System.Windows.Forms.Button();
            this.resultPanel = new System.Windows.Forms.Panel();
            this.searchResultListView = new System.Windows.Forms.ListView();
            this.label3 = new System.Windows.Forms.Label();
            this.conditionPanel = new System.Windows.Forms.Panel();
            this.searchDataButton = new System.Windows.Forms.Button();
            this.concreteConPanel = new System.Windows.Forms.Panel();
            this.delConButton = new System.Windows.Forms.Button();
            this.conNameTextBox = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.saveButton = new System.Windows.Forms.Button();
            this.clearButton = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.addButton = new System.Windows.Forms.Button();
            this.opValueTextBox = new System.Windows.Forms.TextBox();
            this.operationTypeComboBox = new System.Windows.Forms.ComboBox();
            this.savedConComboBox = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.segmentComboBox = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.logicTypeComboBox = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.dataTableComboBox = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.deviceTypeComboBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.panel1.SuspendLayout();
            this.buttonPanel.SuspendLayout();
            this.resultPanel.SuspendLayout();
            this.conditionPanel.SuspendLayout();
            this.concreteConPanel.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.buttonPanel);
            this.panel1.Controls.Add(this.resultPanel);
            this.panel1.Controls.Add(this.conditionPanel);
            this.panel1.Location = new System.Drawing.Point(12, 13);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(707, 599);
            this.panel1.TabIndex = 0;
            // 
            // buttonPanel
            // 
            this.buttonPanel.Controls.Add(this.exitButton);
            this.buttonPanel.Location = new System.Drawing.Point(3, 558);
            this.buttonPanel.Name = "buttonPanel";
            this.buttonPanel.Size = new System.Drawing.Size(701, 38);
            this.buttonPanel.TabIndex = 2;
            // 
            // exitButton
            // 
            this.exitButton.Location = new System.Drawing.Point(609, 3);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(75, 25);
            this.exitButton.TabIndex = 0;
            this.exitButton.Text = "退出";
            this.exitButton.UseVisualStyleBackColor = true;
            this.exitButton.Click += new System.EventHandler(this.exitButton_Click);
            // 
            // resultPanel
            // 
            this.resultPanel.Controls.Add(this.searchResultListView);
            this.resultPanel.Controls.Add(this.label3);
            this.resultPanel.Location = new System.Drawing.Point(3, 316);
            this.resultPanel.Name = "resultPanel";
            this.resultPanel.Size = new System.Drawing.Size(701, 235);
            this.resultPanel.TabIndex = 1;
            // 
            // searchResultListView
            // 
            this.searchResultListView.GridLines = true;
            this.searchResultListView.Location = new System.Drawing.Point(12, 30);
            this.searchResultListView.Name = "searchResultListView";
            this.searchResultListView.ShowItemToolTips = true;
            this.searchResultListView.Size = new System.Drawing.Size(672, 201);
            this.searchResultListView.TabIndex = 1;
            this.searchResultListView.UseCompatibleStateImageBehavior = false;
            this.searchResultListView.View = System.Windows.Forms.View.Details;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(52, 14);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "检索结果：";
            // 
            // conditionPanel
            // 
            this.conditionPanel.Controls.Add(this.groupBox1);
            this.conditionPanel.Controls.Add(this.searchDataButton);
            this.conditionPanel.Controls.Add(this.deviceTypeComboBox);
            this.conditionPanel.Controls.Add(this.label1);
            this.conditionPanel.Location = new System.Drawing.Point(3, 3);
            this.conditionPanel.Name = "conditionPanel";
            this.conditionPanel.Size = new System.Drawing.Size(701, 307);
            this.conditionPanel.TabIndex = 0;
            // 
            // searchDataButton
            // 
            this.searchDataButton.Location = new System.Drawing.Point(521, 9);
            this.searchDataButton.Name = "searchDataButton";
            this.searchDataButton.Size = new System.Drawing.Size(75, 25);
            this.searchDataButton.TabIndex = 4;
            this.searchDataButton.Text = "检索";
            this.searchDataButton.UseVisualStyleBackColor = true;
            this.searchDataButton.Click += new System.EventHandler(this.searchDataButton_Click);
            // 
            // concreteConPanel
            // 
            this.concreteConPanel.Controls.Add(this.delConButton);
            this.concreteConPanel.Controls.Add(this.conNameTextBox);
            this.concreteConPanel.Controls.Add(this.label8);
            this.concreteConPanel.Controls.Add(this.saveButton);
            this.concreteConPanel.Controls.Add(this.clearButton);
            this.concreteConPanel.Controls.Add(this.textBox1);
            this.concreteConPanel.Controls.Add(this.addButton);
            this.concreteConPanel.Controls.Add(this.opValueTextBox);
            this.concreteConPanel.Controls.Add(this.operationTypeComboBox);
            this.concreteConPanel.Controls.Add(this.savedConComboBox);
            this.concreteConPanel.Controls.Add(this.label7);
            this.concreteConPanel.Controls.Add(this.segmentComboBox);
            this.concreteConPanel.Controls.Add(this.label6);
            this.concreteConPanel.Controls.Add(this.logicTypeComboBox);
            this.concreteConPanel.Controls.Add(this.label5);
            this.concreteConPanel.Controls.Add(this.dataTableComboBox);
            this.concreteConPanel.Controls.Add(this.label4);
            this.concreteConPanel.Location = new System.Drawing.Point(11, 19);
            this.concreteConPanel.Name = "concreteConPanel";
            this.concreteConPanel.Size = new System.Drawing.Size(666, 227);
            this.concreteConPanel.TabIndex = 3;
            // 
            // delConButton
            // 
            this.delConButton.Location = new System.Drawing.Point(430, 182);
            this.delConButton.Name = "delConButton";
            this.delConButton.Size = new System.Drawing.Size(75, 25);
            this.delConButton.TabIndex = 16;
            this.delConButton.Text = "删除";
            this.delConButton.UseVisualStyleBackColor = true;
            // 
            // conNameTextBox
            // 
            this.conNameTextBox.Location = new System.Drawing.Point(80, 184);
            this.conNameTextBox.Name = "conNameTextBox";
            this.conNameTextBox.Size = new System.Drawing.Size(244, 20);
            this.conNameTextBox.TabIndex = 15;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(20, 190);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(67, 13);
            this.label8.TabIndex = 14;
            this.label8.Text = "条件名称：";
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(340, 182);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(75, 25);
            this.saveButton.TabIndex = 13;
            this.saveButton.Text = "保存";
            this.saveButton.UseVisualStyleBackColor = true;
            // 
            // clearButton
            // 
            this.clearButton.Location = new System.Drawing.Point(551, 127);
            this.clearButton.Name = "clearButton";
            this.clearButton.Size = new System.Drawing.Size(75, 25);
            this.clearButton.TabIndex = 12;
            this.clearButton.Text = "清空";
            this.clearButton.UseVisualStyleBackColor = true;
            this.clearButton.Click += new System.EventHandler(this.clearButton_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(22, 106);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(523, 71);
            this.textBox1.TabIndex = 11;
            // 
            // addButton
            // 
            this.addButton.Location = new System.Drawing.Point(509, 72);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(75, 25);
            this.addButton.TabIndex = 10;
            this.addButton.Text = "增加";
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // opValueTextBox
            // 
            this.opValueTextBox.Location = new System.Drawing.Point(385, 74);
            this.opValueTextBox.Name = "opValueTextBox";
            this.opValueTextBox.Size = new System.Drawing.Size(100, 20);
            this.opValueTextBox.TabIndex = 9;
            // 
            // operationTypeComboBox
            // 
            this.operationTypeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.operationTypeComboBox.FormattingEnabled = true;
            this.operationTypeComboBox.Location = new System.Drawing.Point(244, 75);
            this.operationTypeComboBox.Name = "operationTypeComboBox";
            this.operationTypeComboBox.Size = new System.Drawing.Size(121, 21);
            this.operationTypeComboBox.TabIndex = 8;
            // 
            // savedConComboBox
            // 
            this.savedConComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.savedConComboBox.FormattingEnabled = true;
            this.savedConComboBox.Location = new System.Drawing.Point(445, 15);
            this.savedConComboBox.Name = "savedConComboBox";
            this.savedConComboBox.Size = new System.Drawing.Size(121, 21);
            this.savedConComboBox.TabIndex = 7;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(338, 18);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(103, 13);
            this.label7.TabIndex = 6;
            this.label7.Text = "选择已保存条件：";
            // 
            // segmentComboBox
            // 
            this.segmentComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.segmentComboBox.FormattingEnabled = true;
            this.segmentComboBox.Location = new System.Drawing.Point(99, 75);
            this.segmentComboBox.Name = "segmentComboBox";
            this.segmentComboBox.Size = new System.Drawing.Size(121, 21);
            this.segmentComboBox.TabIndex = 5;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(40, 78);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(43, 13);
            this.label6.TabIndex = 4;
            this.label6.Text = "字段：";
            // 
            // logicTypeComboBox
            // 
            this.logicTypeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.logicTypeComboBox.FormattingEnabled = true;
            this.logicTypeComboBox.Location = new System.Drawing.Point(99, 40);
            this.logicTypeComboBox.Name = "logicTypeComboBox";
            this.logicTypeComboBox.Size = new System.Drawing.Size(121, 21);
            this.logicTypeComboBox.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(40, 43);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(43, 13);
            this.label5.TabIndex = 2;
            this.label5.Text = "逻辑：";
            // 
            // dataTableComboBox
            // 
            this.dataTableComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.dataTableComboBox.FormattingEnabled = true;
            this.dataTableComboBox.Location = new System.Drawing.Point(99, 7);
            this.dataTableComboBox.Name = "dataTableComboBox";
            this.dataTableComboBox.Size = new System.Drawing.Size(121, 21);
            this.dataTableComboBox.TabIndex = 1;
            this.dataTableComboBox.SelectedIndexChanged += new System.EventHandler(this.dataTableComboBox_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(40, 10);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "数据表：";
            // 
            // deviceTypeComboBox
            // 
            this.deviceTypeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.deviceTypeComboBox.FormattingEnabled = true;
            this.deviceTypeComboBox.Location = new System.Drawing.Point(121, 11);
            this.deviceTypeComboBox.Name = "deviceTypeComboBox";
            this.deviceTypeComboBox.Size = new System.Drawing.Size(201, 21);
            this.deviceTypeComboBox.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(50, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "仪器类型：";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.concreteConPanel);
            this.groupBox1.Location = new System.Drawing.Point(12, 40);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(686, 255);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "检索条件";
            // 
            // DataQueryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(731, 625);
            this.Controls.Add(this.panel1);
            this.Name = "DataQueryForm";
            this.Text = "数据查询";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.DataQueryForm_FormClosing);
            this.Load += new System.EventHandler(this.DataQueryForm_Load);
            this.panel1.ResumeLayout(false);
            this.buttonPanel.ResumeLayout(false);
            this.resultPanel.ResumeLayout(false);
            this.resultPanel.PerformLayout();
            this.conditionPanel.ResumeLayout(false);
            this.conditionPanel.PerformLayout();
            this.concreteConPanel.ResumeLayout(false);
            this.concreteConPanel.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel conditionPanel;
        private System.Windows.Forms.Panel resultPanel;
        private System.Windows.Forms.Panel buttonPanel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox deviceTypeComboBox;
        private System.Windows.Forms.Panel concreteConPanel;
        private System.Windows.Forms.Button searchDataButton;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListView searchResultListView;
        private System.Windows.Forms.Button exitButton;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox dataTableComboBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox logicTypeComboBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox segmentComboBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox savedConComboBox;
        private System.Windows.Forms.ComboBox operationTypeComboBox;
        private System.Windows.Forms.TextBox opValueTextBox;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button clearButton;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox conNameTextBox;
        private System.Windows.Forms.Button delConButton;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}