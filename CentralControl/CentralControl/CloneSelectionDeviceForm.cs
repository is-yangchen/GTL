using System;
using System.IO;
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
    public partial class CloneSelectionDeviceForm : Form
    {
        public ControlForm FatherForm;
        public bool IsSocket;
        public CloneSelectionVirtualDevice DeviceInfo;

        private void setButton_Click(object sender, EventArgs e)
        {
            String Lower = "", Upper = "";
            Lower = this.biZhiLowerTextBox.Text;
            Upper = this.biZhiUpperTextBox.Text;
            if (IsSocket)
            {
                String msg = CloneSelectionDeviceMessageCreator.createSetLowAndUpp(Lower, Upper);
                DeviceInfo.SendMsg(msg);
            }
            else
            {
          
            }

            DeviceInfo.setZhouChangMianJiBi_Max(Upper);
            DeviceInfo.setZhouChangMianJiBi_Min(Lower);
        }

        private void setMianJiButton_Click(object sender, EventArgs e)
        {
            String Lower = "", Upper = "";
            Lower = this.areaLowerTextBox.Text;
            Upper = this.areaUpperTextBox.Text;
            if (IsSocket)
            {
                String msg = CloneSelectionDeviceMessageCreator.createSetMianJiLowAndUpp(Lower, Upper);
                DeviceInfo.SendMsg(msg);
            }
            else
            {

            }
        }


        private void setMieJunButton_Click(object sender, EventArgs e)
        {
            String arg1 = "", arg2 = "", arg3 = "", arg4 = "", arg5 = "";
            arg1 = this.jiaReTextBox.Text;
            arg2 = this.qingXiCiShuTextBox.Text;
            arg3 = this.lengQueTextBox.Text;
            arg4 = this.qingXiShiJianTextBox.Text;
            arg5 = this.chouQiTextBox.Text;
            if (IsSocket)
            {
                String msg = CloneSelectionDeviceMessageCreator.createSetMieJun(arg1, arg2, arg3, arg4, arg5);
                DeviceInfo.SendMsg(msg);
            }
            else
            {

            }
        }

        private void PicButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofdPic = new OpenFileDialog();
            ofdPic.Filter = "JPG(*.JPG;*.JPEG);gif文件(*.GIF)|*.jpg;*.jpeg;*.gif";
            ofdPic.FilterIndex = 1;
            ofdPic.RestoreDirectory = true;
            ofdPic.FileName = "";
            if (ofdPic.ShowDialog() == DialogResult.OK)
            {
                string sPicPaht = ofdPic.FileName.ToString();
                FileInfo fiPicInfo = new FileInfo(sPicPaht);
                long lPicLong = fiPicInfo.Length / 1024;
                string sPicName = fiPicInfo.Name;
                string sPicDirectory = fiPicInfo.Directory.ToString();
                string sPicDirectoryPath = fiPicInfo.DirectoryName;
                Bitmap bmPic = new Bitmap(sPicPaht);
                if (lPicLong > 400)
                {
                    MessageBox.Show("此文件大小" + lPicLong + "K；已超最大限制！");
                }
                else
                {
                    Point ptLoction = new Point(bmPic.Size);
                    if (ptLoction.X > this.junLuoPictureBox.Size.Width || ptLoction.Y > junLuoPictureBox.Size.Height)
                    {
                        junLuoPictureBox.SizeMode = PictureBoxSizeMode.Zoom;
                    }
                    else
                    {
                        junLuoPictureBox.SizeMode = PictureBoxSizeMode.CenterImage;
                    }
                }
                junLuoPictureBox.LoadAsync(sPicPaht);
                this.shiBieHouPictureBox.LoadAsync(sPicPaht);
            }
        }

        public CloneSelectionDeviceForm()
        {
            InitializeComponent();
        }

        private void CloneSelectionDeviceForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            FatherForm.Enabled = true;
        }
    }
}
