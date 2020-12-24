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

        //GET: Area_Shop/Shops
        public ActionResult Index(int sellerid)
        {
           
            var shop = db.Shop.Include(s => s.User).Where(s=>s.SellerId==sellerid);
            return View(shop.ToList());
        }


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
        public ActionResult Create([Bind(Include = "Id,Name,Image,SellerId,Score,Address,CreatTime,LicenseId,FansNumber")] Shop shop,int sellerid)
        {
            string FileName = DateTime.Now.ToString("yyyyMMddhhmmss");//防止文件夹中出现同名文件
            string DirPath = (@"~\Images\shop_pic\");
            string FilePath = "";
            if (Request.Files.Count > 0)
            {
                HttpPostedFileBase f = Request.Files["shop_pic"];//获得上传的图片
                FilePath = DirPath + f.FileName;//组成要保存到数据库中的路径
                f.SaveAs(FilePath);//将图片保存到本地image相应文件夹下
            }
            else
            {
                FilePath = "/Images/shop_pic/1.jpg";
        }
            shop.Image = FilePath;
            ViewBag.path = FilePath;
            shop.SellerId = sellerid;
            shop.Id = 9;
            //shop.User = db.User;
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
