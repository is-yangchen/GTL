using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;
using DeviceUtils;

namespace Instrument
{

    public class CloneSelectionDeviceMessageCreator
    {

        public static String createOKResponse()
        {
            ModbusMessageDataCreator creator = new ModbusMessageDataCreator();
            creator.addKeyPair("Result", "OK");
            return ModbusMessageHelper.createModbusMessage(ModbusMessage.messageTypeToByte(ModbusMessage.MessageType.RESPONSE), creator.getDataBytes());
        }

    }

    public class CloneSelectionDevice : BaseVirtualDevice
    {
        public static int JianCeHangShu = 12;

        private UInt32 JiaReShiJian = 0;
        private UInt32 QingXiShiJian = 0;
        private UInt32 LengQueShiJian = 0;
        private UInt32 QingXiCiShu = 0;
        private UInt32 ChouQiShiJian = 0;
        private double ZhouChangMianJiBi_Max = 0.0;
        private double ZhouChangMianJiBi_Min = 0.0;
        private double MianJi_Max = 3.0;
        private double MianJi_Min = 2.0;
        private double ChangJing_Max = 3.0;
        private double ChangJing_Min = 2.5;
        private double DuanJing_Max = 7.0;
        private double DuanJing_Min = 6.0;
        private double BiZhi_Max = 4.0;
        private double BiZhi_Min = 3.0;
        private Int16 R = 18;
        private Int16 G = 21;
        private Int16 B = 75;

        public UInt32 getJiaReShiJian() { return this.JiaReShiJian; }
        public UInt32 getQingXiShiJian() { return this.QingXiShiJian; }
        public UInt32 getQingXiCiShu() { return this.QingXiCiShu; }
        public UInt32 getChouQiShiJian() { return this.ChouQiShiJian; }
        public UInt32 getLengQueShiJian() { return this.LengQueShiJian; }
        public double getZhouChangMianJiBi_Max() { return this.ZhouChangMianJiBi_Max; }
        public double getZhouChangMianJiBi_Min() { return this.ZhouChangMianJiBi_Min; }
        public double getMianJi_Max() { return this.MianJi_Max; }
        public double getMianJi_Min() { return this.MianJi_Min; }
        public double getChangJing_Max() { return this.ChangJing_Max; }
        public double getChangJing_Min() { return this.ChangJing_Min; }
        public double getDuanJing_Max() { return this.DuanJing_Max; }
        public double getDuanJing_Min() { return this.DuanJing_Min; }
        public double getBiZhi_Max() { return this.BiZhi_Max; }
        public double getBiZhi_Min() { return this.BiZhi_Min; }
        public Int16  getR() { return this.R; }
        public Int16  getG() { return this.G; }
        public Int16  getB() { return this.B; }


        private void decodeSetMessage(ModbusMessage msg)
        {
            String setType = (String)msg.Data["SetType"];
            if ("ZhouChangMianJiBi".Equals(setType)) 
            {
                this.ZhouChangMianJiBi_Max = double.Parse((String)msg.Data["ZhouChangMianJiBi_Max"]);
                this.ZhouChangMianJiBi_Min = double.Parse((String)msg.Data["ZhouChangMianJiBi_Min"]);
            }

            if ("MianJiShaiXuan".Equals(setType))
            {
                this.MianJi_Max = double.Parse((String)msg.Data["MianJi_Max"]);
                this.MianJi_Min = double.Parse((String)msg.Data["MianJi_Min"]);
            } 

            if ("ChangDuanJingShaiXuan".Equals(setType))
            {
                this.ChangJing_Max = double.Parse((String)msg.Data["ChangJing_Max"]);
                this.ChangJing_Min = double.Parse((String)msg.Data["ChangJing_Min"]);
                this.DuanJing_Max = double.Parse((String)msg.Data["DuanJing_Max"]);
                this.DuanJing_Min = double.Parse((String)msg.Data["DuanJing_Min"]);
                this.BiZhi_Max = double.Parse((String)msg.Data["BiZhi_Max"]);
                this.BiZhi_Min = double.Parse((String)msg.Data["BiZhi_Min"]);
            } 

            if ("SeDuPingJunZhi".Equals(setType))
            {
                this.R = Int16.Parse((String)msg.Data["R"]);
                this.G = Int16.Parse((String)msg.Data["G"]);
                this.B = Int16.Parse((String)msg.Data["B"]);
            }

            if ("MieJunHeQingXi".Equals(setType))
            {
                this.JiaReShiJian = UInt32.Parse((String)msg.Data["JiaReShiJian"]);
                this.QingXiShiJian = UInt32.Parse((String)msg.Data["QingXiShiJian"]);
                this.QingXiCiShu = UInt32.Parse((String)msg.Data["QingXiCiShu"]);
                this.ChouQiShiJian = UInt32.Parse((String)msg.Data["ChouQiShiJian"]);
                this.LengQueShiJian = UInt32.Parse((String)msg.Data["LengQueShiJian"]);
            }

        }

        public override void ReceiveMsg(String s)
        {
            ModbusMessage message = ModbusMessageHelper.decodeModbusMessage(s);
            switch (message.MsgType) 
            {
                case ModbusMessage.MessageType.SET:
                    decodeSetMessage(message);
                    break;
            }
        }
    }

}
