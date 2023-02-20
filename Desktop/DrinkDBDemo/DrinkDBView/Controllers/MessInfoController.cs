using DrinkDBBLL;
using DrinkDBModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DrinkDBView.Controllers
{
    public class MessInfoController : Controller
    {
        // GET: MessInfo
        public ActionResult Index(string MessNum, int pageize = 5, int curindex = 1)
        {
            int count = 0;
            //方法count变量传引用
            var a = MessInfoBll.GetList(new MessInfo(), MessNum, pageize, curindex, out count);
            //总页数
            double pagecount = Math.Ceiling(count * 1.0 / pageize);
            ViewBag.pagecount = pagecount;
            ViewBag.curindex = curindex;
            ViewBag.action = "Index";
            return View(a);
        }

        [HttpPost]
        public ActionResult Index(string sxx,string MessNum, int pageize = 5, int curindex = 1)
        {
            int count = 0;
            //方法count变量传引用
            var a = MessInfoBll.GetList(new MessInfo(),MessNum, pageize, curindex, out count);
            //总页数
            double pagecount = Math.Ceiling(count * 1.0 / pageize);
            ViewBag.MessNum = MessNum;
            ViewBag.pagecount = pagecount;
            ViewBag.curindex = curindex;
            ViewBag.action = "Index";
            return View(a);
        }
        public ActionResult Edit(int MessID = 0)
        {
            MessInfo model = new MessInfo();
            if (MessID > 0)
            {
                model = MessInfoBll.GetMessInfo(MessID);
            }
            return View(model);

        }
        [HttpPost]
        public ActionResult Edit(MessInfo model)
        {
            if (model.MessID > 0)
            {
                MessInfoBll.Update(model);
            }
            else
            {
                MessInfoBll.Insert(model);
            }
            return Redirect("Index");
        }

        public ActionResult Delete(int MessID = 0)
        {
            if (MessID > 0)
            {
                MessInfoBll.Delete(MessID);
            }
            return Redirect("Index");
        }

        
        //public ActionResult Index(string MessNum, int pageize = 5, int curindex = 1)
        //{
        //    int count = 0;
        //    //方法count变量传引用
        //    var a = MessInfoBll.GetList(new MessInfo(), pageize, curindex, out count, MessNum);
        //    //总页数
        //    double pagecount = Math.Ceiling(count * 1.0 / pageize);
        //    ViewBag.pagecount = pagecount;
        //    ViewBag.curindex = curindex;
        //    ViewBag.action = "Index";
        //    return View(a);
        //}
    }
}