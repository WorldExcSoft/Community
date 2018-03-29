using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Community.Common
{
    [Description("友情链接分类")]
    public class FriendLinkType
    {

        /// <summary>
        /// 开放教育
        /// </summary>
        public const int KaiFang = 0;

        /// <summary>
        /// 老年教育
        /// </summary>
        public const int LaoNian = 1;

        /// <summary>
        /// 社区教育
        /// </summary>
        public const int SheQu = 2;

        
         /// <summary>
        /// 培训教育
        /// </summary>
        public const int PeiXun = 3;



        public static Dictionary<int, string> Dictionary = new Dictionary<int, string>()
            {
                {0, "开放教育"},{1, "老年教育"},{2, "社区教育"},{3, "培训教育"}
            };


        public static List<SelectListItem> SelectListItems = new List<SelectListItem>()
            {
                new SelectListItem() {Text = Dictionary[0], Value = "0"},
                new SelectListItem() {Text = Dictionary[1], Value = "1"},
                new SelectListItem() {Text = Dictionary[2], Value = "2"},
                new SelectListItem() {Text = Dictionary[3], Value = "3"}
            };


    }
}
