using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Community.Common
{
    public class VideoType
    {
        /// <summary>
        /// Mp4视频
        /// </summary>
        public const int Mp4 = 1;

        /// <summary>
        /// Flv视频
        /// </summary>
        public const int Flv = 2;

        /// <summary>
        /// Flash视频
        /// </summary>
        public const int Flash = 3;

        /// <summary>
        /// 三分频
        /// </summary>
        public const int TreeProgress = 4;

        /// <summary>
        /// 听书Mp3
        /// </summary>
        public const int Mp3 = 5;

        public static Dictionary<int, string> Dictionary = new Dictionary<int, string>()
            {
                {1, "Mp4"},{2, "Flv"},{3, "Flash"},{4, "三分频"},{5, "Mp3"}
            };

        public static List<SelectListItem> SelectListItems = new List<SelectListItem>()
            {
                new SelectListItem() {Text = Dictionary[1], Value = "1"},
                new SelectListItem() {Text = Dictionary[2], Value = "2"},
                new SelectListItem() {Text = Dictionary[3], Value = "3"},
                new SelectListItem() {Text = Dictionary[4], Value = "4"},
                new SelectListItem() {Text = Dictionary[5], Value = "5"}
            };
    }
}
