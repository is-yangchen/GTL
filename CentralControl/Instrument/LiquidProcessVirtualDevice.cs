using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GTLutils;

namespace Instrument
{
    public class ALCDeviceMessageCreator
    {
        public static String createDeployStatus(String LHS_PlateStatus)
        {
            ModbusMessageDataCreator creator = new ModbusMessageDataCreator();
            creator.addKeyPair("SetType", "LHS_PlateStatus");
            creator.addKeyPair("LHS_PlateStatus", LHS_PlateStatus);
            return ModbusMessageHelper.createModbusMessage(ModbusMessage.messageTypeToByte(ModbusMessage.MessageType.SET), creator.getDataBytes());
        }

        public static String createWeiZhiConfirmMsg(String LHS_LiquidPosition, String LHS_DischargePosition)
        {
            ModbusMessageDataCreator creator = new ModbusMessageDataCreator();
            creator.addKeyPair("SetType", "weiZhiSheZhi");
            creator.addKeyPair("LHS_LiquidPosition", LHS_LiquidPosition);
            creator.addKeyPair("LHS_DischargePosition", LHS_DischargePosition);
            return ModbusMessageHelper.createModbusMessage(ModbusMessage.messageTypeToByte(ModbusMessage.MessageType.SET), creator.getDataBytes());
        }

        public static String createMuBiaoConfirmMsg(String LHS_SuctionPlate, String LHS_TargetPlate, String LHS_Imbitition)
        {
            ModbusMessageDataCreator creator = new ModbusMessageDataCreator();
            creator.addKeyPair("SetType", "yiYeWeiZhi");
            creator.addKeyPair("LHS_SuctionPlate", LHS_SuctionPlate);
            creator.addKeyPair("LHS_TargetPlate", LHS_TargetPlate);
            creator.addKeyPair("LHS_Imbitition", LHS_Imbitition);
            return ModbusMessageHelper.createModbusMessage(ModbusMessage.messageTypeToByte(ModbusMessage.MessageType.SET), creator.getDataBytes());
        }

        public static String createSuDuConfirmMsg(String LHS_LiquidRate, String LHS_DischargeRate)
        {
            ModbusMessageDataCreator creator = new ModbusMessageDataCreator();
            creator.addKeyPair("SetType", "suDuSheZhi");
            creator.addKeyPair("LHS_LiquidRate", LHS_LiquidRate);
            creator.addKeyPair("LHS_DischargeRate", LHS_DischargeRate);
            return ModbusMessageHelper.createModbusMessage(ModbusMessage.messageTypeToByte(ModbusMessage.MessageType.SET), creator.getDataBytes());
        }
    }

    public class LiquidProcessVirtualDevice : BaseVirtualDevice
    {
        public String LHS_PlateStatus = "";
        public String LHS_SuctionPlate = "";
        public String LHS_TargetPlate = "";
        public int LHS_Imbitition = 0;
        public int LHS_LiquidRate = 0;
        public int LHS_DischargeRate = 0;
        public int LHS_LiquidPosition = 0;
        public int LHS_DischargePosition = 0;
    }

}
