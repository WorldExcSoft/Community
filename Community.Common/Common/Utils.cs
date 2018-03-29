using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Linq; 
using Newtonsoft.Json;

namespace Community.Common
{
    public static class Utils
    {

        #region 过滤拼接到SQL中的不安全字符 

        /// <summary>
        /// 过滤不安全字符
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string SqlSafe(string str)
        {
            if (str == null)
                return "";
            string[] temp = { "'", "’", "|", ";", "$", "%", "@", '"'.ToString(), "\'", "\"", "<>", "()", "+", "\r", "\n", ",", "\\" };
            foreach (string s in temp)
            {
                str = str.Replace(s, "");
            }
            return str;
        }

        #endregion


        #region 生成GUID

        /// <summary>
        /// 生成GUID
        /// </summary>
        /// <returns></returns>
        public static string GetNewGuid()
        {
            return Guid.NewGuid().ToString("N");
        }

        #endregion

        #region 转换用户字输入的字符串为可正确显示的html

        public static string ConvertToHtmlString(string source)
        {
            return ConvertToHtmlString(source, false);
        }

        /// <summary>
        /// 转换&为&amp;空格为&nbsp;<为&lt; >为&gt;
        /// </summary>
        /// <param name="source">源字符串</param>
        /// <param name="keepBR">是否保留换行</param>
        /// <returns></returns>
        public static string ConvertToHtmlString(string source, bool keepBR)
        {
            return source.Replace("&", "&amp;")
                .Replace(" ", "&nbsp;")
                .Replace("<", "&lt;")
                .Replace(">", "&gt;")
                .Replace("\r\n", keepBR ? "<br />" : "&nbsp;")
                .Replace("\n", keepBR ? "<br />" : "&nbsp;");
        }

        public static string ParseHtmlString(string source)
        {
            return source.Replace("&amp;", "&")
                .Replace("&nbsp;", " ")
                .Replace("&lt;", "<")
                .Replace("&gt;", ">")
                .Replace("&mdash;", "—");
        }

        /// <summary>
        /// 表情编码文字对应字典
        /// </summary>
        public static Dictionary<int, string> FaceDic = new Dictionary<int, string>
        {
            { 1,  "微笑" },
            { 2,  "嘻嘻" },
            { 3,  "哈哈" },
            { 4,  "爱你" },
            { 5,  "晕" },
            { 6,  "流泪" },
            { 7,  "馋嘴" },
            { 8,  "抓狂" },
            { 9,  "哼" },
            { 10,  "可爱" },
            { 11,  "怒" },
            { 12,  "汗" },
            { 13,  "困" },
            { 14,  "害羞" },
            { 15,  "睡觉" },
            { 16,  "钱" },
            { 17,  "偷笑" },
            { 18,  "酷" },
            { 19,  "衰" },
            { 20,  "吃惊" },
            { 21,  "闭嘴" },
            { 22,  "鄙视" },
            { 23,  "挖鼻屎" },
            { 24,  "花心" },
            { 25,  "坏笑" },
            { 26,  "鼓掌" },
            { 27,  "失望" },
            { 28,  "思考" },
            { 29,  "生病" },
            { 30,  "亲亲" },
            { 31,  "抱抱" },
            { 32,  "怒骂" },
            { 33,  "太开心" },
            { 34,  "懒得理你" },
            { 35,  "右哼哼" },
            { 36,  "左哼哼" },
            { 37,  "嘘" },
            { 38,  "委屈" },
            { 39,  "吐" },
            { 40,  "可怜" },
            { 41,  "打哈气" },
            { 42,  "顶" },
            { 43,  "疑问" },
            { 44,  "做鬼脸" },
            { 45,  "搞怪" },
            { 46,  "握手" },
            { 47,  "耶" },
            { 48,  "good" },
            { 49,  "弱" },
            { 50,  "no" },
            { 51,  "ok" },
            { 52,  "赞" },
            { 53,  "来" },
            { 54,  "蛋糕" },
            { 55,  "心" },
            { 56,  "伤心" },
            { 57,  "钟" },
            { 58,  "猪头" },
            { 59,  "咖啡" },
            { 60,  "饭" },
            { 61,  "浮云" },
            { 62,  "飘过" },
            { 63,  "月亮" },
            { 64,  "太阳" },
            { 65,  "下雨" },
            { 66,  "遛狗" },
            { 67,  "灰机" },
            { 68,  "叶子" },
            { 69,  "花" },
            { 70,  "干杯" },
            { 71,  "求围观" },
            { 72,  "又胖啦" }
        };

        /// <summary>
        /// 转换表情文字为等为表情图片
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static string ConvertFaceToHtmlString(string host, string source)
        {
            string result = source;

            foreach (var pair in FaceDic)
            {
                result = result.Replace("[" + pair.Value + "]", "<img src=\"" + host + "/content/image/icons/" + pair.Key.ToString() + ".gif\" alt=\"" + pair.Value + "\" />");
            }

            return result;
        }

        #endregion

        #region 删除HTML代码
        /// <summary>
        /// 删除HTML代码
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string RemoveHtml(this string value)
        {
            if (string.IsNullOrEmpty(value)) return string.Empty;

            value = Regex.Replace(value, "<script[^>]*>.*?</script>|<style[^>]*>.*?</style>|<!--.*?-->", "", RegexOptions.Singleline | RegexOptions.IgnoreCase);
            value = Regex.Replace(value, @"</?\s*[\w:\-]+(\s*[\w:\-]+\s*(=\s*""[^""]*""|=\s*'[^']*'|=\s*[^\s=>]*))*\s*/?>", "").Trim();
            value = value.Replace("\r", "").Replace("\n", "").Replace("\t", "").Replace("&nbsp;", "").Replace("&emsp;", "").Replace("</p>", "");
            return value;
        }

        #endregion




        #region 转换含有html标签的内容为记事本格式内容 （用于电子书章节内容转化，谨慎修改）

        /// <summary>
        /// 将html文本转化为 文本内容方法TextNoHTML
        /// </summary>
        /// <param name="Htmlstring">HTML文本值</param>
        /// <returns></returns>
        public static string TextNoHTML(string Htmlstring)
        {

            //替换掉 < 和 > 标记
            Htmlstring = Htmlstring.Replace("<br/>", "\r\n");
            //删除脚本   
            Htmlstring = Regex.Replace(Htmlstring, @"<script[^>]*?>.*?</script>", "", RegexOptions.IgnoreCase);
            //删除HTML   
            Htmlstring = Regex.Replace(Htmlstring, @"<(.[^>]*)>", "", RegexOptions.IgnoreCase);
            //Htmlstring = Regex.Replace(Htmlstring, @"([/r/n])[/s]+", "", RegexOptions.IgnoreCase);
            //Htmlstring = Regex.Replace(Htmlstring, @"-->", "", RegexOptions.IgnoreCase);
            //Htmlstring = Regex.Replace(Htmlstring, @"<!--.*", "", RegexOptions.IgnoreCase);


            //替换掉 < 和 > 标记
            Htmlstring = Htmlstring.Replace("&nbsp;", " ");
            //Htmlstring = Htmlstring.Replace(">", "");
            //Htmlstring = Htmlstring.Replace("\r\n", "");
            //Htmlstring = Htmlstring.Replace("\r", "");
            //Htmlstring = Htmlstring.Replace("\n", "");
            //返回去掉html标记的字符串
            return Htmlstring;
        }

        #endregion



        #region 字符串操作

        /// <summary>
        /// 搜索移除特殊字符
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static string RemoveSpecialCharacters(string source)
        {
            Regex regex = new Regex("[&|<|>|(\\\\r\\\\n)|(\\\\n)|(\\\\)|'|\\s]");
            return regex.Replace(source, "");
        }

        /// <summary>
        /// 截取字符串，中文算两个字符
        /// </summary>
        /// <param name="s">源字符串</param>
        /// <param name="bytes">截取长度</param>
        /// <returns></returns>
        public static string SubStrByByte(string s, int bytes)
        {
            if (string.IsNullOrEmpty(s))
            {
                return string.Empty;
            }
            int totalBytes = 0;
            string res = "";
            for (int i = 0; i < s.Length; i++)
            {
                if (IsChinese(s[i]))
                {
                    totalBytes = totalBytes + 2;
                }
                else
                {
                    totalBytes = totalBytes + 1;
                }

                if (totalBytes <= bytes)
                {
                    res += s[i];
                }
                else
                {
                    break;
                }
            }
            return res;
        }

        public static int EngLength(string str)
        {
            System.Text.ASCIIEncoding n = new System.Text.ASCIIEncoding();

            byte[] b = n.GetBytes(str);
            int length = 0;
            for (int i = 0; i <= b.Length - 1; i++)
            {
                if (b[i] == 63)
                {
                    length++;
                }
                length++;
            }
            return length;
        }

        public static string SubString(string stringToSub, int length)
        {
            Regex regex = new Regex("[\u4e00-\u9fa5]+", RegexOptions.Compiled);
            char[] stringChar = stringToSub.ToCharArray();
            StringBuilder sb = new StringBuilder();
            int nLength = 0;

            for (int i = 0; i < stringChar.Length; i++)
            {
                if (regex.IsMatch((stringChar[i]).ToString()))
                {
                    nLength += 3;
                }
                else
                {
                    nLength = nLength + 1;
                }

                if (nLength <= length)
                {
                    sb.Append(stringChar[i]);
                }
                else
                {
                    break;
                }
            }

            return sb.ToString();
        }

        /// <summary>
        /// 判断一个字符是否为中文字符
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        public static bool IsChinese(char c)
        {
            return (int)c >= 0x4E00 && (int)c <= 0x9FA5;
        }

        /// <summary>
        /// 获取大写的MD5签名结果
        /// </summary>
        /// <param name="encypStr"></param>
        /// <returns></returns>
        public static string GetMD5(string encypStr, string key)
        {
            encypStr += key;
            string retStr;
            MD5CryptoServiceProvider m5 = new MD5CryptoServiceProvider();

            //创建md5对象
            byte[] inputBye;
            byte[] outputBye;

            //使用GB2312编码方式把字符串转化为字节数组．
            inputBye = Encoding.GetEncoding("GB2312").GetBytes(encypStr);

            outputBye = m5.ComputeHash(inputBye);

            retStr = System.BitConverter.ToString(outputBye);
            retStr = retStr.Replace("-", "").ToUpper();
            return retStr;
        }

        public static string GetMD5(string encypStr)
        {
            return GetMD5(encypStr, "");
        }

        /// <summary>
        /// SHA256函数
        /// </summary>
        /// /// <param name="str">原始字符串</param>
        /// <returns>SHA256结果</returns>
        public static string SHA256(string str)
        {
            byte[] SHA256Data = Encoding.UTF8.GetBytes(str);
            SHA256Managed Sha256 = new SHA256Managed();
            byte[] Result = Sha256.ComputeHash(SHA256Data);
            return Convert.ToBase64String(Result);  //返回长度为44字节的字符串
        }

        /// <summary>
        /// 检测是否有Sql危险字符
        /// </summary>
        /// <param name="str">要判断字符串</param>
        /// <returns>判断结果</returns>
        public static bool IsSafeSqlString(string str)
        {
            return !Regex.IsMatch(str, @"[-|;|,|\/|\(|\)|\[|\]|\}|\{|%|@|\*|!|\']");
        }

        /// <summary>
        /// 检测是否有危险的可能用于链接的字符串
        /// </summary>
        /// <param name="str">要判断字符串</param>
        /// <returns>判断结果</returns>
        public static bool IsSafeUserInfoString(string str)
        {
            return !Regex.IsMatch(str, @"^\s*$|^c:\\con\\con$|[%,\*" + "\"" + @"\s\t\<\>\&]|游客|^Guest");
        }

        /// <summary>
        /// 将全角数字转换为数字
        /// </summary>
        /// <param name="SBCCase"></param>
        /// <returns></returns>
        public static string SBCCaseToNumberic(string SBCCase)
        {
            char[] c = SBCCase.ToCharArray();
            for (int i = 0; i < c.Length; i++)
            {
                byte[] b = System.Text.Encoding.Unicode.GetBytes(c, i, 1);
                if (b.Length == 2)
                {
                    if (b[1] == 255)
                    {
                        b[0] = (byte)(b[0] + 32);
                        b[1] = 0;
                        c[i] = System.Text.Encoding.Unicode.GetChars(b)[0];
                    }
                }
            }
            return new string(c);
        }

        /// <summary>
        /// 通过用户的生日月份和日期，返回其星座名称
        /// </summary>
        /// <param name="month"></param>
        /// <param name="day"></param>
        /// <returns></returns>
        public static string GetZodiacName(int month, int day)
        {
            return ("摩羯,水瓶,双鱼,白羊,金牛,双子,巨蟹,狮子,处女,天秤,天蝎,射手,摩羯").Split(',')[day < (20 + int.Parse(("2101122344432")[month].ToString())) ? month - 1 : month] + "座";
        }

        public static string Concat(ICollection items, string delimiter)
        {
            bool first = true;

            StringBuilder sb = new StringBuilder();
            foreach (object item in items)
            {
                if (item == null)
                    continue;

                if (!first)
                {
                    sb.Append(delimiter);
                }
                else
                {

                    first = false;
                }
                sb.Append(item);
            }
            return sb.ToString();
        }

        public static double MathRound(double dou, int num)
        {
            return Math.Round(dou, num);
        }

        public static double MathRound(double? dou)
        {
            if (dou != null)
                return MathRound(dou);
            else
                return 0;
        }

        /// <summary>
        /// 价格保留2位小数，"分"四舍五入
        /// </summary>
        /// <param name="price"></param>
        /// <returns></returns>
        public static string FormatPrice(decimal price)
        {
            return Math.Round(price, 1).ToString("#0.00");
        }

        #endregion


        #region 生成密码加盐

        /// <summary>
        /// 生成密码加盐
        /// </summary>
        /// <returns></returns>
        public static string GetSalt()
        {
            var sb = new StringBuilder();
            SecurityHelper.GetRandomStrArray(6).ToList().ForEach(x => sb.Append(x));
            return sb.ToString();
        }

        #endregion

       



        public static string GetCurrentHost()
        {
            return HttpContext.Current.Request.Url.Scheme + "://" + HttpContext.Current.Request.Url.Host;
        }


        #region URL编码及解码

        public static string UrlEncode(string url)
        {
            return HttpUtility.UrlEncode(url);
        }
        public static string UrlEncode(string url, Encoding encoding)
        {

            return HttpUtility.UrlEncode(url, encoding);
        }

        public static string UrlDecode(string url)
        {
            return HttpUtility.UrlDecode(url);
        }
        public static string UrlDecode(string url, Encoding encoding)
        {
            return HttpUtility.UrlDecode(url, encoding);
        }

        #endregion


        #region 获取短链接

        /// <summary>
        /// 获取短链接
        /// </summary>
        /// <param name="url">原始链接</param>
        /// <returns></returns>
        public static string GetShortUrl(string url)
        {
            //可以自定义生成MD5加密字符传前的混合KEY
            string key = "Leejor";
            //要使用生成URL的字符
            string[] chars = new string[]
            {
                "a","b","c","d","e","f","g","h",
                "i","j","k","l","m","n","o","p",
                "q","r","s","t","u","v","w","x",
                "y","z","0","1","2","3","4","5",
                "6","7","8","9","A","B","C","D",
                "E","F","G","H","I","J","K","L",
                "M","N","O","P","Q","R","S","T",
                "U","V","W","X","Y","Z"
            };

            //对传入网址进行MD5加密
            string hex = System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(key + url, "md5");

            string[] resUrl = new string[4];

            for (int i = 0; i < 4; i++)
            {
                //把加密字符按照8位一组16进制与0x3FFFFFFF进行位与运算
                int hexint = 0x3FFFFFFF & Convert.ToInt32("0x" + hex.Substring(i * 8, 8), 16);
                string outChars = string.Empty;
                for (int j = 0; j < 6; j++)
                {
                    //把得到的值与0x0000003D进行位与运算，取得字符数组chars索引
                    int index = 0x0000003D & hexint;
                    //把取得的字符相加
                    outChars += chars[index];
                    //每次循环按位右移5位
                    hexint = hexint >> 5;
                }
                //把字符串存入对应索引的输出数组
                resUrl[i] = outChars;
            }

            return resUrl[0];
        }

        #endregion


      



        #region ip相关

        /// <summary>
        /// 是否为ip
        /// </summary>
        /// <param name="ip"></param>
        /// <returns></returns>
        public static bool IsIP(string ip)
        {
            ip = Regex.Replace(ip, "[^\\d.]+", "");
            return Regex.IsMatch(ip, @"^((2[0-4]\d|25[0-5]|[01]?\d\d?)\.){3}(2[0-4]\d|25[0-5]|[01]?\d\d?)$");
        }
        /// <summary>
        /// 获取生产环境IP地址 其他地方不要使用这个方法
        /// </summary>
        /// <returns></returns>
        public static string GetOnlineIP()
        {
            System.Net.IPHostEntry IpEntry = System.Net.Dns.GetHostEntry(System.Net.Dns.GetHostName());
            for (int i = 0; i != IpEntry.AddressList.Length; i++)
            {
                if (IpEntry.AddressList[i].AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                {
                    return IpEntry.AddressList[i].ToString();
                }
            }
            return "未成功获取..";
        }
 
        #endregion

        #region email相关

        /// <summary>
        /// 检测是否符合email格式
        /// </summary>
        /// <param name="strEmail">要判断的email字符串</param>
        /// <returns>判断结果</returns>
        public static bool IsValidEmail(string strEmail)
        {
            //return Regex.IsMatch(strEmail, @"^[A-Za-z0-9-_]+@[A-Za-z0-9-_]+[\.][A-Za-z0-9-_]");
            return Regex.IsMatch(strEmail, @"^[\w\.]+@[A-Za-z0-9-_]+[\.][A-Za-z0-9-_]");
        }

        public static bool IsValidDoEmail(string strEmail)
        {
            return Regex.IsMatch(strEmail, @"^@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$");
        }

        #endregion

        #region 留言板数据安全性格式化

        public static string SecurityFormat(string htm, HttpContext context)
        {
            Regex reg = new Regex(@"<(.*?)>");
            string htm2 = reg.Replace(htm, "").Replace("&nbsp;", "");

            if (htm2.Trim().Length == 0)
            {
                return "";
            }

            Regex reg2 = new Regex(@"\[img\](?<Url>.+?)\[\/img\]", RegexOptions.IgnoreCase);
            Regex reg3 = new Regex(@"EditorImg/(.*?)\.gif", RegexOptions.IgnoreCase);
            Regex reg4 = new Regex(@"<br(.*?)>", RegexOptions.IgnoreCase);
            Regex reg5 = new Regex(@"</p>", RegexOptions.IgnoreCase);
            htm = reg4.Replace(htm, "[br]");
            htm = reg5.Replace(htm, "[br]");
            htm = reg.Replace(htm, "");

            var matches = reg2.Matches(htm);
            Regex reg7 = new Regex(@"http://(.*?)/", RegexOptions.IgnoreCase);
            Match mt = reg7.Match(context.Request.Url.ToString());

            string currentDomainUrl = mt.Value.TrimEnd('/');

            foreach (Match match in matches)
            {
                string url = match.Groups["Url"].Value;
                string url2 = string.Empty;
                if (!url.StartsWith(currentDomainUrl))
                {
                    url2 = currentDomainUrl + url;
                }
                else
                {
                    url2 = url;
                }
                string imgUrl = reg3.Replace(url2, "EditorImg");
                if (imgUrl.ToUpper() == (currentDomainUrl + "/CONTENT/PLUGINS/MSGEDITOR/EDITORIMG").ToUpper())
                {
                    htm = htm.Replace("[img]" + url + "[/img]", "<img src=\"" + url + "\" />");
                }
                else
                {
                    htm = htm.Replace("[img]" + url + "[/img]", "");
                }
            }
            htm = htm.Replace("[br]", "<br/>");
            return htm;
        }

        public static string ImageRegex(Match mac)
        {
            string val = "";
            if (mac.Success && mac.Groups.Count > 1)
            {
                string url = mac.Groups[1].Value;
                if (url.StartsWith(".."))
                {
                    url = url.Replace("../..", "").Replace("..", "");
                }
                val = "[img src=\"" + url + "\"/]";
            }

            return val;
        }

        public static string SecurityFormat(string htm, bool keepimg, HttpContext context)
        {
            Regex reg = new Regex(@"<(.*?)>");

            Regex reg2 = new Regex(@"\<img[^>]*src=['|""]([^'|""]*)['|""][^>]*>", RegexOptions.IgnoreCase);
            Regex regimg = new Regex(@"\[img[^]]*src=['|""]([^'|""]*)['|""][^]]*]", RegexOptions.IgnoreCase);
            Regex reg3 = new Regex(@"EditorImg/(.*?)\.gif", RegexOptions.IgnoreCase);
            Regex reg4 = new Regex(@"<br(.*?)>", RegexOptions.IgnoreCase);
            Regex reg5 = new Regex(@"</p>", RegexOptions.IgnoreCase);
            Regex reg7 = new Regex(@"http://(.*?)/", RegexOptions.IgnoreCase);
            Regex regdiv = new Regex(@"<div[^>]*align=['|""]([^'|""]*)['|""][^>]*>", RegexOptions.IgnoreCase);
            Regex regdivend = new Regex(@"</[^>]*div[^>]*>", RegexOptions.IgnoreCase);

            //htm = regdiv.Replace(htm, "[div$1]");
            htm = regdivend.Replace(htm, "[br]");

            htm = reg4.Replace(htm, "[br]");
            htm = reg5.Replace(htm, "[br]");
            htm = reg2.Replace(htm, new MatchEvaluator(ImageRegex));
            htm = reg.Replace(htm, "");
            //htm = htm.Replace("[divleft]", "<div align=\"left\">");
            //htm = htm.Replace("[divcenter]", "<div align=\"center\">");
            //htm = htm.Replace("[divright]", "<div align=\"right\">");
            //htm = htm.Replace("[/div]", "</div>");
            htm = regimg.Replace(htm, "<img src=\"$1\" />");

            htm = htm.Replace("[br]", "<br/>");
            return htm;
        }

        /// <summary>
        /// 过滤HTML
        /// </summary>
        /// <param name="html"></param>
        /// <returns></returns>
        public static string checkStr(string html)
        {
            System.Text.RegularExpressions.Regex regex1 = new System.Text.RegularExpressions.Regex(@"<script[\s\S]+</script *>", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            System.Text.RegularExpressions.Regex regex2 = new System.Text.RegularExpressions.Regex(@" href *= *[\s\S]*script *:", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            System.Text.RegularExpressions.Regex regex3 = new System.Text.RegularExpressions.Regex(@" on[\s\S]*=", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            System.Text.RegularExpressions.Regex regex4 = new System.Text.RegularExpressions.Regex(@"<iframe[\s\S]+</iframe *>", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            System.Text.RegularExpressions.Regex regex5 = new System.Text.RegularExpressions.Regex(@"<frameset[\s\S]+</frameset *>", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            System.Text.RegularExpressions.Regex regex6 = new System.Text.RegularExpressions.Regex(@"\<img[^\>]+\>", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            System.Text.RegularExpressions.Regex regex7 = new System.Text.RegularExpressions.Regex(@"</p>", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            System.Text.RegularExpressions.Regex regex8 = new System.Text.RegularExpressions.Regex(@"<p>", System.Text.RegularExpressions.RegexOptions.IgnoreCase);

            html = regex1.Replace(html, ""); //过滤<script></script>标记
            html = regex2.Replace(html, ""); //过滤href=javascript: (<A>) 属性
            html = regex3.Replace(html, " _disibledevent="); //过滤其它控件的on...事件
            html = regex4.Replace(html, ""); //过滤iframe
            html = regex5.Replace(html, ""); //过滤frameset
            html = regex6.Replace(html, ""); //过滤frameset
            html = regex7.Replace(html, ""); //过滤frameset
            html = regex8.Replace(html, ""); //过滤frameset
            html = html.Replace("</strong>", "");
            html = html.Replace("<strong>", "");
            return html;
        }

        #endregion

        #region 类型转换

        /// <summary>
        /// 将泛类型集合List类转换成DataTable
        /// </summary>
        /// <param name="list">泛类型集合</param>
        /// <returns>转换后的DataTable对象</returns>
        public static DataTable ListToDataTable<T>(IList<T> entitys)
        {

            //检查实体集合不能为空
            if (entitys == null || entitys.Count < 1)
            {
                throw new Exception("需转换的集合为空");
            }

            //取出第一个实体的所有Propertie
            Type entityType = entitys[0].GetType();
            PropertyInfo[] entityProperties = entityType.GetProperties();

            //生成DataTable的structure
            //生产代码中，应将生成的DataTable结构Cache起来，此处略
            DataTable dt = new DataTable();
            for (int i = 0; i < entityProperties.Length; i++)
            {
                //dt.Columns.Add(entityProperties[i].Name, entityProperties[i].PropertyType);
                dt.Columns.Add(entityProperties[i].Name);
            }

            //将所有entity添加到DataTable中
            foreach (object entity in entitys)
            {
                //检查所有的的实体都为同一类型
                if (entity.GetType() != entityType)
                {
                    throw new Exception("要转换的集合元素类型不一致");
                }
                object[] entityValues = new object[entityProperties.Length];
                for (int i = 0; i < entityProperties.Length; i++)
                {
                    entityValues[i] = entityProperties[i].GetValue(entity, null);

                }
                dt.Rows.Add(entityValues);
            }
            return dt;
        }

        #endregion

        #region linq相关
        public static void ForEach<T>(this IEnumerable<T> source, Action<T> action)
        {
            foreach (T p in source)
            {
                action(p);
            }
        }

        public static T FindFirst<T>(this IEnumerable<T> source) where T : class, new()
        {
            return (source != null && source.Count() > 0) ? source.First() : new T();
        }

        #endregion

        #region 获取端口
        public static string GetPort()
        {
            try
            {
                return HttpContext.Current.Request.Url.Port.ToString();
            }
            catch
            {
                return "";
            }
        }
        #endregion

        /// <summary>
        /// 获取字典中的键值（先判断有没有，没有会抛出异常提示）
        /// </summary>
        /// <param name="dic"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static string GetValue(this Dictionary<string, string> dic, string key)
        {
            if (dic.ContainsKey(key))
            {
                return dic[key];
            }
            else
            {
                throw new Exception("缓存字典中不包含【" + key + "】;请检查数据库ConfigDic或SiteConfigDic表字段");
            }
        }

        /// <summary>
        /// 生成一组随机数
        /// </summary>
        /// <param name="min">最小值</param>
        /// <param name="max">最大值</param>
        /// <param name="length">生成个数</param>
        /// <returns></returns>
        public static IEnumerable<int> RangeList(int min, int max, int length)
        {
            return Enumerable.Range(min, max).OrderBy(n => n * n * (new Random()).Next()).Take(length);
        }

        //直积算法
        public static List<string> CartesianProduct(List<List<string>> dimvalue, List<string> result, int layer, string curstring, string split)
        {
            if (layer < dimvalue.Count - 1)
            {
                if (dimvalue[layer].Count == 0)
                    CartesianProduct(dimvalue, result, layer + 1, curstring, split);
                else
                {
                    for (int i = 0; i < dimvalue[layer].Count; i++)
                    {
                        StringBuilder s1 = new StringBuilder();
                        s1.Append(curstring);
                        s1.Append(dimvalue[layer][i] + split);
                        CartesianProduct(dimvalue, result, layer + 1, s1.ToString(), split);
                    }
                }
            }
            else if (layer == dimvalue.Count - 1)
            {
                if (dimvalue[layer].Count == 0) result.Add(curstring);
                else
                {
                    for (int i = 0; i < dimvalue[layer].Count; i++)
                    {
                        result.Add(curstring + dimvalue[layer][i]);
                    }
                }
            }
            return result;
        }

        /// <summary>
        /// 保留N为小数，不四舍五入
        /// </summary>
        /// <param name="val">值</param>
        /// <param name="count">保留小数位</param>
        /// <returns></returns>
        public static decimal KeepPlace(this decimal val, int count)
        {
            var bei = 1;
            while (count-- > 0)
            {
                bei *= 10;
            }
            return Math.Truncate(val * bei) / bei;
        }

        /// <summary>
        /// 去除结尾的0
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string DecimalToString(decimal? value)
        {
            var val = value.ToString().Trim('0');
            val = (val.IndexOf('.') + 1) == val.Length ? val.Substring(0, val.IndexOf('.')) : val;
            return val;
        }

        #region 课程分类，文章分类 前后字符
        public static string TrimStartEndChar(string value)
        {
            char c = ',';
            return value.TrimStart(c).TrimEnd(c);
        }
        public static string AddStartEndChar(string value)
        {
            return ","+value+",";
        }
        #endregion
    }
}
