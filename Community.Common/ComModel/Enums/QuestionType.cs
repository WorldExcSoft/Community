using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Community.Common
{
    public class QuestionType
    {
        /// <summary>
        /// 判断题
        /// </summary>
        public const int Judge = 1;

        /// <summary>
        /// 单选题
        /// </summary>
        public const int Single = 2;

        /// <summary>
        /// 多选题
        /// </summary>
        public const int Multiple = 3;

        /// <summary>
        /// 问答题
        /// </summary>
        public const int EssayQuestion= 4;


        public static Dictionary<int, string> Dictionary = new Dictionary<int, string>()
            {
                {1, "判断题"},{2, "单选题"},{3, "多选题"},{4, "问答题"}
            };


        public static List<SelectListItem> SelectListItems = new List<SelectListItem>()
            {
                new SelectListItem() {Text = Dictionary[1], Value = "1"},
                new SelectListItem() {Text = Dictionary[2], Value = "2"},
                new SelectListItem() {Text = Dictionary[3], Value = "3"},
                new SelectListItem() {Text = Dictionary[4], Value = "4"}
            };
    }
}
