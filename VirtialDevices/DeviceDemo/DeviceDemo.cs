using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DeviceUtils;
using System.Net.Sockets;
using System.Net;
using Instrument;

namespace DeviceDemo
{
    public partial class DeviceDemo : Form
    {
        public DeviceDemo()
        {
            InitializeComponent();
            this.DeviceIPtestBox.Text = "127.0.0.1";
            this.CCIPtextBox.Text = "127.0.0.1";
            this.IdentifyIDtextBox.Text = "000";
            this.DeviceNametextBox.Text = "AutoDispen";
            this.serielIDtextBox.Text = "000";
        }
        DeviceManager virtualDeviceManager = DeviceManager.getInstance();
        DemoVirtualDevice DemoDevice = (DemoVirtualDevice)VirtualDeviceFactory.createVirtualDevice(DeviceType.Unknown, true);
        private void Runbutton_Click(object sender, EventArgs e)
        {
            DemoDevice.IP = this.DeviceIPtestBox.Text;
            DemoDevice.ControlIP = this.CCIPtextBox.Text;
            DemoDevice.IdentifyID = this.IdentifyIDtextBox.Text;
            DemoDevice.Name = this.DeviceNametextBox.Text;
            DemoDevice.SerialID = this.serielIDtextBox.Text;
            DemoDevice.CurrentDeviceType = DeviceType.Unknown;

            this.DeviceCodetextBox.Text = DemoDevice.Code;
            DemoDevice.init();
            DemoDevice.send_basic_info();
            virtualDeviceManager.addDevice(DemoDevice);

            this.MessageTextBox.AppendText("Device " + DemoDevice.Name.ToString() + " connect Control Center\n");
        }

        private void Sendbutton_Click(object sender, EventArgs e)
        {
            Hashtable ht = new Hashtable();
            ht.Add("MPF_Current1", this.Current1textBox.Text);
            ht.Add("MPF_Current2", this.Current2textBox.Text);
            ht.Add("MPF_Current3", this.Current3textBox.Text);
            ht.Add("MPF_Current4", this.Current4textBox.Text);

            DemoDevice.SendModBusMsg(ModbusMessage.MessageType.REPORT, ht);

            this.MessageTextBox.AppendText("Device " + DemoDevice.Name + " send message:MPF_Current1="
                + this.Current1textBox.Text + " MPF_Current2=" + this.Current2textBox.Text +
                " MPF_Current3=" + this.Current3textBox.Text + " MPF_Current4=" + this.Current4textBox.Text + "\n");
        }



        private void timer1_Tick(object sender, EventArgs e)
        {
            if (0 != DemoDevice.MPF_PlateNum && 0.0 != DemoDevice.MPF_Volsperwell)
            {
                this.StacktextBox.Text = DemoDevice.MPF_PlateNum.ToString();
                this.DishtextBox.Text = DemoDevice.MPF_Volsperwell.ToString();
            }
            DemoDevice.MPF_Volsperwell = 0.0;
            DemoDevice.MPF_PlateNum = 0;
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            if (null != DemoDevice.MPF_Cmd)
            {
                this.MessageTextBox.AppendText("Device get cmd: " + DemoDevice.MPF_Cmd + "\n");
            }
            DemoDevice.MPF_Cmd = null;
        }
    }
}
