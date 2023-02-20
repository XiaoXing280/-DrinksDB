using DrinkDBBLL;
using DrinkDBModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DrinkDBView.Controllers
{
    public class DrinkNewsController : Controller
    {
        static string c = "/DrinkNews/Index";
        // GET: DrinkNews
        public ActionResult Index(string NewsName, int pageize = 5, int curindex = 1)
        {
            int count = 0;
            //方法count变量传引用
            var a = DrinkNewsBll.GetList(new DrinkNews(), NewsName, pageize, curindex, out count);
            //总页数
            double pagecount = Math.Ceiling(count * 1.0 / pageize);
            ViewBag.pagecount = pagecount;
            ViewBag.curindex = curindex;
            ViewBag.action = "Index";
            return View(a);
        }
        [HttpPost]
        public ActionResult Index(string x, string NewsName, int pageize = 5, int curindex = 1)
        {
            int count = 0;
            //方法count变量传引用
            var a = DrinkNewsBll.GetList(new DrinkNews(), NewsName, pageize, curindex, out count);
            double pagecount = Math.Ceiling(count * 1.0 / pageize);
            ViewBag.NewsName = NewsName;
            ViewBag.pagecount = pagecount;
            ViewBag.curindex = curindex;
            ViewBag.action = "Index";
            return View(a);
        }
        public ActionResult Edit(int NewsID = 0, string url = "")
        {
            DrinkNews model = new DrinkNews();
            if (NewsID > 0)
            {
                model = DrinkNewsBll.GetDrinkNews(NewsID);
            }
            ViewBag.DrinkID = new SelectList(DrinkInfoBll.GetList(new DrinkInfo()), "DrinkID", "DrinkName", model.DrinkID);
            ViewBag.UserID = new SelectList(UserInfoBll.GetList(new UserInfo()), "UserID", "UserNum", model.UserID);
            if (string.IsNullOrEmpty(url))
            {
                ViewBag.URL = c;
            }
            else
            {
                ViewBag.URL = url;
            }
            return View(model);
        }
        [HttpPost]
        public ActionResult Edit(HttpPostedFileBase uploadFileName, string ccc, DrinkNews model, string url = "")
        {
            string FileName = uploadFileName.FileName;
            string extension = Path.GetExtension(FileName);
            if (extension == ".jpg" || extension == ".jpeg" || extension == ".png")
            {
                if (FileName.LastIndexOf("\\") > -1)
                {
                    FileName = ccc + FileName.Substring(FileName.LastIndexOf("."));
                }
                uploadFileName.SaveAs(Server.MapPath("~/img/DrinkNewsIMG/" + FileName));
                model.Newsimg = uploadFileName.FileName;
            }
            else { return Content("<script>alert('文件格式不正确,请重新选择');history.go(-1);</script>"); }
            ViewBag.NewsTime = DateTime.Parse(model.NewsTime.ToString());
            if (model.NewsID > 0)
            {
                DrinkNewsBll.Update(model);
            }
            else
            {
                DrinkNewsBll.Insert(model);
            }
            if (string.IsNullOrEmpty(url))
            {
                ViewBag.URL = c; 
                return Redirect(c);
            }
            else
            {
                ViewBag.URL = url;
                return Redirect(url);
            }
        }

        public ActionResult Delete(int NewsID = 0)
        {
            if (NewsID > 0)
            {
                DrinkNewsBll.Delete(NewsID);
            }
            return Redirect("Index");
        }
    }
}