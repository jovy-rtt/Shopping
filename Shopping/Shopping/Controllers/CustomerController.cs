using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Shopping.Controllers
{
    public class CustomerController : Controller
    {
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
    }
}