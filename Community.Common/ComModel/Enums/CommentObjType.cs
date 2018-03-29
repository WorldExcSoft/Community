using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Community.Common
{
    public class CommentObjType
    {

        /// <summary>
        /// 未知
        /// </summary>
        public const int WeiZhi = 0;

        /// <summary>
        /// 课程
        /// </summary>
        public const int Course = 1;

        /// <summary>
        /// 文章
        /// </summary>
        public const int Article = 2;

        /// <summary>
        /// 电子书
        /// </summary>
        public const int Book = 3;

        /// <summary>
        /// 展厅
        /// </summary>
        public const int Exhibition = 4;

        /// <summary>
        /// 学习圈
        /// </summary>
        public const int SnsCircle = 5;

        ///// <summary>
        ///// 礼品
        ///// </summary>
        //public const int Gift = 6;

        ///// <summary>
        ///// 频道
        ///// </summary>
        //public const int Channel = 7;

        ///// <summary>
        ///// 首页头
        ///// </summary>
        //public const int Banner = 8;

        ///// <summary>
        ///// 广告
        ///// </summary>
        //public const int AdImage = 9;

        ///// <summary>
        ///// 文本编辑器的内容
        ///// </summary>
        //public const int Upload = 10;


        public static Dictionary<int, string> Dictionary = new Dictionary<int, string>()
            {
                {0, "未知"},{1, "课程评论"},{2, "文章评论"},{3, "电子书评论"},{4, "展厅评论"},{5, "学习圈评论"}
            };


        public static List<SelectListItem> SelectListItems = new List<SelectListItem>()
            {
                new SelectListItem() {Text = Dictionary[0], Value = "0"},
                new SelectListItem() {Text = Dictionary[1], Value = "1"},
                new SelectListItem() {Text = Dictionary[2], Value = "2"},
                new SelectListItem() {Text = Dictionary[3], Value = "3"},
                new SelectListItem() {Text = Dictionary[4], Value = "4"},
                new SelectListItem() {Text = Dictionary[5], Value = "5"}
            };

    }
}
