using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Net;
using System.Threading;
//TwinCAT.ads用于基于TwinCAT的通信
//using TwinCAT.Ads;
using GTLutils;
using Instrument;

namespace CentralControl
{
    public partial class ControlForm : Form
    {
        private Socket mySocket;
        private Thread myThread;
        private DeviceManager deviceManager;

        public class TmpSocketReceiver
        {
            private Socket mySocket;
            private DeviceManager deviceManager;
            private ControlForm FatherForm;
            public Socket MySocket
            {
                get 
                {
                    return this.mySocket;
                }
                set 
                {
                    this.mySocket = value;
                }
            }
            private Thread myThread;
            public TmpSocketReceiver(Socket socket, DeviceManager dm,ControlForm form) 
            {
                mySocket = socket;
                deviceManager = dm;
                FatherForm = form;
            }

            public void init() 
            {
                if (mySocket != null)
                {
                    try
                    {
                        myThread = new Thread(SocketReceiveMsg);
                        myThread.IsBackground = true;
                        myThread.Start();
                    }
                    catch (Exception ex)
                    {

                    }
                }
            }

            private void SocketReceiveMsg()
            {
                byte[] buffer = new byte[1024 * 1024];
                int n;
                String s;
                while (true)
                {
                    if (mySocket == null) break;
                    try
                    {
                        n = mySocket.Receive(buffer);
                        s = StringByteHelper.BytesToString(buffer, 0, n);
                        if (ReceiveBasicMsg(s)) 
                        {
                            decodeBasicMsg(s);
                            break;
                        }
                    }
                    catch (Exception ex)
                    {

                    }
                }
                FatherForm.removeTmpList(this);
            }

            private void decodeBasicMsg(String s) 
            {
                ModbusMessage message = ModbusMessageHelper.decodeModbusMessage(s);
                DeviceType type = EnumHelper.deviceStringToDeviceType((String)message.Data["DeviceType"]);
                BaseVirtualDevice device = (BaseVirtualDevice)VirtualDeviceFactory.createVirtualDevice(type,true);
                device.IsVirt = true;
                device.CurrentDeviceType = type;
                /*
                if (type == DeviceType.Dispen)
                {
                    String subType = (String)message.Data["SubType"];
                    if ("PeiYangMin".Equals(subType))
                    {
                        ((AutoDispenVirtualDevice)device).SubType = AutoDispenVirtualDevice.AutoDispenType.PeiYangMin;
                    }
                    else 
                    {
                        ((AutoDispenVirtualDevice)device).SubType = AutoDispenVirtualDevice.AutoDispenType.ShenKongBan;
                    }
                }*/
                device.IdentifyID = (String)message.Data["IdentifyID"];
                device.Code = (String)message.Data["Code"];
                device.IP = (String)message.Data["IP"];
                device.Name = (String)message.Data["Name"];
                device.SerialID = (String)message.Data["SerialID"];
                device.MySocket = mySocket;
                device.DeviceManager = deviceManager;
                device.init();
                deviceManager.addDevice(device);

            }

            private bool ReceiveBasicMsg(String s)
            {
                ModbusMessage message = ModbusMessageHelper.decodeModbusMessage(s);
                if (message.MsgType == ModbusMessage.MessageType.SET) 
                {
                    String setType = (String)message.Data["SetType"];
                    if ("BasicInfo".Equals(setType)) return true;
                }
                return false;
            }
        }

        private List<TmpSocketReceiver> tmpList;
        //add 20150209
        private object KeyObject = new object();

        private void addTmpList(TmpSocketReceiver rec)
        {
            lock (tmpList) 
            {
                tmpList.Add(rec);
            }
        }

        public void removeTmpList(TmpSocketReceiver rec)
        {
            lock (tmpList) 
            {
                tmpList.Remove(rec);
            }
        }

        public ControlForm()
        {
            InitializeComponent();
            deviceManager = DeviceManager.getInstance();
            tmpList = new List<TmpSocketReceiver>();
            mySocket = null;
            myThread = null;
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            DataQueryForm form = new DataQueryForm();
            form.FatherForm = this;
            form.Show();
        }
        
        /*
        private TcAdsClient adsClient;
        private Dictionary<String, Type> nameDict = new Dictionary<String, Type>();
        private Dictionary<String, int> handleMap = new Dictionary<String, int>();

        private Dictionary<String, BaseDevice> twincatDict = new Dictionary<string, BaseDevice>();
        private void handleNotification(object sender, AdsNotificationExEventArgs e) 
        {            
            String s = (String)e.UserData;
            int handle = handleMap[s];
            if (s.Equals("MAIN.MDF_online_state")) 
            {
                int value = (int)adsClient.ReadAny(handle,nameDict[s]);
                if (value > 0)
                {
                    if (twincatDict.ContainsKey(s)) return;
                    BaseTwincatDevice device = (BaseTwincatDevice)VirtualDeviceFactory.createVirtualDevice(DeviceType.Dispen,false);
                    device.init();
                    twincatDict[s] = device;
                    deviceManager.addDevice(device);
                }
                else 
                {
                    if (!twincatDict.ContainsKey(s)) return;
                    BaseDevice device = twincatDict[s];
                    device.deinit();
                    deviceManager.deleteDevice(device.Code);
                    twincatDict.Remove(s);
                }
            }
        }
         */
        private void ControlForm_Load(object sender, EventArgs e)
        {
            Control.CheckForIllegalCrossThreadCalls = false;
            IPAddress ip = IPAddress.Parse("0.0.0.0");
            IPEndPoint point = new IPEndPoint(ip, 8888);
            mySocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            /*
            adsClient = new TcAdsClient();
            nameDict["MAIN.MDF_online_state"] = typeof(int);
             */
            try 
            {
                mySocket.Bind(point);
                mySocket.Listen(10);
                myThread = new Thread(AcceptInfo);
                myThread.IsBackground = true;
                myThread.Start();
                /*
                adsClient.Connect(801);
                adsClient.AdsNotificationEx += new AdsNotificationExEventHandler(handleNotification);
                foreach (String s in nameDict.Keys)
                {
                    handleMap[s] = adsClient.CreateVariableHandle(s);
                    adsClient.AddDeviceNotificationEx(s, AdsTransMode.OnChange, 100, 0, s, nameDict[s]);
                }
                 */ 
            }
            catch (Exception ex) 
            {
            
            }
            deviceTimer.Start();
            logTimer.Start();
        }

        private void AcceptInfo()
        {
            while (true) 
            {
                try 
                {
                    Socket tSocket = mySocket.Accept();
                    TmpSocketReceiver rec = new TmpSocketReceiver(tSocket,deviceManager,this);
                    addTmpList(rec);
                    rec.init();
                }
                catch (Exception ex) 
                {
                
                }
            }
        }

        private void ControlForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            //if (myThread != null) myThread.Abort();
            if (mySocket != null) mySocket.Close(); 
            //adsClient.Dispose();
        }

        private void deviceTimer_Tick(object sender, EventArgs e)
        {
            deviceTimer.Stop();
            List<BaseDevice> devices = deviceManager.getAllDevices();
            ListViewItem item = null;
            ListViewItem.ListViewSubItem subItem = null;
            onlineAllListView.BeginUpdate();
            onlineAllListView.Items.Clear();
            foreach (BaseDevice device in devices)
            {
                item = new ListViewItem();
                String deviceType = EnumHelper.getDeviceTypeString(device.CurrentDeviceType);
                item.Text = deviceType;

                subItem = new ListViewItem.ListViewSubItem();
                subItem.Text = device.Name;
                item.SubItems.Add(subItem);

                subItem = new ListViewItem.ListViewSubItem();
                subItem.Text = device.Code;
                item.SubItems.Add(subItem);

                subItem = new ListViewItem.ListViewSubItem();
                String isVirt = "否";
                if (device.IsVirt) isVirt = "是";
                subItem.Text = isVirt;
                item.SubItems.Add(subItem);

                onlineAllListView.Items.Add(item);
            }


            if (devices.Count > 0)
            {
                foreach (ColumnHeader header in onlineAllListView.Columns)
                {
                    header.Width = -1;
                }
            }
            else
            {
                foreach (ColumnHeader header in onlineAllListView.Columns)
                {
                    header.Width = -2;
                }
            }
            onlineAllListView.EndUpdate();
            deviceTimer.Start();
        }

        private void logTimer_Tick(object sender, EventArgs e)
        {
            logTimer.Stop();

           
            List<DeviceMessage> messages = deviceManager.getAllMessages();
            ListViewItem item = null;
            logAllListView.BeginUpdate();
            logAllListView.Items.Clear();

            //foreach (DeviceMessage message in messages)
            //{
            //    item = new ListViewItem();
            //    String type = "接收";
            //    if (message.Type == DeviceMessage.DeviceMessageType.OUT) type = "发送";
            //    item.Text = type;
            //    item.SubItems.Add(message.Time);
            //    item.SubItems.Add(message.Device.Name);
            //    item.SubItems.Add(message.Msg);
            //    logAllListView.Items.Add(item);
            //}

            //Database insert
            //Database mydb = new Database();

            for (int i = 0; i < messages.Count; i++ )
            {
                DeviceMessage message = messages[i];
                item = new ListViewItem();
                String type = "接收";
                if (message.Type == DeviceMessage.DeviceMessageType.OUT) type = "发送";
                item.Text = type;
                item.SubItems.Add(message.Time);
                item.SubItems.Add(message.Device.Name);
                item.SubItems.Add(message.Msg);
                logAllListView.Items.Add(item);

                //Database insert
                //mydb.insertlog(message.Msg, 1, type);
            }

            if (messages.Count > 0)
            {
                foreach (ColumnHeader header in logAllListView.Columns)
                {
                    header.Width = -1;
                }
            }
            else
            {
                foreach (ColumnHeader header in logAllListView.Columns)
                {
                    header.Width = -2;
                }
            }
            logAllListView.EndUpdate();


            logTimer.Start();
        }

        private void exitAllButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void onlineAllListView_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ListViewHitTestInfo info = onlineAllListView.HitTest(e.X, e.Y);
            if (info.Item != null) 
            {
                int index = info.Item.Index;
                BaseDevice device = deviceManager.getDevice(index);
              
                switch (device.CurrentDeviceType)
                {
                    case DeviceType.Dispen:
                        AutoDispenDeviceForm form = new AutoDispenDeviceForm();
                        form.FatherForm = this;
                        form.IsSocket = true;
                        if (device is AutoDispenVirtualDevice)
                            form.DispenDevice = (AutoDispenVirtualDevice)device;
                        else
                        {
                            form.DispenTwincatDevice = (AutoDispenTwincatDevice)device;
                            form.IsSocket = false;
                        }
                        form.Show();
                        break;
                    case DeviceType.Plate:
                        AutoPlateDeviceForm pform = new AutoPlateDeviceForm();
                        pform.FatherForm = this;
                        pform.IsSocket = true;
                        pform.PlateDevice = (AutoPlateVirtualDevice)device;
                        pform.Show();
                        break;
                    case DeviceType.Analysis:
                        MultiTunnelDeviceForm mForm = new MultiTunnelDeviceForm();
                        mForm.FatherForm = this;
                        mForm.DeviceInfo = (MultiTunnelVirtualDevice)device;
                        mForm.Show();
                        break;
                    case DeviceType.Clone:
                        CloneSelectionDeviceForm cForm = new CloneSelectionDeviceForm();
                        cForm.FatherForm = this;
                        cForm.IsSocket = true;
                        cForm.DeviceInfo = (CloneSelectionVirtualDevice)device;
                        cForm.Show();
                        break;
                    case DeviceType.Liquid:
                        LiquidProcessForm forml = new LiquidProcessForm();
                        forml.FatherForm = this;
                        forml.DeviceInfo = device;
                        forml.Show();
                        break;
                    case DeviceType.Matrix:
                        MatrixSystemDeviceForm maForm = new MatrixSystemDeviceForm();
                        maForm.FatherForm = this;
                        maForm.IsSocket = true;
                        maForm.DeviceInfo = (MatrixSystemVirtualDevice)device;
                        maForm.Show();
                        break;
                    case DeviceType.Storage:
                        MicroReactorForm mmForm = new MicroReactorForm();
                        mmForm.FatherForm = this;
                        mmForm.mrDevice = (MicroStorageVirtualDevice)device;
                        mmForm.Show();
                        break;
                    default:
                        DeviceInfoForm form2 = new DeviceInfoForm();
                        form2.FatherForm = this;
                        form2.DeviceInfo = device;
                        form2.Show();
                        break;

                }
            }
        }
    }
}
