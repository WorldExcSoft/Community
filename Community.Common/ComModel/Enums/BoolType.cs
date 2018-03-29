using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Community.Common
{
    public class BoolType
    {
        /// <summary>
        /// 是
        /// </summary>
        public const int Shi = 1;

        /// <summary>
        /// 否
        /// </summary>
        public const int Fou = 0;




        public static Dictionary<int, string> Dictionary = new Dictionary<int, string>()
            {
                {0, "否"},{1, "是"}
            };


        public static List<SelectListItem> SelectListItems = new List<SelectListItem>()
            {
                new SelectListItem() {Text = Dictionary[1], Value = "0"},
                new SelectListItem() {Text = Dictionary[1], Value = "1"}
            };
    }
}
