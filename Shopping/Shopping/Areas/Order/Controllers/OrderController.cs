using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Shopping.Areas.Order.Controllers
{
    //订单控制类
    public class OrderController : Controller
    {
        // GET: Order/Order
        public ActionResult Index()
        {
            return View();
        }
    }
}