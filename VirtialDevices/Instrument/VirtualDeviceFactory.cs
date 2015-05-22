using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DeviceUtils;

namespace Instrument
{
    public class VirtualDeviceFactory
    {
        public static BaseDevice createVirtualDevice(DeviceType type,bool IsSocket) 
        {
            if (IsSocket)
            {
                switch (type)
                {
                    case DeviceType.Analysis:
                        return new MultiTunnelDevice();
                    case DeviceType.Clone:
                        return new CloneSelectionDevice();
                    case DeviceType.Dispen:
                        return new AutoDispenDevice();
                    case DeviceType.Plate:
                        return new AutoPlateDevice();
                    case DeviceType.Liquid:
                        return new LiquidProcessDevice();
                    case DeviceType.Matrix:
                        return new MatrixSystemDevice();
                    case DeviceType.Storage:
                        return new MicroStorageDevice();
                    case DeviceType.Unknown:
                        return new DemoVirtualDevice();
                }
            }
            else 
            {
                switch (type)
                {
                    case DeviceType.Analysis:
                        return new MultiTunnelDevice();
                    case DeviceType.Clone:
                        return new CloneSelectionDevice();
                    case DeviceType.Dispen:
                        return new AutoDispenDevice();
                    case DeviceType.Plate:
                        return new AutoPlateDevice();
                    case DeviceType.Liquid:
                        return new LiquidProcessDevice();
                    case DeviceType.Matrix:
                        return new MatrixSystemDevice();
                    case DeviceType.Storage:
                        return new MicroStorageDevice();
                    case DeviceType.Unknown:
                        return new DemoVirtualDevice();
                }
            }
            return null;
        }
    }
}
