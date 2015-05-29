using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GTLutils;

namespace Instrument
{
    public class CloneSelectionDeviceMessageCreator
    {
        public static String createSetLowAndUpp(String Lower, String Upper)
        {
            ModbusMessageDataCreator creator = new ModbusMessageDataCreator();
            creator.addKeyPair("SetType", "ZhouChangMianJiBi");
            creator.addKeyPair("ZhouChangMianJiBi_Max", Upper);
            creator.addKeyPair("ZhouChangMianJiBi_Min", Lower);
            return ModbusMessageHelper.createModbusMessage(ModbusMessage.messageTypeToByte(ModbusMessage.MessageType.SET), creator.getDataBytes());
        }

        public static String createSetMianJiLowAndUpp(String Lower, String Upper)
        {
            ModbusMessageDataCreator creator = new ModbusMessageDataCreator();
            creator.addKeyPair("SetType", "MianJiShaiXuan");
            creator.addKeyPair("MianJi_Max", Upper);
            creator.addKeyPair("MianJi_Min", Lower);
            return ModbusMessageHelper.createModbusMessage(ModbusMessage.messageTypeToByte(ModbusMessage.MessageType.SET), creator.getDataBytes());
        }

        public static String createSetMieJun(String arg1, String arg2, String arg3, String arg4, String arg5)
        {
            ModbusMessageDataCreator creator = new ModbusMessageDataCreator();
            creator.addKeyPair("SetType", "MieJunHeQingXi");
            creator.addKeyPair("JiaReShiJian", arg1);
            creator.addKeyPair("QingXiCiShu", arg2);
            creator.addKeyPair("LengQueShiJian", arg3);
            creator.addKeyPair("QingXiShiJian", arg4);
            creator.addKeyPair("ChouQiShiJian", arg5);
            return ModbusMessageHelper.createModbusMessage(ModbusMessage.messageTypeToByte(ModbusMessage.MessageType.SET), creator.getDataBytes());
        }

        
    }
    public class CloneSelectionVirtualDevice : BaseVirtualDevice
    {
        //平皿和孔板选择
        public int SCP_LightType = 0;
        public int SCP_DishType = 0;
        public int SCP_NeedleFlag = 0;
        public int SCP_NeedleNum = 0;
        public int SCP_DishNeedleFlag = 0;
        public int SCP_CloneNum = 0;
        public int SCP_PlateFlag = 0;
        public int SCP_PlateType = 0;
        public int SCP_SpaceFlag = 0;
        public int SCP_ProbeMethod = 0;
        public static int SCP_TestRowNum = 12;

        //过程设置
        public int SCP_PickStopTime = 0;
        public int SCP_InoStopTime = 0;
        public int SCP_ShockCount = 0;

        //相机参数
        //色彩处理
        public int SCP_Gamma = 0;
        public int SCP_Contrast = 0;
        public int SCP_ColEnhance = 0;
        public int SCP_Saturate = 0;
        //亮度控制
        public int SCP_Exposure = 0;
        public int SCP_Target = 0;
        public int SCP_ExpoTime = 0;
        public int SCP_Gain = 0;
        //白平衡
        public int SCP_Red = 0;
        public int SCP_Green = 0;
        public int SCP_Blue = 0;
        //大小
        public string SCP_Pixel = "";
        public int SCP_FrameRate = 0;
        public int SCP_PowerFrequency = 0;
        public int SCP_ParaSet = 0;
        public int SCP_Flip = 0;
        public int SCP_Horizontal = 0;
        public int SCP_GreyLevel = 0;
        public int SCP_Scale = 0;


        //灭菌与清洗
        public UInt32 SCP_HeatTime = 0;
        public UInt32 SCP_FlushTime = 0;
        public UInt32 SCP_CoolTime = 0;
        public UInt32 SCP_FlushNo = 0;
        public UInt32 SCP_ExhaustTime = 0;

        //区域定位
        public int SCP_CircleLoc = 0;
        public int SCP_MatrixLoc = 0;
        public int SCP_Calibrate = 0;
        public int SCP_X = 0;
        public int SCP_Y = 0;
        public int SCP_Radius = 0;
        public int SCP_CenterX = 0;
        public int SCP_CenterY = 0;
        public int SCP_Length = 0;
        public int SCP_Width = 0;
        public int SCP_OriginPoint = 0;
        public int SCP_ControlPoint = 0;

        //筛选条件
        public double SCP_MaxPARate = 0.0;
        public double SCP_MinPARate = 0.0;
        public double SCP_SizeMax = 3.0;
        public double SCP_SizeMin = 2.0;
        public double SCP_MaxLength = 3.0;
        public double SCP_MinLength = 2.5;
        public double SCP_MaxShort = 7.0;
        public double SCP_MinShort = 6.0;
        public double SCP_MaxRate = 4.0;
        public double SCP_MinRate = 3.0;
        public int SCP_AreaFilter = 0;
        public int SCP_PARate = 0;
        public int SCP_LengthFilter = 0;
        public int SCP_ColorFlag = 0;
        public Int16 SCP_R = 18;
        public Int16 SCP_G = 21;
        public Int16 SCP_B = 75;

        //上层Form需要用到这些函数，所以暂时保留，但底层类操作中不需要这些函数
        public UInt32 getJiaReShiJian() { return this.SCP_HeatTime; }
        public UInt32 getQingXiShiJian() { return this.SCP_FlushTime; }
        public UInt32 getQingXiCiShu() { return this.SCP_FlushNo; }
        public UInt32 getChouQiShiJian() { return this.SCP_ExhaustTime; }
        public UInt32 getLengQueShiJian() { return this.SCP_CoolTime; }
        public double getZhouChangMianJiBi_Max() { return this.SCP_MaxPARate; }
        public double getZhouChangMianJiBi_Min() { return this.SCP_MinPARate; }
        public double getMianJi_Max() { return this.SCP_SizeMax; }
        public double getMianJi_Min() { return this.SCP_SizeMin; }
        public double getChangJing_Max() { return this.SCP_MaxLength; }
        public double getChangJing_Min() { return this.SCP_MinLength; }
        public double getDuanJing_Max() { return this.SCP_MaxShort; }
        public double getDuanJing_Min() { return this.SCP_MinShort; }
        public double getBiZhi_Max() { return this.SCP_MaxRate; }
        public double getBiZhi_Min() { return this.SCP_MinRate; }
        public Int16 getR() { return this.SCP_R; }
        public Int16 getG() { return this.SCP_G; }
        public Int16 getB() { return this.SCP_B; }

        public void setZhouChangMianJiBi_Max(string max) {  SCP_MaxPARate = double.Parse(max); }
        public void setZhouChangMianJiBi_Min(string min) {  SCP_MinPARate = double.Parse(min); }

        public override void ReceiveMsg(String s)
        {
            ModbusMessage message = ModbusMessageHelper.decodeModbusMessage(s);
            //switch (message.MsgType)
            {

            }
        }
    }


}
