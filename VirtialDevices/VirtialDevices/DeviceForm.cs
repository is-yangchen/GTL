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
    public partial class DeviceForm : Form
    {
        public bool IsCreating;
        public VirtualDevicesForm FatherForm;
        public Boolean IsSocket;
        //public AutoDispenDevice.AutoDispenType DispenType;
        public AutoDispenTwincatDevice.AutoDispenType DispenTwincatType;
        public DeviceType Type;
        public BaseDevice DeviceInfo;
        public List<DeviceMessage> DeviceMessages;
        private DeviceManager virtualDeviceManager;


        public DeviceForm()
        {
            InitializeComponent();
            virtualDeviceManager = DeviceManager.getInstance();
        }

        private void DeviceForm_Load(object sender, EventArgs e)
        {
            Control.CheckForIllegalCrossThreadCalls = false;
            FatherForm.Enabled = false;
            if (IsCreating)
            {
                runButton.Visible = true;
                runButton.Enabled = true;
                deviceButton.Visible = false;
                deviceButton.Enabled = false;
            }
            else 
            {
                runButton.Visible = false;
                runButton.Enabled = false;
                deviceButton.Visible = true;
                deviceButton.Enabled = true;

                deviceIPTextBox.Text = DeviceInfo.IP;
                controlIPTextBox.Text = DeviceInfo.ControlIP;
                deviceNameTextBox.Text = DeviceInfo.Name;
                deviceNameLabel.Text = DeviceInfo.Name;
                identifyIDTextBox.Text = DeviceInfo.IdentifyID;
                serielIDTextBox.Text = DeviceInfo.SerialID;
                deviceCodeTextBox.Text = DeviceInfo.Code;
            }


        }

        private void normalStateButton_Click(object sender, EventArgs e)
        {

        }

        private void DeviceForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            FatherForm.Enabled = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void runButton_Click(object sender, EventArgs e)
        {
                BaseDevice device = checkInfoAndCreate();
                if (device != null)
                {
                    device.VirtualDeviceManager = virtualDeviceManager;
                    virtualDeviceManager.addDevice(device);
                    device.init();
                    if (IsSocket) ((BaseVirtualDevice)device).send_basic_info();
                    else ((BaseTwincatDevice)device).send_basic_info();
                    this.Close();
                    FatherForm.refresh_Devices();
                }
        }

        private BaseDevice checkInfoAndCreate()
        {
            BaseDevice result = null;
            String ip = deviceIPTextBox.Text;
            String controlIP = controlIPTextBox.Text;
            String deviceName = deviceNameTextBox.Text;
            String deviceIdentify = identifyIDTextBox.Text;
            String deviceCode = deviceCodeTextBox.Text;
            String deviceSerial = serielIDTextBox.Text;
            String sampleTime = sampleTimeTextBox.Text;
            if (!CheckUtil.checkIP(ip))
            {

            }

            if (!CheckUtil.checkIP(controlIP))
            {

            }

            String hostIP = "127.0.0.1";
            String hostPort = "8888";
            String[] parts = controlIP.Split(':');
            if (parts.Length == 2)
            {
                hostIP = parts[0];
                hostPort = parts[1];
            }
            if (parts.Length == 1) hostIP = parts[0];

            if (!CheckUtil.checkTime(sampleTime))
            {

            }

            if (!CheckUtil.checkIdentify(deviceIdentify))
            {

            }

            if (!CheckUtil.checkCode(deviceCode))
            {

            }

            if (!CheckUtil.checkSerial(deviceSerial))
            {

            }


            result = VirtualDeviceFactory.createVirtualDevice(Type,IsSocket);
            //result.Code = deviceCode;
            result.ControlIP = controlIP;
            result.CurrentDeviceType = Type;
            result.CurrentState = DeviceStates.Created;
            result.IdentifyID = deviceIdentify;
            result.IP = ip;
            result.Name = deviceName;
            result.SerialID = deviceSerial;
            result.SampleTime = int.Parse(sampleTime);

            if (IsSocket)
            {
                ((BaseVirtualDevice)result).HostIP = hostIP;
                ((BaseVirtualDevice)result).HostPort = hostPort;
            }

            //在为分装仪时需要设定是面向培养皿还是深孔板
            /*
            if (Type == DeviceType.Dispen)
            {
                if (IsSocket)
                    ((AutoDispenDevice)result).SubType = DispenType;
                else 
                {
                    ((AutoDispenTwincatDevice)result).SubType = DispenTwincatType;
                }
            }
            */
            return result;
        }

        private void deviceButton_Click(object sender, EventArgs e)
        {
            switch (DeviceInfo.CurrentDeviceType) 
            {
                case DeviceType.Dispen:
                    AutoDispenDeviceForm aForm = new AutoDispenDeviceForm();
                    aForm.FatherForm = this;
                    aForm.IsSocket = true;
                    /*
                    if (DeviceInfo is AutoDispenDevice) aForm.DispenDevice = (AutoDispenDevice)DeviceInfo;
                    else 
                    {
                        aForm.TwincatDevice = (AutoDispenTwincatDevice)DeviceInfo;
                        aForm.IsSocket = false;
                    }*/
                    aForm.DispenDevice = (AutoDispenDevice)DeviceInfo;
                    aForm.Show();
                    break;
                case DeviceType.Plate:
                    AutoPlateDeviceForm pForm = new AutoPlateDeviceForm();
                    pForm.FatherForm = this;
                    pForm.IsSocket = true;
                    pForm.PlateDevice = (AutoPlateDevice)DeviceInfo;
                    pForm.Show();
                    break;
                case DeviceType.Analysis:
                    MultiTunnelDeviceForm mForm = new MultiTunnelDeviceForm();
                    mForm.FatherForm = this;
                    //mForm.IsSocket = true;
                    mForm.DeviceInfo = (MultiTunnelDevice)DeviceInfo;
                    mForm.Show();
                    break;
                case DeviceType.Clone:
                    CloneSelectionDeviceForm cForm = new CloneSelectionDeviceForm();
                    cForm.FatherForm = this;
                    cForm.IsSocket = true;
                    cForm.DeviceInfo = (CloneSelectionDevice)DeviceInfo;
                    cForm.Show();
                    break;
                case DeviceType.Liquid:
                    LiquidProcessForm lForm = new LiquidProcessForm();
                    lForm.FatherForm = this;
                    lForm.alcDevice = (LiquidProcessDevice)DeviceInfo;
                    lForm.Show();
                    break;

                case DeviceType.Matrix:
                    MatrixSystemDeviceForm maForm = new MatrixSystemDeviceForm();
                    maForm.FatherForm = this;
                    maForm.DeviceInfo = (MatrixSystemDevice)DeviceInfo;
                    maForm.Show();
                    break;
                case DeviceType.Storage:
                    MicroReactorForm mmForm = new MicroReactorForm();
                    mmForm.FatherForm = this;
                    mmForm.mrDevice = (MicroStorageDevice)DeviceInfo;
                    mmForm.Show();
                    break;
                default:
                    break;
            }
        }
    }
}
