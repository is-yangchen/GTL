using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TwinCAT.Ads;

namespace DeviceUtils
{

    public class ConstSettings 
    {
        public static int StringLength = 200;
    }

    public class BaseTwincatDevice : BaseDevice
    {
        protected Dictionary<String,int> handleMap = new Dictionary<String,int>();
        protected TcAdsClient adsClient;
        protected String cmdString;
        public void send_basic_info()
        {
            ModbusMessageDataCreator creator = new ModbusMessageDataCreator();
            creator.addKeyPair("SetType", "BasicInfo");
            creator.addKeyPair("DeviceType", EnumHelper.getDeviceTypeString(this.CurrentDeviceType));
            //if (this.CurrentDeviceType == DeviceType.Dispen)
            //{
            //    if (((AutoDispenTwincatDevice)this).SubType == AutoDispenTwincatDevice.AutoDispenType.PeiYangMin)
            //        creator.addKeyPair("SubType", "PeiYangMin");
            //    else
            //        creator.addKeyPair("SubType", "ShenKongBan");
            //}
            creator.addKeyPair("IP", this.IP);
            creator.addKeyPair("Name", this.Name);
            creator.addKeyPair("IdentifyID", this.IdentifyID);
            creator.addKeyPair("SerialID", this.SerialID);
            creator.addKeyPair("Code", this.Code);
            String msg = ModbusMessageHelper.createModbusMessage(ModbusMessage.messageTypeToByte(ModbusMessage.MessageType.SET), creator.getDataBytes());
            adsClient.WriteAny(handleMap[cmdString],msg,new int[]{ConstSettings.StringLength});
        }
    }
}
