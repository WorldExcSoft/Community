using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Community.Common
{
    [Serializable]
    public class Pager
    {
        [DisplayName("当前页码")]
        public int Page { get; set; }

         [DisplayName("页大小")]
        public int Limit { get; set; }

        [DisplayName("升降序 :asc   desc  ")]
        public string Sort { get; set; }

         [DisplayName("排序字段")]
        public string Order { get; set; }

    }
}
