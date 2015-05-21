using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Sockets;  
using System.Net;  
using System.Threading;
using System.Collections;

namespace DeviceUtils
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
            /*
            if (this.CurrentDeviceType == DeviceType.Dispen)
            {
                if (((autodispendevice)this).subtype == autodispendevice.autodispentype.peiyangmin)
                    creator.addkeypair("subtype", "peiyangmin");
                else
                    creator.addkeypair("subtype", "shenkongban");
            }*/
            creator.addKeyPair("IP", this.IP);
            creator.addKeyPair("Name", this.Name);
            creator.addKeyPair("IdentifyID", this.IdentifyID);
            creator.addKeyPair("SerialID", this.SerialID);
            creator.addKeyPair("Code", this.Code);
            String msg = ModbusMessageHelper.createModbusMessage(ModbusMessage.messageTypeToByte(ModbusMessage.MessageType.SET), creator.getDataBytes());
            ModbusMessage mod = ModbusMessageHelper.decodeModbusMessage(msg);
            this.SendMsg(msg);
        }


        /*加入新的数据接口函数*/
        public void SendModBusMsg(ModbusMessage.MessageType type, String key, Object value)
        {
            ModbusMessageDataCreator creator = new ModbusMessageDataCreator();
            creator.addKeyPair(key, (String)value);
            string msg = ModbusMessageHelper.createModbusMessage(ModbusMessage.messageTypeToByte(type), creator.getDataBytes());
            this.SendMsg(msg);
        }

        public void SendModBusMsg(ModbusMessage.MessageType type, Hashtable htable)
        {
            ModbusMessageDataCreator creator = new ModbusMessageDataCreator();
            foreach (DictionaryEntry de in htable)
            {
                creator.addKeyPair((string)de.Key, (string)de.Value);
            }
            string msg = ModbusMessageHelper.createModbusMessage(ModbusMessage.messageTypeToByte(type), creator.getDataBytes());
            this.SendMsg(msg);
        }

        public virtual void decodeResponseMessage(ModbusMessage s)
        {
            ModbusMessageDataCreator creator = new ModbusMessageDataCreator();
            creator.addKeyPair("Result", "OK");
            string msg = ModbusMessageHelper.createModbusMessage(ModbusMessage.messageTypeToByte(ModbusMessage.MessageType.RESPONSE), creator.getDataBytes());
            this.SendMsg(msg);
        }
        public virtual void decodeReportMessage(ModbusMessage s)
        {
            foreach (DictionaryEntry de in s.Data)
            {
                DataOperate.WriteAny((String)de.Key, Code, de.Value);
            }
        }
        public virtual void decodeSetMessage(ModbusMessage s)
        {
            foreach (DictionaryEntry de in s.Data)
            {
                DataOperate.WriteAny((String)de.Key, Code, de.Value);
            }
        }

        public virtual void decodeCmdMessage(ModbusMessage s) { }
        public override void ReceiveMsg(String s)
        {
            ModbusMessage message = ModbusMessageHelper.decodeModbusMessage(s);
            switch (message.MsgType)
            {
                case ModbusMessage.MessageType.RESPONSE:
                    decodeResponseMessage(message);
                    break;
                case ModbusMessage.MessageType.CMD:
                    decodeCmdMessage(message);
                    break;
                case ModbusMessage.MessageType.REPORT:
                    decodeReportMessage(message);
                    break;
                case ModbusMessage.MessageType.SET:
                    decodeSetMessage(message);
                    break;
                case ModbusMessage.MessageType.GET:
                    break;
            }
        }

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

            System.Guid guid = new Guid();
            guid = Guid.NewGuid();
            this.Code = guid.ToString();
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
