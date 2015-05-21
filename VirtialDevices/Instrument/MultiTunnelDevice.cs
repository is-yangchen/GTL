using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;
using DeviceUtils;

namespace Instrument
{


    public class MultiTunnelDeviceMessageCreator
    {

        public static String createOKResponse()
        {
            ModbusMessageDataCreator creator = new ModbusMessageDataCreator();
            creator.addKeyPair("Result", "OK");
            return ModbusMessageHelper.createModbusMessage(ModbusMessage.messageTypeToByte(ModbusMessage.MessageType.RESPONSE), creator.getDataBytes());
        }

        public static String createKongBanReport(bool YouKongBan,String TiaoMaHao) 
        {
            ModbusMessageDataCreator creator = new ModbusMessageDataCreator();
            creator.addKeyPair("ReportType", "YouKongBan");
            String f = "";
            if(YouKongBan) f = "1";
            else f = "0";
            creator.addKeyPair("Flag", f);
            if (YouKongBan) 
            {
                creator.addKeyPair("TiaoMaHao",TiaoMaHao);
            }
            return ModbusMessageHelper.createModbusMessage(ModbusMessage.messageTypeToByte(ModbusMessage.MessageType.REPORT), creator.getDataBytes());
        }

        public static String createJianCeZhiReport(int b, float[] v)
        {
            ModbusMessageDataCreator creator = new ModbusMessageDataCreator();
            creator.addKeyPair("ReportType", "Value");
            for (int i = 0; i < v.Length; i++) 
            {
                creator.addKeyPair("v"+b, v[i].ToString());
                b++;
            }
            return ModbusMessageHelper.createModbusMessage(ModbusMessage.messageTypeToByte(ModbusMessage.MessageType.REPORT), creator.getDataBytes());
        }

    }

    public class MultiTunnelDevice : BaseVirtualDevice
    {

        public static int JianCeHangShu = 8;
        public static int JianCeLieShu = 12;

        public enum JianCeMoShi { OD, YingGuang, HuaXueFaGuang };
        public static JianCeMoShi stringToJianCeMoShi(String mode) 
        {
            if ("OD".Equals(mode)) return JianCeMoShi.OD;
            if ("YG".Equals(mode)) return JianCeMoShi.YingGuang;
            if ("HXFG".Equals(mode)) return JianCeMoShi.HuaXueFaGuang;
            return JianCeMoShi.OD;
        }

        public static String jianCeMoShiToString(JianCeMoShi m)
        {
            switch (m) 
            {
                case JianCeMoShi.OD:
                    return "OD";
                case JianCeMoShi.YingGuang:
                    return "YG";
                case JianCeMoShi.HuaXueFaGuang:
                    return "HXFG";
            }
            return "OD";
        }

        private bool needSendKongBanReport = true;

        private String currentTiaoMaHao = null;

        private JianCeMoShi moShi = JianCeMoShi.OD;
        public JianCeMoShi MoShi
        {
            get
            {
                return this.moShi;
            }
            set
            {
                this.moShi = value;
            }
        }

        private float[][] detectValues = null;

        public void setDetectValues(float[][] v)
        {
            if (v.Length != JianCeHangShu) return;
            for (int i = 0; i < v.Length; i++)
            {
                if (v[i].Length != JianCeLieShu) return;
            }
            detectValues = new float[JianCeHangShu][];
            for(int i=0;i<JianCeHangShu;i++)
            {
                detectValues[i] = new float[JianCeLieShu];
            }
            for (int i = 0; i < JianCeHangShu; i++)
            {
                for (int j = 0; j < JianCeLieShu; j++) 
                {
                    detectValues[i][j] = v[i][j];
                }
            }
        }

        private System.Timers.Timer chuLiTimer = null;

        private void chuLiTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            chuLiTimer.Stop();
            if (youKongBan)
            {
                int b = 0;
                String s;
                for (int i = 0; i < JianCeHangShu; i++) 
                {
                    s = MultiTunnelDeviceMessageCreator.createJianCeZhiReport(b, detectValues[i]);
                    SendMsg(s);
                    b += JianCeLieShu;
                }
                //s = MultiTunnelDeviceMessageCreator.createKongBanReport(youKongBan,currentTiaoMaHao);
                //SendMsg(s);
                youKongBan = false;
                currentTiaoMaHao = null;
            }
            chuLiTimer = null;
        }

        private void startTimer() 
        {
            if (youKongBan) currentTiaoMaHao = TiaoMaHaoGenerator.generateTiaoMaHao();
            String s = MultiTunnelDeviceMessageCreator.createKongBanReport(youKongBan,currentTiaoMaHao);
            SendMsg(s);
            if (youKongBan)
            {
                if (chuLiTimer != null) chuLiTimer.Stop();
                chuLiTimer = new System.Timers.Timer();
                chuLiTimer.Interval = chuLiShiJian * 1000;
                chuLiTimer.Elapsed += new System.Timers.ElapsedEventHandler(chuLiTimer_Elapsed);
                chuLiTimer.Start();
            }
        }

        public void setSingleDetectValue(int i,int j,float v) 
        {
            if (i < 0 || i >= JianCeHangShu) return;
            if (j < 0 || j >= JianCeLieShu) return;
            if (detectValues == null) return;
            detectValues[i][j] = v;
        }

        public float[][] getDetectValues() 
        {
            return detectValues;
        }

        public float getSingeDetectValue(int i, int j) 
        {
            if (i < 0 || i >= JianCeHangShu) return 0;
            if (j < 0 || j >= JianCeLieShu) return 0;
            if (detectValues == null) return 0;
            return detectValues[i][j];
        }

        private bool youKongBan = false;
        public bool YouKongBan
        {
            get
            {
                return this.youKongBan;
            }
            set
            {
                this.youKongBan = value;
            }
        }

        private int chuLiShiJian;
        public int ChuLiShiJian
        {
            get
            {
                return this.chuLiShiJian;
            }
            set
            {
                this.chuLiShiJian = value;
            }
        }

        private float dangQiangWenDu;
        public float DangQiangWenWu
        {
            get
            {
                return this.dangQiangWenDu;
            }
            set
            {
                this.dangQiangWenDu = value;
            }
        }

        private float boChangXiaXian;
        public float BoChangXiaXian
        {
            get
            {
                return this.boChangXiaXian;
            }
            set
            {
                this.boChangXiaXian = value;
            }
        }

        private float boChangShangXian;
        public float BoChangShangXian
        {
            get
            {
                return this.boChangShangXian;
            }
            set
            {
                this.boChangShangXian = value;
            }
        }

        private void decodeCmdMessage(ModbusMessage msg)
        {
            String cmd = (String)msg.Data["Cmd"];
            if ("Start".Equals(cmd)) 
            {
                startTimer();
            }
            if ("Next".Equals(cmd)) 
            {
                youKongBan = true;
                startTimer();
            }
        }

        private void decodeSetMessage(ModbusMessage msg)
        {
            String setType = (String)msg.Data["SetType"];
            if ("Mode".Equals(setType)) 
            {
                String mode = (String)msg.Data["Mode"];
                moShi = stringToJianCeMoShi(mode);
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
