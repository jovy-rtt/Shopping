using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Shopping.Areas.Buyers.Controllers
{
    //买家控制类
    public class BuyersController : Controller
    {
        // GET: Buyers/Buyers
        public ActionResult Index()
        {
            return View();
        }
    }
}