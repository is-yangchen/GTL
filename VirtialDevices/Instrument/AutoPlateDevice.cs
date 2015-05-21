using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Timers;
using DeviceUtils;

namespace Instrument
{
    public class AutoPlateDeviceMessageCreator
    {

        public static String createCmd(String cmd)
        {
            ModbusMessageDataCreator creator = new ModbusMessageDataCreator();
            creator.addKeyPair("Cmd", cmd);
            return ModbusMessageHelper.createModbusMessage(ModbusMessage.messageTypeToByte(ModbusMessage.MessageType.CMD), creator.getDataBytes());
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

        public static String createMPFCodesReport(String Whichplate, String BarCode)
        {
            ModbusMessageDataCreator creator = new ModbusMessageDataCreator();
            creator.addKeyPair("ReportType", "MPF");
            creator.addKeyPair("MPF_Whichplate", Whichplate);
            creator.addKeyPair("MPF_BarCode", BarCode);
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

    public class MPFDispenMessage
    {
        public String Barcode;
        public String PlateNum;

        public MPFDispenMessage()
        {
            Barcode = PlateNum = "";
        }

    }

    public class AutoPlateDevice : BaseVirtualDevice
    {
        /// <summary>
        /// MPF parameters
        /// </summary>
        public int MPF_PlateNum;
        public double MPF_Volsperwell;
        public int MPF_CurSamTime;
        public string MPF_Cmd;
        public int MPF_Whichplate = 1;
        public int MPF_RunningError;
        public int FenZhuangShiJian;
        public double MPF_Current1;
        public double MPF_Current2;
        public double MPF_Current3;
        public double MPF_Current4;
        public string MPF_BarCode;

        /// <summary>
        /// Others
        /// </summary>
        private List<MPFDispenMessage> FenZhuangMessages = new List<MPFDispenMessage>();

        private bool needRefreshMessages = false;
        private Object RefreshObject = new Object();
        private object KeyObject = new object();

        private System.Timers.Timer caiYangTimer = null;
        private System.Timers.Timer fenZhuangTimer = null;

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
        public List<MPFDispenMessage> getFenZhuangMessages()
        {
            List<MPFDispenMessage> res = new List<MPFDispenMessage>();
            lock (FenZhuangMessages)
            {
                foreach (MPFDispenMessage xinXin in FenZhuangMessages)
                {
                    res.Add(xinXin);
                }
            }
            return res;
        }

        public int getLeft()
        {
            lock (KeyObject)
            {
                return 97 - MPF_Whichplate;
            }
        }

        private void resetFenZhuangZhuangTai()
        {
            lock (KeyObject)
            {
                MPF_Whichplate = 1;
            }
        }

        private void increaseFenZhuangZhuangTai()
        {
            lock (KeyObject)
            {
                MPF_Whichplate++;
                if (MPF_Whichplate > 96)
                {
                    MPF_Whichplate = 1;
                    fenZhuangTimer.Stop();
                }
            }
        }

        private String createFenZhuangMessage()
        {
            String tiaomahao = "";
            String kongbanhao = "";

            lock (KeyObject)
            {
                kongbanhao = MPF_Whichplate.ToString();
            }
            tiaomahao = TiaoMaHaoGenerator.generateTiaoMaHao();
            increaseFenZhuangZhuangTai();
            String msg;
            MPF_BarCode = tiaomahao;
            msg = AutoPlateDeviceMessageCreator.createMPFCodesReport(kongbanhao, tiaomahao);

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
            String[] currencies = new String[] { MPF_Current1.ToString(), MPF_Current2.ToString(), MPF_Current3.ToString(), MPF_Current4.ToString() };
            String msg = AutoPlateDeviceMessageCreator.createMPFCurrencyReport(currencies);
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
            caiYangTimer.Interval = MPF_CurSamTime * 1000;
            caiYangTimer.Elapsed += new System.Timers.ElapsedEventHandler(caiYangTimer_Elapsed);
            caiYangTimer.Start();
        }

        public override void decodeResponseMessage(ModbusMessage msg)
        {
            String s = AutoDispenDeviceMessageCreator.createOKResponse();
            this.SendMsg(s);
        }

        public override void decodeReportMessage(ModbusMessage msg)//解码报告消息
        {
            String reportType = (String)msg.Data["ReportType"];

            if ("MPF_Current".Equals(reportType))
            {

                MPF_Current1 = double.Parse((String)msg.Data["MPF_Current1"]);
                MPF_Current2 = double.Parse((String)msg.Data["MPF_Current2"]);
                MPF_Current3 = double.Parse((String)msg.Data["MPF_Current3"]);
                MPF_Current4 = double.Parse((String)msg.Data["MPF_Current4"]);
            }
            if ("MPF".Equals(reportType))
            {
                String PlateNum = (String)msg.Data["MPF_Whichplate"];
                String Barcode = (String)msg.Data["MPF_BarCode"];
                MPFDispenMessage xinXi = new MPFDispenMessage();
                xinXi.PlateNum = PlateNum;
                xinXi.Barcode = Barcode;
                lock (FenZhuangMessages)
                {
                    FenZhuangMessages.Add(xinXi);
                }
                lock (RefreshObject)
                {
                    needRefreshMessages = true;
                }
            }
        }



        public override void decodeCmdMessage(ModbusMessage msg)
        {
            String cmd = (String)msg.Data["Cmd"];
            if ("Start".Equals(cmd))
            {
                fenZhuangTimer.Start();
            }
            if ("Reset".Equals(cmd))
            {
                MPF_Whichplate = 1;
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

        public override void decodeSetMessage(ModbusMessage msg)
        {
            String setType = (String)msg.Data["SetType"];
            if ("MPF_NumAndVol".Equals(setType))
            {
                this.MPF_PlateNum = Int32.Parse((String)msg.Data["MPF_PlateNum"]);
                this.MPF_Volsperwell = double.Parse((String)msg.Data["MPF_Volsperwell"]);
            }
        }
    }
}

