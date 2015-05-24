using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GTLutils;
using Instrument;

namespace CentralControl
{
    public partial class MicroReactorForm : Form
    {
        public MicroStorageVirtualDevice mrDevice;
        int curSelectModule;
        int size;

        public ControlForm FatherForm;
        public bool IsSocket;

        public MicroReactorForm()
        {
            mrDevice = new MicroStorageVirtualDevice();
            curSelectModule = 1;
            size = 8;
            InitializeComponent();
        }

        private void comboBox1_textChanged(object sender, EventArgs e)
        {
            curSelectModule = parseInt(this.comboBox1.Text);
            refresh();
        }

        private void MicroReactorForm_Load(object sender, EventArgs e)
        {
            refresh();
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();
            curSelectModule = parseInt(this.comboBox1.Text);
            showData(curSelectModule);
            timer1.Start();
        }

        private void showData(int curSelectModule)
        {
            switch (curSelectModule)
            {
                case 1:
                    if (mrDevice.MMR_Module1)
                    {
                        this.textBox6.Text = mrDevice.MMR_ModTemp1.ToString();
                        this.textBox7.Text = mrDevice.MMR_ModPh1.ToString();
                        this.textBox8.Text = mrDevice.MMR_ModDO1.ToString();
                        button2.Text = "停止";
                    }

                    else
                    {
                        this.textBox6.Text = "0";
                        this.textBox7.Text = "0";
                        this.textBox8.Text = "0";
                        button2.Text = "开始 ";
                    }
                    break;
                case 2:
                    if (mrDevice.MMR_Module2)
                    {
                        this.textBox6.Text = mrDevice.MMR_ModTemp2.ToString();
                        this.textBox7.Text = mrDevice.MMR_ModPh2.ToString();
                        this.textBox8.Text = mrDevice.MMR_ModDO2.ToString();
                        button2.Text = "停止";
                    }

                    else
                    {
                        this.textBox6.Text = "0";
                        this.textBox7.Text = "0";
                        this.textBox8.Text = "0";
                        button2.Text = "开始 ";
                    }
                    break;
                case 3:
                    if (mrDevice.MMR_Module3)
                    {
                        this.textBox6.Text = mrDevice.MMR_ModTemp3.ToString();
                        this.textBox7.Text = mrDevice.MMR_ModPh3.ToString();
                        this.textBox8.Text = mrDevice.MMR_ModDO3.ToString();
                        button2.Text = "停止";
                    }

                    else
                    {
                        this.textBox6.Text = "0";
                        this.textBox7.Text = "0";
                        this.textBox8.Text = "0";
                        button2.Text = "开始 ";
                    }
                    break;
                case 4:
                    if (mrDevice.MMR_Module4)
                    {
                        this.textBox6.Text = mrDevice.MMR_ModTemp4.ToString();
                        this.textBox7.Text = mrDevice.MMR_ModPh4.ToString();
                        this.textBox8.Text = mrDevice.MMR_ModDO4.ToString();
                        button2.Text = "停止";
                    }

                    else
                    {
                        this.textBox6.Text = "0";
                        this.textBox7.Text = "0";
                        this.textBox8.Text = "0";
                        button2.Text = "开始 ";
                    }
                    break;
                case 5:
                    if (mrDevice.MMR_Module5)
                    {
                        this.textBox6.Text = mrDevice.MMR_ModTemp5.ToString();
                        this.textBox7.Text = mrDevice.MMR_ModPh5.ToString();
                        this.textBox8.Text = mrDevice.MMR_ModDO5.ToString();
                        button2.Text = "停止";
                    }

                    else
                    {
                        this.textBox6.Text = "0";
                        this.textBox7.Text = "0";
                        this.textBox8.Text = "0";
                        button2.Text = "开始 ";
                    }
                    break;
                case 6:
                    if (mrDevice.MMR_Module6)
                    {
                        this.textBox6.Text = mrDevice.MMR_ModTemp6.ToString();
                        this.textBox7.Text = mrDevice.MMR_ModPh6.ToString();
                        this.textBox8.Text = mrDevice.MMR_ModDO6.ToString();
                        button2.Text = "停止";
                    }

                    else
                    {
                        this.textBox6.Text = "0";
                        this.textBox7.Text = "0";
                        this.textBox8.Text = "0";
                        button2.Text = "开始 ";
                    }
                    break;
                case 7:
                    if (mrDevice.MMR_Module7)
                    {
                        this.textBox6.Text = mrDevice.MMR_ModTemp7.ToString();
                        this.textBox7.Text = mrDevice.MMR_ModPh7.ToString();
                        this.textBox8.Text = mrDevice.MMR_ModDO7.ToString();
                        button2.Text = "停止";
                    }

                    else
                    {
                        this.textBox6.Text = "0";
                        this.textBox7.Text = "0";
                        this.textBox8.Text = "0";
                        button2.Text = "开始 ";
                    }
                    break;
                case 8:
                    if (mrDevice.MMR_Module8)
                    {
                        this.textBox6.Text = mrDevice.MMR_ModTemp8.ToString();
                        this.textBox7.Text = mrDevice.MMR_ModPh8.ToString();
                        this.textBox8.Text = mrDevice.MMR_ModDO8.ToString();
                        button2.Text = "停止";
                    }

                    else
                    {
                        this.textBox6.Text = "0";
                        this.textBox7.Text = "0";
                        this.textBox8.Text = "0";
                        button2.Text = "开始 ";
                    }
                    break;
                default:
                    break;

            }

        }
        private void refresh()
        {

            switch (curSelectModule)
            {
                case 1:
                    this.textBox1.Text = mrDevice.MMR_ModuleSpeed1.ToString();
                    this.textBox3.Text = mrDevice.MMR_ModuleTemp1.ToString();
                    this.textBox5.Text = mrDevice.MMR_ModuleSampleTime1.ToString();
                    this.textBox2.Text = mrDevice.MMR_ModuleAir1.ToString();
                    this.textBox4.Text = mrDevice.MMR_ModulemPa1.ToString();
                    if (mrDevice.MMR_Module1) button2.Text = "停止";
                    else button2.Text = "开始 ";
                    break;
                case 2:
                    this.textBox1.Text = mrDevice.MMR_ModuleSpeed2.ToString();
                    this.textBox3.Text = mrDevice.MMR_ModuleTemp2.ToString();
                    this.textBox5.Text = mrDevice.MMR_ModuleSampleTime2.ToString();
                    this.textBox2.Text = mrDevice.MMR_ModuleAir2.ToString();
                    this.textBox4.Text = mrDevice.MMR_ModulemPa2.ToString();
                    if (mrDevice.MMR_Module2) button2.Text = "停止";
                    else button2.Text = "开始 ";
                    break;
                case 3:
                    this.textBox1.Text = mrDevice.MMR_ModuleSpeed3.ToString();
                    this.textBox3.Text = mrDevice.MMR_ModuleTemp3.ToString();
                    this.textBox5.Text = mrDevice.MMR_ModuleSampleTime3.ToString();
                    this.textBox2.Text = mrDevice.MMR_ModuleAir3.ToString();
                    this.textBox4.Text = mrDevice.MMR_ModulemPa3.ToString();
                    if (mrDevice.MMR_Module3) button2.Text = "停止";
                    else button2.Text = "开始 ";
                    break;
                case 4:
                    this.textBox1.Text = mrDevice.MMR_ModuleSpeed4.ToString();
                    this.textBox3.Text = mrDevice.MMR_ModuleTemp4.ToString();
                    this.textBox5.Text = mrDevice.MMR_ModuleSampleTime4.ToString();
                    this.textBox2.Text = mrDevice.MMR_ModuleAir4.ToString();
                    this.textBox4.Text = mrDevice.MMR_ModulemPa4.ToString();
                    if (mrDevice.MMR_Module4) button2.Text = "停止";
                    else button2.Text = "开始 ";
                    break;
                case 5:
                    this.textBox1.Text = mrDevice.MMR_ModuleSpeed5.ToString();
                    this.textBox3.Text = mrDevice.MMR_ModuleTemp5.ToString();
                    this.textBox5.Text = mrDevice.MMR_ModuleSampleTime5.ToString();
                    this.textBox2.Text = mrDevice.MMR_ModuleAir5.ToString();
                    this.textBox4.Text = mrDevice.MMR_ModulemPa5.ToString();
                    if (mrDevice.MMR_Module5) button2.Text = "停止";
                    else button2.Text = "开始 ";
                    break;
                case 6:
                    this.textBox1.Text = mrDevice.MMR_ModuleSpeed6.ToString();
                    this.textBox3.Text = mrDevice.MMR_ModuleTemp6.ToString();
                    this.textBox5.Text = mrDevice.MMR_ModuleSampleTime6.ToString();
                    this.textBox2.Text = mrDevice.MMR_ModuleAir6.ToString();
                    this.textBox4.Text = mrDevice.MMR_ModulemPa6.ToString();
                    if (mrDevice.MMR_Module6) button2.Text = "停止";
                    else button2.Text = "开始 ";
                    break;
                case 7:
                    this.textBox1.Text = mrDevice.MMR_ModuleSpeed7.ToString();
                    this.textBox3.Text = mrDevice.MMR_ModuleTemp7.ToString();
                    this.textBox5.Text = mrDevice.MMR_ModuleSampleTime7.ToString();
                    this.textBox2.Text = mrDevice.MMR_ModuleAir7.ToString();
                    this.textBox4.Text = mrDevice.MMR_ModulemPa7.ToString();
                    if (mrDevice.MMR_Module7) button2.Text = "停止";
                    else button2.Text = "开始 ";
                    break;
                case 8:
                    this.textBox1.Text = mrDevice.MMR_ModuleSpeed8.ToString();
                    this.textBox3.Text = mrDevice.MMR_ModuleTemp8.ToString();
                    this.textBox5.Text = mrDevice.MMR_ModuleSampleTime8.ToString();
                    this.textBox2.Text = mrDevice.MMR_ModuleAir8.ToString();
                    this.textBox4.Text = mrDevice.MMR_ModulemPa8.ToString();
                    if (mrDevice.MMR_Module8) button2.Text = "停止";
                    else button2.Text = "开始 ";
                    break;
                default:
                    break;

            }

        }



        private void start_Click(object sender, EventArgs e)
        {
            if (IsSocket)
            {
                switch (curSelectModule)
                {
                    case 1:
                        if (!mrDevice.MMR_Module1)
                        {
                            String msg = MRDeviceMessageCreator.createStartMsg(curSelectModule);
                            mrDevice.SendMsg(msg);
                            mrDevice.MMR_Module1 = true;
                        }
                        else
                        {
                            String msg = MRDeviceMessageCreator.createStopMsg(curSelectModule);
                            mrDevice.SendMsg(msg);
                            mrDevice.MMR_Module1 = false;
                        }
                        break;

                    case 2:
                        if (!mrDevice.MMR_Module2)
                        {
                            String msg = MRDeviceMessageCreator.createStartMsg(curSelectModule);
                            mrDevice.SendMsg(msg);
                            mrDevice.MMR_Module2 = true;
                        }
                        else
                        {
                            String msg = MRDeviceMessageCreator.createStopMsg(curSelectModule);
                            mrDevice.SendMsg(msg);
                            mrDevice.MMR_Module2 = false;
                        }
                        break;
                    case 3:
                        if (!mrDevice.MMR_Module3)
                        {
                            String msg = MRDeviceMessageCreator.createStartMsg(curSelectModule);
                            mrDevice.SendMsg(msg);
                            mrDevice.MMR_Module3 = true;
                        }
                        else
                        {
                            String msg = MRDeviceMessageCreator.createStopMsg(curSelectModule);
                            mrDevice.SendMsg(msg);
                            mrDevice.MMR_Module3 = false;
                        }
                        break;
                    case 4:
                        if (!mrDevice.MMR_Module4)
                        {
                            String msg = MRDeviceMessageCreator.createStartMsg(curSelectModule);
                            mrDevice.SendMsg(msg);
                            mrDevice.MMR_Module4 = true;
                        }
                        else
                        {
                            String msg = MRDeviceMessageCreator.createStopMsg(curSelectModule);
                            mrDevice.SendMsg(msg);
                            mrDevice.MMR_Module4 = false;
                        }
                        break;
                    case 5:
                        if (!mrDevice.MMR_Module5)
                        {
                            String msg = MRDeviceMessageCreator.createStartMsg(curSelectModule);
                            mrDevice.SendMsg(msg);
                            mrDevice.MMR_Module5 = true;
                        }
                        else
                        {
                            String msg = MRDeviceMessageCreator.createStopMsg(curSelectModule);
                            mrDevice.SendMsg(msg);
                            mrDevice.MMR_Module5 = false;
                        }
                        break;
                    case 6:
                        if (!mrDevice.MMR_Module6)
                        {
                            String msg = MRDeviceMessageCreator.createStartMsg(curSelectModule);
                            mrDevice.SendMsg(msg);
                            mrDevice.MMR_Module6 = true;
                        }
                        else
                        {
                            String msg = MRDeviceMessageCreator.createStopMsg(curSelectModule);
                            mrDevice.SendMsg(msg);
                            mrDevice.MMR_Module6 = false;
                        }
                        break;
                    case 7:
                        if (!mrDevice.MMR_Module7)
                        {
                            String msg = MRDeviceMessageCreator.createStartMsg(curSelectModule);
                            mrDevice.SendMsg(msg);
                            mrDevice.MMR_Module7 = true;
                        }
                        else
                        {
                            String msg = MRDeviceMessageCreator.createStopMsg(curSelectModule);
                            mrDevice.SendMsg(msg);
                            mrDevice.MMR_Module7 = false;
                        }
                        break;
                    case 8:
                        if (!mrDevice.MMR_Module8)
                        {
                            String msg = MRDeviceMessageCreator.createStartMsg(curSelectModule);
                            mrDevice.SendMsg(msg);
                            mrDevice.MMR_Module8 = true;
                        }
                        else
                        {
                            String msg = MRDeviceMessageCreator.createStopMsg(curSelectModule);
                            mrDevice.SendMsg(msg);
                            mrDevice.MMR_Module8 = false;
                        }
                        break;
                }

            }
        }

        private void send_Click(object sender, EventArgs e)
        {
            mrDevice.MMR_CurentSelectIndex = parseInt(this.comboBox1.Text);
            mrDevice.MMR_CurSpeed = Int32.Parse(this.textBox1.Text);
            mrDevice.MMR_CurTemp = Int32.Parse(this.textBox3.Text);
            mrDevice.MMR_CurTime = Int32.Parse(this.textBox5.Text);
            mrDevice.MMR_CurAir = Int32.Parse(this.textBox2.Text);
            mrDevice.MMR_CurPressure = Int32.Parse(this.textBox4.Text);
            switch (curSelectModule)
            {
                case 1:
                    mrDevice.MMR_ModuleSpeed1 = mrDevice.MMR_CurSpeed;
                    mrDevice.MMR_ModuleTemp1 = mrDevice.MMR_CurTemp;
                    mrDevice.MMR_ModuleSampleTime1 = mrDevice.MMR_CurTime;
                    mrDevice.MMR_ModuleAir1 = mrDevice.MMR_CurAir;
                    mrDevice.MMR_ModulemPa1 = mrDevice.MMR_CurPressure;
                    break;
                case 2:
                    mrDevice.MMR_ModuleSpeed2 = mrDevice.MMR_CurSpeed;
                    mrDevice.MMR_ModuleTemp2 = mrDevice.MMR_CurTemp;
                    mrDevice.MMR_ModuleSampleTime2 = mrDevice.MMR_CurTime;
                    mrDevice.MMR_ModuleAir2 = mrDevice.MMR_CurAir;
                    mrDevice.MMR_ModulemPa2 = mrDevice.MMR_CurPressure;
                    break;
                case 3:
                    mrDevice.MMR_ModuleSpeed3 = mrDevice.MMR_CurSpeed;
                    mrDevice.MMR_ModuleTemp3 = mrDevice.MMR_CurTemp;
                    mrDevice.MMR_ModuleSampleTime3 = mrDevice.MMR_CurTime;
                    mrDevice.MMR_ModuleAir3 = mrDevice.MMR_CurAir;
                    mrDevice.MMR_ModulemPa3 = mrDevice.MMR_CurPressure;
                    break;
                case 4:
                    mrDevice.MMR_ModuleSpeed4 = mrDevice.MMR_CurSpeed;
                    mrDevice.MMR_ModuleTemp4 = mrDevice.MMR_CurTemp;
                    mrDevice.MMR_ModuleSampleTime4 = mrDevice.MMR_CurTime;
                    mrDevice.MMR_ModuleAir4 = mrDevice.MMR_CurAir;
                    mrDevice.MMR_ModulemPa4 = mrDevice.MMR_CurPressure;
                    break;
                case 5:
                    mrDevice.MMR_ModuleSpeed5 = mrDevice.MMR_CurSpeed;
                    mrDevice.MMR_ModuleTemp5 = mrDevice.MMR_CurTemp;
                    mrDevice.MMR_ModuleSampleTime5 = mrDevice.MMR_CurTime;
                    mrDevice.MMR_ModuleAir5 = mrDevice.MMR_CurAir;
                    mrDevice.MMR_ModulemPa5 = mrDevice.MMR_CurPressure;
                    break;
                case 6:
                    mrDevice.MMR_ModuleSpeed6 = mrDevice.MMR_CurSpeed;
                    mrDevice.MMR_ModuleTemp6 = mrDevice.MMR_CurTemp;
                    mrDevice.MMR_ModuleSampleTime6 = mrDevice.MMR_CurTime;
                    mrDevice.MMR_ModuleAir6 = mrDevice.MMR_CurAir;
                    mrDevice.MMR_ModulemPa6 = mrDevice.MMR_CurPressure;
                    break;
                case 7:
                    mrDevice.MMR_ModuleSpeed7 = mrDevice.MMR_CurSpeed;
                    mrDevice.MMR_ModuleTemp7 = mrDevice.MMR_CurTemp;
                    mrDevice.MMR_ModuleSampleTime7 = mrDevice.MMR_CurTime;
                    mrDevice.MMR_ModuleAir7 = mrDevice.MMR_CurAir;
                    mrDevice.MMR_ModulemPa7 = mrDevice.MMR_CurPressure;
                    break;
                case 8:
                    mrDevice.MMR_ModuleSpeed8 = mrDevice.MMR_CurSpeed;
                    mrDevice.MMR_ModuleTemp8 = mrDevice.MMR_CurTemp;
                    mrDevice.MMR_ModuleSampleTime8 = mrDevice.MMR_CurTime;
                    mrDevice.MMR_ModuleAir8 = mrDevice.MMR_CurAir;
                    mrDevice.MMR_ModulemPa8 = mrDevice.MMR_CurPressure;
                    break;
                default:
                    break;

            }
            if (IsSocket)
            {
                String msg = MRDeviceMessageCreator.createSettingMsg(mrDevice.MMR_CurentSelectIndex, mrDevice.MMR_CurSpeed, mrDevice.MMR_CurTemp, mrDevice.MMR_CurTime, mrDevice.MMR_CurAir, mrDevice.MMR_CurPressure);
                mrDevice.SendMsg(msg);
            }

        }

        private int parseInt(String text)
        {
            if (text.Equals("模块1")) return 1;
            if (text.Equals("模块2")) return 2;
            if (text.Equals("模块3")) return 3;
            if (text.Equals("模块4")) return 4;
            if (text.Equals("模块5")) return 5;
            if (text.Equals("模块6")) return 6;
            if (text.Equals("模块7")) return 7;
            if (text.Equals("模块8")) return 8;
            return 0;

        }


        private void bindingNavigator1_RefreshItems(object sender, EventArgs e)
        {

        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
