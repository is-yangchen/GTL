using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DeviceUtils;

namespace Instrument
{
    public class LiquidProcessDevice : BaseVirtualDevice
    {
        public String quYePan;
        public String muBiaoPan;
        public int xiYeLiang;
        public int xiYeSuDu;
        public int paiYeSuDu;
        public int quYeWeiZhi;
        public int paiYeWeiZhi;
        public String taiMianPeiZhi;

        public LiquidProcessDevice() 
        {
            quYePan = "";
            muBiaoPan = "";
            xiYeLiang = 0;
            xiYeSuDu = 0;
            paiYeSuDu = 0;
            quYeWeiZhi = 0;
            paiYeWeiZhi = 0;
            taiMianPeiZhi = "00000000000000000000";
        }

        private void decodeSetMessage(ModbusMessage msg)
        {
            String setType = (String)msg.Data["SetType"];
            if ("yiYeWeiZhi".Equals(setType))
            {
                quYePan = (String)msg.Data["quYePan"];
                muBiaoPan = (String)msg.Data["muBiaoPan"];
                xiYeLiang = Int32.Parse((String)msg.Data["xiYeLiang"]);
            }
            if ("suDuSheZhi".Equals(setType))
            {
                xiYeSuDu = Int32.Parse((String)msg.Data["xiYeSuDu"]);
                paiYeSuDu = Int32.Parse((String)msg.Data["paiYeSuDu"]);
            }
            if ("weiZhiSheZhi".Equals(setType))
            {
                quYeWeiZhi = Int32.Parse((String)msg.Data["xiYeWeiZhi"]);
                paiYeWeiZhi = Int32.Parse((String)msg.Data["paiYeWeiZhi"]);
            }
            if ("taiMianPeiZhi".Equals(setType))
            {
                taiMianPeiZhi = (String)msg.Data["taiMianPeiZhi"];
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
