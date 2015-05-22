using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TwinCAT.Ads;
using System.Timers;
using DeviceUtils;

namespace Instrument
{
    public class AutoDispenTwincatDevice : BaseTwincatDevice
    {

        private Dictionary<String,Type> nameDict = new Dictionary<String,Type>();
        public override void init()
        {
            adsClient = new TcAdsClient();
            nameDict["MAIN.MDF_WhichStack"] = typeof(int);
            nameDict["MAIN.MDF_WhichDish"] = typeof(int);
            nameDict["MAIN.MDF_RunningError"] = typeof(int);
            nameDict["MAIN.MDF_online_state"] = typeof(int);
            nameDict["MAIN.MDF_Command_response"] = typeof(String);
            nameDict["MAIN.MDF_bar_code"] = typeof(string);
            nameDict["MAIN.MDF_Motor_1_cur"] = typeof(float);
            nameDict["MAIN.MDF_Motor_2_cur"] = typeof(float);
            nameDict["MAIN.MDF_Motor_3_cur"] = typeof(float);
            nameDict["MAIN.MDF_Motor_4_cur"] = typeof(float);
            nameDict["MAIN.CCS_to_MDF_command_listen"] = typeof(String);
            nameDict["MAIN.CCS_to_MDF_NumsperStack_listen"] = typeof(int);
            nameDict["MAIN.CCS_to_MDF_VolsperDish_listen"] = typeof(float);
            cmdString = "MAIN.MDF_Command_response";
            try
            {
                adsClient.Connect(801);
                adsClient.AdsNotificationEx += new AdsNotificationExEventHandler(handleNotification);
                foreach (String s in nameDict.Keys)
                {
                    handleMap[s] = adsClient.CreateVariableHandle(s);
                    if (nameDict[s] == typeof(string))
                    {
                        adsClient.AddDeviceNotificationEx(s, AdsTransMode.OnChange, 100, 0, s, nameDict[s],new int[]{ConstSettings.StringLength});
                    }
                    else
                    {
                        adsClient.AddDeviceNotificationEx(s, AdsTransMode.OnChange, 100, 0, s, nameDict[s]);
                    }
                }
                adsClient.WriteAny(handleMap["MAIN.MDF_online_state"], 1);
            }
            catch (Exception ex)
            {
                
            }
        }

        public override void deinit()
        {
            adsClient.WriteAny(handleMap["MAIN.MDF_online_state"], 0);
            adsClient.Dispose();
        }

        private void handleNotification(object sender, AdsNotificationExEventArgs e)
        {
            String s = (String)e.UserData;
            int handle = handleMap[s];
            if (s.Equals("MAIN.CCS_to_MDF_NumsperStack_listen")) 
            {
                Num = (int) adsClient.ReadAny(handle, nameDict[s]);
            }
            if (s.Equals("MAIN.CCS_to_MDF_VolsperDish_listen")) 
            {
                Vol = (float)adsClient.ReadAny(handle,nameDict[s]);
            }
            if (s.Equals("MAIN.CCS_to_MDF_command_listen")) 
            {
                String cmd = adsClient.ReadAny(handle, nameDict[s],new int[]{ConstSettings.StringLength}).ToString();

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
                //String msg = AutoDispenDeviceMessageCreator.createOKResponse();
                //adsClient.WriteAny(handleMap["MAIN.MDF_Command_response"],msg,new int[]{ConstSettings.StringLength});
            }
        }

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
        private float Vol;
        public float getVol() { return this.Vol; }

        public int YunXingChuCuoBiaoZhi;
        public int FenZhuangShiJian;
        public int CaiYangShiJian;
        public float DianLiu1;
        public float DianLiu2;
        public float Dianliu3;

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
                    if (DuiMaHao > 8)
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
            tiaomahao = BarCodeGenerator.generateBarCode();
            increaseFenZhuangZhuangTai();
            String msg = "";
            //if (true) msg = AutoDispenDeviceMessageCreator.createMDFCodesReport(duimahao, peiyangminhao, tiaomahao);
            //else msg = AutoDispenDeviceMessageCreator.createMPFCodesReport(kongbanhao, tiaomahao);
            return msg;
        }

        private void fenZhuangTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            String msg = "";
            msg = createFenZhuangMessage();
            adsClient.WriteAny(handleMap["MAIN.MDF_Command_response"], msg,new int[]{ConstSettings.StringLength});
        }

        private void caiYangTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            int handle = handleMap["MAIN.MDF_Motor_1_cur"];
            adsClient.WriteAny(handle, DianLiu1);
            String[] dianLiuList = new String[] { "MAIN.MDF_Motor_1_cur", "MAIN.MDF_Motor_2_cur", "MAIN.MDF_Motor_3_cur" };
            float[] currencies = new float[] { (float)DianLiu1, (float)DianLiu2, (float)Dianliu3 };
            for (int i = 0; i < dianLiuList.Length; i++) 
            {
                handle = handleMap[dianLiuList[i]];
                adsClient.WriteAny(handle,currencies[i]);
            }
            adsClient.WriteAny(handleMap["MAIN.MDF_RunningError"],YunXingChuCuoBiaoZhi);
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
    }
}
