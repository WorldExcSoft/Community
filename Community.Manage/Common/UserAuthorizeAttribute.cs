using Community.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Community.Manage.Common
{
    public class UserAuthorizeAttribute : AuthorizeAttribute
    {
        public override void OnAuthorization(System.Web.Mvc.AuthorizationContext filterContext)
        {
            var islogin = filterContext.HttpContext.User.Identity.IsAuthenticated;
            if (!islogin)
            {
                if (AjaxRequestExtensions.IsAjaxRequest(filterContext.HttpContext.Request))
                {
                    filterContext.Result = new System.Web.Mvc.JsonResult { Data = new { success = true, login = false, data = "", message = "" }, JsonRequestBehavior = System.Web.Mvc.JsonRequestBehavior.AllowGet };
                }
                else
                {
                    var returnUrl = string.IsNullOrWhiteSpace(HttpContext.Current.Request.RawUrl) ? "" : HttpContext.Current.Request.RawUrl;
                    //未登陆返回登陆页
                    filterContext.Result = new System.Web.Mvc.RedirectToRouteResult(new System.Web.Routing.RouteValueDictionary(new { controller = "Login", action = "Index"}));
                }
                return;
            }
            string controllerName = filterContext.ActionDescriptor.ControllerDescriptor.ControllerName;
            string actionName = filterContext.ActionDescriptor.ActionName;
            base.OnAuthorization(filterContext);
        }
        /// <summary>
        /// 通过验证用户权限是否可以使用该Action（暂无用）
        /// </summary>
        /// <param name="httpContext"></param>
        /// <returns></returns>
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            if (HttpContext.Current.User == null || HttpContext.Current.User.Identity.IsAuthenticated == false)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        /// <summary>
        /// 授权失败时返回页
        /// </summary>
        /// <param name="filterContext"></param>
        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            filterContext.HttpContext.Response.Redirect("/Login/Index");
        }


    }
}