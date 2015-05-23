using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DeviceUtils;
using Instrument;

namespace VirtialDevices
{
    public class CloneSelectFileHelper
    {
        public static float[][] getJianCeShuJu(String FileName, int JianCeLieShu)
        {
            float[][] res = null;
            XmlFileInterpretor inter = new XmlFileInterpretor(FileName);
            if (inter.getFileType() != XmlFileHelper.XmlFileType.CloneSelect) return res;
            try
            {
                res = new float[CloneSelectionDevice.SCP_TestRowNum][];
                int b = 0;
                for (int i = 0; i < CloneSelectionDevice.SCP_TestRowNum; i++)
                {
                    res[i] = new float[JianCeLieShu];
                    for (int j = 0; j < JianCeLieShu; j++)
                        res[i][j] = float.Parse(inter.getNodeMessage("v" + (b + j).ToString()));
                    b += JianCeLieShu;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
            return res;
        }

        public static void setJianCeShuJu(String FileName, float[][] v, int JianCeLieShu)
        {
            if (v.Length != CloneSelectionDevice.SCP_TestRowNum) return;
            for (int i = 0; i < v.Length; i++)
            {
                if (v[i].Length != JianCeLieShu) return;
            }

            XmlFileCreator creator = new XmlFileCreator(XmlFileHelper.XmlFileType.CloneSelect, FileName);
            int b = 0;
            for (int i = 0; i < CloneSelectionDevice.SCP_TestRowNum; i++)
            {
                for (int j = 0; j < JianCeLieShu; j++)
                {
                    creator.addElement("v" + (b + j).ToString(), v[i][j].ToString());
                }
                b += JianCeLieShu;
            }
            creator.save();
        }
    }
}

