using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Community.Common.ComModel.Enums
{
   public  class DeviceType
    {
        /// <summary>
        /// PC(电脑端) 
        /// </summary>
        public const int PC = 0;

        /// <summary>
        /// 移动端APP
        /// </summary>
        public const int APP = 1;

        /// <summary>
        /// 移动端微信
        /// </summary>
        public const int WeChat = 2;



        public static Dictionary<int, string> Dictionary = new Dictionary<int, string>()
            {
                {0, "PC(电脑端)"},{1, "移动端APP"},{2, "移动端微信"}
            };


        public static List<SelectListItem> SelectListItems = new List<SelectListItem>()
            {
                new SelectListItem() {Text = Dictionary[0], Value = "0"},
                new SelectListItem() {Text = Dictionary[1], Value = "1"},
                new SelectListItem() {Text = Dictionary[2], Value = "2"}
            };
    }
}
