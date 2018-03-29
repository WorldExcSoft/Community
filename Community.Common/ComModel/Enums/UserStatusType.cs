using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Community.Common
{
    public class UserStatusType
    {

        /// <summary>
        /// 正常
        /// </summary>
        public const int ZhengChang = 1;

        /// <summary>
        /// 禁用
        /// </summary>
        public const int Forbidden = 0;




        public static Dictionary<int, string> Dictionary = new Dictionary<int, string>()
            {
                {1, "正常"},{0, "禁用"}
            };


        public static List<SelectListItem> SelectListItems = new List<SelectListItem>()
            {
                new SelectListItem() {Text = Dictionary[0], Value = "1"},
                new SelectListItem() {Text = Dictionary[1], Value = "0"}
            };

    }
}
