using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Community.Common
{
    public class IpHelper
    {



        #region 获取客户端外网IP地址

        public static string GetIP()
        {
            string ip = string.Empty;
            if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.ServerVariables["HTTP_VIA"]))
                ip = Convert.ToString(System.Web.HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"]);
            if (string.IsNullOrEmpty(ip))
                ip = Convert.ToString(System.Web.HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"]);
            return ip;
        }

        #endregion

        #region 根据外网IP地址获取所属地区

        public static string GetCityFromIp(string ip)
        {
            try
            {
                var str = "http://ip.taobao.com/service/getIpInfo.php?ip=" + ip;
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(str);
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                Stream stream = response.GetResponseStream();
                string result = new StreamReader(stream, System.Text.Encoding.UTF8).ReadToEnd();
                string[] temp = result.Split('"');
                //if (temp.Length < 10 || String.IsNullOrEmpty(temp[31]))  //23  7
                //{
                //    return "内网地址";
                //}
                if (temp.Length > 7)
                {
                    if (String.IsNullOrEmpty(temp[31]))
                    {
                        if (String.IsNullOrEmpty(temp[23]))
                        {
                            return Unicode(temp[7]);
                        }
                        else
                        {
                            return Unicode(temp[23]);
                        }
                    }
                    return Unicode(temp[31]);
                }
                else
                {
                    return "内网地址";
                }

            }
            catch (Exception e)
            {
                return "地址获取错误";
            }
        }

        #endregion


        public static string Unicode(string str)
        {
            string outStr = "";
            if (!string.IsNullOrEmpty(str))
            {
                string[] strlist = str.Replace("\\", "").Split('u');
                try
                {
                    for (int i = 1; i < strlist.Length; i++)
                    {
                        //将unicode字符转为10进制整数，然后转为char中文字符  
                        outStr += (char)int.Parse(strlist[i], System.Globalization.NumberStyles.HexNumber);
                    }
                }
                catch (FormatException ex)
                {
                    outStr = ex.Message;
                }
            }
            return outStr;
        }


    }
}
