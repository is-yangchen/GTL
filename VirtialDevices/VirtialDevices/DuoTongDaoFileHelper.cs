using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DeviceUtils;
using Instrument;

namespace VirtialDevices
{
    public class DuoTongDaoFileHelper
    {
        public static float[][] getJianCeShuJu(String FileName) 
        {
            float[][] res = null;
            XmlFileInterpretor inter = new XmlFileInterpretor(FileName);
            if (inter.getFileType() != XmlFileHelper.XmlFileType.DuoTongDaoFenXiYi) return res;
            try
            {
                res = new float[MultiTunnelDevice.JianCeHangShu][];
                int b = 0;
                for (int i = 0; i < MultiTunnelDevice.JianCeHangShu; i++) 
                {
                    res[i] = new float[MultiTunnelDevice.JianCeLieShu];
                    for (int j = 0; j < MultiTunnelDevice.JianCeLieShu;j++ )
                        res[i][j] = float.Parse(inter.getNodeMessage("v" + (b + j).ToString()));
                    b += MultiTunnelDevice.JianCeLieShu;
                }
            }
            catch (Exception ex) 
            {
                return null;
            }
            return res;
        }

        public static void setJianCeShuJu(String FileName, float[][] v)
        {
            if (v.Length != MultiTunnelDevice.JianCeHangShu) return;
            for (int i = 0; i < v.Length; i++) 
            {
                if (v[i].Length != MultiTunnelDevice.JianCeLieShu) return;
            }

            XmlFileCreator creator = new XmlFileCreator(XmlFileHelper.XmlFileType.DuoTongDaoFenXiYi, FileName);
            int b = 0;
            for (int i = 0; i < MultiTunnelDevice.JianCeHangShu; i++)
            {
                for (int j = 0; j < MultiTunnelDevice.JianCeLieShu; j++)
                {
                    creator.addElement("v" + (b + j).ToString(), v[i][j].ToString());
                }
                b += MultiTunnelDevice.JianCeLieShu;
            }
            creator.save();
        }
    }
}
