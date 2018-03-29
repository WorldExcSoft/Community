using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Community.Common
{
    public class UserType
    {

        /// <summary>
        /// 普通用户
        /// </summary>
        public const int PuTong = 0;

        /// <summary>
        /// 管理员
        /// </summary>
        public const int GuanLiYuan = 1;

        /// <summary>
        /// 超级管理员
        /// </summary>
        public const int ChaoJiGuanLiYuan = 2;



        public static Dictionary<int, string> Dictionary = new Dictionary<int, string>()
            {
                {0, "普通用户"},{1, "管理员"},{2, "超级管理员"}
            };


        public static List<SelectListItem> SelectListItems = new List<SelectListItem>()
            {
                new SelectListItem() {Text = Dictionary[0], Value = "0"},
                new SelectListItem() {Text = Dictionary[1], Value = "1"},
                new SelectListItem() {Text = Dictionary[2], Value = "2"}
            };


    }
}
