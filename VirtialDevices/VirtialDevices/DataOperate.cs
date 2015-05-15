using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Windows.Forms;

namespace VirtialDevices
{
    public class DataOperate
    {
        public static object ReadAny(string VariableName, BaseDevice device)
        {
            Type type = device.GetType();
            PropertyInfo pi = type.GetProperty(VariableName);//   .GetField(VariableName);
            if (pi != null)
                return pi.GetValue(device, null);
            else
                throw new Exception("找不到变量：" + VariableName);
        }

        public static String ReadString(string VariableName, BaseDevice device)
        {
            Type type = device.GetType();
            PropertyInfo pi = type.GetProperty(VariableName);
            if (pi != null)
                return (String) pi.GetValue(device, null);
            else
                throw new Exception("找不到变量：" + VariableName);
        }

        public static object[] ReadArray(string VariableName, BaseDevice device)
        {
            //DeviceManager devicemanager = DeviceManager.getInstance();
            //BaseDevice device = devicemanager.getDevice(code);
            Type type = device.GetType();
            PropertyInfo pi = type.GetProperty(VariableName);
            FieldInfo fi = type.GetField(VariableName);

            if (fi != null)
            {
                return (object[])fi.GetValue(device);
            }
            else
                throw new Exception("找不到变量或变量类型不对：" + VariableName);
        }

        public static void WriteAny(string VariableName, BaseDevice device, object value)
        {
            //DeviceManager devicemanager = DeviceManager.getInstance();
            //BaseDevice device = devicemanager.getDevice(code);
            Type type = device.GetType();
            PropertyInfo pi = type.GetProperty(VariableName);
            if(pi!=null)
                pi.SetValue(device ,value, null);
            else
                throw new Exception("找不到变量：" + VariableName);
        }

        public static void WriteString(string VariableName, BaseDevice device, String value)
        {
            //DeviceManager devicemanager = DeviceManager.getInstance();
            //BaseDevice device = devicemanager.getDevice(code);
            Type type = device.GetType();
            PropertyInfo pi = type.GetProperty(VariableName);
            if (pi!=null)
                pi.SetValue(device, value, null);
            else
                throw new Exception("找不到变量：" + VariableName);
        }

        public static void WriteArray(string VariableName, BaseDevice device, object[] value)
        {
            //DeviceManager devicemanager = DeviceManager.getInstance();
            //BaseDevice device = devicemanager.getDevice(code);
            Type type = device.GetType();
            PropertyInfo pi = type.GetProperty(VariableName);
            FieldInfo fi = type.GetField(VariableName);
            if (fi != null)
            {
                fi.SetValue(device, value);
            }
        }
    }
}
