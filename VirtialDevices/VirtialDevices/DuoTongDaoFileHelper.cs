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
                res = new float[MultiTunnelDevice.MMA_TestRowIndex][];
                int b = 0;
                for (int i = 0; i < MultiTunnelDevice.MMA_TestRowIndex; i++) 
                {
                    res[i] = new float[MultiTunnelDevice.MMA_TestRowIndex];
                    for (int j = 0; j < MultiTunnelDevice.MMA_TestRowIndex; j++)
                        res[i][j] = float.Parse(inter.getNodeMessage("v" + (b + j).ToString()));
                    b += MultiTunnelDevice.MMA_TestRowIndex;
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
            if (v.Length != MultiTunnelDevice.MMA_TestRowIndex) return;
            for (int i = 0; i < v.Length; i++) 
            {
                if (v[i].Length != MultiTunnelDevice.MMA_TestRowIndex) return;
            }

            XmlFileCreator creator = new XmlFileCreator(XmlFileHelper.XmlFileType.DuoTongDaoFenXiYi, FileName);
            int b = 0;
            for (int i = 0; i < MultiTunnelDevice.MMA_TestRowIndex; i++)
            {
                for (int j = 0; j < MultiTunnelDevice.MMA_TestRowIndex; j++)
                {
                    creator.addElement("v" + (b + j).ToString(), v[i][j].ToString());
                }
                b += MultiTunnelDevice.MMA_TestRowIndex;
            }
            creator.save();
        }
    }
}
