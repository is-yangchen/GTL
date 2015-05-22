using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DeviceUtils;

namespace Instrument
{
    public class BarCodeGenerator
    {
        private static HashSet<String> BarCodeSet = new HashSet<String>();

        private static String randomString()
        {
            String res = "";
            Random ra = new Random();
            for (int i = 0; i < 9; i++) 
            {
                res += ra.Next(1,9);
            }
            return res;
        }

        public static String generateBarCode() //随机模拟产生条码号
        {
            String res = "";
            do
            {
                res = randomString();
            } while (BarCodeSet.Contains(res));
            BarCodeSet.Add(res);
            return res;
        }
    }
}
