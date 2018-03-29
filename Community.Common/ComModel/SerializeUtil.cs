using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Script.Serialization;
using System.Xml;
using System.Xml.Serialization;

namespace Community.Common
{
    public class SerializeUtil
    {
        /// <summary>
        /// xml序列化
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string XmlSerialize<T>(T obj)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
            using (MemoryStream ms = new MemoryStream())
            {
                xmlSerializer.Serialize(ms, obj);
                return Encoding.UTF8.GetString(ms.ToArray());
            }
        }
        /// <summary>
        /// XML反序列化
        /// </summary>
        public static T XmlDeserialize<T>(string xml)
        {
            T t = default(T);
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
            using (Stream xmlStream = new MemoryStream(Encoding.UTF8.GetBytes(xml)))
            {
                using (XmlReader xmlReader = XmlReader.Create(xmlStream))
                {
                    Object obj = xmlSerializer.Deserialize(xmlReader);
                    t = (T)obj;
                }
            }
            return t;
        }
        /// <summary>
        /// Json序列化
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string JsonSerialize(object obj)
        {
            if (obj == null) return string.Empty;
            return new JavaScriptSerializer().Serialize(obj);
        }
        /// <summary>
        /// Json反序列化
        /// </summary>
        public static T JsonDeserialize<T>(string json)
        {
            return new JavaScriptSerializer().Deserialize<T>(json);
        }
    }
}