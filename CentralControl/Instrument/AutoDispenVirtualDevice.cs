using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GTLutils;

namespace Instrument
{
    public class MDFDispenMessage
    {
        public String Barcode;//条码号
        public String Stackcode;//堆码号
        public String Petricode;//培养皿号
		
        public MDFDispenMessage()
        {
            Barcode = Stackcode = Petricode = "";
        }
    }

    public class AutoDispenVirtualDevice : BaseVirtualDevice
    {
        /// <summary>
        /// MDF parameters
        /// </summary>
        public int MDF_NumsperStack = 0;
        public double MDF_VolsperDish = 0;
        public double MDF_Current1;
        public double MDF_Current2;
        public double MDF_Current3;
        public double MDF_Current4;
        public int MDF_RunningError;
        public int MDF_DispenTime;
        public int MDF_CurSamTime;
        public int MDF_WhichStack = 1;
        public int MDF_WhichDish = 1;
        public string MDF_BarCode;
        public string MDF_Cmd;

        /// <summary>
        /// Others
        /// </summary>
        private List<MDFDispenMessage> DispenMessages = new List<MDFDispenMessage>();

        private bool needRefreshMessages = false;
        private Object RefreshObject = new Object();

        //private System.Timers.Timer samTimer = null;
        //private System.Timers.Timer dispenTimer = null;

        public void sendCmd(String cmd)
        {
            SendModBusMsg(ModbusMessage.MessageType.CMD, "Cmd", cmd);
        }

        public void sendMDFSetNumAndVol(String Num, String Vol)
        {
            Hashtable ht = new Hashtable();
            ht.Add("SetType", "MDF_NumAndVol");
            ht.Add("MDF_NumsperStack", Num);
            ht.Add("MDF_VolsperDish", Vol);
            SendModBusMsg(ModbusMessage.MessageType.SET, ht);
        }

        public void sendOKResponse()
        {
            SendModBusMsg(ModbusMessage.MessageType.RESPONSE, "Result", "OK");
        }

        public void sendMDFCodesReport(String WhichStack, String WhichDish, String BarCode)
        {
            Hashtable ht = new Hashtable();
            ht.Add("ReportType", "MDF");
            ht.Add("MDF_WhichStack", WhichStack);
            ht.Add("MDF_WhichDish", WhichDish);
            ht.Add("MDF_BarCode", BarCode);
            SendModBusMsg(ModbusMessage.MessageType.REPORT, ht);
        }

        public void sendMDFCurrencyReport(String[] currency)
        {
            Hashtable ht = new Hashtable();
            ht.Add("ReportType", "MDF_Current");
            String[] s = { "MDF_Current1", "MDF_Current2", "MDF_Current3", "MDF_Current4" };
            for (int i = 0; i < s.Length; i++)
            {
                ht.Add(s[i], currency[i]);
            }
            SendModBusMsg(ModbusMessage.MessageType.REPORT, ht);
        }

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
        public List<MDFDispenMessage> getDispenMessages()
        {
            List<MDFDispenMessage> res = new List<MDFDispenMessage>();
            lock (DispenMessages)
            {
                foreach (MDFDispenMessage xinXin in DispenMessages)
                {
                    res.Add(xinXin);
                }
            }
            return res;
        }

        public override void decodeResponseMessage(ModbusMessage msg)
        {
            this.sendOKResponse();
        }

        public override void decodeReportMessage(ModbusMessage msg)//解码报告消息
        {
            String reportType = (String)msg.Data["ReportType"];
            if ("MDF_Current".Equals(reportType))
            {

                MDF_Current1 = double.Parse((String)msg.Data["MDF_Current1"]);
                MDF_Current2 = double.Parse((String)msg.Data["MDF_Current2"]);
                MDF_Current3 = double.Parse((String)msg.Data["MDF_Current3"]);
                MDF_Current4 = double.Parse((String)msg.Data["MDF_Current4"]);
            }
            if ("MDF".Equals(reportType))
            {
                String Stackcode = (String)msg.Data["MDF_WhichStack"];
                String Petricode = (String)msg.Data["MDF_WhichDish"];
                String Barcode = (String)msg.Data["MDF_BarCode"];
                MDFDispenMessage xinXi = new MDFDispenMessage();
                xinXi.Stackcode = Stackcode;
                xinXi.Petricode = Petricode;
                xinXi.Barcode = Barcode;
                lock (DispenMessages)
                {
                    DispenMessages.Add(xinXi);
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
                //dispenTimer.Start();
                this.MDF_Cmd = "Start";
            }
            if ("Reset".Equals(cmd))
            {
                MDF_WhichDish = 1;
                MDF_WhichStack = 1;
                this.MDF_Cmd = "Reset";
            }
            if ("Stop".Equals(cmd))
            {
                //dispenTimer.Stop();
                this.MDF_Cmd = "Stop";
            }
            if ("Auto".Equals(cmd))
            {
                this.MDF_Cmd = "Auto";
            }

            this.sendOKResponse();
        }

        public override void decodeSetMessage(ModbusMessage msg)
        {
            String setType = (String)msg.Data["SetType"];
            if ("MDF_NumAndVol".Equals(setType))
            {
                this.MDF_NumsperStack = Int32.Parse((String)msg.Data["MDF_NumsperStack"]);
                this.MDF_VolsperDish = double.Parse((String)msg.Data["MDF_VolsperDish"]);
            }
        }

    }
}