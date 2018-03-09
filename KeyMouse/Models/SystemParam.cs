using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KeyMouse.Models
{
    public class SystemParam
    {
        /// <summary>
        ///  获取当前登录用户
        /// </summary>
        public static dl_basic_user CurrentUser
        {
            get { return (HttpContext.Current.Session["user"] as dl_basic_user); }
        }
        public static string EnvironmentPath
        {
            get { return HttpContext.Current.Server.MapPath("~"); }
        }
    }
}