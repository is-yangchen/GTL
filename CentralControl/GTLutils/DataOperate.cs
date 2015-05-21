using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace GTLutils
{
    class DataOperate
    {
        public static object ReadAny(string VariableName, string code)
        {
            DeviceManager devicemanager = DeviceManager.getInstance();
            BaseDevice device = devicemanager.getDevice(code);
            DeviceType devicetype = device.CurrentDeviceType;

            switch (devicetype)
            {
                case DeviceType.Analysis:
                    Convert.ChangeType(device, Assembly.Load("Instrument").GetType("Instrument.MultiTunnelVirtualDevice"));
                    break;
                case DeviceType.Clone:
                    Convert.ChangeType(device, Assembly.Load("Instrument").GetType("Instrument.CloneSelectionVirtualDevice"));
                    break;
                case DeviceType.Dispen:
                    Convert.ChangeType(device, Assembly.Load("Instrument").GetType("Instrument.AutoDispenVirtualDevice"));
                    break;
                case DeviceType.Liquid:
                    Convert.ChangeType(device, Assembly.Load("Instrument").GetType("Instrument.LiquidProcessVirtualDevice"));
                    break;
                case DeviceType.Matrix:
                    Convert.ChangeType(device, Assembly.Load("Instrument").GetType("Instrument.MatrixSystemVirtualDevice"));
                    break;
                case DeviceType.Storage:
                    Convert.ChangeType(device, Assembly.Load("Instrument").GetType("Instrument.MicroStorageVirtualDevice"));
                    break;
                default:
                    Convert.ChangeType(device, Assembly.Load("Instrument").GetType("Instrument.DemoVirtualDevice"));
                    break;
            }

            Type type = device.GetType();
            PropertyInfo pi = type.GetProperty(VariableName);
            FieldInfo fi = type.GetField(VariableName);
            if (pi != null)
                return pi.GetValue(device, null);
            if (fi != null)
                return fi.GetValue(device);
            if (pi == null && fi == null)
                Console.WriteLine("找不到变量：" + VariableName);
            return null;
        }

        public static String ReadString(string VariableName, string code)
        {
            DeviceManager devicemanager = DeviceManager.getInstance();
            BaseDevice device = devicemanager.getDevice(code);
            DeviceType devicetype = device.CurrentDeviceType;
            switch (devicetype)
            {
                case DeviceType.Analysis:
                    Convert.ChangeType(device, Assembly.Load("Instrument").GetType("Instrument.MultiTunnelVirtualDevice"));
                    break;
                case DeviceType.Clone:
                    Convert.ChangeType(device, Assembly.Load("Instrument").GetType("Instrument.CloneSelectionVirtualDevice"));
                    break;
                case DeviceType.Dispen:
                    Convert.ChangeType(device, Assembly.Load("Instrument").GetType("Instrument.AutoDispenVirtualDevice"));
                    break;
                case DeviceType.Liquid:
                    Convert.ChangeType(device, Assembly.Load("Instrument").GetType("Instrument.LiquidProcessVirtualDevice"));
                    break;
                case DeviceType.Matrix:
                    Convert.ChangeType(device, Assembly.Load("Instrument").GetType("Instrument.MatrixSystemVirtualDevice"));
                    break;
                case DeviceType.Storage:
                    Convert.ChangeType(device, Assembly.Load("Instrument").GetType("Instrument.MicroStorageVirtualDevice"));
                    break;
                default:
                    Convert.ChangeType(device, Assembly.Load("Instrument").GetType("Instrument.DemoVirtualDevice"));
                    break;
            }

            Type type = device.GetType();
            PropertyInfo pi = type.GetProperty(VariableName);
            FieldInfo fi = type.GetField(VariableName);
            if (pi != null)
                return (String)pi.GetValue(device, null);
            if (fi != null)
                return (String)fi.GetValue(device);
            if (pi == null && fi == null)
                Console.WriteLine("找不到变量：" + VariableName);
            return null;
        }

        public static object[] ReadArray(string VariableName, string code)
        {
            DeviceManager devicemanager = DeviceManager.getInstance();
            BaseDevice device = devicemanager.getDevice(code);
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

        public static void WriteAny(string VariableName, string code, object value)
        {
            DeviceManager devicemanager = DeviceManager.getInstance();
            BaseDevice device = devicemanager.getDevice(code);
            DeviceType devicetype = device.CurrentDeviceType;
            switch (devicetype)
            {
                case DeviceType.Analysis:
                    Convert.ChangeType(device, Assembly.Load("Instrument").GetType("Instrument.MultiTunnelVirtualDevice"));
                    break;
                case DeviceType.Clone:
                    Convert.ChangeType(device, Assembly.Load("Instrument").GetType("Instrument.CloneSelectionVirtualDevice"));
                    break;
                case DeviceType.Dispen:
                    Convert.ChangeType(device, Assembly.Load("Instrument").GetType("Instrument.AutoDispenVirtualDevice"));
                    break;
                case DeviceType.Liquid:
                    Convert.ChangeType(device, Assembly.Load("Instrument").GetType("Instrument.LiquidProcessVirtualDevice"));
                    break;
                case DeviceType.Matrix:
                    Convert.ChangeType(device, Assembly.Load("Instrument").GetType("Instrument.MatrixSystemVirtualDevice"));
                    break;
                case DeviceType.Storage:
                    Convert.ChangeType(device, Assembly.Load("Instrument").GetType("Instrument.MicroStorageVirtualDevice"));
                    break;
                default:
                    Convert.ChangeType(device, Assembly.Load("Instrument").GetType("Instrument.DemoVirtualDevice"));
                    break;
            }

            Type type = device.GetType();
            PropertyInfo pi = type.GetProperty(VariableName);
            FieldInfo fi = type.GetField(VariableName);
            if (fi != null)
            {
                fi.SetValue(device, Convert.ChangeType((string)value, fi.FieldType));
            }

            if (pi != null)
                pi.SetValue(device, Convert.ChangeType((string)value, pi.PropertyType), null);
            if (fi == null && pi == null)
                Console.WriteLine("找不到变量：" + VariableName);
        }

        public static void WriteString(string VariableName, string code, String value)
        {
            DeviceManager devicemanager = DeviceManager.getInstance();
            BaseDevice device = devicemanager.getDevice(code);
            DeviceType devicetype = device.CurrentDeviceType;
            switch (devicetype)
            {
                case DeviceType.Analysis:
                    Convert.ChangeType(device, Assembly.Load("Instrument").GetType("Instrument.MultiTunnelVirtualDevice"));
                    break;
                case DeviceType.Clone:
                    Convert.ChangeType(device, Assembly.Load("Instrument").GetType("Instrument.CloneSelectionVirtualDevice"));
                    break;
                case DeviceType.Dispen:
                    Convert.ChangeType(device, Assembly.Load("Instrument").GetType("Instrument.AutoDispenVirtualDevice"));
                    break;
                case DeviceType.Liquid:
                    Convert.ChangeType(device, Assembly.Load("Instrument").GetType("Instrument.LiquidProcessVirtualDevice"));
                    break;
                case DeviceType.Matrix:
                    Convert.ChangeType(device, Assembly.Load("Instrument").GetType("Instrument.MatrixSystemVirtualDevice"));
                    break;
                case DeviceType.Storage:
                    Convert.ChangeType(device, Assembly.Load("Instrument").GetType("Instrument.MicroStorageVirtualDevice"));
                    break;
                default:
                    Convert.ChangeType(device, Assembly.Load("Instrument").GetType("Instrument.DemoVirtualDevice"));
                    break;
            }

            Type type = device.GetType();
            PropertyInfo pi = type.GetProperty(VariableName);
            FieldInfo fi = type.GetField(VariableName);
            if (fi != null)
                fi.SetValue(device, Double.Parse((string)value));
            if (pi != null)
                pi.SetValue(device, (string)value, null);
            if (fi == null && pi == null)
                Console.WriteLine("找不到变量：" + VariableName);
        }

        public static void WriteArray(string VariableName, string code, object[] value)
        {
            DeviceManager devicemanager = DeviceManager.getInstance();
            BaseDevice device = devicemanager.getDevice(code);
            Type type = device.GetType();
            PropertyInfo pi = type.GetProperty(VariableName);
            FieldInfo fi = type.GetField(VariableName);
            if (fi != null)
            {
                fi.SetValue(device, value);
            }
        }

        internal static void WriteAny(object p1, string p2, object p3)
        {
            throw new NotImplementedException();
        }
    }
}
