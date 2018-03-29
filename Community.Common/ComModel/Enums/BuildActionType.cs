using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;


namespace Community.Common
{
    public class BuildActionType
    {
        /// <summary>
        /// 选题组卷
        /// </summary>
        public const int Select = 1;

        /// <summary>
        /// 随机组卷
        /// </summary>
        public const int Random = 2;

        public static Dictionary<int, string> Dictionary = new Dictionary<int, string>()
            {
                {1, "选题组卷"},{2, "随机组卷"}
            };


        public static List<SelectListItem> SelectListItems = new List<SelectListItem>()
            {
                new SelectListItem() {Text = Dictionary[1], Value = "1"},
                new SelectListItem() {Text = Dictionary[2], Value = "2"}
            };
    }
}
