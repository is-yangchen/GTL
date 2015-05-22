using System;
using System.Collections;
using System.Linq;
using System.Text;
using GTLutils;

namespace Instrument
{
    public class DemoVirtualDevice : BaseVirtualDevice
    {
        /// <summary>
        /// MPF parameters
        /// </summary>
        public int MPF_PlateNum;
        public double MPF_Volsperwell;
        public int MPF_CurSamTime;
        public string MPF_Cmd;
        public int MPF_RunningError;
        public double MPF_Current1;
        public double MPF_Current2;
        public double MPF_Current3;
        public double MPF_Current4;

        public void SendCmd(String cmd)
        {
            this.SendModBusMsg(ModbusMessage.MessageType.CMD, "Cmd", cmd);
        }

        public void SendMPFSetNumAndVol(String Num, String Vol)
        {
            this.SendModBusMsg(ModbusMessage.MessageType.SET, "MPF_PlateNum", Num);
            this.SendModBusMsg(ModbusMessage.MessageType.SET, "MPF_Volsperwell", Vol);
        }

        public void SendMPFCurrentReport()
        {
            Hashtable htable = new Hashtable();
            htable.Add("MPF_Current1", MPF_Current1.ToString());
            htable.Add("MPF_Current2", MPF_Current2.ToString());
            htable.Add("MPF_Current3", MPF_Current3.ToString());
            htable.Add("MPF_Current4", MPF_Current4.ToString());
            this.SendModBusMsg(ModbusMessage.MessageType.REPORT, htable);
        }
    }
}
