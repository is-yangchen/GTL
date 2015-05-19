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

        public DeviceInfoForm FatherForm;
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
                    if (mrDevice.run1)
                    {
                        this.textBox6.Text = mrDevice.tpR1.ToString();
                        this.textBox7.Text = mrDevice.phR1.ToString();
                        this.textBox8.Text = mrDevice.doR1.ToString();
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
                    if (mrDevice.run2)
                    {
                        this.textBox6.Text = mrDevice.tpR2.ToString();
                        this.textBox7.Text = mrDevice.phR2.ToString();
                        this.textBox8.Text = mrDevice.doR2.ToString();
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
                    if (mrDevice.run3)
                    {
                        this.textBox6.Text = mrDevice.tpR3.ToString();
                        this.textBox7.Text = mrDevice.phR3.ToString();
                        this.textBox8.Text = mrDevice.doR3.ToString();
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
                    if (mrDevice.run4)
                    {
                        this.textBox6.Text = mrDevice.tpR4.ToString();
                        this.textBox7.Text = mrDevice.phR4.ToString();
                        this.textBox8.Text = mrDevice.doR4.ToString();
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
                    if (mrDevice.run5)
                    {
                        this.textBox6.Text = mrDevice.tpR5.ToString();
                        this.textBox7.Text = mrDevice.phR5.ToString();
                        this.textBox8.Text = mrDevice.doR5.ToString();
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
                    if (mrDevice.run6)
                    {
                        this.textBox6.Text = mrDevice.tpR6.ToString();
                        this.textBox7.Text = mrDevice.phR6.ToString();
                        this.textBox8.Text = mrDevice.doR6.ToString();
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
                    if (mrDevice.run7)
                    {
                        this.textBox6.Text = mrDevice.tpR7.ToString();
                        this.textBox7.Text = mrDevice.phR7.ToString();
                        this.textBox8.Text = mrDevice.doR7.ToString();
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
                    if (mrDevice.run8)
                    {
                        this.textBox6.Text = mrDevice.tpR8.ToString();
                        this.textBox7.Text = mrDevice.phR8.ToString();
                        this.textBox8.Text = mrDevice.doR8.ToString();
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
                    this.textBox1.Text = mrDevice.Speed1.ToString();
                    this.textBox3.Text = mrDevice.Temp1.ToString();
                    this.textBox5.Text = mrDevice.Time1.ToString();
                    this.textBox2.Text = mrDevice.Air1.ToString();
                    this.textBox4.Text = mrDevice.Pressure1.ToString();
                    if (mrDevice.run1) button2.Text = "停止";
                    else button2.Text = "开始 ";
                    break;
                case 2:
                    this.textBox1.Text = mrDevice.Speed2.ToString();
                    this.textBox3.Text = mrDevice.Temp2.ToString();
                    this.textBox5.Text = mrDevice.Time2.ToString();
                    this.textBox2.Text = mrDevice.Air2.ToString();
                    this.textBox4.Text = mrDevice.Pressure2.ToString();
                    if (mrDevice.run2) button2.Text = "停止";
                    else button2.Text = "开始 ";
                    break;
                case 3:
                    this.textBox1.Text = mrDevice.Speed3.ToString();
                    this.textBox3.Text = mrDevice.Temp3.ToString();
                    this.textBox5.Text = mrDevice.Time3.ToString();
                    this.textBox2.Text = mrDevice.Air3.ToString();
                    this.textBox4.Text = mrDevice.Pressure3.ToString();
                    if (mrDevice.run3) button2.Text = "停止";
                    else button2.Text = "开始 ";
                    break;
                case 4:
                    this.textBox1.Text = mrDevice.Speed4.ToString();
                    this.textBox3.Text = mrDevice.Temp4.ToString();
                    this.textBox5.Text = mrDevice.Time4.ToString();
                    this.textBox2.Text = mrDevice.Air4.ToString();
                    this.textBox4.Text = mrDevice.Pressure4.ToString();
                    if (mrDevice.run4) button2.Text = "停止";
                    else button2.Text = "开始 ";
                    break;
                case 5:
                    this.textBox1.Text = mrDevice.Speed5.ToString();
                    this.textBox3.Text = mrDevice.Temp5.ToString();
                    this.textBox5.Text = mrDevice.Time5.ToString();
                    this.textBox2.Text = mrDevice.Air5.ToString();
                    this.textBox4.Text = mrDevice.Pressure5.ToString();
                    if (mrDevice.run5) button2.Text = "停止";
                    else button2.Text = "开始 ";
                    break;
                case 6:
                    this.textBox1.Text = mrDevice.Speed6.ToString();
                    this.textBox3.Text = mrDevice.Temp6.ToString();
                    this.textBox5.Text = mrDevice.Time6.ToString();
                    this.textBox2.Text = mrDevice.Air6.ToString();
                    this.textBox4.Text = mrDevice.Pressure6.ToString();
                    if (mrDevice.run6) button2.Text = "停止";
                    else button2.Text = "开始 ";
                    break;
                case 7:
                    this.textBox1.Text = mrDevice.Speed7.ToString();
                    this.textBox3.Text = mrDevice.Temp7.ToString();
                    this.textBox5.Text = mrDevice.Time7.ToString();
                    this.textBox2.Text = mrDevice.Air7.ToString();
                    this.textBox4.Text = mrDevice.Pressure7.ToString();
                    if (mrDevice.run7) button2.Text = "停止";
                    else button2.Text = "开始 ";
                    break;
                case 8:
                    this.textBox1.Text = mrDevice.Speed8.ToString();
                    this.textBox3.Text = mrDevice.Temp8.ToString();
                    this.textBox5.Text = mrDevice.Time8.ToString();
                    this.textBox2.Text = mrDevice.Air8.ToString();
                    this.textBox4.Text = mrDevice.Pressure8.ToString();
                    if (mrDevice.run8) button2.Text = "停止";
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
                        if (!mrDevice.run1)
                        {
                            String msg = MRDeviceMessageCreator.createStartMsg(curSelectModule);
                            mrDevice.SendMsg(msg);
                            mrDevice.run1 = true;
                        }
                        else
                        {
                            String msg = MRDeviceMessageCreator.createStopMsg(curSelectModule);
                            mrDevice.SendMsg(msg);
                            mrDevice.run1 = false;
                        }
                        break;

                    case 2:
                        if (!mrDevice.run2)
                        {
                            String msg = MRDeviceMessageCreator.createStartMsg(curSelectModule);
                            mrDevice.SendMsg(msg);
                            mrDevice.run2 = true;
                        }
                        else
                        {
                            String msg = MRDeviceMessageCreator.createStopMsg(curSelectModule);
                            mrDevice.SendMsg(msg);
                            mrDevice.run2 = false;
                        }
                        break;
                    case 3:
                        if (!mrDevice.run3)
                        {
                            String msg = MRDeviceMessageCreator.createStartMsg(curSelectModule);
                            mrDevice.SendMsg(msg);
                            mrDevice.run3 = true;
                        }
                        else
                        {
                            String msg = MRDeviceMessageCreator.createStopMsg(curSelectModule);
                            mrDevice.SendMsg(msg);
                            mrDevice.run3 = false;
                        }
                        break;
                    case 4:
                        if (!mrDevice.run4)
                        {
                            String msg = MRDeviceMessageCreator.createStartMsg(curSelectModule);
                            mrDevice.SendMsg(msg);
                            mrDevice.run4 = true;
                        }
                        else
                        {
                            String msg = MRDeviceMessageCreator.createStopMsg(curSelectModule);
                            mrDevice.SendMsg(msg);
                            mrDevice.run4 = false;
                        }
                        break;
                    case 5:
                        if (!mrDevice.run5)
                        {
                            String msg = MRDeviceMessageCreator.createStartMsg(curSelectModule);
                            mrDevice.SendMsg(msg);
                            mrDevice.run5 = true;
                        }
                        else
                        {
                            String msg = MRDeviceMessageCreator.createStopMsg(curSelectModule);
                            mrDevice.SendMsg(msg);
                            mrDevice.run5 = false;
                        }
                        break;
                    case 6:
                        if (!mrDevice.run6)
                        {
                            String msg = MRDeviceMessageCreator.createStartMsg(curSelectModule);
                            mrDevice.SendMsg(msg);
                            mrDevice.run6 = true;
                        }
                        else
                        {
                            String msg = MRDeviceMessageCreator.createStopMsg(curSelectModule);
                            mrDevice.SendMsg(msg);
                            mrDevice.run6 = false;
                        }
                        break;
                    case 7:
                        if (!mrDevice.run7)
                        {
                            String msg = MRDeviceMessageCreator.createStartMsg(curSelectModule);
                            mrDevice.SendMsg(msg);
                            mrDevice.run7 = true;
                        }
                        else
                        {
                            String msg = MRDeviceMessageCreator.createStopMsg(curSelectModule);
                            mrDevice.SendMsg(msg);
                            mrDevice.run7 = false;
                        }
                        break;
                    case 8:
                        if (!mrDevice.run8)
                        {
                            String msg = MRDeviceMessageCreator.createStartMsg(curSelectModule);
                            mrDevice.SendMsg(msg);
                            mrDevice.run8 = true;
                        }
                        else
                        {
                            String msg = MRDeviceMessageCreator.createStopMsg(curSelectModule);
                            mrDevice.SendMsg(msg);
                            mrDevice.run8 = false;
                        }
                        break;
                }

            }
        }

        private void send_Click(object sender, EventArgs e)
        {
            mrDevice.curSelectModule = parseInt(this.comboBox1.Text);
            mrDevice.curSpeed = Int32.Parse(this.textBox1.Text);
            mrDevice.curTemp = Int32.Parse(this.textBox3.Text);
            mrDevice.curTime = Int32.Parse(this.textBox5.Text);
            mrDevice.curAir = Int32.Parse(this.textBox2.Text);
            mrDevice.curPressure = Int32.Parse(this.textBox4.Text);
            switch (curSelectModule)
            {
                case 1:
                    mrDevice.Speed1 = mrDevice.curSpeed;
                    mrDevice.Temp1 = mrDevice.curTemp;
                    mrDevice.Time1 = mrDevice.curTime;
                    mrDevice.Air1 = mrDevice.curAir;
                    mrDevice.Pressure1 = mrDevice.curPressure;
                    break;
                case 2:
                    mrDevice.Speed2 = mrDevice.curSpeed;
                    mrDevice.Temp2 = mrDevice.curTemp;
                    mrDevice.Time2 = mrDevice.curTime;
                    mrDevice.Air2 = mrDevice.curAir;
                    mrDevice.Pressure2 = mrDevice.curPressure;
                    break;
                case 3:
                    mrDevice.Speed3 = mrDevice.curSpeed;
                    mrDevice.Temp3 = mrDevice.curTemp;
                    mrDevice.Time3 = mrDevice.curTime;
                    mrDevice.Air3 = mrDevice.curAir;
                    mrDevice.Pressure3 = mrDevice.curPressure;
                    break;
                case 4:
                    mrDevice.Speed4 = mrDevice.curSpeed;
                    mrDevice.Temp4 = mrDevice.curTemp;
                    mrDevice.Time4 = mrDevice.curTime;
                    mrDevice.Air4 = mrDevice.curAir;
                    mrDevice.Pressure4 = mrDevice.curPressure;
                    break;
                case 5:
                    mrDevice.Speed5 = mrDevice.curSpeed;
                    mrDevice.Temp5 = mrDevice.curTemp;
                    mrDevice.Time5 = mrDevice.curTime;
                    mrDevice.Air5 = mrDevice.curAir;
                    mrDevice.Pressure5 = mrDevice.curPressure;
                    break;
                case 6:
                    mrDevice.Speed6 = mrDevice.curSpeed;
                    mrDevice.Temp6 = mrDevice.curTemp;
                    mrDevice.Time6 = mrDevice.curTime;
                    mrDevice.Air6 = mrDevice.curAir;
                    mrDevice.Pressure6 = mrDevice.curPressure;
                    break;
                case 7:
                    mrDevice.Speed7 = mrDevice.curSpeed;
                    mrDevice.Temp7 = mrDevice.curTemp;
                    mrDevice.Time7 = mrDevice.curTime;
                    mrDevice.Air7 = mrDevice.curAir;
                    mrDevice.Pressure7 = mrDevice.curPressure;
                    break;
                case 8:
                    mrDevice.Speed8 = mrDevice.curSpeed;
                    mrDevice.Temp8 = mrDevice.curTemp;
                    mrDevice.Time8 = mrDevice.curTime;
                    mrDevice.Air8 = mrDevice.curAir;
                    mrDevice.Pressure8 = mrDevice.curPressure;
                    break;
                default:
                    break;

            }
            if (IsSocket)
            {
                String msg = MRDeviceMessageCreator.createSettingMsg(mrDevice.curSelectModule, mrDevice.curSpeed, mrDevice.curTemp, mrDevice.curTime, mrDevice.curAir, mrDevice.curPressure);
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
