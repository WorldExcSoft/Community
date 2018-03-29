using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography; 
using System.Text;
using System.Threading.Tasks;

namespace Community.Common
{
    public static class SecurityHelper
    {
        private static readonly Encoding Encoder = Encoding.UTF8;

        #region 前台登录密码加密

        public static string EncodePassword(string password)
        {
            return EncodeMD5(password + GlobalVars.FixedPassKey);
        }

        #endregion

        #region MD5加密

        /// <summary>
        /// 将字符串加密为MD5
        /// </summary>
        /// <returns></returns>
        public static string EncodeMD5(string text)
        {
            var md5 = new MD5CryptoServiceProvider();
            var result = md5.ComputeHash(Encoding.Default.GetBytes(text));
            md5.Clear();
            var sTemp = new StringBuilder();
            for (var i = 0; i < result.Length; i++)
                sTemp.Append(result[i].ToString("x").PadLeft(2, '0'));
            return sTemp.ToString().ToLower();
        }

        #endregion

        #region 随机选几位数
        /// <summary>
        /// 返回指定数量随机除字母O之外的25个字母和数字0之外的9个数字 
        /// </summary>
        /// <param name="count"></param>
        /// <returns></returns>
        public static string[] GetRandomStrArray(int count)
        {
            var r = new Random();
            var lst = new List<string>();
            for (var i = 0; i < count; i++)
            {
                var re = r.Next(GetString().Length - 1);
                lst.Add(GetString()[re]);
            }
            return lst.ToArray();
        }

        /// <summary>
        /// 返回除字母O之外的25个字母和数字0之外的9个数字
        /// </summary>
        /// <returns></returns>
        private static string[] GetString()
        {
            string[] Arr = { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z", "1", "2", "3", "4", "5", "6", "7", "8", "9" };
            return Arr;
        }
        #endregion

    }
}
