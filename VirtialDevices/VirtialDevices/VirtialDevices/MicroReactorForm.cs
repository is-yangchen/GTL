using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

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
                    this.textBox1.Text = mrDevice.Speed1.ToString();
                    this.textBox3.Text = mrDevice.Temp1.ToString();
                    this.textBox5.Text = mrDevice.Time1.ToString();
                    this.textBox2.Text = mrDevice.Air1.ToString();
                    this.textBox4.Text = mrDevice.Pressure1.ToString();

                    if (mrDevice.run1)
                    {
                        this.textBox6.Text = mrDevice.tpR1.ToString();
                        this.textBox7.Text = mrDevice.phR1.ToString();
                        this.textBox8.Text = mrDevice.doR1.ToString();
                    }
                    else
                    {
                        this.textBox6.Text = "0";
                        this.textBox7.Text = "0";
                        this.textBox8.Text = "0";
                    }
                    break;
                case 2:
                    this.textBox1.Text = mrDevice.Speed2.ToString();
                    this.textBox3.Text = mrDevice.Temp2.ToString();
                    this.textBox5.Text = mrDevice.Time2.ToString();
                    this.textBox2.Text = mrDevice.Air2.ToString();
                    this.textBox4.Text = mrDevice.Pressure2.ToString();

                    if (mrDevice.run2)
                    {
                        this.textBox6.Text = mrDevice.tpR2.ToString();
                        this.textBox7.Text = mrDevice.phR2.ToString();
                        this.textBox8.Text = mrDevice.doR2.ToString();
                    }
                    else
                    {
                        this.textBox6.Text = "0";
                        this.textBox7.Text = "0";
                        this.textBox8.Text = "0";
                    }
                    break;
                case 3:
                    this.textBox1.Text = mrDevice.Speed3.ToString();
                    this.textBox3.Text = mrDevice.Temp3.ToString();
                    this.textBox5.Text = mrDevice.Time3.ToString();
                    this.textBox2.Text = mrDevice.Air3.ToString();
                    this.textBox4.Text = mrDevice.Pressure3.ToString();

                    if (mrDevice.run3)
                    {
                        this.textBox6.Text = mrDevice.tpR3.ToString();
                        this.textBox7.Text = mrDevice.phR3.ToString();
                        this.textBox8.Text = mrDevice.doR3.ToString();
                    }
                    else
                    {
                        this.textBox6.Text = "0";
                        this.textBox7.Text = "0";
                        this.textBox8.Text = "0";
                    }
                    break;
                case 4:
                    this.textBox1.Text = mrDevice.Speed4.ToString();
                    this.textBox3.Text = mrDevice.Temp4.ToString();
                    this.textBox5.Text = mrDevice.Time4.ToString();
                    this.textBox2.Text = mrDevice.Air4.ToString();
                    this.textBox4.Text = mrDevice.Pressure4.ToString();

                    if (mrDevice.run4)
                    {
                        this.textBox6.Text = mrDevice.tpR4.ToString();
                        this.textBox7.Text = mrDevice.phR4.ToString();
                        this.textBox8.Text = mrDevice.doR4.ToString();
                    }
                    else
                    {
                        this.textBox6.Text = "0";
                        this.textBox7.Text = "0";
                        this.textBox8.Text = "0";
                    }
                    break;
                case 5:
                    this.textBox1.Text = mrDevice.Speed5.ToString();
                    this.textBox3.Text = mrDevice.Temp5.ToString();
                    this.textBox5.Text = mrDevice.Time5.ToString();
                    this.textBox2.Text = mrDevice.Air5.ToString();
                    this.textBox4.Text = mrDevice.Pressure5.ToString();

                    if (mrDevice.run5)
                    {
                        this.textBox6.Text = mrDevice.tpR5.ToString();
                        this.textBox7.Text = mrDevice.phR5.ToString();
                        this.textBox8.Text = mrDevice.doR5.ToString();
                    }
                    else
                    {
                        this.textBox6.Text = "0";
                        this.textBox7.Text = "0";
                        this.textBox8.Text = "0";
                    }
                    break;
                case 6:
                    this.textBox1.Text = mrDevice.Speed6.ToString();
                    this.textBox3.Text = mrDevice.Temp6.ToString();
                    this.textBox5.Text = mrDevice.Time6.ToString();
                    this.textBox2.Text = mrDevice.Air6.ToString();
                    this.textBox4.Text = mrDevice.Pressure6.ToString();

                    if (mrDevice.run6)
                    {
                        this.textBox6.Text = mrDevice.tpR6.ToString();
                        this.textBox7.Text = mrDevice.phR6.ToString();
                        this.textBox8.Text = mrDevice.doR6.ToString();
                    }
                    else
                    {
                        this.textBox6.Text = "0";
                        this.textBox7.Text = "0";
                        this.textBox8.Text = "0";
                    }
                    break;
                case 7:
                    this.textBox1.Text = mrDevice.Speed7.ToString();
                    this.textBox3.Text = mrDevice.Temp7.ToString();
                    this.textBox5.Text = mrDevice.Time7.ToString();
                    this.textBox2.Text = mrDevice.Air7.ToString();
                    this.textBox4.Text = mrDevice.Pressure7.ToString();

                    if (mrDevice.run7)
                    {
                        this.textBox6.Text = mrDevice.tpR7.ToString();
                        this.textBox7.Text = mrDevice.phR7.ToString();
                        this.textBox8.Text = mrDevice.doR7.ToString();
                    }
                    else
                    {
                        this.textBox6.Text = "0";
                        this.textBox7.Text = "0";
                        this.textBox8.Text = "0";
                    }
                    break;
                case 8:
                    this.textBox1.Text = mrDevice.Speed8.ToString();
                    this.textBox3.Text = mrDevice.Temp8.ToString();
                    this.textBox5.Text = mrDevice.Time8.ToString();
                    this.textBox2.Text = mrDevice.Air8.ToString();
                    this.textBox4.Text = mrDevice.Pressure8.ToString();

                    if (mrDevice.run8)
                    {
                        this.textBox6.Text = mrDevice.tpR8.ToString();
                        this.textBox7.Text = mrDevice.phR8.ToString();
                        this.textBox8.Text = mrDevice.doR8.ToString();
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
