using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Sockets;  
using System.Net;  
using System.Threading;  

namespace VirtialDevices
{
    public class BaseVirtualDevice : BaseDevice
    {
        private Socket mySocket;
        private Thread myThread;

        private bool isTerminating;
        public override void init() 
        {
            isTerminating = false;
            mySocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPAddress myIP = IPAddress.Parse(hostIP);
            IPEndPoint point = new IPEndPoint(myIP, int.Parse(hostPort));

            try
            {
                mySocket.Connect(point);
                myThread = new Thread(SocketReceiveMsg);
                myThread.IsBackground = true;
                myThread.Start();
            }
            catch (Exception ex)
            {

            }
        }

        public override void deinit() 
        {
            isTerminating = true;
        }

        public override void SendMsg(String s)
        {
            lock (mySocket) 
            { 
                if (mySocket != null) 
                {
                    try
                    {
                        byte[] buffer = StringByteHelper.StringToBytes(s);
                        mySocket.Send(buffer);
                        virtualDeviceManager.sendMsg(this,s);
                    }
                    catch (Exception ex) 
                    {
                
                    }
                }
            }
        }

        public void send_basic_info() 
        {
            ModbusMessageDataCreator creator = new ModbusMessageDataCreator();
            creator.addKeyPair("SetType", "BasicInfo");
            creator.addKeyPair("DeviceType", EnumHelper.getDeviceTypeString(this.CurrentDeviceType));
            if (this.CurrentDeviceType == DeviceType.Dispen) 
            {
                if (((AutoDispenDevice)this).SubType == AutoDispenDevice.AutoDispenType.PeiYangMin)
                    creator.addKeyPair("SubType", "PeiYangMin");
                else 
                    creator.addKeyPair("SubType", "ShenKongBan");
            }
            creator.addKeyPair("IP", this.IP);
            creator.addKeyPair("Name", this.Name);
            creator.addKeyPair("IdentifyID", this.IdentifyID);
            creator.addKeyPair("SerialID", this.SerialID);
            creator.addKeyPair("Code", this.Code);
            String msg = ModbusMessageHelper.createModbusMessage(ModbusMessage.messageTypeToByte(ModbusMessage.MessageType.SET), creator.getDataBytes());
            ModbusMessage mod = ModbusMessageHelper.decodeModbusMessage(msg);
            this.SendMsg(msg);
        }

        public override void ReceiveMsg(String s) { }

        private void SocketReceiveMsg() 
        {
            byte[] buffer = new byte[1024 * 1024];
            int n;
            String s;
            while (true) 
            {
                if (isTerminating) break;
                if (mySocket == null) break;
                try 
                {
                    n = mySocket.Receive(buffer);
                    s = StringByteHelper.BytesToString(buffer,0,n);
                    ReceiveMsg(s);
                    virtualDeviceManager.receiveMsg(this,s);
                }
                catch(Exception ex)
                {
                
                }
            }
        }

        public BaseVirtualDevice() 
        {
            hostPort = "8888";
            hostIP = "127.0.0.1";
            myThread = null;
            mySocket = null;
        }

        ~BaseVirtualDevice() 
        {
            if (mySocket != null) mySocket.Close();
            if (myThread != null) myThread.Abort();
        }

        private String hostIP;
        public String HostIP 
        {
            get 
            {
                return this.hostIP;
            }
            set 
            {
                this.hostIP = value;
            }
        }

        private String hostPort;
        public String HostPort 
        {
            get 
            {
                return this.hostPort;
            }
            set 
            {
                this.hostPort = value;
            }
        }



    }
}
