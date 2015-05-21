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
        /*
         * SendModBusMsg函数，以ModBus协议的方式发送数据
         * ModbusMessage.MessageType 有{ CMD, RESPONSE, GET, SET, REPORT }
         * Key 和 Value 分别指的是生成ModBusMessage的键和值
         * 通常来说Key为变量名，Value为该变量的值，示例：SendModBusMsg(ModbusMessage.MessageType.REPORT,"MPF_PlateNum","10");
         * 函数完成的就是将这组Key，Value封装成ModBusMessage然后发送出去
         */
        public void SendModBusMsg(ModbusMessage.MessageType type, String key, Object value)
        {
            ModbusMessageDataCreator creator = new ModbusMessageDataCreator();
            creator.addKeyPair(key, (String)value);
            string msg = ModbusMessageHelper.createModbusMessage(ModbusMessage.messageTypeToByte(type), creator.getDataBytes());
            this.SendMsg(msg);
        }

        /*
         * SendModBusMsg函数，以ModBus协议的方式发送数据
         * ModbusMessage.MessageType 有{ CMD, RESPONSE, GET, SET, REPORT }
         * htable指的是多组的Key和Value，主要用于多个键以及值的数据发送
         * 函数完成的就是将这htable包含的多组Key，Value封装成ModBusMessage然后发送出去
         */
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

        /*
        * decodeResponseMessage函数，处理Response命令的函数
        * 虚函数，方法已实现，会自动给出消息的Response答复
        * 如有需要，可在仪器类中重写该函数
        */
        public virtual void decodeResponseMessage(ModbusMessage s) 
        {
            ModbusMessageDataCreator creator = new ModbusMessageDataCreator();
            creator.addKeyPair("Result", "OK");
            string msg = ModbusMessageHelper.createModbusMessage(ModbusMessage.messageTypeToByte(ModbusMessage.MessageType.RESPONSE), creator.getDataBytes());
            this.SendMsg(msg);
        }
        /*
        * decodeReportMessage函数，处理REPORT命令的函数
        * 虚函数，方法已实现，会自动将REPORT命令后的参数进行一一处理
        * 如有需要，可在仪器类中重写该函数
        */
        public virtual void decodeReportMessage(ModbusMessage s) 
        {
            foreach (DictionaryEntry de in s.Data)
            {  
                DataOperate.WriteAny((String)de.Key, Code ,de.Value);
            }
        }
        /*
        * decodeSetMessage函数，处理SET命令的函数
        * 虚函数，方法已实现，会自动将SET命令后的参数进行一一赋值
        * 如有需要，可在仪器类中重写该函数
        */
        public virtual void decodeSetMessage(ModbusMessage s) 
        {
            foreach (DictionaryEntry de in s.Data)
            {
                DataOperate.WriteAny((String)de.Key, Code, de.Value);
            } 
        }
        /*
        * decodeCmdMessage函数，处理CMD命令的函数
        * 虚函数实现，可根据需要在仪器类中实现相关处理方法
        */
        public virtual void decodeCmdMessage(ModbusMessage s) { }
        /*
         * 接受数据函数，每次收到数据会自动调用该函数进行解析成ModBusMessage
         * 该函数会根据MessageType去调用不同的解析函数
         */
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
