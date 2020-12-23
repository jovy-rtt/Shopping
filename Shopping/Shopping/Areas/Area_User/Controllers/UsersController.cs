using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Shopping.Controllers;
using Shopping.Models;

namespace Shopping.Areas.Area_User.Controllers
{
    public class UsersController : Controller
    {

        #region 买家相关操作自定义方法

        //数据上下文类
        private PeachMd db = new PeachMd();


        //TempData["us"]是为了判断用于是否已经登录，如果已经登录，那么ta中始终会有这个信息，所以登出的时候，需要把ta再此设置为null
        User us=null;

        /* 
            作者：zmx
            时间：2020/12/20
            功能：查看用户信息，点击用户按钮，如果还没登录，则提示登录，否则显示用户信息
            第一次修改
         */
        public ActionResult Index()
        {
            us = (User)TempData["us"];
            //为空证明用户还未登录，否则显示信息
            return us == null ? Isajax("userLogin") : Isajax("userInfo", us);
        }

        /*
            作者：zmx
            时间：2020/12/22
            功能：登出
            第一次修改
         */
        public ActionResult Logout()
        {
            TempData["us"]= us = null;
            //为空证明用户还未登录，否则显示信息
            return us == null ? Isajax("userLogin") : Isajax("userInfo", us);
        }

        /*
         *  用户等录
            作者：zmx
            时间：2020/12/20
            功能：实现用户的登录功能
            Add：
                时间：2020/12/21
                作者：zmx
                功能：添加用户的忘记密码、注册功能
         */
        [HttpPost]
        public ActionResult userLogin()
        {
            //获取登录窗体内点击的按钮
            var tt = Request["btn"];

            if(tt=="注册")
            {
                return Isajax("userCreate");
            }
            if(tt=="忘记密码")
            {
                return Isajax("userForget");
            }


            int account;
            //尝试获取账号信息，账号信息是int类型
            try
            {
                account = int.Parse(Request.Form["Account"]);
            }catch
            {
                //失败
                return Isajax("userLogin");
            }

            //根据账号，密码，类别，找到该条记录
            var passwd = Request.Form["Password"];
            var q = from t in db.User
                    where t.Id == account && t.Password == passwd && t.TType =="买家"
                    select t;
            //找到
            if(q!=null)
                TempData["us"] = us = q.FirstOrDefault();

            return us == null ? Isajax("userLogin") : Isajax("userInfo", us);
        }

        /*
            作者：zmx
            时间：2020/12/21
            功能：忘记密码、找回,成功则返回登录界面，失败则还返回忘记密码界面
         */
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult userForget([Bind(Include = "Id,IdCard,PhoneNumber,Name,Sex,MailBox,Password")] User user)
        {
            //验证通过
            //var q = from t in db.User
            //        where t.Id == user.Id && t.IdCard == user.IdCard && t.PhoneNumber == user.PhoneNumber && t.Name == user.Name && t.Sex == user.Sex
            //       && t.MailBox == user.MailBox
            //        select t;

            /*这一段是test时专用*/
            var q = from t in db.User
                    where t.Id == user.Id
                    select t;

            var tmp = q.FirstOrDefault();
            //为空则失败
            if (tmp == null)
                return Isajax("userForget");

            tmp.Password = user.Password;
        

            db.SaveChanges();
            return Isajax("userLogin");
        }

        /*
            作者：zmx
            时间：2020/12/22
            功能：注册账号、成功则返回登录界面、失败则返回注册界面
         */
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult userCreate([Bind(Include = "Id,Password,IdCard,PhoneNumber,Name,Sex,Birthday,MailBox,Sign,TType")] User user)
        {

            if (ModelState.IsValid)
            {
                db.User.Add(user);
                db.SaveChanges();
                return Isajax("userLogin");
            }

            return Isajax("userCreate");
        }
        #endregion

        #region 商家相关操作自定义方法
        //商家注册
        [HttpGet]
        public ActionResult SellerCreate()
        {
            return View("SellerCreate");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SellerCreate(User user)
        {
            int n = db.User.Count();
            user.Id = n + 1;
            user.IdCard = "S" + user.Id.ToString();
            user.TType = "商家";
            db.User.Add(user);
            db.SaveChanges();
            return View("CreateWin",user);
        }
        //注册成功
        public ActionResult CreateWin()
        {
            return View();
        }
        //商家登录
        [HttpGet]
        public ActionResult SellerLogin()
        {
            return View("SellerLogin");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SellerLogin(User user)
        {
            int account;
            //尝试获取账号信息，账号信息是int类型
            try
            {
                account = int.Parse(Request["userid"]);
            }
            catch
            {
                //失败
                ViewBag.message = "账号错误!";
                return View("SellerLogin");
            }

            //根据账号，密码，类别，找到该条记录
            var passwd = Request["userpwd"];
            var q1 =  from w in db.User
                      where w.Id == account && w.TType == "商家"
                      select w;
            //找到
            if (q1.Count()>0)
            {
                var us = q1.First();
                if(us.Password!=passwd)
                {
                    ViewBag.message = "密码错误!";
                    return View("SellerLogin");
                }
                else
                {
                    Session.Add("userid", us.Id);
                    Session.Add("username", us.Name);
                    return Redirect("/Seller/Index");
                }
            }
            else
            {
                ViewBag.message = "账号或密码错误!";
                return View("SellerLogin");
            }
        }
        //退出账户
        public ActionResult LoginOut()
        {
            Session.Remove("username");
            Session.Remove("userid");
            return Redirect("/Area_User/Users/SellerLogin");
        }

        //修改密码
        [HttpGet]
        public ActionResult SellerEditPwd()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SellerEditPwd(User user)
        {
            int account;
            if(Session["userid"]==null)
            {
                ViewBag.message = "请先进行登录";
                return View();
            }
            else
            {
                account = int.Parse(Session["userid"].ToString());
                var q1 = from w in db.User
                         where w.Id == account
                         select w;
                if(q1.Count()>0)
                {
                    var us = q1.First();
                    string s = Request["pwd"];
                    string s1 = Request["pwd1"];
                    string s2 = Request["pwd2"];
                    if(s1!=s2)
                    {
                        ViewBag.message = "重置密码不一致";
                    }
                    if(s==us.Password)
                    {
                        us.Password = s1;
                        db.SaveChanges();
                        ViewBag.message = "修改成功，请重新登录";
                        Session.Remove("username");
                        Session.Remove("userid");
                        return View();
                    }
                    return View();
                }
                else
                {
                    ViewBag.message = "修改失败";
                    return View();
                }
            }
        }

        public ActionResult SellerDetail()
        {
            int account;
            account = int.Parse(Session["useerid"].ToString());
            var q1 = from w in db.User
                     where w.Id == account
                     select w;
            if (q1.Count() > 0)
            {
                var us = q1.First();
                return View(us);
            }
            else
            {
                return View();
            }
                
        }
        #endregion

        #region 自动生成的原始代码
        // GET: Area_User/Users
        //public ActionResult Index()
        //{
        //    return View(db.User.ToList());
        //}

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
            return Isajax("Create");
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
        #endregion

        #region 可以共用的方法
        //自定义的一个方法，自动返回视图
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
