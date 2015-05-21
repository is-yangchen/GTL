using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DeviceUtils;

namespace Instrument
{
    public class TiaoMaHaoGenerator
    {
        private static HashSet<String> TiaoMaHaoSet = new HashSet<String>();

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

        public static String generateTiaoMaHao() 
        {
            String res = "";
            do
            {
                res = randomString();
            }while(TiaoMaHaoSet.Contains(res));
            TiaoMaHaoSet.Add(res);
            return res;
        }
    }
}
