﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TwinCAT.Ads;
using GTLutils;

namespace Instrument
{
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
    public class AutoDispenTwincatDevice : BaseTwincatDevice
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

        private int Num = 0;
        public int getNum() { return this.Num; }
        private double Vol = 0;
        public double getVol() { return this.Vol; }

        public int YunXingChuCuoBiaoZhi;
        public double MDF_Current1;
        public double MDF_Current2;
        public double MDF_Current3;
        
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


        private Dictionary<String, Type> nameDict = new Dictionary<String, Type>();
        public override void init()
        {
            adsClient = new TcAdsClient();
            nameDict["MAIN.MDF_WhichStack"] = typeof(int);
            nameDict["MAIN.MDF_WhichDish"] = typeof(int);
            nameDict["MAIN.MDF_RunningError"] = typeof(int);
            nameDict["MAIN.MDF_online_state"] = typeof(int);
            nameDict["MAIN.MDF_Command_response"] = typeof(string);
            nameDict["MAIN.MDF_bar_code"] = typeof(string);
            nameDict["MAIN.MDF_Motor_1_cur"] = typeof(float);
            nameDict["MAIN.MDF_Motor_2_cur"] = typeof(float);
            nameDict["MAIN.MDF_Motor_3_cur"] = typeof(float);
            nameDict["MAIN.MDF_Motor_4_cur"] = typeof(float);
            nameDict["MAIN.CCS_to_MDF_command_listen"] = typeof(string);
            nameDict["MAIN.CCS_to_MDF_NumsperStack_listen"] = typeof(int);
            nameDict["MAIN.CCS_to_MDF_VolsperDish_listen"] = typeof(float);
            try
            {
                adsClient.Connect(801);
                adsClient.AdsNotificationEx += new AdsNotificationExEventHandler(handleNotification);
                foreach (String s in nameDict.Keys)
                {
                    handleMap[s] = adsClient.CreateVariableHandle(s);
                    handleMap[s].GetType();
                    if (nameDict[s] == typeof(string))
                    {
                        adsClient.AddDeviceNotificationEx(s, AdsTransMode.OnChange, 100, 0, s, handleMap[s].GetType(), new int[] { ConstSettings.StringLength });
                    }
                    else
                    {
                        adsClient.AddDeviceNotificationEx(s, AdsTransMode.OnChange, 100, 0, s, nameDict[s]);
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }

        public override void SendMsg(string msg)
        {
            adsClient.WriteAny(handleMap["MAIN.CCS_to_MDF_command_listen"], msg, new int[] { ConstSettings.StringLength });
        }

        public void SendNumAndVol(int Num, float Vol)
        {
            adsClient.WriteAny(handleMap["MAIN.CCS_to_MDF_NumsperStack_listen"], Num);
            adsClient.WriteAny(handleMap["MAIN.CCS_to_MDF_VolsperDish_listen"], Vol);
        }

        public override void deinit()
        {
            adsClient.Dispose();
        }
        //*
        private void decodeResponseMessage(ModbusMessage msg)
        {
            //String s = AutoDispenDeviceMessageCreator.createOKResponse();
            //this.SendMsg(s);
        }
        //*/
        private void decodeReportMessage(ModbusMessage msg)//解码报告消息
        {
            String reportType = (String)msg.Data["ReportType"];
            if ("Currency".Equals(reportType))
            {
                MDF_Current1 = double.Parse((String)msg.Data["Currency1"]);
                MDF_Current2 = double.Parse((String)msg.Data["Currency2"]);
                MDF_Current3 = double.Parse((String)msg.Data["Currency3"]);
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
            }
        }

        private void decodeSetMessage(ModbusMessage message)
        {
            DeviceType type = EnumHelper.deviceStringToDeviceType((String)message.Data["DeviceType"]);
            IsVirt = false;
            CurrentDeviceType = type;
            if (type == DeviceType.Dispen)
            {
                String subType = (String)message.Data["SubType"];
                if ("PeiYangMin".Equals(subType))
                {
                    SubType = AutoDispenTwincatDevice.AutoDispenType.PeiYangMin;
                }
                else
                {
                    SubType = AutoDispenTwincatDevice.AutoDispenType.ShenKongBan;
                }
            }
            IdentifyID = (String)message.Data["IdentifyID"];
            Code = (String)message.Data["Code"];
            Name = (String)message.Data["Name"];
            SerialID = (String)message.Data["SerialID"];
        }
        private void handleNotification(object sender, AdsNotificationExEventArgs e)
        {
            String s = (String)e.UserData;
            int handle = handleMap[s];
            if (s.Equals("MAIN.MDF_RunningError"))
            {
                YunXingChuCuoBiaoZhi = (int)adsClient.ReadAny(handle, nameDict[s]);
            }
            if (s.Equals("MAIN.MDF_online_state"))
            {

            }
            if (s.Equals("MAIN.MDF_Command_response"))
            {
                String msg = (String)adsClient.ReadAny(handle, nameDict[s], new int[] { ConstSettings.StringLength });
                ModbusMessage message = ModbusMessageHelper.decodeModbusMessage(msg);
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
            if (s.Equals("MAIN.MDF_Motor_1_cur"))
            {
                MDF_Current1 = (float)adsClient.ReadAny(handle, nameDict[s]);
            }
            if (s.Equals("MAIN.MDF_Motor_2_cur"))
            {
                MDF_Current2 = (float)adsClient.ReadAny(handle, nameDict[s]);
            }
            if (s.Equals("MAIN.MDF_Motor_3_cur"))
            {
                MDF_Current3 = (float)adsClient.ReadAny(handle, nameDict[s]);
            }
            if (s.Equals("MAIN.MDF_Motor_4_cur"))
            {

            }
        }
    }
}
