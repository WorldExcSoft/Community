using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Community.Common
{
    public class AssistConstraintTimeUnitType
    {

        /// <summary>
        /// 小时
        /// </summary>
        public const int Hour = 0;

        /// <summary>
        /// 天
        /// </summary>
        public const int Day = 1;




        public static Dictionary<int, string> Dictionary = new Dictionary<int, string>()
            {
                {0, "小时"},{1, "天"}
            };


        public static List<SelectListItem> SelectListItems = new List<SelectListItem>()
            {
                new SelectListItem() {Text = Dictionary[0], Value = "0"},
                new SelectListItem() {Text = Dictionary[1], Value = "1"}
            };

    }
}
