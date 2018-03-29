using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Community.Common
{
    public class ImageType
    {
        /// <summary>
        /// 课程
        /// </summary>
        public const int Course = 0;

        /// <summary>
        /// 文章
        /// </summary>
        public const int Article = 1;

        /// <summary>
        /// 电子书
        /// </summary>
        public const int Book = 2;

        /// <summary>
        /// 展厅
        /// </summary>
        public const int Exhibition = 3;

        /// <summary>
        /// 学习圈
        /// </summary>
        public const int SnsCircle = 4;

        /// <summary>
        /// 礼品
        /// </summary>
        public const int Gift = 5;

        /// <summary>
        /// 频道
        /// </summary>
        public const int Channel = 6;

        /// <summary>
        /// 首页头
        /// </summary>
        public const int Banner = 7;

        /// <summary>
        /// 广告
        /// </summary>
        public const int AdImage = 8;


        /// <summary>
        /// 学历教育学校封面图
        /// </summary>
        public const int EduSchool = 9;

        /// <summary>
        /// 文本编辑器的内容
        /// </summary>
        public const int Upload = 10;

        public static string ToDirectory(int imageType)
        {
            string FileRoot = string.Empty;
            switch (imageType)
            {
                case ImageType.Course:
                    FileRoot = "Course";
                    break;
                case ImageType.Article:
                    FileRoot = "Article";
                    break;
                case ImageType.Book:
                    FileRoot = "Book";
                    break;
                case ImageType.Exhibition:
                    FileRoot = "Exhibition";
                    break;
                case ImageType.SnsCircle:
                    FileRoot = "SnsCircle";
                    break;
                case ImageType.Gift:
                    FileRoot = "Gift";
                    break;
                case ImageType.Channel:
                    FileRoot = "Channel";
                    break;
                case ImageType.Banner:
                    FileRoot = "Banner";
                    break;
                case ImageType.AdImage:
                    FileRoot = "AdImage";
                    break;
                case ImageType.Upload:
                    FileRoot = "Upload";
                    break;
                case ImageType.EduSchool:
                    FileRoot = "EduSchool";
                    break;
                default:
                    break;
            }
            return FileRoot;
        }
    }

    

}
