using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GTLutils
{
    public class DeviceManager
    {
        private static DeviceManager deviceManager = new DeviceManager();

        public static DeviceManager getInstance()
        {
            return deviceManager;
        }

         private List<DeviceMessage> allMessages;
        public List<DeviceMessage> getAllMessages() 
        {
            return allMessages;
        }

        public List<DeviceMessage> getDeviceMessage(BaseDevice device) 
        {
            List<DeviceMessage> result = new List<DeviceMessage>();
            foreach (DeviceMessage msg in allMessages) 
            {
                if (msg.Device == device) 
                {
                    result.Add(msg);
                }
            }
            return result;
        }

        public void receiveMsg(BaseDevice device, String s) 
        {
            DeviceMessage msg = new DeviceMessage();
            msg.Device = device;
            msg.Msg = s;
            msg.Type = DeviceMessage.DeviceMessageType.IN;
            msg.Time = DateTime.Now.ToShortTimeString();
            lock (allMessages) 
            {
                allMessages.Add(msg);
            }
        }

        public void sendMsg(BaseDevice device, String s) 
        {
            DeviceMessage msg = new DeviceMessage();
            msg.Device = device;
            msg.Msg = s;
            msg.Type = DeviceMessage.DeviceMessageType.OUT;
            msg.Time = DateTime.Now.ToShortTimeString();
            lock (allMessages)
            {
                allMessages.Add(msg);
            }
        }


        private List<BaseDevice> deviceList;
        private DeviceManager()
        {
            deviceList = new List<BaseDevice>();
            allMessages = new List<DeviceMessage>();
        }

        public List<BaseDevice> getAllDevices()
        {
            List<BaseDevice> res = new List<BaseDevice>();
            lock (deviceList)
            {
                for (int i = 0; i < deviceList.Count; i++) 
                {
                    res.Add(deviceList[i]);
                }
            }
            return res;
        }

        public bool addDevice(BaseDevice newDevice)
        {
            lock (deviceList)
            {
                deviceList.Add(newDevice);
            }
            return true;
        }

        public BaseDevice getDevice(String code)
        {
            lock (deviceList)
            {
                foreach (BaseDevice device in deviceList)
                {
                    if (device.Code == code) return device;
                }
            }       
            return null;
        }

        public BaseDevice getDevice(int index)
        {
            lock (deviceList)
            {
                return deviceList[index];
            }
        }

        public bool deleteDevice(String code)
        {
            lock (deviceList)
            {
                foreach (BaseDevice device in deviceList)
                {
                    if (device.Code == code)
                    {
                        deviceList.Remove(device);
                        return true;
                    }
                }
            }
            return false;
        }
    }
}
