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
    public partial class LiquidProcessForm : Form
    {
        public LiquidProcessVirtualDevice alcDevice;
        int LHS_TipBoxIdx;
        private String initStatus = "00000000000000000000";
        // String initStatus = "54263414263512363251";
        public String curStatus;
        public String tempStatus;
        private int size;

        public ControlForm FatherForm;
        public BaseDevice DeviceInfo;

        public bool IsSocket;

        public LiquidProcessForm()
        {
            alcDevice = new LiquidProcessVirtualDevice();
            LHS_TipBoxIdx = 0;
            tempStatus = initStatus;
            curStatus = tempStatus;
            size = 20;
            InitializeComponent();
        }

        private void LiquidProcessForm_new_Load(object sender, EventArgs e)
        {
            Control.CheckForIllegalCrossThreadCalls = false;
            FatherForm.Enabled = false;
            if (DeviceInfo.IsVirt)
            {
                isVirtualCheckBox.Checked = true;
            }
            deviceNameLabel.Text = DeviceInfo.Name;
            deviceIPTextBox.Text = DeviceInfo.IP;
            localIPTextBox.Text = DeviceInfo.ControlIP;
            deviceNameTextBox.Text = DeviceInfo.Name;
            identifyIDTextBox.Text = DeviceInfo.IdentifyID;
            codeTextBox.Text = DeviceInfo.Code;
            serialIDTextBox.Text = DeviceInfo.SerialID;

            setPaltesByMsgAll(initStatus);
            refreshQuYePan();
            refreshMuBiaoPan();

        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void DeviceInfoForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            FatherForm.Enabled = true;
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

        private void setPaltesByMsgAll(String msg)
        {
            try
            {
                button1.Text = getPlate(msg[0]) + "1";
                button2.Text = getPlate(msg[1]) + "2";
                button3.Text = getPlate(msg[2]) + "3";
                button4.Text = getPlate(msg[3]) + "4";
                button5.Text = getPlate(msg[4]) + "5";
                button6.Text = getPlate(msg[5]) + "6";
                button7.Text = getPlate(msg[6]) + "7";
                button8.Text = getPlate(msg[7]) + "8";
                button9.Text = getPlate(msg[8]) + "9";
                button10.Text = getPlate(msg[9]) + "10";
                button11.Text = getPlate(msg[10]) + "11";
                button12.Text = getPlate(msg[11]) + "12";
                button13.Text = getPlate(msg[12]) + "13";
                button14.Text = getPlate(msg[13]) + "14";
                button15.Text = getPlate(msg[14]) + "15";
                button16.Text = getPlate(msg[15]) + "16";
                button17.Text = getPlate(msg[16]) + "17";
                button18.Text = getPlate(msg[17]) + "18";
                button19.Text = getPlate(msg[18]) + "19";
                button20.Text = getPlate(msg[19]) + "20";

                button22.Text = getPlate(msg[0]) + "1";
                button23.Text = getPlate(msg[1]) + "2";
                button24.Text = getPlate(msg[2]) + "3";
                button25.Text = getPlate(msg[3]) + "4";
                button26.Text = getPlate(msg[4]) + "5";
                button27.Text = getPlate(msg[5]) + "6";
                button28.Text = getPlate(msg[6]) + "7";
                button29.Text = getPlate(msg[7]) + "8";
                button30.Text = getPlate(msg[8]) + "9";
                button31.Text = getPlate(msg[9]) + "10";
                button32.Text = getPlate(msg[10]) + "11";
                button33.Text = getPlate(msg[11]) + "12";
                button34.Text = getPlate(msg[12]) + "13";
                button35.Text = getPlate(msg[13]) + "14";
                button36.Text = getPlate(msg[14]) + "15";
                button37.Text = getPlate(msg[15]) + "16";
                button38.Text = getPlate(msg[16]) + "17";
                button39.Text = getPlate(msg[17]) + "18";
                button40.Text = getPlate(msg[18]) + "19";
                button41.Text = getPlate(msg[19]) + "20";

            }
            catch (Exception ex) { }
        }

        private void setPaltesByMsg(String msg)
        {
            try
            {
                button1.Text = getPlate(msg[0]) + "1";
                button2.Text = getPlate(msg[1]) + "2";
                button3.Text = getPlate(msg[2]) + "3";
                button4.Text = getPlate(msg[3]) + "4";
                button5.Text = getPlate(msg[4]) + "5";
                button6.Text = getPlate(msg[5]) + "6";
                button7.Text = getPlate(msg[6]) + "7";
                button8.Text = getPlate(msg[7]) + "8";
                button9.Text = getPlate(msg[8]) + "9";
                button10.Text = getPlate(msg[9]) + "10";
                button11.Text = getPlate(msg[10]) + "11";
                button12.Text = getPlate(msg[11]) + "12";
                button13.Text = getPlate(msg[12]) + "13";
                button14.Text = getPlate(msg[13]) + "14";
                button15.Text = getPlate(msg[14]) + "15";
                button16.Text = getPlate(msg[15]) + "16";
                button17.Text = getPlate(msg[16]) + "17";
                button18.Text = getPlate(msg[17]) + "18";
                button19.Text = getPlate(msg[18]) + "19";
                button20.Text = getPlate(msg[19]) + "20";

            }
            catch (Exception ex) { }
        }


        #region button_click
        private void button1_click(object sender, EventArgs e)
        {
            LHS_TipBoxIdx = 1;
            showPlateInfo(LHS_TipBoxIdx);
            comboBox1.Text = "";
        }
        private void button2_click(object sender, EventArgs e)
        {
            LHS_TipBoxIdx = 2;
            showPlateInfo(LHS_TipBoxIdx);
            comboBox1.Text = "";
        }
        private void button3_click(object sender, EventArgs e)
        {
            LHS_TipBoxIdx = 3;
            showPlateInfo(LHS_TipBoxIdx);
            comboBox1.Text = "";
        }
        private void button4_click(object sender, EventArgs e)
        {
            LHS_TipBoxIdx = 4;
            showPlateInfo(LHS_TipBoxIdx);
            comboBox1.Text = "";
        }
        private void button5_click(object sender, EventArgs e)
        {
            LHS_TipBoxIdx = 5;
            showPlateInfo(LHS_TipBoxIdx);
            comboBox1.Text = "";
        }
        private void button6_click(object sender, EventArgs e)
        {
            LHS_TipBoxIdx = 6;
            showPlateInfo(LHS_TipBoxIdx);
            comboBox1.Text = "";
        }
        private void button7_click(object sender, EventArgs e)
        {
            LHS_TipBoxIdx = 7;
            showPlateInfo(LHS_TipBoxIdx);
            comboBox1.Text = "";
        }
        private void button8_click(object sender, EventArgs e)
        {
            LHS_TipBoxIdx = 8;
            showPlateInfo(LHS_TipBoxIdx);
            comboBox1.Text = "";
        }
        private void button9_click(object sender, EventArgs e)
        {
            LHS_TipBoxIdx = 9;
            showPlateInfo(LHS_TipBoxIdx);
            comboBox1.Text = "";
        }
        private void button10_click(object sender, EventArgs e)
        {
            LHS_TipBoxIdx = 10;
            showPlateInfo(LHS_TipBoxIdx);
            comboBox1.Text = "";
        }
        private void button11_click(object sender, EventArgs e)
        {
            LHS_TipBoxIdx = 11;
            showPlateInfo(LHS_TipBoxIdx);
            comboBox1.Text = "";
        }
        private void button12_click(object sender, EventArgs e)
        {
            LHS_TipBoxIdx = 12;
            showPlateInfo(LHS_TipBoxIdx);
            comboBox1.Text = "";
        }
        private void button13_click(object sender, EventArgs e)
        {
            LHS_TipBoxIdx = 13;
            showPlateInfo(LHS_TipBoxIdx);
            comboBox1.Text = "";
        }
        private void button14_click(object sender, EventArgs e)
        {
            LHS_TipBoxIdx = 14;
            showPlateInfo(LHS_TipBoxIdx);
            comboBox1.Text = "";
        }
        private void button15_click(object sender, EventArgs e)
        {
            LHS_TipBoxIdx = 15;
            showPlateInfo(LHS_TipBoxIdx);
            comboBox1.Text = "";
        }
        private void button16_click(object sender, EventArgs e)
        {
            LHS_TipBoxIdx = 16;
            showPlateInfo(LHS_TipBoxIdx);
            comboBox1.Text = "";
        }
        private void button17_click(object sender, EventArgs e)
        {
            LHS_TipBoxIdx = 17;
            showPlateInfo(LHS_TipBoxIdx);
            comboBox1.Text = "";
        }
        private void button18_click(object sender, EventArgs e)
        {
            LHS_TipBoxIdx = 18;
            showPlateInfo(LHS_TipBoxIdx);
            comboBox1.Text = "";
        }
        private void button19_click(object sender, EventArgs e)
        {
            LHS_TipBoxIdx = 19;
            showPlateInfo(LHS_TipBoxIdx);
            comboBox1.Text = "";
        }
        private void button20_click(object sender, EventArgs e)
        {
            LHS_TipBoxIdx = 20;
            showPlateInfo(LHS_TipBoxIdx);
            comboBox1.Text = "";
        }

        #endregion
        private void showPlateInfo(int index)
        {
            switch (index)
            {
                case 1: textBox1.Text = button1.Text; break;
                case 2: textBox1.Text = button2.Text; break;
                case 3: textBox1.Text = button3.Text; break;
                case 4: textBox1.Text = button4.Text; break;
                case 5: textBox1.Text = button5.Text; break;
                case 6: textBox1.Text = button6.Text; break;
                case 7: textBox1.Text = button7.Text; break;
                case 8: textBox1.Text = button8.Text; break;
                case 9: textBox1.Text = button9.Text; break;
                case 10: textBox1.Text = button10.Text; break;
                case 11: textBox1.Text = button11.Text; break;
                case 12: textBox1.Text = button12.Text; break;
                case 13: textBox1.Text = button13.Text; break;
                case 14: textBox1.Text = button14.Text; break;
                case 15: textBox1.Text = button15.Text; break;
                case 16: textBox1.Text = button16.Text; break;
                case 17: textBox1.Text = button17.Text; break;
                case 18: textBox1.Text = button18.Text; break;
                case 19: textBox1.Text = button19.Text; break;
                case 20: textBox1.Text = button20.Text; break;
                default: textBox1.Text = ""; break;
            }
            if (index != 0)
            {
                // textBox1.Text = getPlate(tempStatus[index - 1]) + (char)((int)'0' + index);
                textBox3.Text = getPlate(tempStatus[index - 1]);
            }
        }

        private void comboBox1_textChanged(object sender, EventArgs e)
        {
            if ((LHS_TipBoxIdx != 0) && (comboBox1.Text != ""))
            {
                String t = "";
                for (int i = 0; i < size; i++)
                {
                    if (i == LHS_TipBoxIdx - 1)
                        t += (char)((int)'0' + comboBox1.SelectedIndex);
                    else
                        t += tempStatus[i];
                }
                tempStatus = t;
            }
            setPaltesByMsg(tempStatus);
            showPlateInfo(LHS_TipBoxIdx);
        }

        private void deployConfirm_click(object sender, EventArgs e)
        {
            curStatus = tempStatus;
            setPaltesByMsgAll(curStatus);
            refreshQuYePan();
            refreshMuBiaoPan();
            alcDevice.LHS_PlateStatus = curStatus;
            if (IsSocket)
            {
                String msg = ALCDeviceMessageCreator.createDeployStatus(alcDevice.LHS_PlateStatus);
                alcDevice.SendMsg(msg);
                //Database mydb = new Database();
                //mydb.insertlpssetting(1, alcDevice.msgStatus);
            }
        }


        private void tabControl1_tabCancel(object sender, EventArgs e)
        {
            tempStatus = curStatus;
            setPaltesByMsgAll(curStatus);
            comboBox2.Text = "";
            comboBox3.Text = "";
        }

        private void refreshQuYePan()
        {
            comboBox2.Items.Clear();
            for (int i = 0; i < size; i++)
            {
                int tmp = (int)curStatus[i];
                switch (tmp)
                {
                    case 49:
                    case 50:
                    case 53:
                    case 54:
                        {
                            switch (i)
                            {
                                case 0: comboBox2.Items.Add(button22.Text); break;
                                case 1: comboBox2.Items.Add(button23.Text); break;
                                case 2: comboBox2.Items.Add(button24.Text); break;
                                case 3: comboBox2.Items.Add(button25.Text); break;
                                case 4: comboBox2.Items.Add(button26.Text); break;
                                case 5: comboBox2.Items.Add(button27.Text); break;
                                case 6: comboBox2.Items.Add(button28.Text); break;
                                case 7: comboBox2.Items.Add(button29.Text); break;
                                case 8: comboBox2.Items.Add(button30.Text); break;
                                case 9: comboBox2.Items.Add(button31.Text); break;
                                case 10: comboBox2.Items.Add(button32.Text); break;
                                case 11: comboBox2.Items.Add(button33.Text); break;
                                case 12: comboBox2.Items.Add(button34.Text); break;
                                case 13: comboBox2.Items.Add(button35.Text); break;
                                case 14: comboBox2.Items.Add(button36.Text); break;
                                case 15: comboBox2.Items.Add(button37.Text); break;
                                case 16: comboBox2.Items.Add(button38.Text); break;
                                case 17: comboBox2.Items.Add(button39.Text); break;
                                case 18: comboBox2.Items.Add(button40.Text); break;
                                case 19: comboBox2.Items.Add(button41.Text); break;
                                default: break;
                            }
                            break;
                        }
                    default:
                        break;


                }
            }
        }

        private void refreshMuBiaoPan()
        {
            comboBox3.Items.Clear();
            for (int i = 0; i < size; i++)
            {
                int tmp = (int)curStatus[i];
                switch (tmp)
                {
                    case 49:
                    case 50:
                    case 54:
                        {
                            switch (i)
                            {
                                case 0: comboBox3.Items.Add(button22.Text); break;
                                case 1: comboBox3.Items.Add(button23.Text); break;
                                case 2: comboBox3.Items.Add(button24.Text); break;
                                case 3: comboBox3.Items.Add(button25.Text); break;
                                case 4: comboBox3.Items.Add(button26.Text); break;
                                case 5: comboBox3.Items.Add(button27.Text); break;
                                case 6: comboBox3.Items.Add(button28.Text); break;
                                case 7: comboBox3.Items.Add(button29.Text); break;
                                case 8: comboBox3.Items.Add(button30.Text); break;
                                case 9: comboBox3.Items.Add(button31.Text); break;
                                case 10: comboBox3.Items.Add(button32.Text); break;
                                case 11: comboBox3.Items.Add(button33.Text); break;
                                case 12: comboBox3.Items.Add(button34.Text); break;
                                case 13: comboBox3.Items.Add(button35.Text); break;
                                case 14: comboBox3.Items.Add(button36.Text); break;
                                case 15: comboBox3.Items.Add(button37.Text); break;
                                case 16: comboBox3.Items.Add(button38.Text); break;
                                case 17: comboBox3.Items.Add(button39.Text); break;
                                case 18: comboBox3.Items.Add(button40.Text); break;
                                case 19: comboBox3.Items.Add(button41.Text); break;
                                default: break;
                            }
                            break;
                        }
                    default:
                        break;
                }
            }
        }

        private void confirm_Click(object sender, EventArgs e)
        {
            alcDevice.LHS_SuctionPlate = this.comboBox2.Text;
            alcDevice.LHS_TargetPlate = this.comboBox3.Text;
            alcDevice.LHS_Imbitition = Int32.Parse(this.textBox4.Text);
            alcDevice.LHS_LiquidRate = Decimal.ToInt32(this.numericUpDown1.Value);
            alcDevice.LHS_DischargeRate = Decimal.ToInt32(this.numericUpDown2.Value);
            alcDevice.LHS_LiquidPosition = Int32.Parse(this.textBox5.Text);
            alcDevice.LHS_DischargePosition = Int32.Parse(this.textBox6.Text);
            if (IsSocket)
            {
                String msg1 = ALCDeviceMessageCreator.createMuBiaoConfirmMsg(alcDevice.LHS_SuctionPlate, alcDevice.LHS_TargetPlate, alcDevice.LHS_Imbitition.ToString());
                alcDevice.SendMsg(msg1);
                String msg2 = ALCDeviceMessageCreator.createSuDuConfirmMsg(alcDevice.LHS_LiquidRate.ToString(), alcDevice.LHS_DischargeRate.ToString());
                alcDevice.SendMsg(msg2);
                String msg3 = ALCDeviceMessageCreator.createWeiZhiConfirmMsg(alcDevice.LHS_LiquidPosition.ToString(), alcDevice.LHS_DischargePosition.ToString());
                alcDevice.SendMsg(msg3);
                //Database mydb = new Database();
                //mydb.insertlpsplace(1, alcDevice.quYePan, alcDevice.muBiaoPan, alcDevice.xiYeLiang, alcDevice.xiYeSuDu, alcDevice.paiYeSuDu, alcDevice.xiYeWeiZhi, alcDevice.paiYeWeiZhi);
            }
        }


    }
}
