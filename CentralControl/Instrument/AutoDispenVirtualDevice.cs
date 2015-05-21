using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GTLutils;

namespace Instrument
{
    public class AutoDispenDeviceMessageCreator
    {

        public static String createCmd(String cmd) 
        {
            ModbusMessageDataCreator creator = new ModbusMessageDataCreator();
            creator.addKeyPair("Cmd", cmd);
            return ModbusMessageHelper.createModbusMessage(ModbusMessage.messageTypeToByte(ModbusMessage.MessageType.CMD), creator.getDataBytes());
        }

        public static String createMDFSetNumAndVol(String Num, String Vol) 
        {
            ModbusMessageDataCreator creator = new ModbusMessageDataCreator();
            creator.addKeyPair("SetType", "MDF_NumAndVol");
            creator.addKeyPair("MDF_NumsperStack", Num);
            creator.addKeyPair("MDF_VolsperDish", Vol);
            return ModbusMessageHelper.createModbusMessage(ModbusMessage.messageTypeToByte(ModbusMessage.MessageType.SET), creator.getDataBytes());
        }

        public static String createMPFSetNumAndVol(String Num, String Vol)
        {
            ModbusMessageDataCreator creator = new ModbusMessageDataCreator();
            creator.addKeyPair("SetType", "MPF_NumAndVol");
            creator.addKeyPair("MPF_PlateNum", Num);
            creator.addKeyPair("MPF_Volsperwell", Vol);
            return ModbusMessageHelper.createModbusMessage(ModbusMessage.messageTypeToByte(ModbusMessage.MessageType.SET), creator.getDataBytes());
        }

        public static String createOKResponse()
        {
            ModbusMessageDataCreator creator = new ModbusMessageDataCreator();
            creator.addKeyPair("Result", "OK");
            return ModbusMessageHelper.createModbusMessage(ModbusMessage.messageTypeToByte(ModbusMessage.MessageType.RESPONSE), creator.getDataBytes());
        }
    }

    public class FenZhuangXinXi
    {
        public String TiaoMaHao;
        public String DuiMaHao;
        public String PeiYangMinHao;

        public FenZhuangXinXi()
        {
            TiaoMaHao = DuiMaHao = PeiYangMinHao = "";
        }
    
    }

    public class AutoDispenVirtualDevice : BaseVirtualDevice
    {
        public enum AutoDispenType { PeiYangMin, ShenKongBan };
        public enum AutoDispenCmdType { RESET, START, STOP, SET };


        private AutoDispenType subType;
        public AutoDispenType SubType
        {
            get
            {
                return this.subType;
            }
            set
            {
                this.subType = value;
            }
        }

        /// <summary>
        /// MDF parameters
        /// </summary>
        private int MDF_NumsperStack = 0;
        public int getNum() { return this.MDF_NumsperStack; }
        private double MDF_VolsperDish = 0;
        public double getVol() { return this.MDF_VolsperDish; }
        public int MDF_RunningError;
        public double MDF_Current1;
        public double MDF_Current2;
        public double MDF_Current3;
        public double MDF_Current4;
        public string MDF_Cmd;

        /// <summary>
        /// MPF parameters
        /// </summary>
        public int MPF_PlateNum;
        public double MPF_Volsperwell;
        public int MPF_CurSamTime;
        public string MPF_Cmd;
        public int MPF_RunningError;
        public double MPF_Current1;
        public double MPF_Current2;
        public double MPF_Current3;
        public double MPF_Current4;

        /// <summary>
        /// Others
        /// </summary>
        private List<FenZhuangXinXi> FenZhuangMessages = new List<FenZhuangXinXi>();

        private bool needRefreshMessages = false;
        private Object RefreshObject = new Object();

        public bool NeedRefreshMessages 
        {
            get
            {
                lock (RefreshObject)
                {
                    bool res = needRefreshMessages;
                    needRefreshMessages = false;
                    return res;
                }
            }
        }
        public List<FenZhuangXinXi> getFenZhuangMessages()
        {
            List<FenZhuangXinXi> res = new List<FenZhuangXinXi>();
            lock (FenZhuangMessages)
            {
                foreach (FenZhuangXinXi xinXin in FenZhuangMessages) 
                {
                    res.Add(xinXin);
                }
            }
            return res;
        }

        public override void decodeResponseMessage(ModbusMessage msg)
        {
            String s = AutoDispenDeviceMessageCreator.createOKResponse();
            this.SendMsg(s);
        }

        public override void decodeReportMessage(ModbusMessage msg)//解码报告消息
        {
            String reportType = (String)msg.Data["ReportType"];
            if ("MDF_Current".Equals(reportType)) 
            {

                MDF_Current1 = double.Parse((String)msg.Data["MDF_Current1"]);
                MDF_Current2 = double.Parse((String)msg.Data["MDF_Current2"]);
                MDF_Current3 = double.Parse((String)msg.Data["MDF_Current3"]);
                MPF_Current4 = double.Parse((String)msg.Data["MDF_Current4"]);
                //插入数据库
                Database mydb = new Database();
                mydb.insertop((int)MDF_Current1, (int)MDF_Current2, (int)MDF_Current3, (int)MDF_Current4, "", 1, 1);
            }
            if ("MPF_Current".Equals(reportType))
            {

                MPF_Current1 = double.Parse((String)msg.Data["MPF_Current1"]);
                MPF_Current2 = double.Parse((String)msg.Data["MPF_Current2"]);
                MPF_Current3 = double.Parse((String)msg.Data["MPF_Current3"]);
                MPF_Current4 = double.Parse((String)msg.Data["MPF_Current4"]);
                //插入数据库
                Database mydb = new Database();
                mydb.insertmb((int)MPF_Current1, (int)MPF_Current2, (int)MPF_Current3, (int)MPF_Current4, "", 1, 1);
            }
            if ("MPF".Equals(reportType))
            {
                String KongBanHao = (String)msg.Data["MPF_Whichplate"];
                String TiaoMaHao = (String)msg.Data["MPF_BarCode"];
                FenZhuangXinXi xinXi = new FenZhuangXinXi();
                xinXi.DuiMaHao = KongBanHao;
                xinXi.TiaoMaHao = TiaoMaHao;
                lock (FenZhuangMessages) 
                {
                    FenZhuangMessages.Add(xinXi);
                }
                lock (RefreshObject) 
                {
                    needRefreshMessages = true;
                }

                Database mydb = new Database();
                mydb.insertmb((int)MPF_Current1, (int)MPF_Current2, (int)MPF_Current3, (int)MPF_Current4, TiaoMaHao, 1, 1);
            }
            if ("MDF".Equals(reportType)) 
            {
                String DuiMaHao = (String)msg.Data["MDF_WhichStack"];
                String PeiYangMinHao = (String)msg.Data["MDF_WhichDish"];
                String TiaoMaHao = (String)msg.Data["MDF_BarCode"];
                FenZhuangXinXi xinXi = new FenZhuangXinXi();
                xinXi.DuiMaHao = DuiMaHao;
                xinXi.PeiYangMinHao = PeiYangMinHao;
                xinXi.TiaoMaHao = TiaoMaHao;
                lock (FenZhuangMessages)
                {
                    FenZhuangMessages.Add(xinXi);
                }
                lock (RefreshObject)
                {
                    needRefreshMessages = true;
                }

                Database mydb = new Database();
                mydb.insertop((int)MDF_Current1, (int)MDF_Current2, (int)MDF_Current3, (int)MDF_Current4, TiaoMaHao, 1, 1);
            }
        }

        public override void decodeSetMessage(ModbusMessage msg)
        {
            String setType = (String)msg.Data["SetType"];
            if ("BasicInfo".Equals(setType))
            {

            }
        }

        public override void ReceiveMsg(String s)
        {
            ModbusMessage message = ModbusMessageHelper.decodeModbusMessage(s);
            switch (message.MsgType)
            {
                case ModbusMessage.MessageType.RESPONSE:
                    decodeResponseMessage(message);
                    break;
                case ModbusMessage.MessageType.REPORT:
                    decodeReportMessage(message);
                    break;
                case ModbusMessage.MessageType.SET:
                    decodeSetMessage(message);
                    break;
            }
        }
    }
}
