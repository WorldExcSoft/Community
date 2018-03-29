using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Text;
using System.Web;

namespace Community.Common
{
    public class ImageHelper
    {
        /// <summary>
        /// 保存缩略图到磁盘(可指定宽高，可指定缩放模式)
        /// </summary>
        /// <param name="srcPath"></param>
        /// <param name="destPath"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="mode"></param>
        public static void SaveThumbnail(String srcPath, String destPath, int width, int height)
        {
            using (Image srcImg = Image.FromFile(srcPath))
            {
                ThumbSize t = getCutSize(width, height, srcImg);
                using (Bitmap newImg = new Bitmap(t.New.Width, t.New.Height))
                {
                    using (Graphics g = Graphics.FromImage(newImg))
                    {
                        g.InterpolationMode = InterpolationMode.High;
                        g.SmoothingMode = SmoothingMode.HighQuality;
                        g.Clear(Color.Transparent);
                        g.DrawImage(srcImg, t.getNewRect(), t.getRect(), GraphicsUnit.Pixel);
                        try
                        {
                            newImg.Save(destPath, ImageFormat.Jpeg);
                        }
                        catch (Exception e)
                        {
                            throw e;
                        }
                    }
                }
            }
        }


        private static ThumbSize getCutSize(int width, int height, Image src)
        {
            ThumbSize t = new ThumbSize();
            if ((double)src.Width / (double)src.Height > (double)width / (double)height)
            {
                int newWidth = src.Height * width / height;
                t.Src = new Size(newWidth, src.Height);
                t.New = new Size(width, height);
                t.Point = new Point((src.Width - newWidth) / 2, 0);
            }
            else
            {
                int newHeight = src.Width * height / width;
                t.Src = new Size(src.Width, newHeight);
                t.New = new Size(width, height);
                t.Point = new Point(0, (src.Height - newHeight) / 2);
            }
            return t;
        }


        /// <summary>
        /// 根据原始图片名称和缩略图类型，获取缩略图名称
        /// </summary>
        /// <param name="srcPath"></param>
        /// <param name="ttype"></param>
        /// <returns></returns>
        public static String GetThumbPath(Object srcPath, string suffix, string imgname)
        {
            if (srcPath == null) return "";
            String path = srcPath.ToString();
            if (IsNullOrEmpty(path)) return "";
            String pathWithoutExt = TrimEnd(path, imgname);
            return pathWithoutExt + suffix + imgname;
        }

        /// <summary>
        /// 检查字符串是否是 null 或者空白字符。不同于.net自带的string.IsNullOrEmpty，多个空格在这里也返回true。
        /// </summary>
        /// <param name="target"></param>
        /// <returns></returns>
        public static Boolean IsNullOrEmpty(String target)
        {
            if (target != null)
            {
                return target.Trim().Length == 0;
            }
            return true;
        }

        /// <summary>
        /// 从 srcString 的末尾剔除掉 trimString
        /// </summary>
        /// <param name="srcString"></param>
        /// <param name="trimString"></param>
        /// <returns></returns>
        public static String TrimEnd(String srcString, String trimString)
        {
            if (IsNullOrEmpty(trimString)) return srcString;
            if (srcString.EndsWith(trimString) == false) return srcString;
            if (srcString.Equals(trimString)) return "";
            return srcString.Substring(0, srcString.Length - trimString.Length);
        }

        //判断图片格式
        public static Boolean isAllowedPic(HttpPostedFile pfile)
        {
            String[] types = { "jpg", "gif", "bmp", "png", "jpeg" };
            foreach (String ext in types)
            {
                if (string.IsNullOrEmpty(ext)) continue;
                String extWithDot = ext.StartsWith(".") ? ext : "." + ext;
                if (EqualsIgnoreCase(Path.GetExtension(pfile.FileName), extWithDot)) return true;
            }
            return false;
        }

        /// <summary>
        /// 保存生成后的缩略图
        /// </summary>
        /// <param name="x">宽</param>
        /// <param name="y">高</param>
        /// <param name="srcPath">图片路径</param>
        /// <param name="suffix">图片标识名称，返回的缩略图名称会在原图片名称前面加上此字符串</param>
        /// <param name="imgname">图片名称</param>
        public static void saveAvatarPrivate(int x, int y, String srcPath, string suffix, string imgname)
        {
            String thumbPath = GetThumbPath(srcPath, suffix, imgname);
            System.Drawing.Image img = System.Drawing.Image.FromFile(srcPath);
            if (img.Size.Width <= x && img.Size.Height <= y)
            {
                File.Copy(srcPath, thumbPath);
            }
            else
            {
                SaveThumbnail(srcPath, thumbPath, x, y);
            }
            img.Dispose();
        }

        /// <summary>
        /// 比较两个字符串是否相等(不区分大小写)
        /// </summary>
        /// <param name="s1"></param>
        /// <param name="s2"></param>
        /// <returns></returns>
        public static Boolean EqualsIgnoreCase(String s1, String s2)
        {
            if (s1 == null && s2 == null) return true;
            if (s1 == null || s2 == null) return false;
            if (s2.Length != s1.Length) return false;
            return string.Compare(s1, 0, s2, 0, s2.Length, StringComparison.OrdinalIgnoreCase) == 0;
        }
    }
}
