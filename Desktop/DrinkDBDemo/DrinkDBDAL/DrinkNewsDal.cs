using DrinkDBModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrinkDBDAL
{
    public class DrinkNewsDal
    {
        static DrinkDBEntities db = new DrinkDBEntities();
        public static bool Insert(DrinkNews model)
        {
            using (DrinkDBEntities db = new DrinkDBEntities())
            {
                db.DrinkNews.Add(model);
                return db.SaveChanges() > 0;
            }
        }
        public static bool Update(DrinkNews model)
        {
            using (DrinkDBEntities db = new DrinkDBEntities())
            {
                db.Entry(model).State = System.Data.Entity.EntityState.Modified;
                return db.SaveChanges() > 0;
            }
        }
        public static bool Delete(int DrinkID)
        {
            using (DrinkDBEntities db = new DrinkDBEntities())
            {
                var a = db.DrinkNews.Find(DrinkID);
                db.DrinkNews.Remove(a);
                return db.SaveChanges() > 0;
            }
        }
        public static DrinkNews GetDrinkNews(int DrinkID)
        {
            return db.DrinkNews.Find(DrinkID);
        }

        public static List<DrinkNews> GetList(DrinkNews modelwhere, string NewsName, int pageize, int curindex, out int num)
        {
            using (DrinkDBEntities db = new DrinkDBEntities())
            {
                var lists = db.DrinkNews.Include("DrinkInfo").Include("UserInfo");
                if (!string.IsNullOrEmpty(NewsName))
                {
                    var a = lists.Where(t => t.NewsName.Contains(NewsName));
                    a = a.OrderBy(m => m.NewsID).Skip(pageize * (curindex - 1)).Take(pageize);
                    num = a.Count();
                    return a.ToList();
                }
                var list= lists.Where(o => string.IsNullOrEmpty(modelwhere.NewsName) || o.NewsName.Contains(modelwhere.NewsName));
                num = list.Count();
                //分页先排序
                var pages = list.OrderBy(m => m.NewsID).Skip(pageize * (curindex - 1)).Take(pageize);
                return pages.ToList();
            }
        }
    }
}
