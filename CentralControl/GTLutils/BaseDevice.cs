using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GTLutils
{
    public enum DeviceStates { Running, Stop, Fault, Connected };
    public enum DeviceType { Dispen, Plate, Clone, Matrix, Liquid, Analysis, Storage, Unknown };

    public class EnumHelper
    {
        public static DeviceType[] TypeEnums = { DeviceType.Dispen, DeviceType.Plate, DeviceType.Clone, DeviceType.Matrix, DeviceType.Liquid, DeviceType.Analysis, DeviceType.Storage };

        public static DeviceType deviceStringToDeviceType(String s) 
        {
            if ("多通道高速代谢性能分析仪".Equals(s)) return DeviceType.Analysis;
            if ("单克隆挑选仪".Equals(s)) return DeviceType.Clone;
            if ("全自动培养皿分装仪".Equals(s)) return DeviceType.Dispen;
            if ("全自动深孔板分装仪".Equals(s)) return DeviceType.Plate;
            if ("全自动液体处理工作站".Equals(s)) return DeviceType.Liquid;
            if ("阵列式高通量培养仪".Equals(s)) return DeviceType.Matrix;
            if ("微孔板储存器".Equals(s)) return DeviceType.Storage;
            return DeviceType.Unknown;
        }

        public static String getDeviceTypeString(DeviceType type)
        {
            switch (type)
            {
                case DeviceType.Analysis:
                    return "多通道高速代谢性能分析仪";
                case DeviceType.Clone:
                    return "单克隆挑选仪";
                case DeviceType.Dispen:
                    return "全自动培养皿分装仪";
                case DeviceType.Plate:
                    return "全自动深孔板分装仪";
                case DeviceType.Liquid:
                    return "全自动液体处理工作站";
                case DeviceType.Matrix:
                    return "阵列式高通量培养仪";
                case DeviceType.Storage:
                    return "微孔板储存器";
                case DeviceType.Unknown:
                    return "未知";
            }
            return null;
        }

        public static String getDeviceStatusString(DeviceStates status)
        {
            switch (status)
            {
                case DeviceStates.Connected:
                    return "刚连接";
                case DeviceStates.Fault:
                    return "故障";
                case DeviceStates.Running:
                    return "正常";
                case DeviceStates.Stop:
                    return "停止";
            }
            return null;
        }
    }

    public class BaseDevice
    {

        protected DeviceManager deviceManager;

        public DeviceManager DeviceManager
        {
            get
            {
                return this.deviceManager;
            }
            set
            {
                this.deviceManager = value;
            }
        }

        private DeviceStates currentState;
        public DeviceStates CurrentState
        {
            get
            {
                return this.currentState;
            }
            set
            {
                this.currentState = value;
            }
        }
        private DeviceType currentDeviceType;
        public DeviceType CurrentDeviceType
        {
            get
            {
                return this.currentDeviceType;
            }
            set
            {
                this.currentDeviceType = value;
            }
        }

        private String ip;
        public String IP
        {
            get
            {
                return this.ip;
            }
            set
            {
                this.ip = value;
            }
        }

        private String name;
        public String Name
        {
            get
            {
                return this.name;
            }
            set
            {
                this.name = value;
            }
        }

        private String code;//MAC生成的机器码
        public String Code
        {
            get
            {
                return this.code;
            }
            set
            {
                this.code = value;
            }
        }

        private String identifyID;//识别码
        public String IdentifyID
        {
            get
            {
                return this.identifyID;
            }
            set
            {
                this.identifyID = value;
            }
        }

        private String serialID;//序列号
        public String SerialID
        {
            get
            {
                return this.serialID;
            }
            set
            {
                this.serialID = value;
            }
        }

        private String controlIP;
        public String ControlIP
        {
            get
            {
                return this.controlIP;
            }
            set
            {
                this.controlIP = value;
            }
        }

        private int sampleTime;
        public int SampleTime
        {
            get
            {
                return this.sampleTime;
            }
            set
            {
                this.sampleTime = value;
            }
        }


        private bool isVirt;
        public bool IsVirt 
        {
            get 
            {
                return this.isVirt;
            }
            set 
            {
                this.isVirt = value;
            }
        }

        public virtual void SendMsg(String s) { }

        public virtual void ReceiveMsg(String s) { }
        public virtual void init() { }
        public virtual void deinit() { }
    }
}
