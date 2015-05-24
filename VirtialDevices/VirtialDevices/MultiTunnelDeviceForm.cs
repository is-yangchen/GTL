using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DeviceUtils;
using Instrument;

namespace VirtialDevices
{
    public partial class MultiTunnelDeviceForm : Form
    {
        public MultiTunnelDevice DeviceInfo;
        public DeviceForm FatherForm;

        private DataTable dt;

        private bool Updating = true;

        public MultiTunnelDeviceForm()
        {
            InitializeComponent();
        }

        private void daoRuButton_Click(object sender, EventArgs e)
        {
            if (shuJuOpenFileDialog.ShowDialog() == DialogResult.OK)
            {
                String fileName = shuJuOpenFileDialog.FileName;
                float[][] v = DuoTongDaoFileHelper.getJianCeShuJu(fileName);
                if (v != null)
                {
                    DeviceInfo.setDetectValues(v);
                    for (int i = 0; i < MultiTunnelDevice.MMA_TestRowIndex; i++)
                    {
                        DataRow dr = dt.Rows[i];
                        for (int j = 0; j < MultiTunnelDevice.MMA_TestColumnIndex; j++)
                        {
                            dr[j] = v[i][j];
                        }
                    }
                }
                dataGridView.DataSource = dt;
                dataGridView.Update();
            }
        }

        private void MultiTunnelDeviceForm_Load(object sender, EventArgs e)
        {
            FatherForm.Enabled = false;
            placeFlagComboBox.SelectedIndex = 0;
            detectModelComboBox.SelectedIndex = 0;
            stateComboBox.SelectedIndex = 0;
            dt = new DataTable();
            Updating = true;
            DataColumn dc;
            for (int i = 1; i <= MultiTunnelDevice.MMA_TestColumnIndex; i++)
            {
                dc = new DataColumn(i.ToString());
                dt.Columns.Add(dc);
            }
            DataRow dr;
            for (int i = 1; i <= MultiTunnelDevice.MMA_TestRowIndex; i++)
            {
                dr = dt.NewRow();
                for (int j = 0; j < MultiTunnelDevice.MMA_TestColumnIndex; j++)
                {
                    dr[i] = "";
                }
                dt.Rows.Add(dr);
            }
            dataGridView.DataSource = dt;
            foreach (DataGridViewColumn dgc in dataGridView.Columns)
            {
                dgc.Width = 44;
                dgc.Resizable = DataGridViewTriState.False;
            }
            Updating = false;
        }

        private void MultiTunnelDeviceForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            FatherForm.Enabled = true;
        }

        private void dataGridView_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (!Updating)
            {
                int i = e.RowIndex;
                int j = e.ColumnIndex;
                String v = (String)dataGridView.Rows[i].Cells[j].Value;
                float val = float.Parse(v);
                DataRow dr = dt.Rows[i];
                dr[j] = v;
                DeviceInfo.setSingleDetectValue(i, j, val);
            }
        }

        private void dataGridView_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (!Updating)
            {
                int i = e.RowIndex;
                int j = e.ColumnIndex;
                String v = (String)dataGridView.Rows[i].Cells[j].Value;
                try
                {
                    float.Parse(v);
                }
                catch (Exception ex)
                {
                    ErrorMessageForm form = new ErrorMessageForm("检测值必须为浮点数");
                    form.Show();
                }
            }
        }

        private void setButton_Click(object sender, EventArgs e)
        {
            try
            {
                bool hasKongBan = false;
                if (placeFlagComboBox.SelectedIndex == 0) hasKongBan = true;
                int chuLiShiJian = int.Parse(dealTImeTextBox.Text);
                float dangQiangWenDu = float.Parse(currentTmpTextBox.Text);
                float boChangXiaXian = float.Parse(lowerTextBox.Text);
                float boChangShangXian = float.Parse(upperTextBox.Text);
                DeviceInfo.ChuLiShiJian = chuLiShiJian;
                DeviceInfo.DangQiangWenWu = dangQiangWenDu;
                DeviceInfo.BoChangShangXian = boChangShangXian;
                DeviceInfo.BoChangXiaXian = boChangXiaXian;
                DeviceInfo.YouKongBan = hasKongBan;
            }
            catch (System.Exception ex)
            {

            }
        }

        private void shengChengButton_Click(object sender, EventArgs e)
        {
            DuoTongDaoShuJuShengChengForm form = new DuoTongDaoShuJuShengChengForm();
            form.FatherForm = this;
            form.Show();
        }



    }
}
