using System;
using System.IO;
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
    public partial class CloneSelectionDeviceForm : Form
    {

        public DeviceForm FatherForm;
        public bool IsSocket;
        public CloneSelectionDevice DeviceInfo;

        public CloneSelectionDeviceForm()
        {
            InitializeComponent();
        }

        private void CloneSelectionDeviceForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            FatherForm.Enabled = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //if (IsSocket)
            {
                //*
                this.jiaReTextBox.Text = DeviceInfo.getJiaReShiJian().ToString();
                this.qingXiShiJianTextBox.Text = DeviceInfo.getQingXiShiJian().ToString();
                this.qingXiCiShuTextBox.Text = DeviceInfo.getQingXiCiShu().ToString();
                this.lengQueTextBox.Text = DeviceInfo.getLengQueShiJian().ToString();
                this.chouQiTextBox.Text = DeviceInfo.getChouQiShiJian().ToString();
                this.biZhiUpperTextBox.Text = DeviceInfo.getZhouChangMianJiBi_Max().ToString();
                this.biZhiLowerTextBox.Text = DeviceInfo.getZhouChangMianJiBi_Min().ToString();
                this.areaUpperTextBox.Text = DeviceInfo.getMianJi_Max().ToString();
                this.areaLowerTextBox.Text = DeviceInfo.getMianJi_Min().ToString();
                this.changJingUpperTextBox.Text = DeviceInfo.getChangJing_Max().ToString();
                this.changJingLowerTextBox.Text = DeviceInfo.getChangJing_Min().ToString();
                this.duanJingUpperTextBox.Text = DeviceInfo.getDuanJing_Max().ToString();
                this.duanJingLowerTextBox.Text = DeviceInfo.getDuanJing_Min().ToString();
                this.jingBiZhiUpperTextBox.Text = DeviceInfo.getBiZhi_Max().ToString();
                this.jingBiZhiLowerTextBox.Text = DeviceInfo.getBiZhi_Min().ToString();
                this.colorRTextBox.Text = DeviceInfo.getR().ToString();
                this.colorGTextBox.Text = DeviceInfo.getG().ToString();
                this.colorBTextBox.Text = DeviceInfo.getB().ToString();
                 //* */
            }
            //else
            {
                /*
                this.jiaReTextBox.Text = DeviceInfo.getJiaReShiJian().ToString();
                this.qingXiShiJianTextBox.Text = DeviceInfo.getQingXiShiJian().ToString();
                this.qingXiCiShuTextBox.Text = DeviceInfo.getQingXiCiShu().ToString();
                this.lengQueTextBox.Text = DeviceInfo.getLengQueShiJian().ToString();
                this.chouQiTextBox.Text = DeviceInfo.getChouQiShiJian().ToString();
                this.biZhiUpperTextBox.Text = DeviceInfo.getZhouChangMianJiBi_Max().ToString();
                this.biZhiLowerTextBox.Text = DeviceInfo.getZhouChangMianJiBi_Min().ToString();
                this.areaUpperTextBox.Text = DeviceInfo.getMianJi_Max().ToString();
                this.areaLowerTextBox.Text = DeviceInfo.getMianJi_Min().ToString();
                this.changJingUpperTextBox.Text = DeviceInfo.getChangJing_Max().ToString();
                this.changJingLowerTextBox.Text = DeviceInfo.getChangJing_Min().ToString();
                this.duanJingUpperTextBox.Text = DeviceInfo.getDuanJing_Max().ToString();
                this.duanJingLowerTextBox.Text = DeviceInfo.getDuanJing_Min().ToString();
                this.jingBiZhiUpperTextBox.Text = DeviceInfo.getBiZhi_Max().ToString();
                this.jingBiZhiLowerTextBox.Text = DeviceInfo.getBiZhi_Min().ToString();
                this.colorRTextBox.Text = DeviceInfo.getR().ToString();
                this.colorGTextBox.Text = DeviceInfo.getG().ToString();
                this.colorBTextBox.Text = DeviceInfo.getB().ToString();
                 * */

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

        private void shengchengButton_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                String fileName = saveFileDialog1.FileName;
                this.textBox1.Text = fileName;

                int JianCeLieShu = int.Parse((String)this.textBox2.Text);

                try
                {
                    float inc = 1;
                    float start = 1;
                    float[][] v;
                    v = new float[CloneSelectionDevice.SCP_TestRowNum][];
                    for (int i = 0; i < CloneSelectionDevice.SCP_TestRowNum; i++)
                    {
                        v[i] = new float[JianCeLieShu];
                    }
                    for (int i = 0; i < CloneSelectionDevice.SCP_TestRowNum; i++)
                    {
                        for (int j = 0; j < JianCeLieShu; j++)
                        {
                            v[i][j] = start;
                            start += inc;
                        }
                    }
                    CloneSelectFileHelper.setJianCeShuJu(fileName, v, JianCeLieShu);
                }
                catch (Exception ex)
                {

                }
             }
        }

        private void daoRuButton_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                String fileName = openFileDialog1.FileName;
                float[][] v = CloneSelectFileHelper.getJianCeShuJu(fileName, int.Parse(textBox2.Text));
                if (v != null)
                {
                    //DeviceInfo.setDetectValues(v);
                    for (int i = 0; i < int.Parse(textBox2.Text); i++)
                    {
                        ListViewItem lvi = new ListViewItem();
                        for (int j = 0; j < CloneSelectionDevice.SCP_TestRowNum; j++)
                        {
                            lvi.SubItems.Add(v[j][i].ToString()); 
                        }
                        this.listView1.Items.Add(lvi); 
                    }
                }

                listView1.EndUpdate();
            }
        }

    }
}
