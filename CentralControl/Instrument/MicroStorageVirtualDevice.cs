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

        public int MMR_ModuleSpeed1;
        public int MMR_ModuleTemp1;
        public int MMR_ModuleAir1;
        public int MMR_ModulemPa1;
        public int MMR_ModuleSampleTime1;
        public int MMR_ModTemp1;
        public int MMR_ModPh1;
        public int MMR_ModDO1;
        public int MMR_ModFlow1;
        public int MMR_Mod1O2;
        public int MMR_Mod1CO2;


        public int MMR_ModuleSpeed2;
        public int MMR_ModuleTemp2;
        public int MMR_ModuleAir2;
        public int MMR_ModulemPa2;
        public int MMR_ModuleSampleTime2;
        public int MMR_ModTemp2;
        public int MMR_ModPh2;
        public int MMR_ModDO2;
        public int MMR_ModFlow2;
        public int MMR_Mod2O2;
        public int MMR_Mod2CO2;

        public int MMR_ModuleSpeed3;
        public int MMR_ModuleTemp3;
        public int MMR_ModuleAir3;
        public int MMR_ModulemPa3;
        public int MMR_ModuleSampleTime3;
        public int MMR_ModTemp3;
        public int MMR_ModPh3;
        public int MMR_ModDO3;
        public int MMR_ModFlow3;
        public int MMR_Mod3O2;
        public int MMR_Mod3CO2;

        public int MMR_ModuleSpeed4;
        public int MMR_ModuleTemp4;
        public int MMR_ModuleAir4;
        public int MMR_ModulemPa4;
        public int MMR_ModuleSampleTime4;
        public int MMR_ModTemp4;
        public int MMR_ModPh4;
        public int MMR_ModDO4;
        public int MMR_ModFlow4;
        public int MMR_Mod4O2;
        public int MMR_Mod4CO2;

        public int MMR_ModuleSpeed5;
        public int MMR_ModuleTemp5;
        public int MMR_ModuleAir5;
        public int MMR_ModulemPa5;
        public int MMR_ModuleSampleTime5;
        public int MMR_ModTemp5;
        public int MMR_ModPh5;
        public int MMR_ModDO5;
        public int MMR_ModFlow5;
        public int MMR_Mod5O2;
        public int MMR_Mod5CO2;

        public int MMR_ModuleSpeed6;
        public int MMR_ModuleTemp6;
        public int MMR_ModuleAir6;
        public int MMR_ModulemPa6;
        public int MMR_ModuleSampleTime6;
        public int MMR_ModTemp6;
        public int MMR_ModPh6;
        public int MMR_ModDO6;
        public int MMR_ModFlow6;
        public int MMR_Mod6O2;
        public int MMR_Mod6CO2;

        public int MMR_ModuleSpeed7;
        public int MMR_ModuleTemp7;
        public int MMR_ModuleAir7;
        public int MMR_ModulemPa7;
        public int MMR_ModuleSampleTime7;
        public int MMR_ModTemp7;
        public int MMR_ModPh7;
        public int MMR_ModDO7;
        public int MMR_ModFlow7;
        public int MMR_Mod7O2;
        public int MMR_Mod7CO2;

        public int MMR_ModuleSpeed8;
        public int MMR_ModuleTemp8;
        public int MMR_ModuleAir8;
        public int MMR_ModulemPa8;
        public int MMR_ModuleSampleTime8;
        public int MMR_ModTemp8;
        public int MMR_ModPh8;
        public int MMR_ModDO8;
        public int MMR_ModFlow8;
        public int MMR_Mod8O2;
        public int MMR_Mod8CO2;

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
                        MMR_ModTemp1 = curtpR;
                        MMR_ModPh1 = curphR;
                        MMR_ModDO1 = curdoR;
                        break;
                    case 2:
                        MMR_ModTemp2 = curtpR;
                        MMR_ModPh2 = curphR;
                        MMR_ModDO2 = curdoR;
                        break;
                    case 3:
                        MMR_ModTemp3 = curtpR;
                        MMR_ModPh3 = curphR;
                        MMR_ModDO3 = curdoR;
                        break;
                    case 4:
                        MMR_ModTemp4 = curtpR;
                        MMR_ModPh4 = curphR;
                        MMR_ModDO4 = curdoR;
                        break;
                    case 5:
                        MMR_ModTemp5 = curtpR;
                        MMR_ModPh5 = curphR;
                        MMR_ModDO5 = curdoR;
                        break;
                    case 6:
                        MMR_ModTemp6 = curtpR;
                        MMR_ModPh6 = curphR;
                        MMR_ModDO6 = curdoR;
                        break;
                    case 7:
                        MMR_ModTemp7 = curtpR;
                        MMR_ModPh7 = curphR;
                        MMR_ModDO7 = curdoR;
                        break;
                    case 8:
                        MMR_ModTemp8 = curtpR;
                        MMR_ModPh8 = curphR;
                        MMR_ModDO8 = curdoR;
                        break;
                }
            }
        }

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
