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
            this.runTypeTextBox.Text = DeviceInfo.Sys_Mode.ToString();
            this.runCommandTextBox.Text = DeviceInfo.Sys_Command.ToString();

            this.zhanKongBiTextBox.Text = DeviceInfo.Light_pwm.ToString();
            this.guangQiangTextBox.Text = DeviceInfo.Light_allighText.ToString();

            this.wenDuSheDingTextBox.Text = DeviceInfo.TH_tempset.ToString();
            this.chaoWenTiaoZhengTextBox6.Text = DeviceInfo.TH_htempchaval.ToString();
            this.diWenTiaoZhengTextBox.Text = DeviceInfo.TH_ltempchaval.ToString();
            this.xiTongZhuangTaiTiaoZhengTextBox.Text = DeviceInfo.TH_syso_change.ToString();
            this.chaoWenBaoJingTextBox.Text = DeviceInfo.TH_htempalarmval.ToString();
            this.diWenBaoJingTextBox.Text = DeviceInfo.TH_ltempalarmval.ToString();
            this.yaSuoJiGongZuoMoShiTextBox.Text = DeviceInfo.TH_compressormode.ToString();
            this.yaSuoJiGongZuoZhuangTaiTextBox.Text = DeviceInfo.TH_compressorsituation.ToString();
            this.chuShuangJianGeTextBox.Text = DeviceInfo.TH_def_interval.ToString();
            this.chuShuangShiChangTextBox1.Text = DeviceInfo.TH_def_span.ToString();
            this.jiaReGuanTextBox.Text = DeviceInfo.TH_hottube.ToString();
            this.wenDuKongZhiMoShiTextBox.Text = DeviceInfo.TH_humi_con_mod.ToString();
            this.wenDuKongZhiZhuangTaitextBox.Text = DeviceInfo.TH_humi_con_sit.ToString();
            this.shiDuSheDingTextBox.Text = DeviceInfo.TH_hum_set.ToString();
            this.shiDuBaoJingTextBox.Text = DeviceInfo.TH_hum_alarm_val.ToString();
            this.jiaShiYuZhiTextBox.Text = DeviceInfo.TH_add_hum.ToString();
            this.chuShiYuZhiTextBox.Text = DeviceInfo.TH_remo_hum.ToString();

            this.yaoChuangTextBox.Text = DeviceInfo.Motor_text_speed.ToString();
            this.maDaTextBox.Text = DeviceInfo.Motor_slope.ToString();
            this.dianJiTextBox.Text = DeviceInfo.Motor_elecspeed.ToString();

            this.sheBeiXinXiTextBox.Text = DeviceInfo.Sys_DeviceInfo.ToString();
            this.zuoYeZhuangTaiTextBox.Text = DeviceInfo.Sys_Status.ToString();
            this.yiQiZhuangTaiTextBox.Text = DeviceInfo.Sys_Batch_Info.ToString();

            this.wenDu1TextBox.Text = DeviceInfo.TH_temperature1.ToString();
            this.wenDu2TextBox.Text = DeviceInfo.TH_temperature2.ToString();
            this.wenDu3TextBox.Text = DeviceInfo.TH_temperature3.ToString();
            this.shiDu1TextBox.Text = DeviceInfo.TH_humidity1.ToString();
            this.shiDu2TextBox.Text = DeviceInfo.TH_humidity2.ToString();
            this.wenShiZhuangTaiTextBox.Text = DeviceInfo.TH_Status.ToString();

            this.dianJiZhuangTaiTextBox.Text = DeviceInfo.Motor_Status.ToString();
            this.dianJiZhuanSuTextBox.Text = DeviceInfo.Motor_elecspeed.ToString();
            this.dianJiGongLvTextBox.Text = DeviceInfo.Motor_Power.ToString();
            this.yaoChuangZhuanSuTextBox.Text = DeviceInfo.Motor_text_speed.ToString();

            this.yiRuTiaoMaTextBox.Text = DeviceInfo.Add_Num.ToString();
            this.yiChuTiaoMaTextBox.Text = DeviceInfo.Rem_Num.ToString();

            dataListView.BeginUpdate();
            if (DeviceInfo.OD_rowl != null)
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
