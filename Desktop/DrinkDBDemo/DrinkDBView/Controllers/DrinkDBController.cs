using DrinkDBBLL;
using DrinkDBModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DrinkDBView.Controllers
{
    public class DrinkDBController : Controller
    {
        static int id = 0;
        static string name = "请登录";
        // GET: DrinkDB
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult xinwen1()
        {
            return View();
        }
        public ActionResult xinwen2()
        {
            return View();
        }
        public ActionResult xinwen3()
        {
            return View();
        }
        //首页
        public ActionResult Main()
        {
            if (id == 0)
            {
                ViewBag.Text = name;
                return RedirectToAction("Login");
            }
            else
            {
                ViewBag.Text = name;
                return View();
            }

        }
        //饮品新时代
        public ActionResult News(string NewsName, int pageize = 5, int curindex = 1)
        {
            if (id == 0)
            {
                ViewBag.Text = name;
                return RedirectToAction("Login");
            }
            else
            {
                int count = 0;
                //方法count变量传引用
                var a = DrinkNewsBll.GetList(new DrinkNews(), NewsName, pageize, curindex, out count);
                //总页数
                double pagecount = Math.Ceiling(count * 1.0 / pageize);
                ViewBag.pagecount = pagecount;
                ViewBag.curindex = curindex;
                ViewBag.Text = name;
                ViewBag.action = "News";
                return View(a);
            }
        }
        [HttpPost]
        public ActionResult News(string NewsName, string x, int pageize = 5, int curindex = 1)
        {
            int count = 0;
            //方法count变量传引用
            var a = DrinkNewsBll.GetList(new DrinkNews(), NewsName, pageize, curindex, out count);
            //总页数
            double pagecount = Math.Ceiling(count * 1.0 / pageize);
            ViewBag.NewsName = NewsName;
            ViewBag.pagecount = pagecount;
            ViewBag.curindex = curindex;
            ViewBag.Text = name;
            ViewBag.action = "News";
            return View(a);
        }
        public ActionResult NewsMessage(int NewsID=0) 
        {
            ViewBag.Text = name;
            DrinkNews model = new DrinkNews();
            if (NewsID > 0)
            {
                model = DrinkNewsBll.GetDrinkNews(NewsID);
            }
            return View(model);
        }
        //饮品科普
        public ActionResult DrinkXT(string DrinkName, int TypeID = 0, int pageize = 5, int curindex = 1)
        {
            if (id == 0)
            {
                ViewBag.Text = name;
                return RedirectToAction("Login");
            }
            else
            {
                int count = 0;
                //方法count变量传引用
                var a = DrinkInfoBll.GetList(new DrinkInfo(), DrinkName, pageize, curindex, out count,TypeID);
                ViewBag.TypeID = new SelectList(DrinkTypeBll.GetList1(new DrinkType()), "TypeID", "TypeName", TypeID);
                //总页数
                double pagecount = Math.Ceiling(count * 1.0 / pageize);
                ViewBag.pagecount = pagecount;
                ViewBag.curindex = curindex;
                ViewBag.action = "DrinkXT";
                ViewBag.Text = name;
                return View(a);
            }
        }
        [HttpPost]
        public ActionResult DrinkXT(string DrinkName,string x, int TypeID=0, int pageize = 5, int curindex = 1)
        {
            int count = 0;
            //方法count变量传引用
            var a = DrinkInfoBll.GetList(new DrinkInfo(), DrinkName, pageize, curindex, out count,TypeID);
            ViewBag.TypeID = new SelectList(DrinkTypeBll.GetList1(new DrinkType()), "TypeID", "TypeName", TypeID);
            //总页数
            double pagecount = Math.Ceiling(count * 1.0 / pageize);
            ViewBag.pagecount = pagecount;
            ViewBag.curindex = curindex;
            ViewBag.action = "DrinkXT";
            ViewBag.Text = name;
            return View(a);
        }
        //科普管理
        /// <summary>
        /// 管理员
        /// </summary>
        /// <param name="DrinkName"></param>
        /// <param name="pageize"></param>
        /// <param name="curindex"></param>
        /// <returns></returns>
        public ActionResult XTguanli()
        {
            if (id == 0)
            {
                ViewBag.Text = name;
                return RedirectToAction("Login");
            }
            else if (id == 2)
            {
                ViewBag.Text = name;
                return RedirectToAction("XTguanliUser");
            }
            else
            {
                ViewBag.Text = name;
                return View();
            }
        }
        /// <summary>
        /// 用户
        /// </summary>
        /// <returns></returns>
        public ActionResult XTguanliUser()
        {
            return View();
        }
        //关于我们
        public ActionResult Jianjie()
        {
            if (id == 0)
            {
                ViewBag.Text = name;
                return RedirectToAction("Login");
            }
            else
            {
                ViewBag.Text = name;
                return View();
            }
        }
        //登录
        public ActionResult Login()
        {
            List<SelectListItem> a = new List<SelectListItem>();
            a.Add(new SelectListItem() { Value = "1", Text = "用户" });
            a.Add(new SelectListItem() { Value = "2", Text = "管理员" });
            SelectList list = new SelectList(a, "Value", "Text");
            ViewBag.b = list;
            return View();
        }
        public ActionResult Login1(MessInfo Mmodel, string b)
        {
            UserInfo Umodel = new UserInfo();
            Umodel.UserNum = Mmodel.MessNum;
            Umodel.UserPwd = Mmodel.MessPwd;
            List<SelectListItem> a = new List<SelectListItem>();
            a.Add(new SelectListItem() { Value = "1", Text = "用户" });
            a.Add(new SelectListItem() { Value = "2", Text = "管理员" });
            SelectList list = new SelectList(a, "Value", "Text");
            ViewBag.b = list;
            //用户登录
            if (b == "1")
            {
                var model2 = UserInfoBll.Login(Umodel);
                if (model2 != null && model2.UserID > 0)
                {
                    id = 2;
                    name = model2.UserNum;
                    Response.Write("<script>alert('用户" + model2.UserNum + "登陆成功')</script>");
                    ViewBag.Text = model2.UserNum;
                    return View("Main");
                }
                else
                {
                    Response.Write("<script>alert('账号或密码错误，请重新输入!')</script>");
                    return View("Login");
                }
            }
            //管理员登录
            else if (b == "2")
            {
                var model = MessInfoBll.Login(Mmodel);
                if (model != null && model.MessID > 0)
                {
                    id = 1;
                    name = model.MessNum;
                    Response.Write("<script>alert('管理员" + model.MessNum + "登陆成功')</script>");
                    ViewBag.Text = model.MessNum;
                    return View("Main");
                }
                else
                {
                    Response.Write("<script>alert('账号或密码错误，请重新输入!')</script>");
                    return View("Login");
                }
            }
            else
            {
                Response.Write("<script>alert('请选择登陆操作者')</script>");
                return View("Login");
            }
        }
        //注册
        public ActionResult Register()
        {
            List<SelectListItem> a = new List<SelectListItem>();
            a.Add(new SelectListItem() { Value = "1", Text = "用户" });
            a.Add(new SelectListItem() { Value = "2", Text = "管理员" });
            SelectList list = new SelectList(a, "Value", "Text");
            ViewBag.b = list;
            return View();
        }
        [HttpPost]
        public ActionResult RegisterADD(MessInfo Mmodel, string b)
        {
            UserInfo Umodel = new UserInfo();
            Umodel.UserNum = Mmodel.MessNum;
            Umodel.UserName = Mmodel.MessName;
            Umodel.UserPwd = Mmodel.MessPwd;
            List<SelectListItem> a = new List<SelectListItem>();
            a.Add(new SelectListItem() { Value = "1", Text = "用户" });
            a.Add(new SelectListItem() { Value = "2", Text = "管理员" });
            SelectList list = new SelectList(a, "Value", "Text");
            ViewBag.b = list;
            if (b == "1")
            {
                UserInfoBll.Insert(Umodel);
                return Redirect("Login");
            }
            else if (b == "2")
            {
                MessInfoBll.Insert(Mmodel);
                return Redirect("Login");
            }
            else
            {
                Response.Write("<script>alert('请选择注册的操作者')</script>");
                return View("Register");
            }
        }
    }
}
