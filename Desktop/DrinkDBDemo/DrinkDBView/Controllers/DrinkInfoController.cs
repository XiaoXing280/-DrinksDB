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
    public class DrinkInfoController : Controller
    {
        static string c = "/DrinkInfo/Index";
        // GET: DrinkInfo
        public ActionResult Index(string DrinkName, int TypeID = 0, int pageize = 5, int curindex = 1)
        {
            int count = 0;
            //方法count变量传引用
            var a = DrinkInfoBll.GetList(new DrinkInfo(), DrinkName, pageize, curindex, out count,TypeID);
            ViewBag.TypeID = new SelectList(DrinkTypeBll.GetList1(new DrinkType()), "TypeID", "TypeName");
            //总页数
            double pagecount = Math.Ceiling(count * 1.0 / pageize);
            ViewBag.pagecount = pagecount;
            ViewBag.curindex = curindex;
            ViewBag.action = "Index";
            return View(a);
        }
        [HttpPost]
        public ActionResult Index(string x, string DrinkName, int TypeID = 0, int pageize = 5, int curindex = 1)
        {
            int count = 0;
            DrinkInfo model = new DrinkInfo();
            //方法count变量传引用
            var a = DrinkInfoBll.GetList(model, DrinkName, pageize, curindex, out count, TypeID);
            ViewBag.TypeID = new SelectList(DrinkTypeBll.GetList1(new DrinkType()), "TypeID", "TypeName", model.TypeID);
            //总页数
            double pagecount = Math.Ceiling(count * 1.0 / pageize);
            ViewBag.DrinkName = DrinkName;
            ViewBag.pagecount = pagecount;
            ViewBag.curindex = curindex;
            ViewBag.action = "Index";
            return View(a);
        }
        public ActionResult Edit(int DrinkID = 0, string url = "")
        {
            DrinkInfo model = new DrinkInfo();
            if (DrinkID > 0)
            {
                model = DrinkInfoBll.GetDrinkInfo(DrinkID);
            }
            ViewBag.TypeID = new SelectList(DrinkTypeBll.GetList1(new DrinkType()), "TypeID", "TypeName", model.TypeID);
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
        public ActionResult Edit(HttpPostedFileBase uploadFileName, string ccc, DrinkInfo model, string url = "")
        {            
            string FileName = uploadFileName.FileName;
            string extension = Path.GetExtension(FileName);
            if (extension == ".jpg" || extension == "jpeg" || extension == ".png")
            {
                if (FileName.LastIndexOf("\\") > -1)
                {
                    FileName = ccc + FileName.Substring(FileName.LastIndexOf("."));
                }
                uploadFileName.SaveAs(Server.MapPath("~/img/DrinkInfoIMG/" + FileName));
                
            }
            else { return Content("<script>alert('文件格式不正确');history.go(-1);</script>"); }
            model.Drinkimg = uploadFileName.FileName;
            if (model.DrinkID > 0)
            {
                DrinkInfoBll.Update(model);
            }
            else
            {
                DrinkInfoBll.Insert(model);
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

        public ActionResult Delete(int DrinkID = 0)
        {
            if (DrinkID > 0)
            {
                DrinkInfoBll.Delete(DrinkID);
            }
            return Redirect("Index");
        }

    }
}