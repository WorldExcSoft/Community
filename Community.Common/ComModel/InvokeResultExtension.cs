using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace Community.Common
{
    public static class InvokeResultExtension
    {
        public static string Jsonp(this InvokeResult result, string callback)
        {
            return string.Format("{0}({1})", callback, SerializeUtil.JsonSerialize(result));
        }
        public static JsonResult JsonResult(this InvokeResult result)
        {
            JsonResult jsonResult = new JsonResult();
            jsonResult.ContentEncoding = Encoding.UTF8;
            jsonResult.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            jsonResult.Data = result;
            return jsonResult;
        }

        public static JsonResult JsonResultWithCORS(this InvokeResult result)
        {
            HttpContext.Current.Response.Headers.Add("Access-Control-Allow-Origin", "*");//CROS            
            HttpContext.Current.Response.Headers.Add("Access-Control-Allow-Headers", "X-Requested-With");//AJAX
            HttpContext.Current.Response.Headers.Add("ContentType", "application/json");

            JsonResult jsonResult = new JsonResult();
            jsonResult.ContentEncoding = Encoding.UTF8;
            jsonResult.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            jsonResult.Data = result;
            return jsonResult;
        }

        //HttpContext.Current.Response.Headers.Add("Access-Control-Allow-Origin", "*");//CROS            
        //HttpContext.Current.Response.Headers.Add("Access-Control-Allow-Headers", "Content-Type, Accept, X-Requested-With,Authorization,");//AJAX
        //HttpContext.Current.Response.Headers.Add("Access-Control-Allow-Methods", "GET,POST,OPTIONS");
        //HttpContext.Current.Response.Headers.Add("ContentType", "application/json");
        public static ActionResult JsonpResult(this InvokeResult result, string callback)
        {
            ContentResult contentResult = new ContentResult();
            contentResult.ContentEncoding = Encoding.UTF8;
            contentResult.ContentType = "application/jsonp";
            contentResult.Content = result.Jsonp(callback);
            return contentResult;
        }
    }
}