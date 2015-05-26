using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DeviceUtils;
using Instrument;

namespace VirtialDevices
{
    public partial class LiquidProcessForm : Form
    {
        public DeviceForm FatherForm;
        public LiquidProcessDevice alcDevice;
        public bool IsSocket;

        private String initStatus = "00000000000000000000";
        //private String initStatus = "54263414263512363251";

        public LiquidProcessForm()
        {
            //  alcDevice = new LiquidProcessDevice();
            //  alcDevice.taiMianPeiZhi = initStatus;
            InitializeComponent();
        }

        private void setPaltesByMsg(String msg)
        {
            try
            {
                button1.Text = getPlate(msg[0]) + "1";
                if ((int)msg[0] == 53) button1.BackColor = System.Drawing.SystemColors.Highlight;
                button2.Text = getPlate(msg[1]) + "2";
                if ((int)msg[1] == 53) button2.BackColor = System.Drawing.SystemColors.Highlight;
                button3.Text = getPlate(msg[2]) + "3";
                if ((int)msg[2] == 53) button3.BackColor = System.Drawing.SystemColors.Highlight;
                button4.Text = getPlate(msg[3]) + "4";
                if ((int)msg[3] == 53) button4.BackColor = System.Drawing.SystemColors.Highlight;
                button5.Text = getPlate(msg[4]) + "5";
                if ((int)msg[4] == 53) button5.BackColor = System.Drawing.SystemColors.Highlight;
                button6.Text = getPlate(msg[5]) + "6";
                if ((int)msg[5] == 53) button6.BackColor = System.Drawing.SystemColors.Highlight;
                button7.Text = getPlate(msg[6]) + "7";
                if ((int)msg[6] == 53) button7.BackColor = System.Drawing.SystemColors.Highlight;
                button8.Text = getPlate(msg[7]) + "8";
                if ((int)msg[7] == 53) button8.BackColor = System.Drawing.SystemColors.Highlight;
                button9.Text = getPlate(msg[8]) + "9";
                if ((int)msg[8] == 53) button9.BackColor = System.Drawing.SystemColors.Highlight;
                button10.Text = getPlate(msg[9]) + "10";
                if ((int)msg[9] == 53) button10.BackColor = System.Drawing.SystemColors.Highlight;
                button11.Text = getPlate(msg[10]) + "11";
                if ((int)msg[10] == 53) button11.BackColor = System.Drawing.SystemColors.Highlight;
                button12.Text = getPlate(msg[11]) + "12";
                if ((int)msg[11] == 53) button12.BackColor = System.Drawing.SystemColors.Highlight;
                button13.Text = getPlate(msg[12]) + "13";
                if ((int)msg[12] == 53) button13.BackColor = System.Drawing.SystemColors.Highlight;
                button14.Text = getPlate(msg[13]) + "14";
                if ((int)msg[13] == 53) button14.BackColor = System.Drawing.SystemColors.Highlight;
                button15.Text = getPlate(msg[14]) + "15";
                if ((int)msg[14] == 53) button15.BackColor = System.Drawing.SystemColors.Highlight;
                button16.Text = getPlate(msg[15]) + "16";
                if ((int)msg[15] == 53) button16.BackColor = System.Drawing.SystemColors.Highlight;
                button17.Text = getPlate(msg[16]) + "17";
                if ((int)msg[16] == 53) button17.BackColor = System.Drawing.SystemColors.Highlight;
                button18.Text = getPlate(msg[17]) + "18";
                if ((int)msg[17] == 53) button18.BackColor = System.Drawing.SystemColors.Highlight;
                button19.Text = getPlate(msg[18]) + "19";
                if ((int)msg[18] == 53) button19.BackColor = System.Drawing.SystemColors.Highlight;
                button20.Text = getPlate(msg[19]) + "20";
                if ((int)msg[19] == 53) button20.BackColor = System.Drawing.SystemColors.Highlight;

            }
            catch (Exception ex) { }
        }

        private String getPlate(char c)
        {
            int tmp = (int)c;
            switch (tmp)
            {
                case 48: return "无";                      // c == '0'
                case 49: return "48 Plates";
                case 50: return "96 Plates";
                case 51: return "50ul吸头盒";
                case 52: return "250ul吸头盒";
                case 53: return "样品盒";
                case 54: return "空孔板";
                default: return "错误信息";
            }

        }
        private void ALCDeviceForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            FatherForm.Enabled = true;
        }


        private void ALCDeviceForm_Load(object sender, EventArgs e)
        {



            setPaltesByMsg(alcDevice.LHS_PlateStatus);


            timer1.Start();

        }


        private void groupBox4_Enter(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();
            // IsSocket = true; // warning!-----------------temp setting----------------------
            // if (IsSocket)

            this.textBox4.Text = alcDevice.LHS_SuctionPlate;
            this.textBox5.Text = alcDevice.LHS_TargetPlate;
            this.textBox1.Text = alcDevice.LHS_Imbitition.ToString();
            this.textBox6.Text = alcDevice.LHS_LiquidRate.ToString();
            this.textBox7.Text = alcDevice.LHS_DischargeRate.ToString();
            this.textBox2.Text = alcDevice.LHS_LiquidPosition.ToString();
            this.textBox3.Text = alcDevice.LHS_DischargePosition.ToString();
            setPaltesByMsg(alcDevice.LHS_PlateStatus);



            timer1.Start();
        }

        private void cancelButton_click(object sender, EventArgs e)
        {
            this.Close();
            FatherForm.Enabled = true;
        }
    }
}
