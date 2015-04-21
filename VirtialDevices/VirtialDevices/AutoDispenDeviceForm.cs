using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Timers;

namespace VirtialDevices
{
    public partial class AutoDispenDeviceForm : Form
    {
        public DeviceForm FatherForm;
        public bool IsSocket;
        public AutoDispenDevice DispenDevice;
        public AutoDispenTwincatDevice TwincatDevice;

        private String[] VolStr = { "每摞培养皿数量","堆栈孔板数"};
        private String[] CapStr = { "单皿分装量","单孔分装量"};
        private String[] LeftStr = { "剩余培养皿数量","剩余孔板数量"};

        private String[] StateStr = { "正常","出错"};

        public AutoDispenDeviceForm()
        {
            InitializeComponent();
            foreach (String s in StateStr) 
            {
                stateComboBox.Items.Add(s);
            }
            stateComboBox.SelectedIndex = 0;
        }

        private void AutoDispenDeviceForm_Load(object sender, EventArgs e)
        {
            FatherForm.Enabled = false;

            int index = 0;
            if (IsSocket)
            {
                if (DispenDevice.SubType == AutoDispenDevice.AutoDispenType.ShenKongBan)
                {
                    index = 1;
                }
            }
            else
            {
                if (TwincatDevice.SubType == AutoDispenTwincatDevice.AutoDispenType.ShenKongBan)
                {
                    index = 1;
                }
            }

            totalNumberLabel.Text = VolStr[index];
            capLabel.Text = CapStr[index];
            leftNumberLabel.Text = LeftStr[index];

            foreach (String s in StateStr) 
            {
                stateComboBox.Items.Add(s);
            }
            stateComboBox.SelectedIndex = 0;
        }


        private void AutoDispenDeviceForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            FatherForm.Enabled = true;
        }

        private void setButton_Click(object sender, EventArgs e)
        {
            if (IsSocket)
            {
                DispenDevice.YunXingChuCuoBiaoZhi = stateComboBox.SelectedIndex;
                DispenDevice.DianLiu1 = double.Parse(currency1TextBox.Text);
                DispenDevice.DianLiu2 = double.Parse(currency2TextBox.Text);
                DispenDevice.Dianliu3 = double.Parse(currency3TextBox.Text);
                DispenDevice.FenZhuangShiJian = int.Parse(dispenTimeTextBox.Text);
                DispenDevice.CaiYangShiJian = int.Parse(sampleTimeTextBox.Text);
                DispenDevice.startTimers();
            }
            else 
            {
                TwincatDevice.YunXingChuCuoBiaoZhi = stateComboBox.SelectedIndex;
                TwincatDevice.DianLiu1 = float.Parse(currency1TextBox.Text);
                TwincatDevice.DianLiu2 = float.Parse(currency2TextBox.Text);
                TwincatDevice.Dianliu3 = float.Parse(currency3TextBox.Text);
                TwincatDevice.FenZhuangShiJian = int.Parse(dispenTimeTextBox.Text);
                TwincatDevice.CaiYangShiJian = int.Parse(sampleTimeTextBox.Text);
                TwincatDevice.startTimers();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (IsSocket) 
            {
                totalNumberTextBox.Text = DispenDevice.getNum().ToString();
                capTextBox.Text = DispenDevice.getVol().ToString();
                leftNumberTextBox.Text = DispenDevice.getLeft().ToString();
            }
            else
            {
                totalNumberTextBox.Text = TwincatDevice.getNum().ToString();
                capTextBox.Text = TwincatDevice.getVol().ToString();
                leftNumberTextBox.Text = TwincatDevice.getLeft().ToString();
            }
        }
    }
}
