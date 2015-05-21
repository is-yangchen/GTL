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
    public partial class CreateDispenForm : Form
    {
        public CreateDispenForm()
        {
            InitializeComponent();

            comboBox1.Items.Add("培养皿");
            comboBox1.Items.Add("深孔板");
            comboBox1.SelectedIndex = 0;
        }

        public VirtualDevicesForm FatherForm;
        public bool IsSocket;

        private void button1_Click(object sender, EventArgs e)
        {
            DeviceForm form = new DeviceForm();
            form.IsCreating = true;
            form.FatherForm = FatherForm;
            form.Type = DeviceType.Dispen;
            form.IsSocket = IsSocket;
            if (comboBox1.SelectedIndex == 0)
            {
                //form.DispenType = AutoDispenDevice.AutoDispenType.PeiYangMin;
                form.DispenTwincatType = AutoDispenTwincatDevice.AutoDispenType.PeiYangMin;
            }
            else
            {
                //form.DispenType = AutoDispenDevice.AutoDispenType.ShenKongBan;
                form.DispenTwincatType = AutoDispenTwincatDevice.AutoDispenType.ShenKongBan;
            }
            this.Close();
            form.Show();
        }

        private void CreateDispenForm_Load(object sender, EventArgs e)
        {
            FatherForm.Enabled = false;
            Control.CheckForIllegalCrossThreadCalls = false;
        }

        private void CreateDispenForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            FatherForm.Enabled = true;
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void preButton_Click(object sender, EventArgs e)
        {
            CreateDeviceForm creatForm = new CreateDeviceForm();
            creatForm.FatherForm = FatherForm;
            this.Close();
            creatForm.Show();
        }
    }
}
