using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using System.Web;

namespace Community.Common
{
    public class JsonHelper
    {
        static JsonSerializerSettings JsonSerializerSettings = new JsonSerializerSettings
        {
            NullValueHandling = NullValueHandling.Ignore,
            ContractResolver = new CamelCasePropertyNamesContractResolver()
        };

        static JsonHelper()
        {
            IsoDateTimeConverter timeConverter = new IsoDateTimeConverter();
            timeConverter.DateTimeFormat = "yyyy'-'MM'-'dd' 'HH':'mm':'ss";
            JsonSerializerSettings.Converters.Add(timeConverter);
        }

        /// <summary>
        ///  转换对象为json格式字符串
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string ToJSON(object obj)
        {
            // 设置参数为Formatting.Indented可输出格式化后的json
            return JsonConvert.SerializeObject(obj, Formatting.None, JsonSerializerSettings);
        }

        public static string ToJSON(object obj, IsoDateTimeConverter converter)
        {
            /* 设置参数为Formatting.Indented可输出格式化后的json
             * 避免污染 JsonSerializerSettings 全局默认设置
             * 采用构造新对象
             */
            JsonSerializerSettings jsonSerializerSettings = new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore,
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            };
            jsonSerializerSettings.Converters.Add(converter);
            return JsonConvert.SerializeObject(obj, jsonSerializerSettings);
        }

        /// <summary>
        ///  转换对象为可供Razor页面使用的json格式字符串
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static IHtmlString ToRawJSON(object obj)
        {
            return new HtmlString(ToJSON(obj));
        }

        /// <summary>
        /// 转换json格式字符串为指定类型对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="json"></param>
        /// <returns></returns>
        public static T ParseJSON<T>(string json)
        {
            return JsonConvert.DeserializeObject<T>(json);
        }

        /// <summary>
        /// 转换json格式字符串为object对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="json"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public static object ParseJSON(string json, Type type)
        {
            return JsonConvert.DeserializeObject(json, type);
        }

    }
}
