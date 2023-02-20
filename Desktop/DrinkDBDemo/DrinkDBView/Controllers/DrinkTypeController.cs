using DrinkDBBLL;
using DrinkDBModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DrinkDBView.Controllers
{
    public class DrinkTypeController : Controller
    {
        // GET: DrinkType
        public ActionResult Index(int pageize = 5, int curindex = 1)
        {
            int count = 0;
            //方法count变量传引用
            var a = DrinkTypeBll.GetList(new DrinkType(),pageize, curindex, out count);
            //总页数
            double pagecount = Math.Ceiling(count * 1.0 / pageize);
            ViewBag.pagecount = pagecount;
            ViewBag.curindex = curindex;
            ViewBag.action = "Index";
            return View(a);
        }
        public ActionResult Edit(int TypeID = 0)
        {
            DrinkType model = new DrinkType();
            if (TypeID > 0)
            {
                model = DrinkTypeBll.GetDrinkType(TypeID);
            }
            return View(model);

        }
        [HttpPost]
        public ActionResult Edit(DrinkType model)
        {
            if (model.TypeID > 0)
            {
                DrinkTypeBll.Update(model);
            }
            else
            {
                DrinkTypeBll.Insert(model);
            }
            return Redirect("Index");
        }
        public ActionResult Delete(int TypeID = 0)
        {
            if (TypeID > 0)
            {
                DrinkTypeBll.Delete(TypeID);
            }
            return Redirect("Index");
        }
    }
}