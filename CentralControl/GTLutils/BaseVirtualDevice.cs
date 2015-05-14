using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Net.Sockets;
using System.Net;
using System.Threading;

namespace GTLutils
{
    public class BaseVirtualDevice : BaseDevice
    {
        private Socket mySocket;
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


        public BaseVirtualDevice()
        {
            myThread = null;
            mySocket = null;
        }

        ~BaseVirtualDevice()
        {
            if (mySocket != null) mySocket.Close();
            //if (myThread != null) myThread.Abort();
        }

        private bool isTerminating;
        public override void init()
        {
            if (mySocket != null)
            {
                isTerminating = false;
                try
                {
                    myThread = new Thread(SocketReceiveMsg);
                    myThread.IsBackground = true;
                    myThread.Start();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("{0} Exception caught.", ex);
                }
            }
        }

        public override void deinit() 
        {
            isTerminating = true;
        }

        public override void SendMsg(String msg)
        {
            if (mySocket != null)
            {
                try
                {
                    mySocket.Send(StringByteHelper.StringToBytes(msg));
                    deviceManager.sendMsg(this, msg);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("{0} Exception caught.", ex);
                }
            }
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
                DataOperate.WriteAny((String)de.Key,code,de.Value);
            }
        }
        public virtual void decodeSetMessage(ModbusMessage s) 
        {
            foreach (DictionaryEntry de in s.Data)
            {
                DataOperate.WriteAny((String)de.Key, code, de.Value);
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

        private void SocketReceiveMsg()//接收socket消息
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
                    deviceManager.receiveMsg(this, s);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("{0} Exception caught.", ex);
                }
            }
        }

    }
}
