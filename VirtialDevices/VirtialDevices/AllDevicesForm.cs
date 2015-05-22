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
    public partial class VirtualDevicesForm : Form
    {
        public VirtualDevicesForm()
        {
            InitializeComponent();
            virtualDeviceManager = DeviceManager.getInstance();
            logTimer.Start();
        }

        private DeviceManager virtualDeviceManager;

        private object KeyObject = new object();

        private void createDeviceButton_Click(object sender, EventArgs e)
        {
            this.Enabled = false;
            CreateDeviceForm creatForm =  new CreateDeviceForm();
            creatForm.FatherForm = this;
            creatForm.Show();
        }

        private void VirtualDevicesForm_Load(object sender, EventArgs e)
        {
            Control.CheckForIllegalCrossThreadCalls = false;
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void logTimer_Tick(object sender, EventArgs e)
        {
            logTimer.Stop();

            List<DeviceMessage> messages = virtualDeviceManager.getAllMessages();
            ListViewItem item = null;
            logsListView.BeginUpdate();
            logsListView.Items.Clear();

            //foreach (DeviceMessage message in messages)
            //{
            //    item = new ListViewItem();
            //    String type = "接收";
            //    if (message.Type == DeviceMessage.DeviceMessageType.OUT) type = "发送";
            //    item.Text = type;
            //    item.SubItems.Add(message.Time);
            //    item.SubItems.Add(message.Device.Name);
            //    item.SubItems.Add(message.Msg);
            //    logsListView.Items.Add(item);
            //}
            for (int i = 0; i < messages.Count; i++)
            {
                DeviceMessage message = messages[i];
                item = new ListViewItem();
                String type = "接收";
                if (message.Type == DeviceMessage.DeviceMessageType.OUT) type = "发送";
                item.Text = type;
                item.SubItems.Add(message.Time);
                item.SubItems.Add(message.Device.Name);
                item.SubItems.Add(message.Msg);
                logsListView.Items.Add(item);
            }

            if (messages.Count > 0)
            {
                foreach (ColumnHeader header in logsListView.Columns)
                {
                    header.Width = -1;
                }
            }
            else
            {
                foreach (ColumnHeader header in logsListView.Columns)
                {
                    header.Width = -2;
                }
            }
            logsListView.EndUpdate();

            logTimer.Start();
        }

        public void refresh_Devices() 
        {
            List<BaseDevice> devices = virtualDeviceManager.getAllDevices();
            ListViewItem item = null;
            ListViewItem.ListViewSubItem subItem = null;
            deviceListView.BeginUpdate();
            deviceListView.Items.Clear();
            foreach (BaseDevice device in devices)
            {
                item = new ListViewItem();
                String deviceType = EnumHelper.getDeviceTypeString(device.CurrentDeviceType);
                String deviceState = EnumHelper.getDeviceStatusString(device.CurrentState);
                item.Text = deviceType;

                subItem = new ListViewItem.ListViewSubItem();
                subItem.Text = device.Name;
                item.SubItems.Add(subItem);

                subItem = new ListViewItem.ListViewSubItem();
                subItem.Text = deviceState;
                item.SubItems.Add(subItem);

                deviceListView.Items.Add(item);
            }


            if (devices.Count > 0)
            {
                foreach (ColumnHeader header in deviceListView.Columns)
                {
                    header.Width = -1;
                }
            }
            else
            {
                foreach (ColumnHeader header in logsListView.Columns)
                {
                    header.Width = -2;
                }
            }
            deviceListView.EndUpdate();
        }

        private void deviceListView_DoubleClick(object sender, EventArgs e)
        {

        }

        private void stopAllButton_Click(object sender, EventArgs e)
        {

        }

        private void deviceListView_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ListViewHitTestInfo info = deviceListView.HitTest(e.X, e.Y);
            if (info.Item != null)
            {
                int index = info.Item.Index;
                BaseDevice device = virtualDeviceManager.getDevice(index);
                DeviceForm form = new DeviceForm();
                form.FatherForm = this;
                form.DeviceInfo = device;
                form.Show();
            }
        }

        private void deviceListView_SelectedIndexChanged(object sender, EventArgs e)
        {

        }



    }
}
