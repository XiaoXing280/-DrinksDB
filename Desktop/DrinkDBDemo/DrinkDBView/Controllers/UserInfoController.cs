using DrinkDBBLL;
using DrinkDBModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DrinkDBView.Controllers
{
    public class UserInfoController : Controller
    {
        // GET: UserInfo
        public ActionResult Index(string UserNum, int pageize = 5, int curindex = 1)
        {
            int count = 0;
            //方法count变量传引用
            var a = UserInfoBll.GetList(new UserInfo(), UserNum, pageize, curindex, out count);
            //总页数
            double pagecount = Math.Ceiling(count * 1.0 / pageize);
            ViewBag.pagecount = pagecount;
            ViewBag.curindex = curindex;
            ViewBag.action = "Index";
            return View(a);
        }
        [HttpPost]
        public ActionResult Index(string sxx, string UserNum, int pageize = 5, int curindex = 1)
        {
            int count = 0;
            //方法count变量传引用
            var a = UserInfoBll.GetList(new UserInfo(), UserNum, pageize, curindex, out count);
            //总页数
            double pagecount = Math.Ceiling(count * 1.0 / pageize);
            ViewBag.UserNum = UserNum;
            ViewBag.pagecount = pagecount;
            ViewBag.curindex = curindex;
            ViewBag.action = "Index";
            return View(a);
        }
        public ActionResult Edit(int UserID= 0)
        {
            UserInfo model = new UserInfo();
            if (UserID > 0)
            {
                model = UserInfoBll.GetUserInfo(UserID);
            }
            return View(model);
        }
        [HttpPost]
        public ActionResult Edit(UserInfo model)
        {
            if (model.UserID > 0)
            {
                UserInfoBll.Update(model);
            }
            else
            {
                UserInfoBll.Insert(model);
            }
            return Redirect("/UserInfo/Index");
        }

        public ActionResult Delete(int UserID = 0)
        {
            if (UserID > 0)
            {
                UserInfoBll.Delete(UserID);
            }
            return Redirect("Index");
        }
    }
}