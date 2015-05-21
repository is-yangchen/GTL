using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GTLutils;

namespace Instrument
{
    public class VirtualDeviceFactory
    {
        public static BaseDevice createVirtualDevice(DeviceType type, bool IsSocket)
        {
            if (IsSocket)
            {
                switch (type)
                {
                    case DeviceType.Analysis:
                        return new MultiTunnelVirtualDevice();
                    case DeviceType.Clone:
                        return new CloneSelectionVirtualDevice();
                    case DeviceType.Dispen:
                        return new AutoDispenVirtualDevice();
                    case DeviceType.Plate:
                        return new AutoPlateVirtualDevice();
                    case DeviceType.Liquid:
                        return new LiquidProcessVirtualDevice();
                    case DeviceType.Matrix:
                        return new MatrixSystemVirtualDevice();
                    case DeviceType.Storage:
                        return new MicroStorageVirtualDevice();
                    case DeviceType.Unknown:
                        return new DemoVirtualDevice();
                }
            }
            else
            {
                switch (type)
                {
                    case DeviceType.Analysis:
                        return new MultiTunnelVirtualDevice();
                    case DeviceType.Clone:
                        return new CloneSelectionVirtualDevice();
                    case DeviceType.Dispen:
                        return new AutoDispenVirtualDevice();
                    case DeviceType.Plate:
                        return new AutoPlateVirtualDevice();
                    case DeviceType.Liquid:
                        return new LiquidProcessVirtualDevice();
                    case DeviceType.Matrix:
                        return new MatrixSystemVirtualDevice();
                    case DeviceType.Storage:
                        return new MicroStorageVirtualDevice();
                    case DeviceType.Unknown:
                        return new DemoVirtualDevice();
                }
            }
            return null;
        }
    }
}
