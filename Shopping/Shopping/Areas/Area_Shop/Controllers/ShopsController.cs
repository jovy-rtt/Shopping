using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Shopping.Models;

namespace Shopping.Areas.Area_Shop.Controllers
{
    public class ShopsController : Controller
    {
        private PeachMd db = new PeachMd();

        // GET: Area_Shop/Shops
        public ActionResult Index()
        {
            var shop = db.Shop.Include(s => s.User);
            return View(shop.ToList());
        }


        //上传图片
        //[HttpPost]
        //public ActionResult UploadImg()
        //{


        //    if (Request.Files.Count > 0)
        //    {
        //        HttpPostedFileBase f = Request.Files["图片"];
        //        f.SaveAs(@"~/Images/commodity_pic" + f.FileName);

        //    }
        //    return View();
        //}



        // GET: Area_Shop/Shops/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Shop shop = db.Shop.Find(id);
            if (shop == null)
            {
                return HttpNotFound();
            }
            return View(shop);
        }

        // GET: Area_Shop/Shops/Create
        public ActionResult Create()
        {
            ViewBag.SellerId = new SelectList(db.User, "Id", "Password");
            return View();
        }

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Image,SellerId,Score,Address,CreatTime,LicenseId,FansNumber")] Shop shop)
        {
            if (ModelState.IsValid)
            {
                db.Shop.Add(shop);
                db.SaveChanges();
                
                return RedirectToAction("Index");
            }


            ViewBag.SellerId = new SelectList(db.User, "Id", "Password", shop.SellerId);
            return View(shop);
        }

        // GET: Area_Shop/Shops/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Shop shop = db.Shop.Find(id);
            if (shop == null)
            {
                return HttpNotFound();
            }
            ViewBag.SellerId = new SelectList(db.User, "Id", "Password", shop.SellerId);
            return View(shop);
        }

        // POST: Area_Shop/Shops/Edit/5
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性；有关
        // 更多详细信息，请参阅 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Image,SellerId,Score,Address,CreatTime,LicenseId,FansNumber")] Shop shop)
        {
            if (ModelState.IsValid)
            {
                db.Entry(shop).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.SellerId = new SelectList(db.User, "Id", "Password", shop.SellerId);
            return View(shop);
        }

        // GET: Area_Shop/Shops/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Shop shop = db.Shop.Find(id);
            if (shop == null)
            {
                return HttpNotFound();
            }
            return View(shop);
        }

        // POST: Area_Shop/Shops/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Shop shop = db.Shop.Find(id);
            db.Shop.Remove(shop);
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
