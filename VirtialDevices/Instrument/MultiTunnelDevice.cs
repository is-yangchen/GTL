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

    public class MultiTunnelDevice : BaseVirtualDevice
    {

        public static int MMA_TestRowIndex = 8;
        public static int MMA_TestColumnIndex = 12;

        public enum MMA_TestMethod { OD, Flu, Che };
        private bool MMA_SendBarCodeFlag = true;
        private String MMA_currentBarCode = null;
        private String MMA_preBarCode = null;
        private MMA_TestMethod MMA_TestMode = MMA_TestMethod.OD;
        private float[][] MMA_DetectValues = null;
        private System.Timers.Timer MMA_Timer = null;
        private bool MMA_PlateDetect = false;
        private int MMA_MeasureTime;
        private float MMA_Temp;
        private float MMA_WaveLengthUp;
        private float MMA_WaveLengthDown;

        private bool[] MMA_PlateFlag;
        private float[] MMA_PlateTemp;
        private float[] MMA_ODValue;
        private float[] MMA_FluCount;
        private float[] MMA_CheCount;
        private float MMA_Wave;



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



        public void setDetectValues(float[][] v)
        {
            if (v.Length != MMA_TestRowIndex) return;
            for (int i = 0; i < v.Length; i++)
            {
                if (v[i].Length != MMA_TestColumnIndex) return;
            }
            MMA_DetectValues = new float[MMA_TestRowIndex][];
            for (int i = 0; i < MMA_TestRowIndex; i++)
            {
                MMA_DetectValues[i] = new float[MMA_TestColumnIndex];
            }
            for (int i = 0; i < MMA_TestRowIndex; i++)
            {
                for (int j = 0; j < MMA_TestColumnIndex; j++)
                {
                    MMA_DetectValues[i][j] = v[i][j];
                }
            }
        }



        private void chuLiTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            MMA_Timer.Stop();
            if (MMA_PlateDetect)
            {
                int b = 0;
                String s;
                for (int i = 0; i < MMA_TestRowIndex; i++)
                {
                    s = MultiTunnelDeviceMessageCreator.createJianCeZhiReport(b, MMA_DetectValues[i]);
                    SendMsg(s);
                    b += MMA_TestColumnIndex;
                }
                //s = MultiTunnelDeviceMessageCreator.createKongBanReport(youKongBan,currentTiaoMaHao);
                //SendMsg(s);
                MMA_PlateDetect = false;
                MMA_currentBarCode = null;
            }
            MMA_Timer = null;
        }

        private void startTimer()
        {
            if (MMA_PlateDetect) MMA_currentBarCode = BarCodeGenerator.generateBarCode();
            String s = MultiTunnelDeviceMessageCreator.createKongBanReport(MMA_PlateDetect, MMA_currentBarCode);
            SendMsg(s);
            if (MMA_PlateDetect)
            {
                if (MMA_Timer != null) MMA_Timer.Stop();
                MMA_Timer = new System.Timers.Timer();
                MMA_Timer.Interval = MMA_MeasureTime * 1000;
                MMA_Timer.Elapsed += new System.Timers.ElapsedEventHandler(chuLiTimer_Elapsed);
                MMA_Timer.Start();
            }
        }

        public void setSingleDetectValue(int i, int j, float v)
        {
            if (i < 0 || i >= MMA_TestRowIndex) return;
            if (j < 0 || j >= MMA_TestColumnIndex) return;
            if (MMA_DetectValues == null) return;
            MMA_DetectValues[i][j] = v;
        }

        public float[][] getDetectValues()
        {
            return MMA_DetectValues;
        }

        public float getSingeDetectValue(int i, int j)
        {
            if (i < 0 || i >= MMA_TestRowIndex) return 0;
            if (j < 0 || j >= MMA_TestColumnIndex) return 0;
            if (MMA_DetectValues == null) return 0;
            return MMA_DetectValues[i][j];
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

        private void decodeCmdMessage(ModbusMessage msg)
        {
            String cmd = (String)msg.Data["Cmd"];
            if ("Start".Equals(cmd))
            {
                startTimer();
            }
            if ("Next".Equals(cmd))
            {
                MMA_PlateDetect = true;
                startTimer();
            }
        }

        private void decodeSetMessage(ModbusMessage msg)
        {
            String setType = (String)msg.Data["SetType"];
            if ("Mode".Equals(setType))
            {
                String mode = (String)msg.Data["Mode"];
                MMA_TestMode = stringToJianCeMoShi(mode);
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
