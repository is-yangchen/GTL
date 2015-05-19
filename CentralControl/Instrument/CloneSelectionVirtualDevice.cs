using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GTLutils;

namespace Instrument
{
    public class CloneSelectionDeviceMessageCreator
    {
        public static String createSetLowAndUpp(String Lower, String Upper)
        {
            ModbusMessageDataCreator creator = new ModbusMessageDataCreator();
            creator.addKeyPair("SetType", "ZhouChangMianJiBi");
            creator.addKeyPair("ZhouChangMianJiBi_Max", Upper);
            creator.addKeyPair("ZhouChangMianJiBi_Min", Lower);
            return ModbusMessageHelper.createModbusMessage(ModbusMessage.messageTypeToByte(ModbusMessage.MessageType.SET), creator.getDataBytes());
        }

        public static String createSetMianJiLowAndUpp(String Lower, String Upper)
        {
            ModbusMessageDataCreator creator = new ModbusMessageDataCreator();
            creator.addKeyPair("SetType", "MianJiShaiXuan");
            creator.addKeyPair("MianJi_Max", Upper);
            creator.addKeyPair("MianJi_Min", Lower);
            return ModbusMessageHelper.createModbusMessage(ModbusMessage.messageTypeToByte(ModbusMessage.MessageType.SET), creator.getDataBytes());
        }

        public static String createSetMieJun(String arg1, String arg2, String arg3, String arg4, String arg5)
        {
            ModbusMessageDataCreator creator = new ModbusMessageDataCreator();
            creator.addKeyPair("SetType", "MieJunHeQingXi");
            creator.addKeyPair("JiaReShiJian", arg1);
            creator.addKeyPair("QingXiCiShu", arg2);
            creator.addKeyPair("LengQueShiJian", arg3);
            creator.addKeyPair("QingXiShiJian", arg4);
            creator.addKeyPair("ChouQiShiJian", arg5);
            return ModbusMessageHelper.createModbusMessage(ModbusMessage.messageTypeToByte(ModbusMessage.MessageType.SET), creator.getDataBytes());
        }

        
    }
    public class CloneSelectionVirtualDevice : BaseVirtualDevice
    {

        private double ZhouChangMianJiBi_Max = 0.0;
        private double ZhouChangMianJiBi_Min = 0.0;
        private double MianJi_Max = 3.0;
        private double MianJi_Min = 2.0;
        private double ChangJing_Max = 3.0;
        private double ChangJing_Min = 2.5;
        private double DuanJin_Max = 7.0;
        private double DuanJin_Min = 6.0;
        private double BiZhi_Max = 4.0;
        private double BiZhi_Min = 3.0;
        private Int16 R = 18;
        private Int16 G = 21;
        private Int16 B = 75;

        public double getZhouChangMianJiBi_Max() { return this.ZhouChangMianJiBi_Max; }
        public double getZhouChangMianJiBi_Min() { return this.ZhouChangMianJiBi_Min; }
        public double getMianJi_Max() { return this.MianJi_Max; }
        public double getMianJi_Min() { return this.MianJi_Min; }
        public double getChangJing_Max() { return this.ChangJing_Max; }
        public double getChangJing_Min() { return this.ChangJing_Min; }
        public double getDuanJing_Max() { return this.DuanJin_Max; }
        public double getDuanJing_Min() { return this.DuanJin_Min; }
        public double getBiZhi_Max() { return this.BiZhi_Max; }
        public double getBiZhi_Min() { return this.BiZhi_Min; }
        public Int16 getR() { return this.R; }
        public Int16 getG() { return this.G; }
        public Int16 getB() { return this.B; }

        public void setZhouChangMianJiBi_Max(string max) {  ZhouChangMianJiBi_Max = double.Parse(max); }
        public void setZhouChangMianJiBi_Min(string min) {  ZhouChangMianJiBi_Min = double.Parse(min); }

        public override void ReceiveMsg(String s)
        {
            ModbusMessage message = ModbusMessageHelper.decodeModbusMessage(s);
            //switch (message.MsgType)
            {

            }
        }
    }


}
