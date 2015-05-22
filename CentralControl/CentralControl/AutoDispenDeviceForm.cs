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
    public partial class AutoDispenDeviceForm : Form
    {
        public ControlForm FatherForm;
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
            String Num = "", Vol = "", msg = "";
            Num = textBox1.Text;
            Vol = textBox2.Text;
            if (IsSocket)
            {
                //if (DispenDevice.SubType == AutoDispenVirtualDevice.AutoDispenType.PeiYangMin)
                /*
                if (true)
                {
                    msg = AutoDispenDeviceMessageCreator.createMDFSetNumAndVol(Num, Vol);
                }
                else
                {
                    //msg = AutoDispenDeviceMessageCreator.createMPFSetNumAndVol(Num, Vol);
                }
                DispenDevice.SendMsg(msg);
                 * */
                DispenDevice.sendMDFSetNumAndVol(Num,Vol);
            }
            else 
            {
                DispenTwincatDevice.SendNumAndVol(int.Parse(Num),float.Parse(Vol));
            }
        }

        private void send_cmd(String cmd) 
        {
            if (IsSocket)
                DispenDevice.SendModBusMsg(ModbusMessage.MessageType.CMD, "Cmd", cmd);
            else 
                DispenTwincatDevice.SendMsg(cmd);
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
                //if (DispenDevice.SubType == AutoDispenVirtualDevice.AutoDispenType.PeiYangMin)
                if (true)
                {
                    dianJi1TextBox.Text = DispenDevice.MDF_Current1.ToString();
                    dianJi2TextBox.Text = DispenDevice.MDF_Current2.ToString();
                    dianJi3TextBox.Text = DispenDevice.MDF_Current3.ToString();
                    dianJi4TextBox.Text = DispenDevice.MDF_Current4.ToString();
                    stateComboBox.SelectedIndex = DispenDevice.MDF_RunningError;
                }
                else
                {
                    /*
                    dianJi1TextBox.Text = DispenDevice.MPF_Current1.ToString();
                    dianJi2TextBox.Text = DispenDevice.MPF_Current2.ToString();
                    dianJi3TextBox.Text = DispenDevice.MPF_Current3.ToString();
                    dianJi4TextBox.Text = DispenDevice.MPF_Current4.ToString();
                    stateComboBox.SelectedIndex = DispenDevice.MPF_RunningError;
                     * */
                }

                if (DispenDevice.NeedRefreshMessages)
                {
                    yiJiaZhuListView.Items.Clear();
                    foreach (MDFDispenMessage xinXi in DispenDevice.getDispenMessages())
                    {
                        //if (DispenDevice.SubType == AutoDispenVirtualDevice.AutoDispenType.PeiYangMin)
                        if (true)
                        {
                            ListViewItem item = new ListViewItem();
                            item.Text = xinXi.Stackcode;
                            item.SubItems.Add(xinXi.Petricode);
                            item.SubItems.Add(xinXi.Barcode);
                            yiJiaZhuListView.Items.Add(item);
                        }
                        else
                        {
                            /*
                            ListViewItem item = new ListViewItem();
                            item.Text = xinXi.DuiMaHao;
                            item.SubItems.Add(xinXi.TiaoMaHao);
                            yiJiaZhuListView.Items.Add(item);
                             */ 
                        }

                    }
                }
            }
            else 
            {
                dianJi1TextBox.Text = DispenTwincatDevice.MDF_Current1.ToString();
                dianJi2TextBox.Text = DispenTwincatDevice.MDF_Current2.ToString();
                dianJi3TextBox.Text = DispenTwincatDevice.MDF_Current3.ToString();
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
                if (DispenDevice.IsVirt)
                {
                    isVirtualCheckBox.Checked = true;
                }
                deviceNameLabel.Text = DispenDevice.Name;
                deviceIPTextBox.Text = DispenDevice.IP;
                localIPTextBox.Text = DispenDevice.ControlIP;
                deviceNameTextBox.Text = DispenDevice.Name;
                identifyIDTextBox.Text = DispenDevice.IdentifyID;
                codeTextBox.Text = DispenDevice.Code;
                serialIDTextBox.Text = DispenDevice.SerialID;

                //if (DispenDevice.SubType == AutoDispenVirtualDevice.AutoDispenType.PeiYangMin)
                if (true)
                {
                    dianJi1TextBox.Text = DispenDevice.MDF_Current1.ToString();
                    dianJi2TextBox.Text = DispenDevice.MDF_Current2.ToString();
                    dianJi3TextBox.Text = DispenDevice.MDF_Current3.ToString();
                    dianJi4TextBox.Text = DispenDevice.MDF_Current4.ToString();
                    stateComboBox.SelectedIndex = DispenDevice.MDF_RunningError;
                }
                else
                {
                    /*
                    dianJi1TextBox.Text = DispenDevice.MPF_Current1.ToString();
                    dianJi2TextBox.Text = DispenDevice.MPF_Current2.ToString();
                    dianJi3TextBox.Text = DispenDevice.MPF_Current3.ToString();
                    dianJi4TextBox.Text = DispenDevice.MPF_Current4.ToString();
                    stateComboBox.SelectedIndex = DispenDevice.MPF_RunningError;
                     * */
                }

                foreach (MDFDispenMessage xinXi in DispenDevice.getDispenMessages())
                {
                    //if (DispenDevice.SubType == AutoDispenVirtualDevice.AutoDispenType.PeiYangMin)
                    if (true)
                    {
                        ListViewItem item = new ListViewItem();
                        item.Text = xinXi.Stackcode;
                        item.SubItems.Add(xinXi.Petricode);
                        item.SubItems.Add(xinXi.Barcode);
                        yiJiaZhuListView.Items.Add(item);
                    }
                    else
                    {
                        /*
                        ListViewItem item = new ListViewItem();
                        item.Text = xinXi.DuiMaHao;
                        item.SubItems.Add(xinXi.TiaoMaHao);
                        yiJiaZhuListView.Items.Add(item);
                         */ 
                    }

                }
            }
            else 
            {
                dianJi1TextBox.Text = DispenTwincatDevice.MDF_Current1.ToString();
                dianJi2TextBox.Text = DispenTwincatDevice.MDF_Current2.ToString();
                dianJi3TextBox.Text = DispenTwincatDevice.MDF_Current3.ToString();
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
                //if (DispenDevice.SubType == AutoDispenVirtualDevice.AutoDispenType.PeiYangMin)
                if (true)
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

        private void basicPanel_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
