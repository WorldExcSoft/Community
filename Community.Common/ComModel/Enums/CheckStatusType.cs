using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Community.Common
{
     [Description("审核状态")]
    public class CheckStatusType
    {

        /// <summary>
        /// 审核中
        /// </summary>
        public const int ShenHeZhong = 0;

        /// <summary>
        /// 审核通过
        /// </summary>
        public const int TongGuo = 1;

        /// <summary>
        /// 审核未通过
        /// </summary>
        public const int WeiTongGuo = 2;




        public static Dictionary<int, string> Dictionary = new Dictionary<int, string>()
            {
                {0, "审核中"},{1, "审核通过"},{2, "审核未通过"}
            };


        public static List<SelectListItem> SelectListItems = new List<SelectListItem>()
            {
                new SelectListItem() {Text = Dictionary[0], Value = "0"},
                new SelectListItem() {Text = Dictionary[1], Value = "1"},
                new SelectListItem() {Text = Dictionary[2], Value = "2"}
            };

    }
}
