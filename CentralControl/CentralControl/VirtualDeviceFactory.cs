using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GTLutils;

namespace CentralControl
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
                    case DeviceType.Liquid:
                        return new LiquidProcessVirtualDevice();
                    case DeviceType.Matrix:
                        return new MatrixSystemVirtualDevice();
                    case DeviceType.Storage:
                        return new MicroStorageVirtualDevice();

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
                        return new AutoDispenTwincatDevice();
                    case DeviceType.Liquid:
                        return new LiquidProcessVirtualDevice();
                    case DeviceType.Matrix:
                        return new MatrixSystemVirtualDevice();
                    case DeviceType.Storage:
                        return new MicroStorageVirtualDevice();

                }
            }
            return null;
        }
    }
}
