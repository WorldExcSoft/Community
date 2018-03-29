using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Community.Common
{
    public class DifficultyLevel
    {
        /// <summary>
        /// 容易
        /// </summary>
        public const int Easy = 1;

        /// <summary>
        /// 一般
        /// </summary>
        public const int General = 2;

        /// <summary>
        /// 困难
        /// </summary>
        public const int Difficult = 3;

        public static Dictionary<int, string> Dictionary = new Dictionary<int, string>()
            {
                {1, "容易"},{2, "一般"},{3, "困难"}
            };


        public static List<SelectListItem> SelectListItems = new List<SelectListItem>()
            {
                new SelectListItem() {Text = Dictionary[1], Value = "1"},
                new SelectListItem() {Text = Dictionary[2], Value = "2"},
                new SelectListItem() {Text = Dictionary[3], Value = "3"}
            };
    }
}
