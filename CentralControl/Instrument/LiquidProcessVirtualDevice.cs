using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GTLutils;

namespace Instrument
{
    public class ALCDeviceMessageCreator
    {
        public static String createDeployStatus(String status)
        {
            ModbusMessageDataCreator creator = new ModbusMessageDataCreator();
            creator.addKeyPair("SetType", "taiMianPeiZhi");
            creator.addKeyPair("taiMianPeiZhi", status);
            return ModbusMessageHelper.createModbusMessage(ModbusMessage.messageTypeToByte(ModbusMessage.MessageType.SET), creator.getDataBytes());
        }

        public static String createWeiZhiConfirmMsg(String xiYeWeiZhi, String paiYeWeiZhi)
        {
            ModbusMessageDataCreator creator = new ModbusMessageDataCreator();
            creator.addKeyPair("SetType", "weiZhiSheZhi");
            creator.addKeyPair("xiYeWeiZhi", xiYeWeiZhi);
            creator.addKeyPair("paiYeWeiZhi", paiYeWeiZhi);
            return ModbusMessageHelper.createModbusMessage(ModbusMessage.messageTypeToByte(ModbusMessage.MessageType.SET), creator.getDataBytes());
        }

        public static String createMuBiaoConfirmMsg(String quYePan, String muBiaoPan,String xiYeLiang)
        {
            ModbusMessageDataCreator creator = new ModbusMessageDataCreator();
            creator.addKeyPair("SetType", "yiYeWeiZhi");
            creator.addKeyPair("quYePan", quYePan);
            creator.addKeyPair("muBiaoPan", muBiaoPan);
            creator.addKeyPair("xiYeLiang", xiYeLiang);
            return ModbusMessageHelper.createModbusMessage(ModbusMessage.messageTypeToByte(ModbusMessage.MessageType.SET), creator.getDataBytes());
        }

        public static String createSuDuConfirmMsg(String xiYeSuDu, String paiYeSuDu)
        {
            ModbusMessageDataCreator creator = new ModbusMessageDataCreator();
            creator.addKeyPair("SetType", "suDuSheZhi");
            creator.addKeyPair("xiYeSuDu", xiYeSuDu);
            creator.addKeyPair("paiYeSuDu", paiYeSuDu);
            return ModbusMessageHelper.createModbusMessage(ModbusMessage.messageTypeToByte(ModbusMessage.MessageType.SET), creator.getDataBytes());
        }
    }

    public class LiquidProcessVirtualDevice : BaseVirtualDevice
    {
        public String msgStatus = "";
        public String quYePan = "";
        public String muBiaoPan = "";
        public int xiYeLiang = 0;
        public int xiYeSuDu = 0;
        public int paiYeSuDu = 0;
        public int xiYeWeiZhi = 0;
        public int paiYeWeiZhi = 0;
    }

}
