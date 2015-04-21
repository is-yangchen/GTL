using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VirtialDevices
{
    public class MicroStorageDevice : BaseVirtualDevice
    {
        public static String createResponseMsg(int moduleNum, int tpR, int phR, int doR)
        {
            ModbusMessageDataCreator creator = new ModbusMessageDataCreator();
            creator.addKeyPair("SetType", "Response");
            creator.addKeyPair("moduleNum", moduleNum.ToString());
            creator.addKeyPair("tpR", tpR.ToString());
            creator.addKeyPair("phR", phR.ToString());
            creator.addKeyPair("doR", doR.ToString());
            return ModbusMessageHelper.createModbusMessage(ModbusMessage.messageTypeToByte(ModbusMessage.MessageType.RESPONSE), creator.getDataBytes());
        }


        private void decodeSetMessage(ModbusMessage msg)
        {
            String setType = (String)msg.Data["SetType"];

            if ("Setting".Equals(setType))
            {
                curSelectModule = Int32.Parse((String)msg.Data["moduleNum"]);
                curSpeed = Int32.Parse((String)msg.Data["speed"]);
                curTemp = Int32.Parse((String)msg.Data["temp"]);
                curTime = Int32.Parse((String)msg.Data["time"]);
                curAir = Int32.Parse((String)msg.Data["air"]);
                curPressure = Int32.Parse((String)msg.Data["pressure"]);

                switch (curSelectModule)
                {
                    case 1:
                        Speed1 = curSpeed;
                        Temp1 = curTemp;
                        Time1 = curTime;
                        Air1 = curAir;
                        Pressure1 = curPressure;
                        break;
                    case 2:
                        Speed2 = curSpeed;
                        Temp2 = curTemp;
                        Time2 = curTime;
                        Air2 = curAir;
                        Pressure2 = curPressure;
                        break;
                    case 3:
                        Speed3 = curSpeed;
                        Temp3 = curTemp;
                        Time3 = curTime;
                        Air3 = curAir;
                        Pressure3 = curPressure;
                        break;
                    case 4:
                        Speed4 = curSpeed;
                        Temp4 = curTemp;
                        Time4 = curTime;
                        Air4 = curAir;
                        Pressure4 = curPressure;
                        break;
                    case 5:
                        Speed5 = curSpeed;
                        Temp5 = curTemp;
                        Time5 = curTime;
                        Air5 = curAir;
                        Pressure5 = curPressure;
                        break;
                    case 6:
                        Speed6 = curSpeed;
                        Temp6 = curTemp;
                        Time6 = curTime;
                        Air6 = curAir;
                        Pressure6 = curPressure;
                        break;
                    case 7:
                        Speed7 = curSpeed;
                        Temp7 = curTemp;
                        Time7 = curTime;
                        Air7 = curAir;
                        Pressure7 = curPressure;
                        break;
                    case 8:
                        Speed8 = curSpeed;
                        Temp8 = curTemp;
                        Time8 = curTime;
                        Air8 = curAir;
                        Pressure8 = curPressure;
                        break;
                    default:
                        break;

                }

            }


            if ("Start".Equals(setType))
            {
                int mnum = Int32.Parse((String)msg.Data["moduleNum"]);
                switch (mnum)
                {
                    case 1:
                        run1 = true;
                        String msg2 = createResponseMsg(mnum, tpR1, phR1, doR1);
                        SendMsg(msg2);
                        break;
                    case 2:
                        run2 = true;
                        String msg3 = createResponseMsg(mnum, tpR2, phR2, doR2);
                        SendMsg(msg3);
                        break;
                    case 3:
                        run3 = true;
                        String msg4 = createResponseMsg(mnum, tpR3, phR3, doR3);
                        SendMsg(msg4);
                        break;
                    case 4:
                        run4 = true;
                        String msg5 = createResponseMsg(mnum, tpR4, phR4, doR4);
                        SendMsg(msg5);
                        break;
                    case 5:
                        run5 = true;
                        String msg6 = createResponseMsg(mnum, tpR5, phR5, doR5);
                        SendMsg(msg6);
                        break;
                    case 6:
                        run6 = true;
                        String msg7 = createResponseMsg(mnum, tpR6, phR6, doR6);
                        SendMsg(msg7);
                        break;
                    case 7:
                        run7 = true;
                        String msg8 = createResponseMsg(mnum, tpR7, phR7, doR7);
                        SendMsg(msg8);
                        break;
                    case 8:
                        run8 = true;
                        String msg9 = createResponseMsg(mnum, tpR8, phR8, doR8);
                        SendMsg(msg9);
                        break;
                }
            }

            if ("Stop".Equals(setType))
            {
                int mnum2 = Int32.Parse((String)msg.Data["moduleNum"]);
                switch (mnum2)
                {
                    case 1:
                        run1 = false;
                        break;
                    case 2:
                        run2 = false;
                        break;
                    case 3:
                        run3 = false;
                        break;
                    case 4:
                        run4 = false;
                        break;
                    case 5:
                        run5 = false;
                        break;
                    case 6:
                        run6 = false;
                        break;
                    case 7:
                        run7 = false;
                        break;
                    case 8:
                        run8 = false;
                        break;
                }
            }


        }
        public override void ReceiveMsg(String s)
        {
            ModbusMessage message = ModbusMessageHelper.decodeModbusMessage(s);
            switch (message.MsgType)
            {
                case ModbusMessage.MessageType.SET:
                    decodeSetMessage(message);
                    break;
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

        public int Speed1 = 0;
        public int Temp1 = 0;
        public int Air1 = 0;
        public int Pressure1 = 0;
        public int Time1 = 0;
        public int tpR1 = 30;
        public int phR1 = 6;
        public int doR1 = 20;

        public int Speed2 = 0;
        public int Temp2 = 0;
        public int Air2 = 0;
        public int Pressure2 = 0;
        public int Time2 = 0;
        public int tpR2 = 30;
        public int phR2 = 7;
        public int doR2 = 18;

        public int Speed3 = 0;
        public int Temp3 = 0;
        public int Air3 = 0;
        public int Pressure3 = 0;
        public int Time3 = 0;
        public int tpR3 = 31;
        public int phR3 = 6;
        public int doR3 = 23;

        public int Speed4 = 0;
        public int Temp4 = 0;
        public int Air4 = 0;
        public int Pressure4 = 0;
        public int Time4 = 0;
        public int tpR4 = 26;
        public int phR4 = 6;
        public int doR4 = 20;

        public int Speed5 = 0;
        public int Temp5 = 0;
        public int Air5 = 0;
        public int Pressure5 = 0;
        public int Time5 = 0;
        public int tpR5 = 31;
        public int phR5 = 7;
        public int doR5 = 25;

        public int Speed6 = 0;
        public int Temp6 = 0;
        public int Air6 = 0;
        public int Pressure6 = 0;
        public int Time6 = 0;
        public int tpR6 = 31;
        public int phR6 = 6;
        public int doR6 = 28;

        public int Speed7 = 0;
        public int Temp7 = 0;
        public int Air7 = 0;
        public int Pressure7 = 0;
        public int Time7 = 0;
        public int tpR7 = 33;
        public int phR7 = 6;
        public int doR7 = 19;

        public int Speed8 = 0;
        public int Temp8 = 0;
        public int Air8 = 0;
        public int Pressure8 = 0;
        public int Time8 = 0;
        public int tpR8 = 34;
        public int phR8 = 6;
        public int doR8 = 25;
    }
}
