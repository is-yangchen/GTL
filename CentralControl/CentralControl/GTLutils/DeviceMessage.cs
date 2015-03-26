using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GTLutils
{
    public class DeviceMessage
    {
        public enum DeviceMessageType { IN, OUT };

        public DeviceMessage()
        {

        }

        private String time;
        public String Time
        {
            get
            {
                return this.time;
            }
            set
            {
                this.time = value;
            }
        }

        private DeviceMessageType type;
        public DeviceMessageType Type
        {
            get
            {
                return this.type;
            }
            set
            {
                this.type = value;
            }
        }

        private String msg;
        public String Msg
        {
            get
            {
                return this.msg;
            }
            set
            {
                this.msg = ModbusMessageHelper.forshow(value);
            }
        }

        private BaseDevice device;
        public BaseDevice Device
        {
            get
            {
                return this.device;
            }
            set
            {
                this.device = value;
            }
        }
    }
}
