using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Shopping.Areas.Merchants.Controllers
{
    //商家控制类
    public class MerchantsController : Controller
    {
        // GET: Merchants/Merchants
        public ActionResult Index()
        {
            return View();
        }
    }
}