using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Community.Common
{
    /// <summary>
    /// 用户存在于浏览器端的身份票据（非持久）
    /// 非持久 FormsAuthenticationTicket 的isPersistent为false只存于浏览器
    /// 持久 True 也存于（win7中的位置为C:\Users\用户名\AppData\Roaming\Microsoft\Windows\Cookies，注意Appdata是个隐藏的文件夹）
    /// </summary>
    public class UserTicket
    {
        /// <summary>
        /// 用户Id(主键)
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// 用户账号
        /// </summary>
        public string UserAccount { get; set; }

        /// <summary>
        /// 用户姓名
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// 角色Id列表
        /// </summary>
        public List<int> RoleIds { get; set; }
    }
}