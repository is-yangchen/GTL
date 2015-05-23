using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GTLutils;

namespace Instrument
{
    public class MatrixSystemVirtualDeviceMessageCreator
    {
        public static String createSetSystem(String Mode, String Command)
        {
            ModbusMessageDataCreator creator = new ModbusMessageDataCreator();
            creator.addKeyPair("SetType", "System");
            creator.addKeyPair("Sys_Mode", Mode);
            creator.addKeyPair("Sys_Command", Command);
            return ModbusMessageHelper.createModbusMessage(ModbusMessage.messageTypeToByte(ModbusMessage.MessageType.SET), creator.getDataBytes());
        }

        public static String createSetLight(String pwm, String allightText )
        {
            ModbusMessageDataCreator creator = new ModbusMessageDataCreator();
            creator.addKeyPair("SetType", "Light");
            creator.addKeyPair("Light_pwm", pwm);
            creator.addKeyPair("Light_allighText", allightText);
            return ModbusMessageHelper.createModbusMessage(ModbusMessage.messageTypeToByte(ModbusMessage.MessageType.SET), creator.getDataBytes());
        }

        public static String createSetTH_1( String tempset,
                                            String htempchaval,
                                            String ltempchaval,
                                            String syso_change,
                                            String htempalarmval,
                                            String ltempalarmval,
                                            String compressormode,
                                            String compressorsituation )
        {
            ModbusMessageDataCreator creator = new ModbusMessageDataCreator();
            creator.addKeyPair("SetType", "TH_1");
            creator.addKeyPair("TH_htempchaval", htempchaval);
            creator.addKeyPair("TH_tempset", tempset); 
            creator.addKeyPair("TH_ltempchaval", ltempchaval );
            creator.addKeyPair("TH_syso_change", syso_change);
            creator.addKeyPair("TH_htempalarmval", htempalarmval );
            creator.addKeyPair("TH_ltempalarmval", ltempalarmval);
            creator.addKeyPair("TH_compressormode", compressormode);
            creator.addKeyPair("TH_compressorsituation", compressorsituation);
            return ModbusMessageHelper.createModbusMessage(ModbusMessage.messageTypeToByte(ModbusMessage.MessageType.SET), creator.getDataBytes());
        }

        public static String createSetTH_2(   String def_interval,
                                              String def_span,
                                              String hottube,
                                              String humi_con_mod,
                                              String humi_con_sit,
                                              String hum_set,
                                              String hum_alarm_val,
                                              String add_hum,
                                              String remo_hum )
        {
            ModbusMessageDataCreator creator = new ModbusMessageDataCreator();
            creator.addKeyPair("SetType", "TH_2");
            creator.addKeyPair("TH_def_interval", def_interval);
            creator.addKeyPair("TH_def_span", def_span);
            creator.addKeyPair("TH_hottube", hottube);
            creator.addKeyPair("TH_humi_con_mod", humi_con_mod);
            creator.addKeyPair("TH_humi_con_sit", humi_con_sit);
            creator.addKeyPair("TH_hum_set", hum_set);
            creator.addKeyPair("TH_hum_alarm_val", hum_alarm_val);
            creator.addKeyPair("TH_add_hum", add_hum);
            creator.addKeyPair("TH_remo_hum", remo_hum);
            return ModbusMessageHelper.createModbusMessage(ModbusMessage.messageTypeToByte(ModbusMessage.MessageType.SET), creator.getDataBytes());
        }

        public static String createSetMotor(String text_speed, String elecspeed, String slope )
        {
            ModbusMessageDataCreator creator = new ModbusMessageDataCreator();
            creator.addKeyPair("SetType", "Motor");
            creator.addKeyPair("Motor_text_speed", text_speed);
            creator.addKeyPair("Motor_elecspeed", elecspeed);
            creator.addKeyPair("Motor_slope", slope);
            return ModbusMessageHelper.createModbusMessage(ModbusMessage.messageTypeToByte(ModbusMessage.MessageType.SET), creator.getDataBytes());
        }
    }

    public class MatrixSystemVirtualDevice : BaseVirtualDevice
    {
        //---------------------view---------------------

        //仪器系统
        public int HAC_Sys_Mode = 0;
        public int HAC_Sys_Command = 0;
        public int HAC_Run_Time = 0;

        //匀光
        public int HAC_Light_pwm = 0;
        public int HAC_Light_allighText = 0;

        //湿温度
        public int HAC_TH_tempset = 0;
        public int HAC_TH_htempchaval = 0;
        public int HAC_TH_ltempchaval = 0;
        public string HAC_TH_syso_change = "";
        public int HAC_TH_htempalarmval = 0;
        public int HAC_TH_ltempalarmval = 0;
        public string HAC_TH_compressormode = "";
        public string HAC_TH_compressorsituation = "";
        public string HAC_TH_def_interval = "";
        public int HAC_TH_def_span = 0;
        public string HAC_TH_hottube = "";
        public string HAC_TH_humi_con_mod = "";
        public string HAC_TH_humi_con_sit = "";
        public int HAC_TH_hum_set = 0;
        public int HAC_TH_hum_alarm_val = 0;
        public int HAC_TH_add_hum = 0;
        public int HAC_TH_remo_hum = 0;

        //电机
        public int HAC_Motor_text_speed = 0;
        public int HAC_Motor_elecspeed = 0;
        public int HAC_Motor_slope = 0;

        //-----------------------data--------------------

        //仪器系统
        public int HAC_Sys_DeviceInfo = 0;
        public int HAC_Sys_Status = 0;
        public int HAC_Sys_Batch_Info = 0;

        //匀光
        public int HAC_Light_Status = 0;
        public int HAC_Light_address = 0;
        public int HAC_Light_light = 0;
        public int HAC_Light_xzoom = 0;
        public int HAC_Light_yzoom = 0;
        public int HAC_Light_currentpwm = 0;

        //动平衡
        public int HAC_Vib_Status = 0;
        public double HAC_Vib_unbalanceAmp = 0;
        public int HAC_Vib_unbalanceAngle = 0;
        public int HAC_Vib_AccAxisX = 0;
        public int HAC_Vib_AccAxisY = 0;
        public int HAC_Vib_AccAxisZ = 0;

        //湿温度
        public int HAC_TH_Status = 0;
        public int HAC_TH_temperature1 = 0;
        public int HAC_TH_temperature2 = 0;
        public int HAC_TH_temperature3 = 0;
        public int HAC_TH_humidity1 = 0;
        public int HAC_TH_humidity2 = 0;

        //电机
        public int HAC_Motor_Status = 0;
        public int HAC_Motor_Power = 0;

        //条码
        public string HAC_InBarCode = "";
        public string HAC_OutBarCode = "";

        //--------------OD-------------------
        public int HAC_OD_Status = 0;
        public int HAC_OD_InfoTime = 0;
        public float[][] HAC_OD_checkBoxs = null;
        public int[][] HAC_OD_rowl = null;

        //int interval = 4;
        //private System.Timers.Timer getODTimer = null;
        //private System.Timers.Timer getTHTimer = null;
        //private System.Timers.Timer getMotorTimer = null;
        //private System.Timers.Timer getSystemTimer = null;
        //private System.Timers.Timer getCodeTimer = null;

        //Lock
        private object KeyObject = new object();

        public override void decodeReportMessage(ModbusMessage msg)//解码报告消息
        {
            String reportType = (String)msg.Data["ReportType"];
            if ("OD".Equals(reportType))
            {
                lock (KeyObject)
                {
                    if (HAC_OD_rowl == null) //为OD_rowl开辟空间，更新OD表
                    {
                        HAC_OD_rowl = new int[8][];
                        for (int i = 0; i < 8; i++)
                        {
                            HAC_OD_rowl[i] = new int[12];
                            for (int j = 0; j < 12; j++)
                            {
                                HAC_OD_rowl[i][j] = Convert.ToInt32(((String)msg.Data["OD"])[12*i + j]);
                            }
                        }
                    }
                   
                    for (int i = 0; i < 8; i++)  //更新OD表
                        for (int j = 0; j < 12; j++)
                        {
                            HAC_OD_rowl[i][j] = Convert.ToInt32(((String)msg.Data["OD"])[12 * i + j]);
                        }

                    //Database mydb = new Database();
                    //mydb.inserthacod(1, OD_rowl, 1);
                }

            }

            if ("TH".Equals(reportType))
            {
                this.HAC_TH_temperature1 = Convert.ToInt32((String)msg.Data["TH_temperature1"]);
                this.HAC_TH_temperature2 = Convert.ToInt32((String)msg.Data["TH_temperature2"]);
                this.HAC_TH_temperature3 = Convert.ToInt32((String)msg.Data["TH_temperature3"]);
                this.HAC_TH_humidity1 = Convert.ToInt32((String)msg.Data["TH_humidity1"]);
                this.HAC_TH_humidity2 = Convert.ToInt32((String)msg.Data["TH_humidity2"]);
                
                //Database mydb = new Database();
                //mydb.inserthactmpmod(1, 1, this.TH_temperature1, TH_temperature2, TH_temperature3, TH_humidity1, TH_humidity2); 
                 
            }

            if ("System".Equals(reportType))
            {
                this.HAC_Sys_DeviceInfo = Convert.ToInt32((String)msg.Data["Sys_DeviceInfo"]);
                this.HAC_Sys_Status = Convert.ToInt32((String)msg.Data["Sys_Status"]);
                this.HAC_Sys_Batch_Info = Convert.ToInt32((String)msg.Data["Sys_Batch_Info"]);

                //Database mydb = new Database();
                //mydb.inserthacstate(1, this.Sys_Status);
            }

            if ("Code".Equals(reportType))
            {
                this.HAC_InBarCode = (String)msg.Data["Add_Num"];
                this.HAC_InBarCode = (String)msg.Data["Rem_Num"];

                //Database mydb = new Database();
                //mydb.inserthacbarcode(Add_Num, Rem_Num, 1);
            }

            if ("Motor".Equals(reportType))
            {
                this.HAC_Motor_text_speed = Convert.ToInt32((String)msg.Data["Motor_text_speed"]);
                this.HAC_Motor_elecspeed = Convert.ToInt32((String)msg.Data["Motor_elecspeed"]);
                this.HAC_Motor_Status = Convert.ToInt32((String)msg.Data["Motor_Status"]);
                this.HAC_Motor_Power = Convert.ToInt32((String)msg.Data["Motor_Power"]);

                //Database mydb = new Database();
                //mydb.inserthacengine(1, Motor_elecspeed, Motor_Power, Motor_text_speed, Motor_Status); 
            }



        }

        //Use lock to protect OD data 
        public int readOD_rowl(int i, int j)
        {
            lock (KeyObject)
            {
                return HAC_OD_rowl[i][j];
            }
        }

        public override void ReceiveMsg(String s)
        {
            ModbusMessage message = ModbusMessageHelper.decodeModbusMessage(s);
            switch (message.MsgType)
            {
                case ModbusMessage.MessageType.REPORT:
                    decodeReportMessage(message);
                    break; 
            }
        }
    }
}
