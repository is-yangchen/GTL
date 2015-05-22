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
        public DemoVirtualDevice DemoDevice;

        public DemoDeviceForm()
        {
            InitializeComponent();
            stateComboBox.Items.Add("正常");
            stateComboBox.Items.Add("出错");
            stateComboBox.SelectedIndex = 0;
        }

        private void sendButton_Click(object sender, EventArgs e)
        {
            String Num = "", Vol = "";
            Num = textBox1.Text;
            Vol = textBox2.Text;
            DemoDevice.SendMPFSetNumAndVol(Num, Vol);
        }

        private void resetButton_Click(object sender, EventArgs e)
        {
            DemoDevice.SendCmd("Reset");
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            DemoDevice.SendCmd("Start");
        }

        private void stopButton_Click(object sender, EventArgs e)
        {
            DemoDevice.SendCmd("Stop");
        }

        private void autoButton_Click(object sender, EventArgs e)
        {
            DemoDevice.SendCmd("Auto");
        }

        private void refreshTimer_Tick(object sender, EventArgs e)
        {
            refreshTimer.Stop();
            dianJi1TextBox.Text = DemoDevice.MPF_Current1.ToString();
            dianJi2TextBox.Text = DemoDevice.MPF_Current2.ToString();
            dianJi3TextBox.Text = DemoDevice.MPF_Current3.ToString();
            dianJi4TextBox.Text = DemoDevice.MPF_Current4.ToString();
            stateComboBox.SelectedIndex = DemoDevice.MPF_RunningError;
            refreshTimer.Start();
        }

        private void loadInfo()
        {
            deviceNameLabel.Text = DemoDevice.Name;
            deviceIPTextBox.Text = DemoDevice.IP;
            localIPTextBox.Text = DemoDevice.ControlIP;
            deviceNameTextBox.Text = DemoDevice.Name;
            identifyIDTextBox.Text = DemoDevice.IdentifyID;
            codeTextBox.Text = DemoDevice.Code;
            serialIDTextBox.Text = DemoDevice.SerialID;

            dianJi1TextBox.Text = DemoDevice.MPF_Current1.ToString();
            dianJi2TextBox.Text = DemoDevice.MPF_Current2.ToString();
            dianJi3TextBox.Text = DemoDevice.MPF_Current3.ToString();
            dianJi4TextBox.Text = DemoDevice.MPF_Current4.ToString();
            stateComboBox.SelectedIndex = DemoDevice.MPF_RunningError;
               
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
