using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Community.Common
{
    public sealed class GlobalVars
    {
        #region 全局

        /// <summary>
        /// 加密密钥
        /// </summary>
        public const string FixedPassKey = "orison%^<>,*3\"728469&#$";
        /// <summary>
        /// 读取路径目录
        /// </summary>
        public static string PathRootRead = ConfigurationManager.AppSettings["ResourcesRead"];
        /// <summary>
        /// 保存路径目录
        /// </summary>
        public static string PathRootSave = ConfigurationManager.AppSettings["ResourcesSave"];

        /// <summary>
        /// 获取图片及文件保存的原始路径（以便获取原图）
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static string GetPrimaryPathRootRead(string path, int imgType)
        {
            string retPath = String.Empty;
            if (!string.IsNullOrEmpty(path))
            {
                retPath = PathRootRead + "Images/";
                string[] arrStr = path.Split('/');
                switch (imgType)
                {
                    case ImageType.Course:
                        retPath = retPath + "Course/";
                        break;
                    case ImageType.Article:
                        retPath = retPath + "Article/";
                        break;
                    case ImageType.Book:
                        retPath = retPath + "Book/";
                        break;
                    case ImageType.Exhibition:
                        retPath = retPath + "Exhibition/";
                        break;
                    case ImageType.SnsCircle:
                        retPath = retPath + "SnsCircle/";
                        break;
                    case ImageType.Gift:
                        retPath = retPath + "Gift/";
                        break;
                    case ImageType.Channel:
                        retPath = retPath + "Channel/";
                        break;
                    case ImageType.Banner:
                        retPath = retPath + "Banner/";
                        break;
                    case ImageType.AdImage:
                        retPath = retPath + "AdImage/";
                        break;
                    case ImageType.EduSchool:
                        retPath = retPath + "EduSchool/";
                        break;
                        
                    case ImageType.Upload:
                        retPath = retPath + "Upload/";
                        break;
                }
                retPath = retPath +"Primary/"+arrStr[arrStr.Length-1];
            }

            if (string.IsNullOrEmpty(retPath))
            {
                retPath = "#";
            }
            return retPath;
        }

        #endregion
    }
}
