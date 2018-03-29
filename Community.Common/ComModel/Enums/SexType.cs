using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Community.Common
{
    public class SexType
    {

        /// <summary>
        /// 男性
        /// </summary>
        public const int NanXing = 1;

        /// <summary>
        /// 女性
        /// </summary>
        public const int NvXing = 2;



        public static Dictionary<int, string> Dictionary = new Dictionary<int, string>()
            {
                {1, "男性"},{2, "女性"}
            };


        public static List<SelectListItem> SelectListItems = new List<SelectListItem>()
            {
                new SelectListItem() {Text = Dictionary[1], Value = "1"},
                new SelectListItem() {Text = Dictionary[2], Value = "2"}
            };
    }
}
