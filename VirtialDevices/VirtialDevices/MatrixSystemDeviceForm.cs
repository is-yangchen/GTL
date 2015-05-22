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
    public partial class MatrixSystemDeviceForm : Form
    {
        public DeviceForm FatherForm;
        public bool IsSocket;
        public MatrixSystemDevice DeviceInfo;
        //private object KeyObject = new object(); 

        public MatrixSystemDeviceForm()
        {
            InitializeComponent();
        }

        private void MatrixSystemDeviceForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            FatherForm.Enabled = true;
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            DeviceInfo.startTimers();
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            this.runTypeTextBox.Text = DeviceInfo.HAC_Sys_Mode.ToString();
            this.runCommandTextBox.Text = DeviceInfo.HAC_Sys_Command.ToString();

            this.zhanKongBiTextBox.Text = DeviceInfo.HAC_Light_pwm.ToString();
            this.guangQiangTextBox.Text = DeviceInfo.HAC_Light_allighText.ToString();

            this.wenDuSheDingTextBox.Text = DeviceInfo.HAC_TH_tempset.ToString();
            this.chaoWenTiaoZhengTextBox6.Text = DeviceInfo.HAC_TH_htempchaval.ToString();
            this.diWenTiaoZhengTextBox.Text = DeviceInfo.HAC_TH_ltempchaval.ToString();
            this.xiTongZhuangTaiTiaoZhengTextBox.Text = DeviceInfo.HAC_TH_syso_change.ToString();
            this.chaoWenBaoJingTextBox.Text = DeviceInfo.HAC_TH_htempalarmval.ToString();
            this.diWenBaoJingTextBox.Text = DeviceInfo.HAC_TH_ltempalarmval.ToString();
            this.yaSuoJiGongZuoMoShiTextBox.Text = DeviceInfo.HAC_TH_compressormode.ToString();
            this.yaSuoJiGongZuoZhuangTaiTextBox.Text = DeviceInfo.HAC_TH_compressorsituation.ToString();
            this.chuShuangJianGeTextBox.Text = DeviceInfo.HAC_TH_def_interval.ToString();
            this.chuShuangShiChangTextBox1.Text = DeviceInfo.HAC_TH_def_span.ToString();
            this.jiaReGuanTextBox.Text = DeviceInfo.HAC_TH_hottube.ToString();
            this.wenDuKongZhiMoShiTextBox.Text = DeviceInfo.HAC_TH_humi_con_mod.ToString();
            this.wenDuKongZhiZhuangTaitextBox.Text = DeviceInfo.HAC_TH_humi_con_sit.ToString();
            this.shiDuSheDingTextBox.Text = DeviceInfo.HAC_TH_hum_set.ToString();
            this.shiDuBaoJingTextBox.Text = DeviceInfo.HAC_TH_hum_alarm_val.ToString();
            this.jiaShiYuZhiTextBox.Text = DeviceInfo.HAC_TH_add_hum.ToString();
            this.chuShiYuZhiTextBox.Text = DeviceInfo.HAC_TH_remo_hum.ToString();

            this.yaoChuangTextBox.Text = DeviceInfo.HAC_Motor_text_speed.ToString();
            this.maDaTextBox.Text = DeviceInfo.HAC_Motor_slope.ToString();
            this.dianJiTextBox.Text = DeviceInfo.HAC_Motor_elecspeed.ToString();

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
                    lvi.SubItems.Add(ra.Next(0,13).ToString());
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

        private void listView2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

    }
}
