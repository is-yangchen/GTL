using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GTLutils;

namespace CentralControl
{
    public class AutoDispenDeviceMessageCreator
    {

        public static String createCmd(String cmd) 
        {
            ModbusMessageDataCreator creator = new ModbusMessageDataCreator();
            creator.addKeyPair("Cmd", cmd);
            return ModbusMessageHelper.createModbusMessage(ModbusMessage.messageTypeToByte(ModbusMessage.MessageType.CMD), creator.getDataBytes());
        }

        public static String createSetNumAndVol(String Num, String Vol) 
        {
            ModbusMessageDataCreator creator = new ModbusMessageDataCreator();
            creator.addKeyPair("SetType", "NumAndVol");
            creator.addKeyPair("Num", Num);
            creator.addKeyPair("Vol", Vol);
            return ModbusMessageHelper.createModbusMessage(ModbusMessage.messageTypeToByte(ModbusMessage.MessageType.SET), creator.getDataBytes());
        }

        public static String createOKResponse()
        {
            ModbusMessageDataCreator creator = new ModbusMessageDataCreator();
            creator.addKeyPair("Result", "OK");
            return ModbusMessageHelper.createModbusMessage(ModbusMessage.messageTypeToByte(ModbusMessage.MessageType.RESPONSE), creator.getDataBytes());
        }

        public static String createPeiYangCodesReport(String DuiMaHao, String PeiYangMinHao, String TiaoMaHao)
        {
            ModbusMessageDataCreator creator = new ModbusMessageDataCreator();
            creator.addKeyPair("ReportType", "PeiYangCode");
            creator.addKeyPair("DuiMaHao", DuiMaHao);
            creator.addKeyPair("PeiYangMinHao", PeiYangMinHao);
            creator.addKeyPair("TiaoMaHao", TiaoMaHao);
            return ModbusMessageHelper.createModbusMessage(ModbusMessage.messageTypeToByte(ModbusMessage.MessageType.REPORT), creator.getDataBytes());
        }

        public static String createShenKongCodesReport(String KongBanHao, String TiaoMaHao)
        {
            ModbusMessageDataCreator creator = new ModbusMessageDataCreator();
            creator.addKeyPair("ReportType", "ShenKongCode");
            creator.addKeyPair("KongBanHao", KongBanHao);
            creator.addKeyPair("TiaoMaHao", TiaoMaHao);
            return ModbusMessageHelper.createModbusMessage(ModbusMessage.messageTypeToByte(ModbusMessage.MessageType.REPORT), creator.getDataBytes());

        }


        public static String createCurrencyReport(String[] currency)
        {
            ModbusMessageDataCreator creator = new ModbusMessageDataCreator();
            creator.addKeyPair("ReportType", "Currency");
            String[] s = { "Currency1", "Currency2", "Currency3"};
            for (int i = 0; i < s.Length; i++)
            {
                creator.addKeyPair(s[i], currency[i]);
            }
            return ModbusMessageHelper.createModbusMessage(ModbusMessage.messageTypeToByte(ModbusMessage.MessageType.REPORT), creator.getDataBytes());

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

        private int Num;
        public int getNum() { return this.Num; }
        private double Vol;
        public double getVol() { return this.Vol; }

        public int YunXingChuCuoBiaoZhi;
        public double DianLiu1;
        public double DianLiu2;
        public double Dianliu3;
        public int Dianliu4;

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

        private void decodeResponseMessage(ModbusMessage msg)
        {
            String s = AutoDispenDeviceMessageCreator.createOKResponse();
            this.SendMsg(s);
        }

        private void decodeReportMessage(ModbusMessage msg)//解码报告消息
        {
            String reportType = (String)msg.Data["ReportType"];
            if ("Currency".Equals(reportType)) 
            {
                
                DianLiu1 = double.Parse((String)msg.Data["Currency1"]);
                DianLiu2 = double.Parse((String)msg.Data["Currency2"]);
                Dianliu3 = double.Parse((String)msg.Data["Currency3"]);
                //插入数据库
                Database mydb = new Database();
                mydb.insertop((int)DianLiu1, (int)DianLiu2, (int)Dianliu3, 0, "", 1, 1);
            }
            if ("ShenKongBan".Equals(reportType))
            {
                String KongBanHao = (String)msg.Data["KongBanHao"];
                String TiaoMaHao = (String)msg.Data["TiaoMaHao"];
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
                mydb.insertmb((int)DianLiu1, (int)DianLiu2, (int)Dianliu3, 0, TiaoMaHao, 1, 1);
            }
            if ("PeiYangMin".Equals(reportType)) 
            {
                String DuiMaHao = (String)msg.Data["DuiMaHao"];
                String PeiYangMinHao = (String)msg.Data["PeiYangMinHao"];
                String TiaoMaHao = (String)msg.Data["TiaoMaHao"];
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
                mydb.insertop((int)DianLiu1, (int)DianLiu2, (int)Dianliu3, 0, TiaoMaHao, 1, 1);
            }
        }

        private void decodeSetMessage(ModbusMessage msg)
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
