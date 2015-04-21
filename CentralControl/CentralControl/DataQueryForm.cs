using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using GTLutils;

namespace CentralControl
{
    public partial class DataQueryForm : Form
    {
        public ControlForm FatherForm;

        public DataQueryForm()
        {
            InitializeComponent();
            foreach (DeviceType type in EnumHelper.TypeEnums) 
            {
                deviceTypeComboBox.Items.Add(EnumHelper.getDeviceTypeString(type));
            }
            deviceTypeComboBox.SelectedIndex = 0;

            foreach (Operations op in OperationHelper.OpeEnums) 
            {
                operationTypeComboBox.Items.Add(OperationHelper.getOperationString(op));
            }
            operationTypeComboBox.SelectedIndex = 0;

            foreach (Logics logic in LogicHelper.LogicEnums) 
            {
                logicTypeComboBox.Items.Add(LogicHelper.getLogicString(logic));
            }
            logicTypeComboBox.SelectedIndex = 0;
        }

        private void DataQueryForm_Load(object sender, EventArgs e)
        {
            Control.CheckForIllegalCrossThreadCalls = false;
            FatherForm.Enabled = false;

            ArrayList list = DBUtil.getTableList();
            dataTableComboBox.Items.Clear();
            foreach (String s in list)
            {
                dataTableComboBox.Items.Add(s);
            }
            dataTableComboBox.SelectedIndex = 0;
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void DataQueryForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            FatherForm.Enabled = true;
        }

        private void dataTableComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            String tableName = dataTableComboBox.SelectedItem.ToString();
            ArrayList list = DBUtil.getTableColumns(tableName);
            segmentComboBox.Items.Clear();
            foreach (String s in list) 
            {
                segmentComboBox.Items.Add(s);
            }
            if(list.Count > 0)segmentComboBox.SelectedIndex = 0;
            textBox1.Text = "";
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            if (opValueTextBox.Text.Equals("")) return;
            String con = "";
            con = segmentComboBox.SelectedItem.ToString() + " " + operationTypeComboBox.SelectedItem.ToString() + " '" + opValueTextBox.Text + "' ";
            String opStr = "&&";
            if (logicTypeComboBox.SelectedIndex > 0) opStr = "||";
            if (textBox1.Text.Equals("")) textBox1.Text = con;
            else textBox1.Text = "(" + textBox1.Text + ") "+ opStr + " " + con;
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
        }

        private void searchDataButton_Click(object sender, EventArgs e)
        {
            String conStr = textBox1.Text;
            String cmdStr = "select * from " + dataTableComboBox.SelectedItem.ToString();
            if (!conStr.Equals("")) cmdStr += " where " + conStr;
            cmdStr += ";";
            ArrayList colList = DBUtil.getTableColumns(dataTableComboBox.SelectedItem.ToString());
            ArrayList list = DBUtil.executeQueryCmd(cmdStr,colList.Count);

            searchResultListView.Columns.Clear();
            for (int i = 0; i < colList.Count; i++) 
            {
                ColumnHeader header = new ColumnHeader();
                header.Text = (String)colList[i];
                searchResultListView.Columns.Add(header);
            }

            searchResultListView.Items.Clear();
            foreach (String[] ele in list) 
            {
                ListViewItem item = new ListViewItem();
                item.Text = ele[0];
                for (int i = 1; i < ele.Length; i++)
                {
                    item.SubItems.Add(ele[i]);
                }
                searchResultListView.Items.Add(item);
            }
        }
    }
}
