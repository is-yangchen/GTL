using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections; 

namespace DeviceUtils
{

    public class ModbusMessage
    {

        public enum MessageType { CMD, RESPONSE, GET,SET, REPORT };

        public static MessageType byteToMessageType(byte f) 
        {
            if (f == 0x88) return MessageType.CMD;
            if (f == 0x01) return MessageType.RESPONSE;
            if (f == 0x02) return MessageType.GET;
            if (f == 0x03) return MessageType.SET;
            if (f == 0x04) return MessageType.REPORT;
            return MessageType.CMD;
        }

        public static byte messageTypeToByte(MessageType t) 
        {
            switch (t)
            {
                case MessageType.CMD:
                    return 0x88;
                case MessageType.RESPONSE:
                    return 0x01;
                case MessageType.GET:
                    return 0x02;
                case MessageType.SET:
                    return 0x03;
                case MessageType.REPORT:
                    return 0x04;
            }
            return 0x00;
        }

        private byte dev;
        public byte Dev 
        {
            get 
            {
                return this.dev;
            }
            set 
            {
                this.dev = value;
            }
        }

        private MessageType msgType;
        public MessageType MsgType 
        {
            get 
            {
                return this.msgType;
            }
            set 
            {
                this.msgType = value;
            }
        }

        private Hashtable data;
        public Hashtable Data 
        {
            get 
            {
                return this.data;
            }
            set 
            {
                this.data = value;
            }
        }

        public ModbusMessage() { }
    }

    public class ModbusMessageDataCreator
    {
        private String data;
        public ModbusMessageDataCreator()
        {
            data = "";
        }

        public void addKeyPair(String key, String value) 
        {
            data += key + "=" + value + ";";
        }

        public byte[] getDataBytes() 
        {
            return Encoding.Default.GetBytes(data);
        }
    }

    public class ModbusMessageHelper
    {

        public static String createModbusMessage(byte func, byte[] data,byte dev = 0x88) 
        {
            byte[] cmd = new byte[6+data.Length];
            cmd[0] = 0x55;
            cmd[1] = 0xAA;
            cmd[2] = (byte)(data.Length + 3);
            cmd[3] = dev;
            cmd[4] = func;
            for (int i = 0; i < data.Length; i++) 
            {
                cmd[i + 5] = data[i];
            }
            byte crc = 0x00;
            for (int i = 0; i < data.Length + 5; i++) 
            {
                crc ^= cmd[i];
            }
            cmd[data.Length + 5] = crc;
            return StringByteHelper.BytesToString(cmd,0,cmd.Length);
        }


        private static bool check_modbus_message(byte[] cmd) 
        {
            if (cmd.Length < 6) return false;
            int len = cmd[2];
            if (len != cmd.Length - 3) return false;
            byte crc = 0x00;
            for (int i = 0; i < cmd.Length - 1; i++) 
            {
                crc ^= cmd[i];
            }
            //if (crc != cmd[cmd.Length - 1]) return false;
            return true;
        }

        public static ModbusMessage decodeModbusMessage(String msg) 
        {
            ModbusMessage res = new ModbusMessage();
            byte[] cmd = StringByteHelper.StringToBytes(msg);
            if (!check_modbus_message(cmd)) return null;
            res.Dev = cmd[3];
            res.MsgType = ModbusMessage.byteToMessageType(cmd[4]);
            int len = cmd[2] - 3;
            byte[] data = new byte[len];
            for(int i=0;i<len;i++)
            {
                data[i] = cmd[i+5];
            }
            String s = Encoding.Default.GetString(data);
            Hashtable map = new Hashtable();
            String[] words = s.Split(';');
            String[] parts;
            for (int i = 0; i < words.Length; i++) 
            {
                if (words[i].Length == 0) continue;
                parts = words[i].Split('=');
                if (parts.Length != 2) return null;
                map.Add(parts[0], parts[1]);
            }
            res.Data = map;
            return res;
        }

        public static string forshow(string msg)
        {
            string tmp;
            byte[] tmp2;
            tmp2 = StringByteHelper.StringToBytes(msg);
            tmp = Encoding.GetEncoding("gb2312").GetString(tmp2,5,tmp2.Length-6);
            return tmp;
        }
    }
}
