using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DeviceUtils;

namespace Instrument
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
                MMR_CurentSelectIndex = Int32.Parse((String)msg.Data["moduleNum"]);
                MMR_CurSpeed = Int32.Parse((String)msg.Data["speed"]);
                MMR_CurTemp = Int32.Parse((String)msg.Data["temp"]);
                MMR_CurTime = Int32.Parse((String)msg.Data["time"]);
                MMR_CurAir = Int32.Parse((String)msg.Data["air"]);
                MMR_CurPressure = Int32.Parse((String)msg.Data["pressure"]);

                switch (MMR_CurentSelectIndex)
                {
                    case 1:
                        MMR_ModuleSpeed1 = MMR_CurSpeed;
                        MMR_ModuleTemp1 = MMR_CurTemp;
                        MMR_ModuleSampleTime1 = MMR_CurTime;
                        MMR_ModuleAir1 = MMR_CurAir;
                        MMR_ModulemPa1 = MMR_CurPressure;
                        break;
                    case 2:
                        MMR_ModuleSpeed2 = MMR_CurSpeed;
                        MMR_ModuleTemp2 = MMR_CurTemp;
                        MMR_ModuleSampleTime2 = MMR_CurTime;
                        MMR_ModuleAir2 = MMR_CurAir;
                        MMR_ModulemPa2 = MMR_CurPressure;
                        break;
                    case 3:
                        MMR_ModuleSpeed3 = MMR_CurSpeed;
                        MMR_ModuleTemp3 = MMR_CurTemp;
                        MMR_ModuleSampleTime3 = MMR_CurTime;
                        MMR_ModuleAir3 = MMR_CurAir;
                        MMR_ModulemPa3 = MMR_CurPressure;
                        break;
                    case 4:
                        MMR_ModuleSpeed4 = MMR_CurSpeed;
                        MMR_ModuleTemp4 = MMR_CurTemp;
                        MMR_ModuleSampleTime4 = MMR_CurTime;
                        MMR_ModuleAir4 = MMR_CurAir;
                        MMR_ModulemPa4 = MMR_CurPressure;
                        break;
                    case 5:
                        MMR_ModuleSpeed5 = MMR_CurSpeed;
                        MMR_ModuleTemp5 = MMR_CurTemp;
                        MMR_ModuleSampleTime5 = MMR_CurTime;
                        MMR_ModuleAir5 = MMR_CurAir;
                        MMR_ModulemPa5 = MMR_CurPressure;
                        break;
                    case 6:
                        MMR_ModuleSpeed6 = MMR_CurSpeed;
                        MMR_ModuleTemp6 = MMR_CurTemp;
                        MMR_ModuleSampleTime6 = MMR_CurTime;
                        MMR_ModuleAir6 = MMR_CurAir;
                        MMR_ModulemPa6 = MMR_CurPressure;
                        break;
                    case 7:
                        MMR_ModuleSpeed7 = MMR_CurSpeed;
                        MMR_ModuleTemp7 = MMR_CurTemp;
                        MMR_ModuleTime7 = MMR_CurTime;
                        MMR_ModuleAir7 = MMR_CurAir;
                        MMR_ModulemPa7 = MMR_CurPressure;
                        break;
                    case 8:
                        MMR_ModuleSpeed8 = MMR_CurSpeed;
                        MMR_ModuleTemp8 = MMR_CurTemp;
                        MMR_ModuleTime8 = MMR_CurTime;
                        MMR_ModuleAir8 = MMR_CurAir;
                        MMR_ModulemPa8 = MMR_CurPressure;
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
                        MMR_Module1 = true;
                        String msg2 = createResponseMsg(mnum, MMR_ModTemp1, MMR_ModPh1, MMR_ModDo1);
                        SendMsg(msg2);
                        break;
                    case 2:
                        MMR_Module2 = true;
                        String msg3 = createResponseMsg(mnum, MMR_ModTemp2, MMR_ModPh2, MMR_ModDo2);
                        SendMsg(msg3);
                        break;
                    case 3:
                        MMR_Module3 = true;
                        String msg4 = createResponseMsg(mnum, MMR_ModTemp3, MMR_Modph3, MMR_ModDo3);
                        SendMsg(msg4);
                        break;
                    case 4:
                        MMR_Module4 = true;
                        String msg5 = createResponseMsg(mnum, MMR_ModTemp4, MMR_Modph4, MMR_ModDo4);
                        SendMsg(msg5);
                        break;
                    case 5:
                        MMR_Module5 = true;
                        String msg6 = createResponseMsg(mnum, MMR_ModTemp5, MMR_Modph5, MMR_ModDo5);
                        SendMsg(msg6);
                        break;
                    case 6:
                        MMR_Module6 = true;
                        String msg7 = createResponseMsg(mnum, MMR_ModTemp6, MMR_Modph6, MMR_ModDo6);
                        SendMsg(msg7);
                        break;
                    case 7:
                        MMR_Module7 = true;
                        String msg8 = createResponseMsg(mnum, MMR_ModTemp7, MMR_Modph7, MMR_ModDo7);
                        SendMsg(msg8);
                        break;
                    case 8:
                        MMR_Module8 = true;
                        String msg9 = createResponseMsg(mnum, MMR_ModTemp8, MMR_Modph8, MMR_ModDo8);
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
                        MMR_Module1 = false;
                        break;
                    case 2:
                        MMR_Module2 = false;
                        break;
                    case 3:
                        MMR_Module3 = false;
                        break;
                    case 4:
                        MMR_Module4 = false;
                        break;
                    case 5:
                        MMR_Module5 = false;
                        break;
                    case 6:
                        MMR_Module6 = false;
                        break;
                    case 7:
                        MMR_Module7 = false;
                        break;
                    case 8:
                        MMR_Module8 = false;
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


        public int MMR_CurentSelectIndex;
        public bool MMR_Module1 = false;
        public bool MMR_Module2 = false;
        public bool MMR_Module3 = false;
        public bool MMR_Module4 = false;
        public bool MMR_Module5 = false;
        public bool MMR_Module6 = false;
        public bool MMR_Module7 = false;
        public bool MMR_Module8 = false;

        public int MMR_CurSpeed;
        public int MMR_CurTemp;
        public int MMR_CurAir;
        public int MMR_CurPressure;
        public int MMR_CurTime;
        public int MMR_CurtpR;
        public int MMR_CurphR;
        public int MMR_CurdoR;

        /*public int MMR_ModuleSpeed1;
        public int MMR_ModuleTemp1;
        public int MMR_ModuleAir1;
        public int MMR_ModulemPa1;
        public int MMR_ModuleSampleTime1;
        public int MMR_ModTemp1;
        public int MMR_ModPh1;
        public int MMR_ModDO1;
         */
        public int MMR_ModuleSpeed1 = 0;
        public int MMR_ModuleTemp1 = 0;
        public int MMR_ModuleAir1 = 0;
        public int MMR_ModulemPa1 = 0;
        public int MMR_ModuleSampleTime1 = 0;
        public int MMR_ModTemp1 = 30;
        public int MMR_ModPh1 = 6;
        public int MMR_ModDo1 = 20;

        public int MMR_ModuleSpeed2 = 0;
        public int MMR_ModuleTemp2 = 0;
        public int MMR_ModuleAir2 = 0;
        public int MMR_ModulemPa2 = 0;
        public int MMR_ModuleSampleTime2 = 0;
        public int MMR_ModTemp2 = 30;
        public int MMR_ModPh2 = 7;
        public int MMR_ModDo2 = 18;

        public int MMR_ModuleSpeed3 = 0;
        public int MMR_ModuleTemp3 = 0;
        public int MMR_ModuleAir3 = 0;
        public int MMR_ModulemPa3 = 0;
        public int MMR_ModuleSampleTime3 = 0;
        public int MMR_ModTemp3 = 31;
        public int MMR_Modph3 = 6;
        public int MMR_ModDo3 = 23;

        public int MMR_ModuleSpeed4 = 0;
        public int MMR_ModuleTemp4 = 0;
        public int MMR_ModuleAir4 = 0;
        public int MMR_ModulemPa4 = 0;
        public int MMR_ModuleSampleTime4 = 0;
        public int MMR_ModTemp4 = 26;
        public int MMR_Modph4 = 6;
        public int MMR_ModDo4 = 20;

        public int MMR_ModuleSpeed5 = 0;
        public int MMR_ModuleTemp5 = 0;
        public int MMR_ModuleAir5 = 0;
        public int MMR_ModulemPa5 = 0;
        public int MMR_ModuleSampleTime5 = 0;
        public int MMR_ModTemp5 = 31;
        public int MMR_Modph5 = 7;
        public int MMR_ModDo5 = 25;

        public int MMR_ModuleSpeed6 = 0;
        public int MMR_ModuleTemp6 = 0;
        public int MMR_ModuleAir6 = 0;
        public int MMR_ModulemPa6 = 0;
        public int MMR_ModuleSampleTime6 = 0;
        public int MMR_ModTemp6 = 31;
        public int MMR_Modph6 = 6;
        public int MMR_ModDo6 = 28;

        public int MMR_ModuleSpeed7 = 0;
        public int MMR_ModuleTemp7 = 0;
        public int MMR_ModuleAir7 = 0;
        public int MMR_ModulemPa7 = 0;
        public int MMR_ModuleTime7 = 0;
        public int MMR_ModTemp7 = 33;
        public int MMR_Modph7 = 6;
        public int MMR_ModDo7 = 19;

        public int MMR_ModuleSpeed8 = 0;
        public int MMR_ModuleTemp8 = 0;
        public int MMR_ModuleAir8 = 0;
        public int MMR_ModulemPa8 = 0;
        public int MMR_ModuleTime8 = 0;
        public int MMR_ModTemp8 = 34;
        public int MMR_Modph8 = 6;
        public int MMR_ModDo8 = 25;
    }
}
