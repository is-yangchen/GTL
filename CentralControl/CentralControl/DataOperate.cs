using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Windows.Forms;
using GTLutils;

namespace CentralControl
{
    public class DataOperate
    {
        public static object ReadAny(string VariableName, string code)
        {
            DeviceManager devicemanager = DeviceManager.getInstance();
            BaseDevice device = devicemanager.getDevice(code);
            DeviceType devicetype = device.CurrentDeviceType;
            Type type = device.GetType();
            switch (devicetype)
            {
                case DeviceType.Analysis:
                    type = ((MultiTunnelVirtualDevice)device).GetType();
                    break;
                case DeviceType.Clone:
                    type = ((CloneSelectionVirtualDevice)device).GetType();
                    break;
                case DeviceType.Dispen:
                    type = ((AutoDispenVirtualDevice)device).GetType();
                    break;
                case DeviceType.Liquid:
                    type = ((LiquidProcessVirtualDevice)device).GetType();
                    break;
                case DeviceType.Matrix:
                    type = ((MatrixSystemVirtualDevice)device).GetType();
                    break;
                case DeviceType.Storage:
                    type = ((MicroStorageVirtualDevice)device).GetType();
                    break;
            }
            PropertyInfo pi = type.GetProperty(VariableName);//   .GetField(VariableName);
            object tmp = pi.GetValue(device, null);
            /*
            Assembly assembly = System.Reflection.Assembly.GetExecutingAssembly();
            Type type = assembly.GetType(str);
            object obj = Activator.CreateInstance(type, true);
            PropertyInfo classProperty = type.GetProperty(VariableName);
            object tmp = classProperty.GetValue(obj, null);            
             */
            return tmp;
        }

        public static String ReadString(string VariableName, string code)
        {
            DeviceManager devicemanager = DeviceManager.getInstance();
            BaseDevice device = devicemanager.getDevice(code);
            DeviceType devicetype = device.CurrentDeviceType;
            Type type = device.GetType();
            switch (devicetype)
            {
                case DeviceType.Analysis:
                    type = ((MultiTunnelVirtualDevice)device).GetType();
                    break;
                case DeviceType.Clone:
                    type = ((CloneSelectionVirtualDevice)device).GetType();
                    break;
                case DeviceType.Dispen:
                    type = ((AutoDispenVirtualDevice)device).GetType();
                    break;
                case DeviceType.Liquid:
                    type = ((LiquidProcessVirtualDevice)device).GetType();
                    break;
                case DeviceType.Matrix:
                    type = ((MatrixSystemVirtualDevice)device).GetType();
                    break;
                case DeviceType.Storage:
                    type = ((MicroStorageVirtualDevice)device).GetType();
                    break;
            }
            PropertyInfo pi = type.GetProperty(VariableName);
            String str =(String) pi.GetValue(device, null);
            return str;
        }

        public static void WriteAny(string VariableName, string code, object value)
        {
            DeviceManager devicemanager = DeviceManager.getInstance();
            BaseDevice device = devicemanager.getDevice(code);
            DeviceType devicetype = device.CurrentDeviceType;
            Type type = device.GetType();
            switch (devicetype)
            {
                case DeviceType.Analysis:
                    type = ((MultiTunnelVirtualDevice)device).GetType();
                    break;
                case DeviceType.Clone:
                    type = ((CloneSelectionVirtualDevice)device).GetType();
                    break;
                case DeviceType.Dispen:
                    type = ((AutoDispenVirtualDevice)device).GetType();
                    break;
                case DeviceType.Liquid:
                    type = ((LiquidProcessVirtualDevice)device).GetType();
                    break;
                case DeviceType.Matrix:
                    type = ((MatrixSystemVirtualDevice)device).GetType();
                    break;
                case DeviceType.Storage:
                    type = ((MicroStorageVirtualDevice)device).GetType();
                    break;
            }
            PropertyInfo pi = type.GetProperty(VariableName);
            pi.SetValue(device ,value, null);
        }

        public static void WriteString(string VariableName, string code, String value)
        {
            DeviceManager devicemanager = DeviceManager.getInstance();
            BaseDevice device = devicemanager.getDevice(code);
            DeviceType devicetype = device.CurrentDeviceType;
            Type type = device.GetType();
            switch (devicetype)
            {
                case DeviceType.Analysis:
                    type = ((MultiTunnelVirtualDevice)device).GetType();
                    break;
                case DeviceType.Clone:
                    type = ((CloneSelectionVirtualDevice)device).GetType();
                    break;
                case DeviceType.Dispen:
                    type = ((AutoDispenVirtualDevice)device).GetType();
                    break;
                case DeviceType.Liquid:
                    type = ((LiquidProcessVirtualDevice)device).GetType();
                    break;
                case DeviceType.Matrix:
                    type = ((MatrixSystemVirtualDevice)device).GetType();
                    break;
                case DeviceType.Storage:
                    type = ((MicroStorageVirtualDevice)device).GetType();
                    break;
            }
            PropertyInfo pi = type.GetProperty(VariableName);
            pi.SetValue(device, value, null);
        }
    }
}
