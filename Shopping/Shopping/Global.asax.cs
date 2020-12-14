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
           ���ߣ�                zmx
           ����ʱ�䣺            2020/12/14
           �������ܣ�            ��дSeed���������ڳ�ʼ�����ݿ�
           ��ڲ�����            ���ݿ���������
         */
            //realeaseʱҪɾ��
            Database.SetInitializer<PeachMd>(new PeachData_init());

            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
