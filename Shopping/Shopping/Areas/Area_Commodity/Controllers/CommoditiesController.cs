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

        #region 用户相关操作自定义方法
        //数据上下文类
        private PeachMd dbView = new PeachMd();

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
                id = "UserLeftIndex";
            if (Request.IsAjaxRequest())
                return PartialView(id);
            return PartialView(id);
        }

        /// <summary>
        /// 作者：                 gz
        /// 创建时间：             2020/12/23
        /// 函数功能：             商品查询
        /// 入口参数：             search
        /// </summary>
        /// <param name="search"></param>
        /// <returns></returns>
        public ActionResult CommodityInfo(string search)
        {
            ViewBag.search = search;
            var t = dbView.Commodity.ToList();
            if (string.IsNullOrEmpty(search) == false)
            {
                t = t.Where(m => m.Type.Contains(search) ||
                            m.Name.Contains(search)).ToList();
            }

            if (Request.IsAjaxRequest())
            {
                return PartialView(t);
            }
            return PartialView(t);
        }
        /// <summary>
        /// 作者：             gz
        /// 创建时间：         2020/12/23
        /// 函数功能：         商品详情页
        /// 入口参数：         id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult CommodityDetails(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Commodity commodity = dbView.Commodity.Find(id);
            if (commodity == null)
            {
                return HttpNotFound();
            }
            return PartialView(commodity);
        }
        
        /// <summary>
        /// 作者：             gz
        /// 创建时间：         2020/12/24
        /// 函数功能：         店铺查询
        /// 入口参数：         searchSeller
        /// </summary>
        /// <param name="searchSeller"></param>
        /// <returns></returns>
        public ActionResult SellerInfo(string searchSeller)
        {
            ViewBag.search = searchSeller;
            return PartialView();
        }
        #endregion

        #region 自动生成的原始代码
        private PeachMd db = new PeachMd();

        // GET: Area_Commodity/Commodities
        //public ActionResult Index()
        //{
        //    return View(db.Commodity.ToList());
        //}

        public ActionResult Index(int? id)
        {
            if (id == null)
            {
                return View(db.Commodity.ToList());
            }
            else
            {
                var commodity = db.Commodity.Where(x => x.shopID == id);
                return View(commodity.ToList());
            }

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
            List<SelectListItem> items = new List<SelectListItem>();
            items.Add(new SelectListItem { Text = "男装", Value = "1" });
            items.Add(new SelectListItem { Text = "女装", Value = "2", Selected = true });
            ViewBag.set = items;
            

            return View();
        }

        [HttpPost]
        [ValidateInput(false)]
        //[ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Type,Image,Price,Number,Introduction")] Commodity commodity)
        {
            List<SelectListItem> items = new List<SelectListItem>();
            items.Add(new SelectListItem { Text = "男装", Value = "1" });
            items.Add(new SelectListItem { Text = "女装", Value = "2", Selected = true });
            ViewBag.set = items;

            string FileName = DateTime.Now.ToString("yyyyMMddhhmmss");//防止文件夹中出现同名文件
            string DirPath = (@"~\Images\shop_pic\");
            string FilePath = "";
            if (Request.Files.Count > 0)
            {
                HttpPostedFileBase f = Request.Files["commodity_pic"];//获得上传的图片
                FilePath = DirPath + f.FileName;//组成要保存到数据库中的路径
                f.SaveAs(FilePath);//将图片保存到本地image相应文件夹下
            }
            commodity.Image = FilePath;
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
        #endregion
    }
}
