using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Instrument;

namespace VirtialDevices
{
    public partial class MicroReactorForm : Form
    {
        public DeviceForm FatherForm;
        public MicroStorageDevice mrDevice;
        public bool IsSocket;

        int curSelectModule;

        public MicroReactorForm()
        {
            mrDevice = new MicroStorageDevice();
            curSelectModule = 1;
            InitializeComponent();
        }
        private void mrDeviceForm_load(object sender, EventArgs e)
        {
            refresh();
            timer1.Start();
        }



        private void comboBox1_textChanged(object sender, EventArgs e)
        {
            curSelectModule = parseInt(this.comboBox1.Text);
            refresh();
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

                    if (mrDevice.MMR_Module2)
                    {
                        this.textBox6.Text = mrDevice.MMR_ModTemp1.ToString();
                        this.textBox7.Text = mrDevice.MMR_ModPh1.ToString();
                        this.textBox8.Text = mrDevice.MMR_ModDo1.ToString();
                    }
                    else
                    {
                        this.textBox6.Text = "0";
                        this.textBox7.Text = "0";
                        this.textBox8.Text = "0";
                    }
                    break;
                case 2:
                    this.textBox1.Text = mrDevice.MMR_ModuleSpeed2.ToString();
                    this.textBox3.Text = mrDevice.MMR_ModuleTemp2.ToString();
                    this.textBox5.Text = mrDevice.MMR_ModuleSampleTime2.ToString();
                    this.textBox2.Text = mrDevice.MMR_ModuleAir2.ToString();
                    this.textBox4.Text = mrDevice.MMR_ModulemPa2.ToString();

                    if (mrDevice.MMR_Module2)
                    {
                        this.textBox6.Text = mrDevice.MMR_ModTemp2.ToString();
                        this.textBox7.Text = mrDevice.MMR_ModPh2.ToString();
                        this.textBox8.Text = mrDevice.MMR_ModDo2.ToString();
                    }
                    else
                    {
                        this.textBox6.Text = "0";
                        this.textBox7.Text = "0";
                        this.textBox8.Text = "0";
                    }
                    break;
                case 3:
                    this.textBox1.Text = mrDevice.MMR_ModuleSpeed3.ToString();
                    this.textBox3.Text = mrDevice.MMR_ModuleTemp3.ToString();
                    this.textBox5.Text = mrDevice.MMR_ModuleSampleTime3.ToString();
                    this.textBox2.Text = mrDevice.MMR_ModuleAir3.ToString();
                    this.textBox4.Text = mrDevice.MMR_ModulemPa3.ToString();

                    if (mrDevice.MMR_Module3)
                    {
                        this.textBox6.Text = mrDevice.MMR_ModTemp3.ToString();
                        this.textBox7.Text = mrDevice.MMR_Modph3.ToString();
                        this.textBox8.Text = mrDevice.MMR_ModDo3.ToString();
                    }
                    else
                    {
                        this.textBox6.Text = "0";
                        this.textBox7.Text = "0";
                        this.textBox8.Text = "0";
                    }
                    break;
                case 4:
                    this.textBox1.Text = mrDevice.MMR_ModuleSpeed4.ToString();
                    this.textBox3.Text = mrDevice.MMR_ModuleTemp4.ToString();
                    this.textBox5.Text = mrDevice.MMR_ModuleSampleTime4.ToString();
                    this.textBox2.Text = mrDevice.MMR_ModuleAir4.ToString();
                    this.textBox4.Text = mrDevice.MMR_ModulemPa4.ToString();

                    if (mrDevice.MMR_Module4)
                    {
                        this.textBox6.Text = mrDevice.MMR_ModTemp4.ToString();
                        this.textBox7.Text = mrDevice.MMR_Modph4.ToString();
                        this.textBox8.Text = mrDevice.MMR_ModDo4.ToString();
                    }
                    else
                    {
                        this.textBox6.Text = "0";
                        this.textBox7.Text = "0";
                        this.textBox8.Text = "0";
                    }
                    break;
                case 5:
                    this.textBox1.Text = mrDevice.MMR_ModuleSpeed5.ToString();
                    this.textBox3.Text = mrDevice.MMR_ModuleTemp5.ToString();
                    this.textBox5.Text = mrDevice.MMR_ModuleSampleTime5.ToString();
                    this.textBox2.Text = mrDevice.MMR_ModuleAir5.ToString();
                    this.textBox4.Text = mrDevice.MMR_ModulemPa5.ToString();

                    if (mrDevice.MMR_Module5)
                    {
                        this.textBox6.Text = mrDevice.MMR_ModTemp5.ToString();
                        this.textBox7.Text = mrDevice.MMR_Modph5.ToString();
                        this.textBox8.Text = mrDevice.MMR_ModDo5.ToString();
                    }
                    else
                    {
                        this.textBox6.Text = "0";
                        this.textBox7.Text = "0";
                        this.textBox8.Text = "0";
                    }
                    break;
                case 6:
                    this.textBox1.Text = mrDevice.MMR_ModuleSpeed6.ToString();
                    this.textBox3.Text = mrDevice.MMR_ModuleTemp6.ToString();
                    this.textBox5.Text = mrDevice.MMR_ModuleSampleTime6.ToString();
                    this.textBox2.Text = mrDevice.MMR_ModuleAir6.ToString();
                    this.textBox4.Text = mrDevice.MMR_ModulemPa6.ToString();

                    if (mrDevice.MMR_Module6)
                    {
                        this.textBox6.Text = mrDevice.MMR_ModTemp6.ToString();
                        this.textBox7.Text = mrDevice.MMR_Modph6.ToString();
                        this.textBox8.Text = mrDevice.MMR_ModDo6.ToString();
                    }
                    else
                    {
                        this.textBox6.Text = "0";
                        this.textBox7.Text = "0";
                        this.textBox8.Text = "0";
                    }
                    break;
                case 7:
                    this.textBox1.Text = mrDevice.MMR_ModuleSpeed7.ToString();
                    this.textBox3.Text = mrDevice.MMR_ModuleTemp7.ToString();
                    this.textBox5.Text = mrDevice.MMR_ModuleTime7.ToString();
                    this.textBox2.Text = mrDevice.MMR_ModuleAir7.ToString();
                    this.textBox4.Text = mrDevice.MMR_ModulemPa7.ToString();

                    if (mrDevice.MMR_Module7)
                    {
                        this.textBox6.Text = mrDevice.MMR_ModTemp7.ToString();
                        this.textBox7.Text = mrDevice.MMR_Modph7.ToString();
                        this.textBox8.Text = mrDevice.MMR_ModDo7.ToString();
                    }
                    else
                    {
                        this.textBox6.Text = "0";
                        this.textBox7.Text = "0";
                        this.textBox8.Text = "0";
                    }
                    break;
                case 8:
                    this.textBox1.Text = mrDevice.MMR_ModuleSpeed8.ToString();
                    this.textBox3.Text = mrDevice.MMR_ModuleTemp8.ToString();
                    this.textBox5.Text = mrDevice.MMR_ModuleTime8.ToString();
                    this.textBox2.Text = mrDevice.MMR_ModuleAir8.ToString();
                    this.textBox4.Text = mrDevice.MMR_ModulemPa8.ToString();

                    if (mrDevice.MMR_Module8)
                    {
                        this.textBox6.Text = mrDevice.MMR_ModTemp8.ToString();
                        this.textBox7.Text = mrDevice.MMR_Modph8.ToString();
                        this.textBox8.Text = mrDevice.MMR_ModDo8.ToString();
                    }
                    else
                    {
                        this.textBox6.Text = "0";
                        this.textBox7.Text = "0";
                        this.textBox8.Text = "0";
                    }
                    break;
                default:
                    break;

            }

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();
            curSelectModule = parseInt(this.comboBox1.Text);
            // IsSocket = true; // warning!-----------------temp setting----------------------
            // if (IsSocket)
            refresh();
            timer1.Start();
        }
        private void timer2_Tick(object sender, EventArgs e)
        {
            timer2.Stop();

        }

        private void cancelButton_click(object sender, EventArgs e)
        {
            this.Close();
            FatherForm.Enabled = true;
        }

    }
}
