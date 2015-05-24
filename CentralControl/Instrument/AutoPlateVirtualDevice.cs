using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GTLutils;

namespace Instrument
{
    public class MPFDispenMessage
    {
        public String Barcode;//条码号
        public String PlateNum;//孔板数

        public MPFDispenMessage()
        {
            Barcode = PlateNum = "";
        }

    }

    public class AutoPlateVirtualDevice : BaseVirtualDevice
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
        public int MPF_DispenTime;
        public double MPF_Current1;
        public double MPF_Current2;
        public double MPF_Current3;
        public double MPF_Current4;
        public string MPF_BarCode;

        /// <summary>
        /// Others
        /// </summary>
        private List<MPFDispenMessage> DispenMessages = new List<MPFDispenMessage>();

        private bool needRefreshMessages = false;
        private Object RefreshObject = new Object();
        //private object KeyObject = new object();

        //private System.Timers.Timer samTimer = null;
        //private System.Timers.Timer dispenTimer = null;

        public void sendCmd(String cmd)
        {
            SendModBusMsg(ModbusMessage.MessageType.CMD, "Cmd", cmd);
        }

        public void sendMPFSetNumAndVol(String Num, String Vol)
        {
            Hashtable ht = new Hashtable();
            ht.Add("SetType", "MPF_NumAndVol");
            ht.Add("MPF_PlateNum", Num);
            ht.Add("MPF_Volsperwell", Vol);
            SendModBusMsg(ModbusMessage.MessageType.SET, ht);
        }

        public void sendOKResponse()
        {
            SendModBusMsg(ModbusMessage.MessageType.RESPONSE, "Result", "OK");
        }

        public void sendMPFCodesReport(String Whichplate, String BarCode)
        {
            Hashtable ht = new Hashtable();
            ht.Add("ReportType", "MPF");
            ht.Add("MPF_Whichplate", Whichplate);
            ht.Add("MPF_BarCode", BarCode);
            SendModBusMsg(ModbusMessage.MessageType.REPORT, ht);
        }

        public void sendMPFCurrencyReport(String[] currency)
        {
            Hashtable ht = new Hashtable();
            ht.Add("ReportType", "MPF_Current");
            String[] s = { "MPF_Current1", "MPF_Current2", "MPF_Current3", "MPF_Current4" };
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
        public List<MPFDispenMessage> getDispenMessages()
        {
            List<MPFDispenMessage> res = new List<MPFDispenMessage>();
            lock (DispenMessages)
            {
                foreach (MPFDispenMessage msg in DispenMessages)
                {
                    res.Add(msg);
                }
            }
            return res;
        }

        public override void decodeResponseMessage(ModbusMessage msg)
        {
            //this.sendOKResponse();
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
                MPFDispenMessage disMsg = new MPFDispenMessage();
                disMsg.PlateNum = PlateNum;
                disMsg.Barcode = Barcode;
                lock (DispenMessages)
                {
                    DispenMessages.Add(disMsg);
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
                this.MPF_Cmd = "Start";
            }
            if ("Reset".Equals(cmd))
            {
                MPF_Whichplate = 1;
                this.MPF_Cmd = "Reset";
            }
            if ("Stop".Equals(cmd))
            {
                //dispenTimer.Stop();
                this.MPF_Cmd = "Stop";
            }
            if ("Auto".Equals(cmd))
            {
                this.MPF_Cmd = "Auto";
            }

            this.sendOKResponse();

            this.sendOKResponse();
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
