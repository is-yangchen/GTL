using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Timers;

namespace VirtialDevices
{
    public class AutoDispenDeviceMessageInterpreter 
    {
        
        
    }

    public class AutoDispenDeviceMessageCreator 
    {

        public static String createOKResponse() 
        {
            ModbusMessageDataCreator creator = new ModbusMessageDataCreator();
            creator.addKeyPair("Result", "OK");
            return ModbusMessageHelper.createModbusMessage(ModbusMessage.messageTypeToByte(ModbusMessage.MessageType.RESPONSE),creator.getDataBytes());
        }

        public static String createPeiYangCodesReport(String DuiMaHao, String PeiYangMinHao, String TiaoMaHao) 
        {
            ModbusMessageDataCreator creator = new ModbusMessageDataCreator();
            creator.addKeyPair("ReportType","PeiYangMin");
            creator.addKeyPair("DuiMaHao",DuiMaHao);
            creator.addKeyPair("PeiYangMinHao", PeiYangMinHao);
            creator.addKeyPair("TiaoMaHao", TiaoMaHao);
            return ModbusMessageHelper.createModbusMessage(ModbusMessage.messageTypeToByte(ModbusMessage.MessageType.REPORT),creator.getDataBytes());
        }

        public static String createShenKongCodesReport(String KongBanHao, String TiaoMaHao) 
        {
            ModbusMessageDataCreator creator = new ModbusMessageDataCreator();
            creator.addKeyPair("ReportType", "ShenKongBan");
            creator.addKeyPair("KongBanHao", KongBanHao);
            creator.addKeyPair("TiaoMaHao", TiaoMaHao);
            return ModbusMessageHelper.createModbusMessage(ModbusMessage.messageTypeToByte(ModbusMessage.MessageType.REPORT), creator.getDataBytes());

        }


        public static String createCurrencyReport(String[] currency)   
        {
            ModbusMessageDataCreator creator = new ModbusMessageDataCreator();
            creator.addKeyPair("ReportType", "Currency");
            String[] s = { "Currency1","Currency2","Currency3"};
            for (int i = 0; i < s.Length; i++) 
            {
                creator.addKeyPair(s[i],currency[i]);
            }
            return ModbusMessageHelper.createModbusMessage(ModbusMessage.messageTypeToByte(ModbusMessage.MessageType.REPORT), creator.getDataBytes());

        }

    }

    public class AutoDispenDevice : BaseVirtualDevice
    {
        public enum AutoDispenType { PeiYangMin, ShenKongBan};
        public enum AutoDispenCmdType {RESET, START, STOP, SET};


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
        public int FenZhuangShiJian;
        public int CaiYangShiJian;
        public double DianLiu1;
        public double DianLiu2;
        public double Dianliu3;

        private System.Timers.Timer caiYangTimer = null;
        private System.Timers.Timer fenZhuangTimer = null;


        private int DuiMaHao = 1;
        private int PeiYangMinHao = 1;
        private int KongBanHao = 1;
        private object KeyObject = new object();

        public int getLeft() 
        {
            lock (KeyObject) 
            {
                if (SubType == AutoDispenType.PeiYangMin)
                {
                    return (Num - DuiMaHao) * 36 + 36 - PeiYangMinHao;
                }
                else
                {
                    return 97 - KongBanHao;
                }
            }
        }

        private void resetFenZhuangZhuangTai()
        {
            lock (KeyObject) 
            {
                DuiMaHao = 1;
                PeiYangMinHao = 1;
                KongBanHao = 1;
            }
        }

        private void increaseFenZhuangZhuangTai()
        {
            lock (KeyObject)
            {
                if (SubType == AutoDispenType.PeiYangMin)
                {
                    PeiYangMinHao++;
                    if (PeiYangMinHao > 36) 
                    {
                        DuiMaHao++;
                        PeiYangMinHao = 1;
                    }
                    if (DuiMaHao > Num) 
                    {
                        DuiMaHao = 1;
                        fenZhuangTimer.Stop();
                    }
                }
                else
                {
                    KongBanHao++;
                    if (KongBanHao > 96) 
                    {
                        KongBanHao = 1;
                        fenZhuangTimer.Stop();
                    }
                }
            }
        }

        private String createFenZhuangMessage() 
        {
            String duimahao = "";
            String peiyangminhao = "";
            String tiaomahao = "";
            String kongbanhao = "";

            lock (KeyObject) 
            {
                if (SubType == AutoDispenType.PeiYangMin)
                {
                    peiyangminhao = PeiYangMinHao.ToString();
                    duimahao = DuiMaHao.ToString();
                }
                else
                {
                    kongbanhao = KongBanHao.ToString();
                }
            }
            tiaomahao = TiaoMaHaoGenerator.generateTiaoMaHao();
            increaseFenZhuangZhuangTai();
            String msg;
            if (subType == AutoDispenType.PeiYangMin) msg = AutoDispenDeviceMessageCreator.createPeiYangCodesReport(duimahao, peiyangminhao, tiaomahao);
            else msg = AutoDispenDeviceMessageCreator.createShenKongCodesReport(kongbanhao, tiaomahao);
            return msg;
        }

        private void fenZhuangTimer_Elapsed(object sender, ElapsedEventArgs e) 
        {
            String msg = "";
            msg = createFenZhuangMessage();
            SendMsg(msg);
        }

        private void caiYangTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            String[] currencies = new String[] { DianLiu1.ToString(),DianLiu2.ToString(),Dianliu3.ToString()};
            String msg = AutoDispenDeviceMessageCreator.createCurrencyReport(currencies);
            SendMsg(msg);
        }
        public void startTimers() 
        {

            if (fenZhuangTimer != null) fenZhuangTimer.Stop();
            if (caiYangTimer != null) caiYangTimer.Stop();
            fenZhuangTimer = new System.Timers.Timer();
            fenZhuangTimer.Interval = FenZhuangShiJian * 1000;
            fenZhuangTimer.Elapsed += new System.Timers.ElapsedEventHandler(fenZhuangTimer_Elapsed);

            caiYangTimer = new System.Timers.Timer();
            caiYangTimer.Interval = CaiYangShiJian * 1000;
            caiYangTimer.Elapsed += new System.Timers.ElapsedEventHandler(caiYangTimer_Elapsed);
            caiYangTimer.Start();
        }

        private void decodeCmdMessage(ModbusMessage msg)
        {
            String cmd = (String)msg.Data["Cmd"];
            if ("Start".Equals(cmd))
            {
                fenZhuangTimer.Start();
            }
            if ("Reset".Equals(cmd)) 
            {
                KongBanHao = 1;
                PeiYangMinHao = 1;
                DuiMaHao = 1;
            }
            if ("Stop".Equals(cmd))
            {
                fenZhuangTimer.Stop();
            }
            if ("Auto".Equals(cmd)) 
            {
                
            }
            String s = AutoDispenDeviceMessageCreator.createOKResponse();
            this.SendMsg(s);
        }

        private void decodeSetMessage(ModbusMessage msg)
        {
            String setType = (String)msg.Data["SetType"];
            if ("NumAndVol".Equals(setType)) 
            {
                this.Num = Int32.Parse((String)msg.Data["Num"]);
                this.Vol = double.Parse((String)msg.Data["Vol"]);
            }
        }

        public override void ReceiveMsg(String s)
        {
            ModbusMessage message = ModbusMessageHelper.decodeModbusMessage(s);
            switch (message.MsgType) 
            {
                case ModbusMessage.MessageType.CMD:
                    decodeCmdMessage(message);
                    break;
                case ModbusMessage.MessageType.SET:
                    decodeSetMessage(message);
                    break;
                case ModbusMessage.MessageType.GET:
                    break;
            }
        }
    }
}
