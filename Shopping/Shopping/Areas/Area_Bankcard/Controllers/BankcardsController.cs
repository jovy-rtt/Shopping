using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Shopping.Models;

namespace Shopping.Areas.Area_Bankcard.Controllers
{
    public class BankcardsController : Controller
    {
        private PeachMd db = new PeachMd();
        #region 商家管理操作
        [HttpGet]
        public ActionResult SellerCreateBank()
        {
            return PartialView();
        }
        [HttpPost]
        public ActionResult SellerCreateBank(Bankcard bc)
        {
            int n = db.Bankcard.Count();
            bc.Id = n + 1;
            bc.Money = 0;
            bc.UserID = int.Parse(Session["userid"].ToString());
            db.Bankcard.Add(bc);
            db.SaveChanges();
            ViewBag.message = "银行卡添加成功！";
            Session.Add("Bankid", bc.Id);
            Session.Add("Bankac", bc.BankAcount);
            Session.Add("Bankmo", bc.Money);
            return PartialView("SellerShowBank");
        }
        public ActionResult SellerShowBank(int? id)
        {
            //int n = int.Parse(Session["userid"].ToString());
            var q = from w in db.Bankcard
                    where w.UserID == id
                    select w;
            
            if (q.Count()>0)
            {
                var us = q.First();
                Session.Add("Bankid", us.Id);
                Session.Add("Bankac", us.BankAcount);
                Session.Add("Bankmo", us.Money);
                return PartialView();
            }
            else
            {
                Session.Add("Bankid", null);
                Session.Add("Bankac", null);
                Session.Add("Bankmo", null);
                ViewBag.message = "没有银行卡，请添加银行卡！";
                return PartialView();
            }
           
        }
        #endregion
        // GET: Area_Bankcard/Bankcards
        public ActionResult Index()
        {
            var bankcard = db.Bankcard.Include(b => b.User);
            return View(bankcard.ToList());
        }

        // GET: Area_Bankcard/Bankcards/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bankcard bankcard = db.Bankcard.Find(id);
            if (bankcard == null)
            {
                return HttpNotFound();
            }
            return View(bankcard);
        }

        // GET: Area_Bankcard/Bankcards/Create
        public ActionResult Create()
        {
            ViewBag.UserID = new SelectList(db.User, "Id", "Password");
            return View();
        }

        // POST: Area_Bankcard/Bankcards/Create
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性；有关
        // 更多详细信息，请参阅 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,UserID,IdCard,Birthday,BankPassword,BankName,BankShortName,logo,BankTel,Money,BankWebSite,BankCode,PhoneNumber")] Bankcard bankcard)
        {
            if (ModelState.IsValid)
            {
                db.Bankcard.Add(bankcard);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.UserID = new SelectList(db.User, "Id", "Password", bankcard.UserID);
            return View(bankcard);
        }

        // GET: Area_Bankcard/Bankcards/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bankcard bankcard = db.Bankcard.Find(id);
            if (bankcard == null)
            {
                return HttpNotFound();
            }
            ViewBag.UserID = new SelectList(db.User, "Id", "Password", bankcard.UserID);
            return View(bankcard);
        }

        // POST: Area_Bankcard/Bankcards/Edit/5
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性；有关
        // 更多详细信息，请参阅 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,UserID,IdCard,Birthday,BankPassword,BankName,BankShortName,logo,BankTel,Money,BankWebSite,BankCode,PhoneNumber")] Bankcard bankcard)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bankcard).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.UserID = new SelectList(db.User, "Id", "Password", bankcard.UserID);
            return View(bankcard);
        }

        // GET: Area_Bankcard/Bankcards/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bankcard bankcard = db.Bankcard.Find(id);
            if (bankcard == null)
            {
                return HttpNotFound();
            }
            return View(bankcard);
        }

        // POST: Area_Bankcard/Bankcards/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Bankcard bankcard = db.Bankcard.Find(id);
            db.Bankcard.Remove(bankcard);
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
