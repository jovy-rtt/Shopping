using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Shopping.Models;

namespace Shopping.Areas.Area_Commodity.Controllers
{
    public class CommoditiesController : Controller
    {
        private PeachMd db = new PeachMd();

        // GET: Area_Commodity/Commodities
        public ActionResult Index()
        {
            return View(db.Commodity.ToList());
        }

        /// <summary>
        /// 作者：                gz
        /// 创建时间：            2020/12/22
        /// 函数功能：            管理用户左下菜单的视图
        /// 入口参数：            视图ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult UserLeftIndex(string id)
        {
            if (id == null)
                id = "Index";
            if (Request.IsAjaxRequest())
                return PartialView(id);
            return PartialView(id);
        }

        // GET: Area_Commodity/Commodities/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Commodity commodity = db.Commodity.Find(id);
            if (commodity == null)
            {
                return HttpNotFound();
            }
            return View(commodity);
        }

        // GET: Area_Commodity/Commodities/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Area_Commodity/Commodities/Create
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性；有关
        // 更多详细信息，请参阅 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Type,Image,Price,Number,Introduction")] Commodity commodity)
        {
            if (ModelState.IsValid)
            {
                db.Commodity.Add(commodity);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(commodity);
        }

        // GET: Area_Commodity/Commodities/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Commodity commodity = db.Commodity.Find(id);
            if (commodity == null)
            {
                return HttpNotFound();
            }
            return View(commodity);
        }

        // POST: Area_Commodity/Commodities/Edit/5
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性；有关
        // 更多详细信息，请参阅 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Type,Image,Price,Number,Introduction")] Commodity commodity)
        {
            if (ModelState.IsValid)
            {
                db.Entry(commodity).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(commodity);
        }

        // GET: Area_Commodity/Commodities/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Commodity commodity = db.Commodity.Find(id);
            if (commodity == null)
            {
                return HttpNotFound();
            }
            return View(commodity);
        }

        // POST: Area_Commodity/Commodities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Commodity commodity = db.Commodity.Find(id);
            db.Commodity.Remove(commodity);
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
    }
}
