using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GTLutils;
using Instrument;

namespace CentralControl
{
    public partial class DemoDeviceForm : Form
    {
        public ControlForm FatherForm;
        public bool IsSocket;
        public DemoVirtualDevice DispenDevice;

        public DemoDeviceForm()
        {
            InitializeComponent();
            stateComboBox.Items.Add("正常");
            stateComboBox.Items.Add("出错");
            stateComboBox.SelectedIndex = 0;
        }

        private void sendButton_Click(object sender, EventArgs e)
        {
            String Num = "", Vol = "", msg = "";
            Num = textBox1.Text;
            Vol = textBox2.Text;
            
        }

        private void resetButton_Click(object sender, EventArgs e)
        {
            DispenDevice.SendCmd("Reset");
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            DispenDevice.SendCmd("Start");
        }

        private void stopButton_Click(object sender, EventArgs e)
        {
            DispenDevice.SendCmd("Stop");
        }

        private void autoButton_Click(object sender, EventArgs e)
        {
            DispenDevice.SendCmd("Auto");
        }

        private void refreshTimer_Tick(object sender, EventArgs e)
        {
            refreshTimer.Stop();
            dianJi1TextBox.Text = DispenDevice.MPF_Current1.ToString();
            dianJi2TextBox.Text = DispenDevice.MPF_Current2.ToString();
            dianJi3TextBox.Text = DispenDevice.MPF_Current3.ToString();
            dianJi4TextBox.Text = DispenDevice.MPF_Current4.ToString();
            stateComboBox.SelectedIndex = DispenDevice.MPF_RunningError;
            refreshTimer.Start();
        }

        private void loadInfo()
        {
                deviceNameLabel.Text = DispenDevice.Name;
                deviceIPTextBox.Text = DispenDevice.IP;
                localIPTextBox.Text = DispenDevice.ControlIP;
                deviceNameTextBox.Text = DispenDevice.Name;
                identifyIDTextBox.Text = DispenDevice.IdentifyID;
                codeTextBox.Text = DispenDevice.Code;
                serialIDTextBox.Text = DispenDevice.SerialID;

                dianJi1TextBox.Text = DispenDevice.MPF_Current1.ToString();
                dianJi2TextBox.Text = DispenDevice.MPF_Current2.ToString();
                dianJi3TextBox.Text = DispenDevice.MPF_Current3.ToString();
                dianJi4TextBox.Text = DispenDevice.MPF_Current4.ToString();
                stateComboBox.SelectedIndex = DispenDevice.MPF_RunningError;
               
        }

        private void AutoDispenDeviceForm_Load(object sender, EventArgs e)
        {

            volumeLabel.Text = "堆栈孔板数";
            capacityLabel.Text = "单孔分装量";
           
            loadInfo();
            refreshTimer.Start();
        }

        private void basicPanel_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
