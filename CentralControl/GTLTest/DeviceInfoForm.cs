using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CentralControl
{
    public partial class DeviceInfoForm : Form
    {
        public ControlForm FatherForm;
        public BaseDevice DeviceInfo;

        public DeviceInfoForm()
        {
            InitializeComponent();
        }

        private void DeviceInfoForm_Load(object sender, EventArgs e)
        {
            Control.CheckForIllegalCrossThreadCalls = false;
            FatherForm.Enabled = false;

            if (DeviceInfo.IsVirt) 
            {
                isVirtualCheckBox.Checked = true;
            }
            deviceNameLabel.Text = DeviceInfo.Name;
            deviceIPTextBox.Text = DeviceInfo.IP;
            localIPTextBox.Text = DeviceInfo.ControlIP;
            deviceNameTextBox.Text = DeviceInfo.Name;
            identifyIDTextBox.Text = DeviceInfo.IdentifyID;
            codeTextBox.Text = DeviceInfo.Code;
            serialIDTextBox.Text = DeviceInfo.SerialID;
        }

        private void infoButton_Click(object sender, EventArgs e)
        {
            
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void DeviceInfoForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            FatherForm.Enabled = true;
        }
    }
}
