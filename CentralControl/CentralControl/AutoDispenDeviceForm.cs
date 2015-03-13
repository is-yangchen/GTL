using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CentralControl
{
    public partial class AutoDispenDeviceForm : Form
    {
        public DeviceInfoForm FatherForm;
        public bool IsSocket;
        public AutoDispenVirtualDevice DispenDevice;
        public AutoDispenTwincatDevice DispenTwincatDevice;

        public AutoDispenDeviceForm()
        {
            InitializeComponent();
            stateComboBox.Items.Add("正常");
            stateComboBox.Items.Add("出错");
            stateComboBox.SelectedIndex = 0;
        }

        private void sendButton_Click(object sender, EventArgs e)
        {
            String Num = "", Vol = "";
            Num = textBox1.Text;
            Vol = textBox2.Text;
            if (IsSocket)
            {
                String msg = AutoDispenDeviceMessageCreator.createSetNumAndVol(Num, Vol);
                DispenDevice.SendMsg(msg);
            }
            else 
            {
                DispenTwincatDevice.SendNumAndVol(int.Parse(Num),float.Parse(Vol));
            }
        }

        private void send_cmd(String s) 
        {
            String msg = AutoDispenDeviceMessageCreator.createCmd(s);
            if (IsSocket)
                DispenDevice.SendMsg(msg);
            else DispenTwincatDevice.SendMsg(s);
        }

        private void resetButton_Click(object sender, EventArgs e)
        {
            send_cmd("Reset");
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            send_cmd("Start");
        }

        private void stopButton_Click(object sender, EventArgs e)
        {
            send_cmd("Stop");
        }

        private void autoButton_Click(object sender, EventArgs e)
        {
            send_cmd("Auto");
        }

        private void refreshTimer_Tick(object sender, EventArgs e)
        {
            refreshTimer.Stop();
            if (IsSocket)
            {
                dianJi1TextBox.Text = DispenDevice.DianLiu1.ToString();
                dianJi2TextBox.Text = DispenDevice.DianLiu2.ToString();
                dianJi3TextBox.Text = DispenDevice.Dianliu3.ToString();
                dianJi4TextBox.Text = DispenDevice.Dianliu4.ToString();

                stateComboBox.SelectedIndex = DispenDevice.YunXingChuCuoBiaoZhi;
                if (DispenDevice.NeedRefreshMessages)
                {
                    yiJiaZhuListView.Items.Clear();
                    foreach (FenZhuangXinXi xinXi in DispenDevice.getFenZhuangMessages())
                    {
                        if (DispenDevice.SubType == AutoDispenVirtualDevice.AutoDispenType.PeiYangMin)
                        {
                            ListViewItem item = new ListViewItem();
                            item.Text = xinXi.DuiMaHao;
                            item.SubItems.Add(xinXi.PeiYangMinHao);
                            item.SubItems.Add(xinXi.TiaoMaHao);
                            yiJiaZhuListView.Items.Add(item);
                        }
                        else
                        {
                            ListViewItem item = new ListViewItem();
                            item.Text = xinXi.DuiMaHao;
                            item.SubItems.Add(xinXi.TiaoMaHao);
                            yiJiaZhuListView.Items.Add(item);
                        }

                    }
                }
            }
            else 
            {
                dianJi1TextBox.Text = DispenTwincatDevice.DianLiu1.ToString();
                dianJi2TextBox.Text = DispenTwincatDevice.DianLiu2.ToString();
                dianJi3TextBox.Text = DispenTwincatDevice.Dianliu3.ToString();
                stateComboBox.SelectedIndex = DispenTwincatDevice.YunXingChuCuoBiaoZhi;
                if (DispenTwincatDevice.NeedRefreshMessages)
                {
                    yiJiaZhuListView.Items.Clear();
                    foreach (FenZhuangXinXi xinXi in DispenTwincatDevice.getFenZhuangMessages())
                    {
                        if (DispenTwincatDevice.SubType == AutoDispenTwincatDevice.AutoDispenType.PeiYangMin)
                        {
                            ListViewItem item = new ListViewItem();
                            item.Text = xinXi.DuiMaHao;
                            item.SubItems.Add(xinXi.PeiYangMinHao);
                            item.SubItems.Add(xinXi.TiaoMaHao);
                            yiJiaZhuListView.Items.Add(item);
                        }
                        else
                        {
                            ListViewItem item = new ListViewItem();
                            item.Text = xinXi.DuiMaHao;
                            item.SubItems.Add(xinXi.TiaoMaHao);
                            yiJiaZhuListView.Items.Add(item);
                        }

                    }
                }
            }
            refreshTimer.Start();
        }

        private void loadInfo()
        {
            if (IsSocket)
            {
                dianJi1TextBox.Text = DispenDevice.DianLiu1.ToString();
                dianJi2TextBox.Text = DispenDevice.DianLiu2.ToString();
                dianJi3TextBox.Text = DispenDevice.Dianliu3.ToString();
                stateComboBox.SelectedIndex = DispenDevice.YunXingChuCuoBiaoZhi;
                foreach (FenZhuangXinXi xinXi in DispenDevice.getFenZhuangMessages())
                {
                    if (DispenDevice.SubType == AutoDispenVirtualDevice.AutoDispenType.PeiYangMin)
                    {
                        ListViewItem item = new ListViewItem();
                        item.Text = xinXi.DuiMaHao;
                        item.SubItems.Add(xinXi.PeiYangMinHao);
                        item.SubItems.Add(xinXi.TiaoMaHao);
                        yiJiaZhuListView.Items.Add(item);
                    }
                    else
                    {
                        ListViewItem item = new ListViewItem();
                        item.Text = xinXi.DuiMaHao;
                        item.SubItems.Add(xinXi.TiaoMaHao);
                        yiJiaZhuListView.Items.Add(item);
                    }

                }
            }
            else 
            {
                dianJi1TextBox.Text = DispenTwincatDevice.DianLiu1.ToString();
                dianJi2TextBox.Text = DispenTwincatDevice.DianLiu2.ToString();
                dianJi3TextBox.Text = DispenTwincatDevice.Dianliu3.ToString();
                stateComboBox.SelectedIndex = DispenTwincatDevice.YunXingChuCuoBiaoZhi;
                foreach (FenZhuangXinXi xinXi in DispenTwincatDevice.getFenZhuangMessages())
                {
                    if (DispenTwincatDevice.SubType == AutoDispenTwincatDevice.AutoDispenType.PeiYangMin)
                    {
                        ListViewItem item = new ListViewItem();
                        item.Text = xinXi.DuiMaHao;
                        item.SubItems.Add(xinXi.PeiYangMinHao);
                        item.SubItems.Add(xinXi.TiaoMaHao);
                        yiJiaZhuListView.Items.Add(item);
                    }
                    else
                    {
                        ListViewItem item = new ListViewItem();
                        item.Text = xinXi.DuiMaHao;
                        item.SubItems.Add(xinXi.TiaoMaHao);
                        yiJiaZhuListView.Items.Add(item);
                    }

                }
            }
        }

        private void AutoDispenDeviceForm_Load(object sender, EventArgs e)
        {
            if (IsSocket)
            {
                if (DispenDevice.SubType == AutoDispenVirtualDevice.AutoDispenType.PeiYangMin)
                {
                    yiJiaZhuLabel.Text = "已加注培养皿";
                    ColumnHeader header1 = new ColumnHeader();
                    header1.Text = "堆码号";
                    yiJiaZhuListView.Columns.Add(header1);
                    ColumnHeader header2 = new ColumnHeader();
                    header2.Text = "培养皿号";
                    yiJiaZhuListView.Columns.Add(header2);
                    ColumnHeader header3 = new ColumnHeader();
                    header3.Text = "条码号";
                    yiJiaZhuListView.Columns.Add(header3);

                    volumeLabel.Text = "每摞培养皿数量";
                    capacityLabel.Text = "单皿分装量";
                }
                else
                {
                    yiJiaZhuLabel.Text = "已加注孔板";
                    ColumnHeader header1 = new ColumnHeader();
                    header1.Text = "孔板号";
                    yiJiaZhuListView.Columns.Add(header1);
                    ColumnHeader header2 = new ColumnHeader();
                    header2.Text = "条码号";
                    yiJiaZhuListView.Columns.Add(header2);

                    volumeLabel.Text = "堆栈孔板数";
                    capacityLabel.Text = "单孔分装量";
                }
            }
            else 
            {
                if (DispenTwincatDevice.SubType == AutoDispenTwincatDevice.AutoDispenType.PeiYangMin)
                {
                    yiJiaZhuLabel.Text = "已加注培养皿";
                    ColumnHeader header1 = new ColumnHeader();
                    header1.Text = "堆码号";
                    yiJiaZhuListView.Columns.Add(header1);
                    ColumnHeader header2 = new ColumnHeader();
                    header2.Text = "培养皿号";
                    yiJiaZhuListView.Columns.Add(header2);
                    ColumnHeader header3 = new ColumnHeader();
                    header3.Text = "条码号";
                    yiJiaZhuListView.Columns.Add(header3);

                    volumeLabel.Text = "每摞培养皿数量";
                    capacityLabel.Text = "单皿分装量";
                }
                else
                {
                    yiJiaZhuLabel.Text = "已加注孔板";
                    ColumnHeader header1 = new ColumnHeader();
                    header1.Text = "孔板号";
                    yiJiaZhuListView.Columns.Add(header1);
                    ColumnHeader header2 = new ColumnHeader();
                    header2.Text = "条码号";
                    yiJiaZhuListView.Columns.Add(header2);

                    volumeLabel.Text = "堆栈孔板数";
                    capacityLabel.Text = "单孔分装量";
                }
            }
            loadInfo();
            refreshTimer.Start();
        }
    }
}
