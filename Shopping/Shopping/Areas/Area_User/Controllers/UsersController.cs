using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Shopping.Models;

namespace Shopping.Areas.Area_User.Controllers
{
    public class UsersController : Controller
    {
        private PeachMd db = new PeachMd();

        //us是为了判断用于是否已经登录，如果已经登录，那么us中始终会有这个信息，所以登出的时候，需要把us再此设置为null
        User us=null;

        // GET: Area_User/Users
        //public ActionResult Index()
        //{
        //    return View(db.User.ToList());
        //}

        /*
            作者：zmx
            时间：2020/12/20
            功能：查看用户信息
            第一次修改
         */
        public ActionResult Index()
        {
            //为空证明用户还未登录
            if (us == null)
            {
                return isajax("userLogin");
            }
            return isajax("userInfo");
        }

        //自定义的一个方法，自动返回视图
        public ActionResult isajax(string name)
        {
            if (Request.IsAjaxRequest())
                return PartialView(name);
            return View(name);
        }
        //用户等录
        /*
            作者：zmx
            时间：2020/12/20
            功能：实现用户的登录功能
         */
        [HttpPost]
        public ActionResult userLogin()
        {
            int account;
            //尝试获取账号信息，账号信息是int类型
            try
            {
                account = int.Parse(Request.Form["Account"]);
            }catch
            {
                //失败
                return isajax("userLogin");
            }


            var passwd = Request.Form["Password"];
            var q = from t in db.User
                    where t.Id == account
                    select t;

            if(q!=null)
            {
                //如果账号密码没错，那么us就可以等于该条信息
                var tmp = q.FirstOrDefault();
                if(tmp.TType=="买家" &&tmp.Password==passwd)
                         us = tmp;
            }
            if (us == null)
                return PartialView("userLogin");
            return View("userInfo",us);
        }

        // GET: Area_User/Users/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.User.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // GET: Area_User/Users/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Area_User/Users/Create
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性；有关
        // 更多详细信息，请参阅 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Password,IdCard,PhoneNumber,Name,Sex,Birthday,MailBox,Sign,TType")] User user)
        {
            if (ModelState.IsValid)
            {
                db.User.Add(user);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(user);
        }

        // GET: Area_User/Users/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.User.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: Area_User/Users/Edit/5
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性；有关
        // 更多详细信息，请参阅 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Password,IdCard,PhoneNumber,Name,Sex,Birthday,MailBox,Sign,TType")] User user)
        {
            if (ModelState.IsValid)
            {
                db.Entry(user).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(user);
        }

        // GET: Area_User/Users/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.User.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: Area_User/Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            User user = db.User.Find(id);
            db.User.Remove(user);
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
