using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Community.Common
{
    [Description("审核方式")]
    public class CheckWayType
    {

        /// <summary>
        /// 人工审核
        /// </summary>
        public const int RenGong = 0;

        /// <summary>
        /// 自动审核
        /// </summary>
        public const int ZiDong = 1;





        public static Dictionary<int, string> Dictionary = new Dictionary<int, string>()
            {
                {0, "人工审核"},{1, "自动审核"}
            };


        public static List<SelectListItem> SelectListItems = new List<SelectListItem>()
            {
                new SelectListItem() {Text = Dictionary[0], Value = "0"},
                new SelectListItem() {Text = Dictionary[1], Value = "1"}
            };

    }
}
