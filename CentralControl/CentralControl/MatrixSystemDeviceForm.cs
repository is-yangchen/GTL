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
    public partial class MatrixSystemDeviceForm : Form
    {
        public ControlForm FatherForm;
        public bool IsSocket;
        public MatrixSystemVirtualDevice DeviceInfo;

        public MatrixSystemDeviceForm()
        {
            InitializeComponent();
        }

        private void sendButton_Click(object sender, EventArgs e)
        {
            switch (this.selectSetTypeComboBox.SelectedItem.ToString())
            {
                case "仪器系统设定":
                    String Mode = this.runTypeTextBox.Text;
                    String Command = this.runCommandTextBox.Text;
                    if (IsSocket)
                    {
                        String msg = MatrixSystemVirtualDeviceMessageCreator.createSetSystem(Mode, Command);
                        DeviceInfo.SendMsg(msg);
                    }
                    break;

                case "匀光设定":
                    String pwm = this.zhanKongBiTextBox.Text;
                    String allightText = this.guangQiangTextBox.Text;
                    if (IsSocket)
                    {
                        String msg = MatrixSystemVirtualDeviceMessageCreator.createSetLight(pwm, allightText);
                        DeviceInfo.SendMsg(msg);
                    } 
                    break;

                case "温湿度设定":
                    String tempset = this.wenDuSheDingTextBox.Text;
                    String htempchaval = this.chaoWenTiaoZhengTextBox6.Text;
                    String ltempchaval = this.diWenTiaoZhengTextBox.Text;
                    String syso_change = this.xiTongZhuangTaiTiaoZhengTextBox.Text;
                    String htempalarmval = this.chaoWenBaoJingTextBox.Text;
                    String ltempalarmval = this.diWenBaoJingTextBox.Text;
                    String compressormode = this.yaSuoJiGongZuoMoShiTextBox.Text;
                    String compressorsituation = this.yaSuoJiGongZuoZhuangTaiTextBox.Text;
                    String def_interval = this.chuShuangJianGeTextBox.Text;
                    String def_span = this.chuShuangShiChangTextBox1.Text;
                    String hottube = this.jiaReGuanTextBox.Text;
                    String humi_con_mod = this.wenDuKongZhiMoShiTextBox.Text;
                    String humi_con_sit = this.wenDuKongZhiZhuangTaitextBox.Text;
                    String hum_set = this.shiDuSheDingTextBox.Text;
                    String hum_alarm_val = this.shiDuBaoJingTextBox.Text;
                    String add_hum = this.jiaShiYuZhiTextBox.Text;
                    String remo_hum = this.chuShiYuZhiTextBox.Text;
                    if (IsSocket)
                    {
                        String msg = MatrixSystemVirtualDeviceMessageCreator.createSetTH_1( tempset,
                                                                                            htempchaval,
                                                                                            ltempchaval,
                                                                                            syso_change,
                                                                                            htempalarmval,
                                                                                            ltempalarmval,
                                                                                            compressormode,
                                                                                            compressorsituation );
                        DeviceInfo.SendMsg(msg);

                        msg = MatrixSystemVirtualDeviceMessageCreator.createSetTH_2(    def_interval,
                                                                                        def_span,
                                                                                        hottube,
                                                                                        humi_con_mod,
                                                                                        humi_con_sit,
                                                                                        hum_set,
                                                                                        hum_alarm_val,
                                                                                        add_hum,
                                                                                        remo_hum);
                        DeviceInfo.SendMsg(msg);
                    } 
                    break;

                case "电机设定":
                    String slope = this.maDaTextBox.Text;
                    String elecspeed = this.dianJiTextBox.Text;
                    String text_speed = this.yaoChuangTextBox.Text;
                    if (IsSocket)
                    {
                        String msg = MatrixSystemVirtualDeviceMessageCreator.createSetMotor(text_speed, elecspeed, slope);
                        DeviceInfo.SendMsg(msg);
                    } 
                    break;

                default:
                    break;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.sheBeiXinXiTextBox.Text = DeviceInfo.HAC_Sys_DeviceInfo.ToString();
            this.zuoYeZhuangTaiTextBox.Text = DeviceInfo.HAC_Sys_Status.ToString();
            this.yiQiZhuangTaiTextBox.Text = DeviceInfo.HAC_Sys_Batch_Info.ToString();

            this.wenDu1TextBox.Text = DeviceInfo.HAC_TH_temperature1.ToString();
            this.wenDu2TextBox.Text = DeviceInfo.HAC_TH_temperature2.ToString();
            this.wenDu3TextBox.Text = DeviceInfo.HAC_TH_temperature3.ToString();
            this.shiDu1TextBox.Text = DeviceInfo.HAC_TH_humidity1.ToString();
            this.shiDu2TextBox.Text = DeviceInfo.HAC_TH_humidity2.ToString();
            this.wenShiZhuangTaiTextBox.Text = DeviceInfo.HAC_TH_Status.ToString();

            this.dianJiZhuangTaiTextBox.Text = DeviceInfo.HAC_Motor_Status.ToString();
            this.dianJiZhuanSuTextBox.Text = DeviceInfo.HAC_Motor_elecspeed.ToString();
            this.dianJiGongLvTextBox.Text = DeviceInfo.HAC_Motor_Power.ToString();
            this.yaoChuangZhuanSuTextBox.Text = DeviceInfo.HAC_Motor_text_speed.ToString();

            this.yiRuTiaoMaTextBox.Text = DeviceInfo.HAC_InBarCode.ToString();
            this.yiChuTiaoMaTextBox.Text = DeviceInfo.HAC_OutBarCode.ToString();

            dataListView.BeginUpdate();
            if (DeviceInfo.HAC_OD_rowl != null)
            {
                for (int i = 0; i < 8; i++)
                {
                    ListViewItem lvi = new ListViewItem();
                    for (int j = 0; j < 12; j++)
                    {
                        lvi.SubItems.Add(DeviceInfo.readOD_rowl(i, j).ToString());
                    }

                    dataListView.Items[i] = lvi;
                }
            }
            dataListView.EndUpdate();

            Random ra = new Random();

            listView1.BeginUpdate();
            for (int i = 0; i < 4; i++)
            {
                ListViewItem lvi = new ListViewItem();
                for (int j = 0; j < 12; j++)
                {
                    lvi.SubItems.Add(ra.Next(0, 13).ToString());
                }

                listView1.Items[i] = lvi;
            }
            listView1.EndUpdate();

            listView2.BeginUpdate();
            for (int i = 0; i < 8; i++)
            {
                ListViewItem lvi = new ListViewItem();
                for (int j = 0; j < 12; j++)
                {
                    lvi.SubItems.Add(ra.Next(0, 2).ToString());
                }

                listView2.Items[i] = lvi;
            }
            listView2.EndUpdate();

        }
    }
}
