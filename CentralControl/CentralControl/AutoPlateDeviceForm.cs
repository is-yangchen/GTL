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
    public partial class AutoPlateDeviceForm : Form
    {
        public ControlForm FatherForm;
        public bool IsSocket;
        public AutoPlateVirtualDevice PlateDevice;
        public AutoDispenTwincatDevice PlateTwincatDevice;

        public AutoPlateDeviceForm()
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
                if (false)
                {
                    msg = AutoDispenDeviceMessageCreator.createMDFSetNumAndVol(Num, Vol);
                }
                else
                {
                    msg = AutoPlateDeviceMessageCreator.createMPFSetNumAndVol(Num, Vol);
                }
                PlateDevice.SendMsg(msg);
                 * */
                PlateDevice.sendMPFSetNumAndVol(Num, Vol);
            }
            else 
            {
                PlateTwincatDevice.SendNumAndVol(int.Parse(Num), float.Parse(Vol));
            }
        }

        private void send_cmd(String cmd) 
        {
            PlateDevice.SendModBusMsg(ModbusMessage.MessageType.CMD, "Cmd", cmd);
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
                dianJi1TextBox.Text = PlateDevice.MPF_Current1.ToString();
                dianJi2TextBox.Text = PlateDevice.MPF_Current2.ToString();
                dianJi3TextBox.Text = PlateDevice.MPF_Current3.ToString();
                dianJi4TextBox.Text = PlateDevice.MPF_Current4.ToString();
                stateComboBox.SelectedIndex = PlateDevice.MPF_RunningError;
                
                if (PlateDevice.NeedRefreshMessages)
                {
                    yiJiaZhuListView.Items.Clear();
                    foreach (MPFDispenMessage xinXi in PlateDevice.getDispenMessages())
                    {
                        //if (DispenDevice.SubType == AutoDispenVirtualDevice.AutoDispenType.PeiYangMin)
                        if (true)
                        {
                            ListViewItem item = new ListViewItem();
                            item.Text = xinXi.Barcode;
                            item.SubItems.Add(xinXi.PlateNum);
                            yiJiaZhuListView.Items.Add(item);
                        }
                    }
                }
            }
            else 
            {
                dianJi1TextBox.Text = PlateTwincatDevice.MDF_Current1.ToString();
                dianJi2TextBox.Text = PlateTwincatDevice.MDF_Current2.ToString();
                dianJi3TextBox.Text = PlateTwincatDevice.MDF_Current3.ToString();
                stateComboBox.SelectedIndex = PlateTwincatDevice.YunXingChuCuoBiaoZhi;
                if (PlateTwincatDevice.NeedRefreshMessages)
                {
                    yiJiaZhuListView.Items.Clear();
                    foreach (FenZhuangXinXi msg in PlateTwincatDevice.getFenZhuangMessages())
                    {
                            ListViewItem item = new ListViewItem();
                            item.Text = msg.DuiMaHao;
                            item.SubItems.Add(msg.TiaoMaHao);
                            yiJiaZhuListView.Items.Add(item);

                    }
                }
            }
            refreshTimer.Start();
        }

        private void loadInfo()
        {
            if (IsSocket)
            {
                if (PlateDevice.IsVirt)
                {
                    isVirtualCheckBox.Checked = true;
                }
                deviceNameLabel.Text = PlateDevice.Name;
                deviceIPTextBox.Text = PlateDevice.IP;
                localIPTextBox.Text = PlateDevice.ControlIP;
                deviceNameTextBox.Text = PlateDevice.Name;
                identifyIDTextBox.Text = PlateDevice.IdentifyID;
                codeTextBox.Text = PlateDevice.Code;
                serialIDTextBox.Text = PlateDevice.SerialID;

                //if (DispenDevice.SubType == AutoDispenVirtualDevice.AutoDispenType.PeiYangMin)
                if (true)
                {
                    dianJi1TextBox.Text = PlateDevice.MPF_Current1.ToString();
                    dianJi2TextBox.Text = PlateDevice.MPF_Current2.ToString();
                    dianJi3TextBox.Text = PlateDevice.MPF_Current3.ToString();
                    dianJi4TextBox.Text = PlateDevice.MPF_Current4.ToString();
                    stateComboBox.SelectedIndex = PlateDevice.MPF_RunningError;
                }

                foreach (MPFDispenMessage msg in PlateDevice.getDispenMessages())
                {
                    //if (DispenDevice.SubType == AutoDispenVirtualDevice.AutoDispenType.PeiYangMin)
                    if (true)
                    {
                        ListViewItem item = new ListViewItem();
                        item.Text = msg.Barcode;
                        item.SubItems.Add(msg.PlateNum);
                        yiJiaZhuListView.Items.Add(item);
                    }
                }
            }
            else 
            {
                dianJi1TextBox.Text = PlateTwincatDevice.MDF_Current1.ToString();
                dianJi2TextBox.Text = PlateTwincatDevice.MDF_Current2.ToString();
                dianJi3TextBox.Text = PlateTwincatDevice.MDF_Current3.ToString();
                stateComboBox.SelectedIndex = PlateTwincatDevice.YunXingChuCuoBiaoZhi;
                foreach (FenZhuangXinXi xinXi in PlateTwincatDevice.getFenZhuangMessages())
                {
                    //if (PlateTwincatDevice.SubType == AutoDispenTwincatDevice.AutoDispenType.PeiYangMin)
                    if (false)
                    {
                        /*
                        ListViewItem item = new ListViewItem();
                        item.Text = xinXi.DuiMaHao;
                        item.SubItems.Add(xinXi.PeiYangMinHao);
                        item.SubItems.Add(xinXi.TiaoMaHao);
                        yiJiaZhuListView.Items.Add(item);
                         * */
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
                if (false)
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
                if (PlateTwincatDevice.SubType == AutoDispenTwincatDevice.AutoDispenType.PeiYangMin)
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
