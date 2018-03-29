using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Community.Common
{
    public class RemoteJsonModel
    {
        public string code { get; set; }

        public string msg { get; set; }

        public Data data { get; set; }
    }

    public class Data
    {
        public string src { get; set; }
        public string title { get; set; }
    }
}