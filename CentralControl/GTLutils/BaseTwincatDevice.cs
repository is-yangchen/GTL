using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TwinCAT.Ads;

namespace GTLutils
{
    public class ConstSettings 
    {
        public static int StringLength = 200;
    }

    public class BaseTwincatDevice: BaseDevice
    {
        protected Dictionary<String, int> handleMap = new Dictionary<String, int>();
        protected TcAdsClient adsClient;

        public override void init() { }
        public override void deinit() { }
    }
}
