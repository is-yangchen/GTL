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
    public partial class CreateDeviceForm : Form
    {

        public CreateDeviceForm()
        {
            InitializeComponent();
            foreach (DeviceType s in EnumHelper.TypeEnums) 
            {
                typeComboBox.Items.Add(EnumHelper.getDeviceTypeString(s));
            }
            typeComboBox.SelectedIndex = 0;
            communicateComboBox.Items.Add("Socket");
            communicateComboBox.Items.Add("TwinCat");
            communicateComboBox.SelectedIndex = 0;
        }

        public VirtualDevicesForm FatherForm;

        private void createDeviceButton_Click(object sender, EventArgs e)
        {
            DeviceType selectType = EnumHelper.TypeEnums[typeComboBox.SelectedIndex];
            bool isSocket = true;
            /*此处是为了都走Socket的方式,如需有TwinCAT支持请加上这句话
                if (communicateComboBox.SelectedIndex == 1) isSocket = false;
             */ 
            //if (selectType == DeviceType.Dispen)
            if (false)
            {
                CreateDispenForm form = new CreateDispenForm();
                form.FatherForm = FatherForm;
                form.IsSocket = isSocket;
                this.Close();
                form.Show();
            }
            else
            {
                DeviceForm form = new DeviceForm();
                form.IsCreating = true;
                form.FatherForm = FatherForm;
                form.Type = selectType;
                form.IsSocket = isSocket;
                this.Close();
                form.Show();
            }
        }

        private void CreateDeviceForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            FatherForm.Enabled = true;
        }

        private void CreateDeviceForm_Load(object sender, EventArgs e)
        {
            FatherForm.Enabled = false;
            Control.CheckForIllegalCrossThreadCalls = false;
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            FatherForm.Enabled = true;
            this.Close();
        }

    }
}
