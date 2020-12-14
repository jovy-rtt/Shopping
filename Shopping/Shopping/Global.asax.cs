using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Data.Entity;
using Shopping.CS_Init;
using Shopping.Models;

namespace Shopping
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            /*
           作者：                zmx
           创建时间：            2020/12/14
           函数功能：            重写Seed方法，用于初始化数据库
           入口参数：            数据库上下文类
         */
            //realease时要删除
            Database.SetInitializer<PeachMd>(new PeachData_init());

            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
