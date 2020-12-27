using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Shopping.Models;
using Shopping.CS_Init;

namespace Shopping.Areas.Area_Order.Controllers
{
    public class OrdersController : Controller
    {
        private PeachMd db = new PeachMd();

        #region 商家
        // GET: Area_Order/Orders
        public ActionResult Index()
        {
            var order = db.Order.Include(o => o.Commodity).Include(o => o.User).Include(o => o.User1);
            return View(order.ToList());
        }

        // GET: Area_Order/Orders/Details/5

        //已处理订单
        public ActionResult order_done(int sellerid)
        {
            //var order = db.Order.Include(o => o.Commodity).Include(o => o.User).Include(o => o.User1).Where(o=>o.State == "已完成");
            var order_new = db.Order.Include(o => o.Commodity).Include(o => o.User).Include(o => o.User1).Where(o => o.State == "已完成").Where(o=>o.SellerID== sellerid);
            return View(order_new.ToList());
        }

        //未处理订单
        public ActionResult order_undone(int sellerid)
        {
            var order = db.Order.Include(o => o.Commodity).Include(o => o.User).Include(o => o.User1).Where(o => o.State != "已完成").Where(o => o.SellerID == sellerid);
            return View(order.ToList());
        }

        //订单收益
        public ActionResult profit(int sellerid)
        {
            double profit = 0.0;

            var order = db.Order.Include(o => o.Commodity).Include(o => o.User).Include(o => o.User1).Where(o => o.State == "已完成").Where(o => o.SellerID == sellerid).ToList();
            foreach (var v in order)
            {
                profit += v.Commodity.Price;
            }
            ViewBag.profit = profit;
            
            return View(order.ToList());
        }


        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = db.Order.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            return View(order);
        }

        // GET: Area_Order/Orders/Create
        public ActionResult Create()
        {
            ViewBag.CommodityID = new SelectList(db.Commodity, "Id", "Name");
            ViewBag.CustomerID = new SelectList(db.User, "Id", "Password");
            ViewBag.SellerID = new SelectList(db.User, "Id", "Password");
            return View();
        }

        // POST: Area_Order/Orders/Create
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性；有关
        // 更多详细信息，请参阅 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,State,StartTime,Logistics,CustomerID,SellerID,CommodityID")] Order order)
        {
            if (ModelState.IsValid)
            {
                db.Order.Add(order);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CommodityID = new SelectList(db.Commodity, "Id", "Name", order.CommodityID);
            ViewBag.CustomerID = new SelectList(db.User, "Id", "Password", order.CustomerID);
            ViewBag.SellerID = new SelectList(db.User, "Id", "Password", order.SellerID);
            return View(order);
        }

        // GET: Area_Order/Orders/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = db.Order.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            ViewBag.CommodityID = new SelectList(db.Commodity, "Id", "Name", order.CommodityID);
            ViewBag.CustomerID = new SelectList(db.User, "Id", "Password", order.CustomerID);
            ViewBag.SellerID = new SelectList(db.User, "Id", "Password", order.SellerID);
            return View(order);
        }

        // POST: Area_Order/Orders/Edit/5
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性；有关
        // 更多详细信息，请参阅 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,State,StartTime,Logistics,CustomerID,SellerID,CommodityID")] Order order)
        {
            if (ModelState.IsValid)
            {
                db.Entry(order).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CommodityID = new SelectList(db.Commodity, "Id", "Name", order.CommodityID);
            ViewBag.CustomerID = new SelectList(db.User, "Id", "Password", order.CustomerID);
            ViewBag.SellerID = new SelectList(db.User, "Id", "Password", order.SellerID);
            return View(order);
        }

        // GET: Area_Order/Orders/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = db.Order.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            return View(order);
        }

        // POST: Area_Order/Orders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Order order = db.Order.Find(id);
            db.Order.Remove(order);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        #endregion

        #region 用户订单操作
        //public ActionResult userindex()
        //{
        //    return Isajax("userindex",db.Order.ToList());
        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult userindex(string search)
        {
            TempData["us"] = UserLoginstate.usstate;
            var t = db.Order.ToList();
            if (string.IsNullOrEmpty(search) == false)
            {
                t = t.Where(m => m.comname.Contains(search)).ToList();
            }

            if (Request.IsAjaxRequest())
            {
                return PartialView(t);
            }
            return PartialView(t);
        }


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
