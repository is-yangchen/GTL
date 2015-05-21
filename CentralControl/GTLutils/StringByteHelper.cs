using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GTLutils
{
    public class StringByteHelper
    {
        public static String BytesToString(byte[] b, int start, int length)
        {
            String res = "";
            for (int i = 0; i < length; i++)
            {
                res += (char)b[i + start];
            }
            return res;
        }

        public static byte[] StringToBytes(String s)
        {
            byte[] res = new byte[s.Length];
            for (int i = 0; i < s.Length; i++)
            {
                res[i] = (byte)s[i];
            }
            return res;
        }
    }
}
