using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Timers;
using DeviceUtils;

namespace Instrument
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

        public static String createMDFCodesReport(String WhichStack, String WhichDish, String BarCode) 
        {
            ModbusMessageDataCreator creator = new ModbusMessageDataCreator();
            creator.addKeyPair("ReportType","MDF");
            creator.addKeyPair("MDF_WhichStack", WhichStack);
            creator.addKeyPair("MDF_WhichDish", WhichDish);
            creator.addKeyPair("MDF_BarCode", BarCode);
            return ModbusMessageHelper.createModbusMessage(ModbusMessage.messageTypeToByte(ModbusMessage.MessageType.REPORT),creator.getDataBytes());
        }

        public static String createMPFCodesReport(String Whichplate, String BarCode) 
        {
            ModbusMessageDataCreator creator = new ModbusMessageDataCreator();
            creator.addKeyPair("ReportType", "MPF");
            creator.addKeyPair("MPF_Whichplate", Whichplate);
            creator.addKeyPair("MPF_BarCode", BarCode);
            return ModbusMessageHelper.createModbusMessage(ModbusMessage.messageTypeToByte(ModbusMessage.MessageType.REPORT), creator.getDataBytes());

        }


        public static String createMDFCurrencyReport(String[] currency)   
        {
            ModbusMessageDataCreator creator = new ModbusMessageDataCreator();
            creator.addKeyPair("ReportType", "MDF_Current");
            String[] s = { "MDF_Current1", "MDF_Current2", "MDF_Current3", "MDF_Current4" };
            for (int i = 0; i < s.Length; i++) 
            {
                creator.addKeyPair(s[i],currency[i]);
            }
            return ModbusMessageHelper.createModbusMessage(ModbusMessage.messageTypeToByte(ModbusMessage.MessageType.REPORT), creator.getDataBytes());

        }

        public static String createMPFCurrencyReport(String[] currency)
        {
            ModbusMessageDataCreator creator = new ModbusMessageDataCreator();
            creator.addKeyPair("ReportType", "MPF_Current");
            String[] s = { "MPF_Current1", "MPF_Current2", "MPF_Current3", "MPF_Current4" };
            for (int i = 0; i < s.Length; i++)
            {
                creator.addKeyPair(s[i], currency[i]);
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

        /// <summary>
        /// MDF parameters
        /// </summary>
        public int MDF_NumsperStack;
        public double MDF_VolsperDish;
        public int MDF_RunningError;
        public int FenZhuangShiJian;
        public int MDF_CurSamTime;
        public string MDF_Cmd;
        public double MDF_Current1;
        public double MDF_Current2;
        public double MDF_Current3;
        public double MDF_Current4;
        private int MDF_WhichStack = 1;
        private int MDF_WhichDish = 1;
        public string MDF_BarCode;
        /// <summary>
        /// MPF parameters
        /// </summary>
        public int MPF_PlateNum;
        public double MPF_Volsperwell;
        public int MPF_CurSamTime;
        public string MPF_Cmd;
        private int MPF_Whichplate = 1;
        public int MPF_RunningError;
        public double MPF_Current1;
        public double MPF_Current2;
        public double MPF_Current3;
        public double MPF_Current4;
        public string MPF_BarCode;


        private System.Timers.Timer caiYangTimer = null;
        private System.Timers.Timer fenZhuangTimer = null;

        private object KeyObject = new object();

        public int getLeft() 
        {
            lock (KeyObject) 
            {
                if (SubType == AutoDispenType.PeiYangMin)
                {
                    return (MDF_NumsperStack - MDF_WhichStack) * 36 + 36 - MDF_WhichDish;
                }
                else
                {
                    return 97 - MPF_Whichplate;
                }
            }
        }

        private void resetFenZhuangZhuangTai()
        {
            lock (KeyObject) 
            {
                MDF_WhichStack = 1;
                MDF_WhichDish = 1;
                MPF_Whichplate = 1;
            }
        }

        private void increaseFenZhuangZhuangTai()
        {
            lock (KeyObject)
            {
                if (SubType == AutoDispenType.PeiYangMin)
                {
                    MDF_WhichDish++;
                    if (MDF_WhichDish > 36) 
                    {
                        MDF_WhichStack++;
                        MDF_WhichDish = 1;
                    }
                    if (MDF_WhichStack > MDF_NumsperStack) 
                    {
                        MDF_WhichStack = 1;
                        fenZhuangTimer.Stop();
                    }
                }
                else
                {
                    MPF_Whichplate++;
                    if (MPF_Whichplate > 96) 
                    {
                        MPF_Whichplate = 1;
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
                    peiyangminhao = MDF_WhichDish.ToString();
                    duimahao = MDF_WhichStack.ToString();
                }
                else
                {
                    kongbanhao = MPF_Whichplate.ToString();
                }
            }
            tiaomahao = TiaoMaHaoGenerator.generateTiaoMaHao();
            increaseFenZhuangZhuangTai();
            String msg;
            if (subType == AutoDispenType.PeiYangMin)
            {
                MDF_BarCode = tiaomahao;
                msg = AutoDispenDeviceMessageCreator.createMDFCodesReport(duimahao, peiyangminhao, tiaomahao);
            }
            else
            {
                MPF_BarCode = tiaomahao;
                msg = AutoDispenDeviceMessageCreator.createMPFCodesReport(kongbanhao, tiaomahao);
            }

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
            if (subType == AutoDispenType.PeiYangMin)
            {
                String[] currencies = new String[] { MDF_Current1.ToString(), MDF_Current2.ToString(), MDF_Current3.ToString(), MDF_Current4.ToString() };
                String msg = AutoDispenDeviceMessageCreator.createMDFCurrencyReport(currencies);
                SendMsg(msg);
            }
            else
            {
                String[] currencies = new String[] { MPF_Current1.ToString(), MPF_Current2.ToString(), MPF_Current3.ToString(), MPF_Current4.ToString() };
                String msg = AutoDispenDeviceMessageCreator.createMPFCurrencyReport(currencies);
                SendMsg(msg);
            }
        }
        public void startTimers() 
        {

            if (fenZhuangTimer != null) fenZhuangTimer.Stop();
            if (caiYangTimer != null) caiYangTimer.Stop();
            fenZhuangTimer = new System.Timers.Timer();
            fenZhuangTimer.Interval = FenZhuangShiJian * 1000;
            fenZhuangTimer.Elapsed += new System.Timers.ElapsedEventHandler(fenZhuangTimer_Elapsed);

            caiYangTimer = new System.Timers.Timer();

            if (subType == AutoDispenType.PeiYangMin)
            {
                caiYangTimer.Interval = MDF_CurSamTime * 1000;
            }
            else
            {
                caiYangTimer.Interval = MPF_CurSamTime * 1000;
            }

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
                MPF_Whichplate = 1;
                MDF_WhichDish = 1;
                MDF_WhichStack = 1;
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
            if ("MDF_NumAndVol".Equals(setType)) 
            {
                this.MDF_NumsperStack = Int32.Parse((String)msg.Data["MDF_NumsperStack"]);
                this.MDF_VolsperDish = double.Parse((String)msg.Data["MDF_VolsperDish"]);
            }
            if ("MPF_NumAndVol".Equals(setType))
            {
                this.MPF_PlateNum = Int32.Parse((String)msg.Data["MPF_PlateNum"]);
                this.MPF_Volsperwell = double.Parse((String)msg.Data["MPF_Volsperwell"]);
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
