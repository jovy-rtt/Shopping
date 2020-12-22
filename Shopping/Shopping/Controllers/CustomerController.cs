using Shopping.CS_Init;
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
            PeachData_init context = new PeachData_init();
            context.InitializeDatabase(new Models.PeachMd());
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