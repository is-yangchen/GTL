using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;
using DeviceUtils;



namespace Instrument
{
    public class MatrixSystemDeviceMessageCreator
    {
        public static String createOKResponse()
        {
            ModbusMessageDataCreator creator = new ModbusMessageDataCreator();
            creator.addKeyPair("Result", "OK");
            return ModbusMessageHelper.createModbusMessage(ModbusMessage.messageTypeToByte(ModbusMessage.MessageType.RESPONSE), creator.getDataBytes());
        }

        public static String createODReport(String OD)
        {
            ModbusMessageDataCreator creator = new ModbusMessageDataCreator();
            creator.addKeyPair("ReportType", "OD");
            creator.addKeyPair("OD", OD);
            return ModbusMessageHelper.createModbusMessage(ModbusMessage.messageTypeToByte(ModbusMessage.MessageType.REPORT), creator.getDataBytes());

        }

        public static String createSystemReport(String DeviceInfo, String Status, String Batch_Info)
        {
            ModbusMessageDataCreator creator = new ModbusMessageDataCreator();
            creator.addKeyPair("ReportType", "System");
            creator.addKeyPair("Sys_DeviceInfo", DeviceInfo);
            creator.addKeyPair("Sys_Status", Status);
            creator.addKeyPair("Sys_Batch_Info", Batch_Info);
            return ModbusMessageHelper.createModbusMessage(ModbusMessage.messageTypeToByte(ModbusMessage.MessageType.REPORT), creator.getDataBytes());

        }

        public static String createTHReport(String temperature1, 
                                            String temperature2,
                                            String temperature3,
                                            String humidity1,
                                            String humidity2)
        {
            ModbusMessageDataCreator creator = new ModbusMessageDataCreator();
            creator.addKeyPair("ReportType", "TH");
            creator.addKeyPair("TH_temperature1", temperature1);
            creator.addKeyPair("TH_temperature2", temperature2);
            creator.addKeyPair("TH_temperature3", temperature3);
            creator.addKeyPair("TH_humidity1", humidity1);
            creator.addKeyPair("TH_humidity2", humidity2);
            return ModbusMessageHelper.createModbusMessage(ModbusMessage.messageTypeToByte(ModbusMessage.MessageType.REPORT), creator.getDataBytes());

        }

        public static String createMotorReport(String Status, String text_speed, String elecspeed, String Power)
        {
            ModbusMessageDataCreator creator = new ModbusMessageDataCreator();
            creator.addKeyPair("ReportType", "Motor");
            creator.addKeyPair("Motor_Status", Status);
            creator.addKeyPair("Motor_text_speed", text_speed);
            creator.addKeyPair("Motor_elecspeed", elecspeed);
            creator.addKeyPair("Motor_Power", Power);
            return ModbusMessageHelper.createModbusMessage(ModbusMessage.messageTypeToByte(ModbusMessage.MessageType.REPORT), creator.getDataBytes());

        }

        public static String createCodeReport(String Add_Num, String Rem_Num)
        {
            ModbusMessageDataCreator creator = new ModbusMessageDataCreator();
            creator.addKeyPair("ReportType", "Code");
            creator.addKeyPair("Add_Num", Add_Num);
            creator.addKeyPair("Rem_Num", Rem_Num);
            return ModbusMessageHelper.createModbusMessage(ModbusMessage.messageTypeToByte(ModbusMessage.MessageType.REPORT), creator.getDataBytes());

        }

    }

    public class MatrixSystemDevice : BaseVirtualDevice
    {
        //---------------------上位机发---------------------

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

        //-----------------------仪器发--------------------

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
        public int HAC_PlateLocation = 0;
        public string HAC_OutBarCode = "";

        //动平衡
        public int HAC_Vib_Status = 0;
        public double HAC_Vib_unbalanceAmp = 0;
        public int HAC_Vib_unbalanceAngle= 0;
        public int HAC_Vib_AccAxisX= 0;
        public int HAC_Vib_AccAxisY= 0;
        public int HAC_Vib_AccAxisZ= 0;


        //--------------OD-------------------

        public float[][] HAC_OD_checkBoxs = null;

        public int HAC_OD_Status = 0;
        public int HAC_OD_InfoTime = 0;
        public int[][] HAC_OD_rowl = null;

        int interval = 4; 
        private System.Timers.Timer getODTimer = null;
        private System.Timers.Timer getTHTimer = null;
        private System.Timers.Timer getMotorTimer = null;
        private System.Timers.Timer getSystemTimer = null;
        private System.Timers.Timer getCodeTimer = null;

        private object KeyObject = new object();

        public int readOD_rowl(int i, int j)
        {
            lock(KeyObject)
            {
                return HAC_OD_rowl[i][j];
            }
        }

        private void getODTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            String s = "";
            char od = '\0';
            Random ra = new Random();

            lock (KeyObject)
            {
                for (int i = 0; i < 8; i++)
                {
                    for (int j = 0; j < 12; j++)
                    {
                        this.HAC_OD_rowl[i][j] = ra.Next(0, 31);
                        od = Convert.ToChar(HAC_OD_rowl[i][j]);
                        s += od;
                    }
                }
            }

            String msg = MatrixSystemDeviceMessageCreator.createODReport(s);
            SendMsg(msg);
        }

        private void getSystemTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            String msg = MatrixSystemDeviceMessageCreator.createSystemReport(this.HAC_Sys_DeviceInfo.ToString(), 
                                                                             this.HAC_Sys_Status.ToString(),
                                                                             this.HAC_Sys_Batch_Info.ToString() );
            SendMsg(msg);
        }

        private void getTHTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            Random ra = new Random();
            this.HAC_TH_temperature1 = ra.Next(300, 600);
            this.HAC_TH_temperature2 = ra.Next(300, 600);
            this.HAC_TH_temperature3 = ra.Next(300, 600);
            this.HAC_TH_humidity1 = ra.Next(50, 100);
            this.HAC_TH_humidity2 = ra.Next(50, 100);

            String msg = MatrixSystemDeviceMessageCreator.createTHReport(this.HAC_TH_temperature1.ToString(),
                                                                         this.HAC_TH_temperature2.ToString(),
                                                                         this.HAC_TH_temperature3.ToString(),
                                                                         this.HAC_TH_humidity1.ToString(),
                                                                         this.HAC_TH_humidity2.ToString() );
            SendMsg(msg);
        }

        private void getMotorTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            Random ra = new Random();
            this.HAC_Motor_text_speed = ra.Next(7000, 10000);
            this.HAC_Motor_elecspeed = ra.Next(30000, 50000);
            this.HAC_Motor_Power = ra.Next(800, 1000);

            String msg = MatrixSystemDeviceMessageCreator.createMotorReport(this.HAC_Motor_Status.ToString(),
                                                                            this.HAC_Motor_text_speed.ToString(),
                                                                            this.HAC_Motor_elecspeed.ToString(),
                                                                            this.HAC_Motor_Power.ToString() );
            SendMsg(msg);
        }

        private void getCodeTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            String msg = MatrixSystemDeviceMessageCreator.createCodeReport(this.HAC_InBarCode, this.HAC_OutBarCode);
            SendMsg(msg);
        }


        public void startTimers()
        {
            HAC_OD_rowl = new int[8][];
            for (int i = 0; i < 8; i++)
            {
                HAC_OD_rowl[i] = new int[12];
                for (int j = 0; j < 12; j++)
                    HAC_OD_rowl[i][j] = 0;
            }

            getODTimer = new System.Timers.Timer();
            getODTimer.Interval = interval * 13000;
            getODTimer.Elapsed += new System.Timers.ElapsedEventHandler(getTHTimer_Elapsed);
            getODTimer.Start();

            getTHTimer = new System.Timers.Timer();
            getTHTimer.Interval = interval * 3000;
            getTHTimer.Elapsed += new System.Timers.ElapsedEventHandler(getODTimer_Elapsed);
            getTHTimer.Start();

            getMotorTimer = new System.Timers.Timer();
            getMotorTimer.Interval = interval * 5000;
            getMotorTimer.Elapsed += new System.Timers.ElapsedEventHandler(getMotorTimer_Elapsed);
            getMotorTimer.Start();

            getCodeTimer = new System.Timers.Timer();
            getCodeTimer.Interval = interval * 7000;
            getCodeTimer.Elapsed += new System.Timers.ElapsedEventHandler(getCodeTimer_Elapsed);
            getCodeTimer.Start();

            getSystemTimer = new System.Timers.Timer();
            getSystemTimer.Interval = interval * 11000;
            getSystemTimer.Elapsed += new System.Timers.ElapsedEventHandler(getSystemTimer_Elapsed);
            getSystemTimer.Start();
        }

        private void decodeSetMessage(ModbusMessage msg)
        {
            String setType = (String)msg.Data["SetType"];
            if ("System".Equals(setType))
            {
                this.HAC_Sys_Mode = int.Parse((String)msg.Data["Sys_Mode"]);
                this.HAC_Sys_Command = int.Parse((String)msg.Data["Sys_Command"]);
            }
            if ("Light".Equals(setType))
            {
                this.HAC_Light_pwm = int.Parse((String)msg.Data["Light_pwm"]);
                this.HAC_Light_allighText = int.Parse((String)msg.Data["Light_allighText"]);
            }
            if ("TH_1".Equals(setType))
            {
                this.HAC_TH_tempset = int.Parse((String)msg.Data["TH_tempset"]);
                this.HAC_TH_htempchaval = int.Parse((String)msg.Data["TH_htempchaval"]);
                this.HAC_TH_ltempchaval = int.Parse((String)msg.Data["TH_ltempchaval"]);
                this.HAC_TH_syso_change = (String)msg.Data["TH_syso_change"];
                this.HAC_TH_htempalarmval = int.Parse((String)msg.Data["TH_htempalarmval"]);
                this.HAC_TH_ltempalarmval = int.Parse((String)msg.Data["TH_ltempalarmval"]);
                this.HAC_TH_compressormode = (String)msg.Data["TH_compressormode"];
                this.HAC_TH_compressorsituation = (String)msg.Data["TH_compressorsituation"];
            }
            if ("TH_2".Equals(setType))
            {
                this.HAC_TH_def_interval = (String)msg.Data["TH_def_interval"];
                this.HAC_TH_def_span = int.Parse((String)msg.Data["TH_def_span"]);
                this.HAC_TH_hottube = (String)msg.Data["TH_hottube"];
                this.HAC_TH_humi_con_mod = (String)msg.Data["TH_humi_con_mod"];
                this.HAC_TH_humi_con_sit = (String)msg.Data["TH_humi_con_sit"];
                this.HAC_TH_hum_set = int.Parse((String)msg.Data["TH_hum_set"]);
                this.HAC_TH_hum_alarm_val = int.Parse((String)msg.Data["TH_hum_alarm_val"]);
                this.HAC_TH_add_hum = int.Parse((String)msg.Data["TH_add_hum"]);
                this.HAC_TH_remo_hum = int.Parse((String)msg.Data["TH_remo_hum"]);
            }
            if ("Motor".Equals(setType))
            {
                this.HAC_Motor_text_speed = int.Parse((String)msg.Data["Motor_text_speed"]);
                this.HAC_Motor_elecspeed = int.Parse((String)msg.Data["Motor_elecspeed"]);
                this.HAC_Motor_slope = int.Parse((String)msg.Data["Motor_slope"]);
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
    }
}
