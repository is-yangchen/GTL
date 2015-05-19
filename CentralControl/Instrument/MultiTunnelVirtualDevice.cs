using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GTLutils;

namespace Instrument
{
    public class MultiTunnelDeviceMessageCreator
    {

        public static String createCmd(String cmd) 
        {
            ModbusMessageDataCreator creator = new ModbusMessageDataCreator();
            creator.addKeyPair("Cmd", cmd);
            return ModbusMessageHelper.createModbusMessage(ModbusMessage.messageTypeToByte(ModbusMessage.MessageType.CMD), creator.getDataBytes());
        }

        public static String createSetMode(String s)
        {
            ModbusMessageDataCreator creator = new ModbusMessageDataCreator();
            creator.addKeyPair("SetType", "Mode");
            creator.addKeyPair("Mode", s);
            return ModbusMessageHelper.createModbusMessage(ModbusMessage.messageTypeToByte(ModbusMessage.MessageType.SET), creator.getDataBytes());
        }

        public static String createOKResponse()
        {
            ModbusMessageDataCreator creator = new ModbusMessageDataCreator();
            creator.addKeyPair("Result", "OK");
            return ModbusMessageHelper.createModbusMessage(ModbusMessage.messageTypeToByte(ModbusMessage.MessageType.RESPONSE), creator.getDataBytes());
        }

        public static String createKongBanReport(bool YouKongBan, String TiaoMaHao)
        {
            ModbusMessageDataCreator creator = new ModbusMessageDataCreator();
            creator.addKeyPair("ReportType", "YouKongBan");
            String f = "";
            if (YouKongBan) f = "1";
            else f = "0";
            creator.addKeyPair("Flag", f);
            if (YouKongBan)
            {
                creator.addKeyPair("TiaoMaHao", TiaoMaHao);
            }
            return ModbusMessageHelper.createModbusMessage(ModbusMessage.messageTypeToByte(ModbusMessage.MessageType.REPORT), creator.getDataBytes());
        }

        public static String createJianCeZhiReport(int b, float[] v)
        {
            ModbusMessageDataCreator creator = new ModbusMessageDataCreator();
            creator.addKeyPair("ReportType", "Value");
            for (int i = 0; i < v.Length; i++)
            {
                creator.addKeyPair("v" + b, v[i].ToString());
                b++;
            }
            return ModbusMessageHelper.createModbusMessage(ModbusMessage.messageTypeToByte(ModbusMessage.MessageType.REPORT), creator.getDataBytes());
        }

    }

    public class MultiTunnelVirtualDevice : BaseVirtualDevice
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

        public void send_moshi() 
        {
            String msg = MultiTunnelDeviceMessageCreator.createSetMode(jianCeMoShiToString(moShi));
            SendMsg(msg);
        }


        private String currentTiaoMaHao = null;
        private String preTiaoMaHao = null;
        public String getTiaoMaHao() 
        {
            return preTiaoMaHao;
        }

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
        private float[][] preDetectValues = null;


        public float[][] getDetectValues()
        {
            float[][] res = null;
            if (preDetectValues == null) return res;
            lock (preDetectValues)
            {
                res = new float[MultiTunnelVirtualDevice.JianCeHangShu][];
                for (int i = 0; i < MultiTunnelVirtualDevice.JianCeHangShu; i++)
                {
                    res[i] = new float[MultiTunnelVirtualDevice.JianCeLieShu];
                    for (int j = 0; j < MultiTunnelVirtualDevice.JianCeLieShu; j++) 
                    {
                        res[i][j] = preDetectValues[i][j];
                    }
                }
            }
            return res;
        }

        public float getSingeDetectValue(int i, int j)
        {
            if (i < 0 || i >= JianCeHangShu) return 0;
            if (j < 0 || j >= JianCeLieShu) return 0;
            if (preDetectValues == null) return 0;
            lock (preDetectValues)
            {
                return preDetectValues[i][j];
            }
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

        public override void decodeCmdMessage(ModbusMessage msg)
        {
            String cmd = (String)msg.Data["Cmd"];

        }

        public override void decodeSetMessage(ModbusMessage msg)
        {
            String setType = (String)msg.Data["SetType"];
            
        }

        public void send_cmd(String cmd) 
        {
            String msg = MultiTunnelDeviceMessageCreator.createCmd(cmd);
            SendMsg(msg);
        }

        public override void decodeReportMessage(ModbusMessage msg)
        {
            String reportType = (String)msg.Data["ReportType"];
            if ("YouKongBan".Equals(reportType)) 
            {
                int f = int.Parse((String)msg.Data["Flag"]);
                if (f > 0) youKongBan = true;
                else youKongBan = false;
                if (youKongBan) 
                {
                    currentTiaoMaHao = (String)msg.Data["TiaoMaHao"];
                }
                else 
                {
                    send_cmd("Next");
                }
            }
            if ("Value".Equals(reportType))
            {
                String key;
                bool hasFinish = false;
                if (detectValues == null)
                {
                    detectValues = new float[MultiTunnelVirtualDevice.JianCeHangShu][];
                    for (int i = 0; i < MultiTunnelVirtualDevice.JianCeHangShu; i++)
                    {
                        detectValues[i] = new float[MultiTunnelVirtualDevice.JianCeLieShu];
                    }
                }
                lock (detectValues)
                {
                    foreach (Object ob in msg.Data.Keys)
                    {
                        key = (String)ob;
                        if (key.StartsWith("v"))
                        {
                            int index = int.Parse(key.Substring(1, key.Length - 1));
                            int i = index / MultiTunnelVirtualDevice.JianCeLieShu;
                            int j = index % MultiTunnelVirtualDevice.JianCeLieShu;
                            if (index == MultiTunnelVirtualDevice.JianCeLieShu * MultiTunnelVirtualDevice.JianCeHangShu - 1) hasFinish = true;
                            float v = float.Parse((String)msg.Data[key]);
                            detectValues[i][j] = v;
                        }
                    }
                }
                if (hasFinish)
                {
                    if (preDetectValues == null)
                    {
                        preDetectValues = detectValues;
                        preTiaoMaHao = currentTiaoMaHao;
                    }
                    else
                    {
                        lock (preDetectValues)
                        {
                            preDetectValues = detectValues;
                            preTiaoMaHao = currentTiaoMaHao;
                        }
                    }
                    lock (detectValues) 
                    {
                        detectValues = null;
                        currentTiaoMaHao = null;
                    }
                }
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
                case ModbusMessage.MessageType.REPORT:
                    decodeReportMessage(message);
                    break;
                case ModbusMessage.MessageType.GET:
                    break;
            }
        }
    }
}
