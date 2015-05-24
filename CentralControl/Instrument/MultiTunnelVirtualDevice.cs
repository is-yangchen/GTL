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
        public static int MMA_TestRowIndex = 8;
        public static int MMA_TestColumnIndex = 12;

        public enum MMA_TestMethod { OD, Flu, Che };
        private String MMA_currentBarCode = null;
        private String MMA_preBarCode = null;
        private MMA_TestMethod MMA_TestMode = MMA_TestMethod.OD;
        private float[][] MMA_CurrentValues = null;
        private float[][] MMA_PreValues = null;
        private bool MMA_PlateDetect = false;
        private int MMA_MeasureTime;
        private float MMA_Temp;
        private float MMA_WaveLengthUp;
        private float MMA_WaveLengthDown;


        private int MMA_TipIdx;
        private string MMA_TargetIdx;
        private int MMA_ContainerType;
        private int MMA_Volume;
        private string MMA_SampleIdx;
        private int MMA_SampleType;
        private int MMA_HeatFlag;
        private int MMA_VibrateFlag;
        private int MMA_TestType;
        private int MMA_LightType;
        private int MMA_WaveLength;
        private int MMA_OrificeType;
        private int MMA_MeasureArea;
        private int MMA_Time;
        private int MMA_IntegralTime;



        public static MMA_TestMethod stringToJianCeMoShi(String mode)
        {
            if ("OD".Equals(mode)) return MMA_TestMethod.OD;
            if ("YG".Equals(mode)) return MMA_TestMethod.Flu;
            if ("HXFG".Equals(mode)) return MMA_TestMethod.Che;
            return MMA_TestMethod.OD;
        }

        public static String jianCeMoShiToString(MMA_TestMethod m)
        {
            switch (m)
            {
                case MMA_TestMethod.OD:
                    return "OD";
                case MMA_TestMethod.Flu:
                    return "YG";
                case MMA_TestMethod.Che:
                    return "HXFG";
            }
            return "OD";
        }

        public void send_moshi()
        {
            String msg = MultiTunnelDeviceMessageCreator.createSetMode(jianCeMoShiToString(MMA_TestMode));
            SendMsg(msg);
        }



        public String getTiaoMaHao()
        {
            return MMA_preBarCode;
        }


        public MMA_TestMethod MoShi
        {
            get
            {
                return this.MMA_TestMode;
            }
            set
            {
                this.MMA_TestMode = value;
            }
        }




        public float[][] getDetectValues()
        {
            float[][] res = null;
            if (MMA_PreValues == null) return res;
            lock (MMA_PreValues)
            {
                res = new float[MultiTunnelVirtualDevice.MMA_TestRowIndex][];
                for (int i = 0; i < MultiTunnelVirtualDevice.MMA_TestRowIndex; i++)
                {
                    res[i] = new float[MultiTunnelVirtualDevice.MMA_TestColumnIndex];
                    for (int j = 0; j < MultiTunnelVirtualDevice.MMA_TestColumnIndex; j++)
                    {
                        res[i][j] = MMA_PreValues[i][j];
                    }
                }
            }
            return res;
        }

        public float getSingeDetectValue(int i, int j)
        {
            if (i < 0 || i >= MMA_TestRowIndex) return 0;
            if (j < 0 || j >= MMA_TestColumnIndex) return 0;
            if (MMA_PreValues == null) return 0;
            lock (MMA_PreValues)
            {
                return MMA_PreValues[i][j];
            }
        }


        public bool YouKongBan
        {
            get
            {
                return this.MMA_PlateDetect;
            }
            set
            {
                this.MMA_PlateDetect = value;
            }
        }


        public int ChuLiShiJian
        {
            get
            {
                return this.MMA_MeasureTime;
            }
            set
            {
                this.MMA_MeasureTime = value;
            }
        }


        public float DangQiangWenWu
        {
            get
            {
                return this.MMA_Temp;
            }
            set
            {
                this.MMA_Temp = value;
            }
        }


        public float BoChangXiaXian
        {
            get
            {
                return this.MMA_WaveLengthUp;
            }
            set
            {
                this.MMA_WaveLengthUp = value;
            }
        }


        public float BoChangShangXian
        {
            get
            {
                return this.MMA_WaveLengthDown;
            }
            set
            {
                this.MMA_WaveLengthDown = value;
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
                if (f > 0) MMA_PlateDetect = true;
                else MMA_PlateDetect = false;
                if (MMA_PlateDetect)
                {
                    MMA_currentBarCode = (String)msg.Data["TiaoMaHao"];
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
                if (MMA_CurrentValues == null)
                {
                    MMA_CurrentValues = new float[MultiTunnelVirtualDevice.MMA_TestRowIndex][];
                    for (int i = 0; i < MultiTunnelVirtualDevice.MMA_TestRowIndex; i++)
                    {
                        MMA_CurrentValues[i] = new float[MultiTunnelVirtualDevice.MMA_TestColumnIndex];
                    }
                }
                lock (MMA_CurrentValues)
                {
                    foreach (Object ob in msg.Data.Keys)
                    {
                        key = (String)ob;
                        if (key.StartsWith("v"))
                        {
                            int index = int.Parse(key.Substring(1, key.Length - 1));
                            int i = index / MultiTunnelVirtualDevice.MMA_TestColumnIndex;
                            int j = index % MultiTunnelVirtualDevice.MMA_TestColumnIndex;
                            if (index == MultiTunnelVirtualDevice.MMA_TestColumnIndex * MultiTunnelVirtualDevice.MMA_TestRowIndex - 1) hasFinish = true;
                            float v = float.Parse((String)msg.Data[key]);
                            MMA_CurrentValues[i][j] = v;
                        }
                    }
                }
                if (hasFinish)
                {
                    if (MMA_PreValues == null)
                    {
                        MMA_PreValues = MMA_CurrentValues;
                        MMA_preBarCode = MMA_currentBarCode;
                    }
                    else
                    {
                        lock (MMA_PreValues)
                        {
                            MMA_PreValues = MMA_CurrentValues;
                            MMA_preBarCode = MMA_currentBarCode;
                        }
                    }
                    lock (MMA_CurrentValues)
                    {
                        MMA_CurrentValues = null;
                        MMA_currentBarCode = null;
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
