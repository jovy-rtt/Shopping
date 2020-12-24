using Shopping.CS_Init;
using Shopping.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Shopping.Controllers
{
    public class CustomerController : Controller
    {
        PeachMd db = new PeachMd();
        // GET: Customer
        public ActionResult Index(string id)
        {
            if (id == null)
                id = "Index";
            if (Request.IsAjaxRequest())
                return PartialView(id);
            return PartialView(id);
        }
        public ActionResult LoginForm()
        {
            return View();
        }

        /*
            作者：zmx
            时间：2020/12/23
            功能：跳转到支付界面
         */

        public ActionResult Pay()
        {
            var q = from t in db.DeliveryAddress
                    where t.UserId == UserLoginstate.usstate.Id
                    select t;
            //正式启用时要取消注释
            //db.DeliveryAddress = (System.Data.Entity.DbSet<DeliveryAddress>)q;
            UserLoginstate.mypeach = db;
            return Isajax("Pay", UserLoginstate.mypeach);
        }

        /*
            作者：zmx
            时间：2020/12/23
            功能：跳转到支付完成界面
         */

        public ActionResult PayOver()
        {
            return Isajax("PayOver");
        }

        #region 可以共用的方法
        //自定义的一个方法，自动返回视图
        public ActionResult Isajax(string name)
        {
            if (Request.IsAjaxRequest())
                return PartialView(name);
            return View(name);
        }
        //重载Isajax方法，自动放回视图
        public ActionResult Isajax(string name, object model)
        {
            if (Request.IsAjaxRequest())
                return PartialView(name, model);
            return View(name, model);
        }
        #endregion
    }
}