using DrinkDBModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrinkDBDAL
{
    public class DrinkInfoDal
    {
        public static bool Insert(DrinkInfo model)
        {
            using (DrinkDBEntities db = new DrinkDBEntities())
            {
                db.DrinkInfo.Add(model);
                return db.SaveChanges() > 0;
            }
        }
        public static bool Update(DrinkInfo model)
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
                var a = db.DrinkInfo.Find(DrinkID);
                db.DrinkInfo.Remove(a);
                return db.SaveChanges() > 0;
            }
        }
        public static DrinkInfo GetDrinkInfo(int DrinkID)
        {
            using (DrinkDBEntities db = new DrinkDBEntities())
            {
                return db.DrinkInfo.Find(DrinkID);
            }
        }
        public static List<DrinkInfo> GetList(DrinkInfo modelwhere, string DrinkName, int pageize, int curindex, out int num, int TypeID = 0)
        {
            using (DrinkDBEntities db = new DrinkDBEntities())
            {
                var lists = db.DrinkInfo.Include("DrinkType");
                if (!string.IsNullOrEmpty(DrinkName))
                {
                    var a = lists.Where(t => string.IsNullOrEmpty(DrinkName) || t.DrinkName.Contains(DrinkName));
                    a = a.OrderBy(m => m.DrinkID).Skip(pageize * (curindex - 1)).Take(pageize);
                    num = a.Count();
                    return a.ToList();
                }
                var list = lists.Where(o => string.IsNullOrEmpty(modelwhere.DrinkName) || o.DrinkName.Contains(modelwhere.DrinkName))
                    .Where(t => TypeID == 0 || t.TypeID == TypeID);
                num = list.Count();
                //分页先排序
                var pages = list.OrderBy(m => m.DrinkID).Skip(pageize * (curindex - 1)).Take(pageize);
                return pages.ToList();
            }
        }
        public static List<DrinkInfo> GetList(DrinkInfo modelwhere)
        {
            using (DrinkDBEntities db = new DrinkDBEntities())
            {
                var lists = db.DrinkInfo.Include("DrinkType");
                lists.Where(o => string.IsNullOrEmpty(modelwhere.DrinkName) || o.DrinkName.Contains(modelwhere.DrinkName));
                return lists.ToList();
            }
        }

    }
}
