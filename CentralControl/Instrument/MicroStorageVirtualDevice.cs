using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GTLutils;

namespace Instrument
{
    public class MRDeviceMessageCreator
    {
        public static String createSettingMsg(int moduleNum, int speed, int temp, int time, int air, int pressure)
        {
            ModbusMessageDataCreator creator = new ModbusMessageDataCreator();
            creator.addKeyPair("SetType", "Setting");
            creator.addKeyPair("moduleNum", moduleNum.ToString());
            creator.addKeyPair("speed", speed.ToString());
            creator.addKeyPair("temp", temp.ToString());
            creator.addKeyPair("time", time.ToString());
            creator.addKeyPair("air", air.ToString());
            creator.addKeyPair("pressure", pressure.ToString());
            return ModbusMessageHelper.createModbusMessage(ModbusMessage.messageTypeToByte(ModbusMessage.MessageType.SET), creator.getDataBytes());
        }

        public static String createStartMsg(int moduleNum)
        {
            ModbusMessageDataCreator creator = new ModbusMessageDataCreator();
            creator.addKeyPair("SetType", "Start");
            creator.addKeyPair("moduleNum", moduleNum.ToString());
            return ModbusMessageHelper.createModbusMessage(ModbusMessage.messageTypeToByte(ModbusMessage.MessageType.SET), creator.getDataBytes());
        }

        public static String createStopMsg(int moduleNum)
        {
            ModbusMessageDataCreator creator = new ModbusMessageDataCreator();
            creator.addKeyPair("SetType", "Stop");
            creator.addKeyPair("moduleNum", moduleNum.ToString());
            return ModbusMessageHelper.createModbusMessage(ModbusMessage.messageTypeToByte(ModbusMessage.MessageType.SET), creator.getDataBytes());
        }

    }
    public class MicroStorageVirtualDevice : BaseVirtualDevice
    {

        public override void decodeResponseMessage(ModbusMessage msg)
        {
            String setType = (String)msg.Data["SetType"];
            if ("Response".Equals(setType))
            {
                int mnum = Int32.Parse((String)msg.Data["moduleNum"]);
                int curtpR = Int32.Parse((String)msg.Data["tpR"]);
                int curphR = Int32.Parse((String)msg.Data["phR"]);
                int curdoR = Int32.Parse((String)msg.Data["doR"]);
                switch (mnum)
                {
                    case 1:
                        tpR1 = curtpR;
                        phR1 = curphR;
                        doR1 = curdoR;
                        break;
                    case 2:
                        tpR2 = curtpR;
                        phR2 = curphR;
                        doR2 = curdoR;
                        break;
                    case 3:
                        tpR3 = curtpR;
                        phR3 = curphR;
                        doR3 = curdoR;
                        break;
                    case 4:
                        tpR4 = curtpR;
                        phR4 = curphR;
                        doR4 = curdoR;
                        break;
                    case 5:
                        tpR5 = curtpR;
                        phR5 = curphR;
                        doR5 = curdoR;
                        break;
                    case 6:
                        tpR6 = curtpR;
                        phR6 = curphR;
                        doR6 = curdoR;
                        break;
                    case 7:
                        tpR7 = curtpR;
                        phR7 = curphR;
                        doR7 = curdoR;
                        break;
                    case 8:
                        tpR8 = curtpR;
                        phR8 = curphR;
                        doR8 = curdoR;
                        break;
                }
                Database mydb = new Database();
                mydb.insertmmrinfo(1, mnum, curtpR, curphR, curdoR);
            }
        }


        public int curSelectModule;
        public bool run1 = false;
        public bool run2 = false;
        public bool run3 = false;
        public bool run4 = false;
        public bool run5 = false;
        public bool run6 = false;
        public bool run7 = false;
        public bool run8 = false;

        public int curSpeed;
        public int curTemp;
        public int curAir;
        public int curPressure;
        public int curTime;
        public int curtpR;
        public int curphR;
        public int curdoR;

        public int Speed1;
        public int Temp1;
        public int Air1;
        public int Pressure1;
        public int Time1;
        public int tpR1;
        public int phR1;
        public int doR1;

        public int Speed2;
        public int Temp2;
        public int Air2;
        public int Pressure2;
        public int Time2;
        public int tpR2;
        public int phR2;
        public int doR2;

        public int Speed3;
        public int Temp3;
        public int Air3;
        public int Pressure3;
        public int Time3;
        public int tpR3;
        public int phR3;
        public int doR3;

        public int Speed4;
        public int Temp4;
        public int Air4;
        public int Pressure4;
        public int Time4;
        public int tpR4;
        public int phR4;
        public int doR4;

        public int Speed5;
        public int Temp5;
        public int Air5;
        public int Pressure5;
        public int Time5;
        public int tpR5;
        public int phR5;
        public int doR5;

        public int Speed6;
        public int Temp6;
        public int Air6;
        public int Pressure6;
        public int Time6;
        public int tpR6;
        public int phR6;
        public int doR6;

        public int Speed7;
        public int Temp7;
        public int Air7;
        public int Pressure7;
        public int Time7;
        public int tpR7;
        public int phR7;
        public int doR7;

        public int Speed8;
        public int Temp8;
        public int Air8;
        public int Pressure8;
        public int Time8;
        public int tpR8;
        public int phR8;
        public int doR8;

        public override void ReceiveMsg(String s)
        {
            ModbusMessage message = ModbusMessageHelper.decodeModbusMessage(s);
            switch (message.MsgType)
            {
                case ModbusMessage.MessageType.RESPONSE:
                    decodeResponseMessage(message);
                    break;
            }
        }

    }
}
