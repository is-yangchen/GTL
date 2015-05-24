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
    public partial class DuoTongDaoShuJuShengChengForm : Form
    {
        public MultiTunnelDeviceForm FatherForm;

        public DuoTongDaoShuJuShengChengForm()
        {
            InitializeComponent();
        }

        private void cunChuButton_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK) 
            {
                String fileName = saveFileDialog1.FileName;
                luJingLabel.Text = fileName;
            }
        }

        private void DuoTongDaoShuJuShengChengForm_Load(object sender, EventArgs e)
        {
            FatherForm.Enabled = false;
            comboBox1.SelectedIndex = 0;
        }

        private void DuoTongDaoShuJuShengChengForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            FatherForm.Enabled = true;
        }

        private void shengChengButton_Click(object sender, EventArgs e)
        {
            try
            {
                float inc = 0;
                if (comboBox1.SelectedIndex == 1)
                {
                    inc = float.Parse(zengLiangTextBox.Text);
                }
                float start = float.Parse(qiShiZhiTextBox.Text);
                String fileName = luJingLabel.Text;
                float[][] v;
                v = new float[MultiTunnelDevice.MMA_TestRowIndex][];
                for (int i = 0; i < MultiTunnelDevice.MMA_TestRowIndex; i++) 
                {
                    v[i] = new float[MultiTunnelDevice.MMA_TestRowIndex];
                }
                for (int i = 0; i < MultiTunnelDevice.MMA_TestRowIndex; i++)
                {
                    for (int j = 0; j < MultiTunnelDevice.MMA_TestRowIndex; j++) 
                    {
                        v[i][j] = start;
                        start += inc;
                    }
                }
                DuoTongDaoFileHelper.setJianCeShuJu(fileName, v);
            }
            catch (Exception ex) 
            {
                
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void fanHuiButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
