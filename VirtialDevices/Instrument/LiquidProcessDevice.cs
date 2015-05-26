using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DeviceUtils;

namespace Instrument
{
    public class LiquidProcessDevice : BaseVirtualDevice
    {
        public String LHS_SuctionPlate;
        public String LHS_TargetPlate;
        public int LHS_Imbitition;
        public int LHS_LiquidRate;
        public int LHS_DischargeRate;
        public int LHS_LiquidPosition;
        public int LHS_DischargePosition;
        public String LHS_PlateStatus;

        public LiquidProcessDevice()
        {
            LHS_SuctionPlate = "";
            LHS_TargetPlate = "";
            LHS_Imbitition = 0;
            LHS_LiquidRate = 0;
            LHS_DischargeRate = 0;
            LHS_LiquidPosition = 0;
            LHS_DischargePosition = 0;
            LHS_PlateStatus = "00000000000000000000";
        }

        private void decodeSetMessage(ModbusMessage msg)
        {
            String setType = (String)msg.Data["SetType"];
            if ("yiYeWeiZhi".Equals(setType))
            {
                LHS_SuctionPlate = (String)msg.Data["LHS_SuctionPlate"];
                LHS_TargetPlate = (String)msg.Data["LHS_TargetPlate"];
                LHS_Imbitition = Int32.Parse((String)msg.Data["LHS_Imbitition"]);
            }
            if ("suDuSheZhi".Equals(setType))
            {
                LHS_LiquidRate = Int32.Parse((String)msg.Data["LHS_LiquidRate"]);
                LHS_DischargeRate = Int32.Parse((String)msg.Data["LHS_DischargeRate"]);
            }
            if ("weiZhiSheZhi".Equals(setType))
            {
                LHS_LiquidPosition = Int32.Parse((String)msg.Data["LHS_LiquidPosition"]);
                LHS_DischargePosition = Int32.Parse((String)msg.Data["LHS_DischargePosition"]);
            }
            if ("LHS_PlateStatus".Equals(setType))
            {
                LHS_PlateStatus = (String)msg.Data["LHS_PlateStatus"];
            }
        }

        public override void ReceiveMsg(String s)
        {
            ModbusMessage message = ModbusMessageHelper.decodeModbusMessage(s);
            switch (message.MsgType)
            {
                case ModbusMessage.MessageType.SET:
                    decodeSetMessage(message);
                    break;
            }
        }
    }
}
