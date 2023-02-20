using DrinkDBModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrinkDBDAL
{
    public class DrinkTypeDal
    {
        public static bool Insert(DrinkType model)
        {
            using (DrinkDBEntities db = new DrinkDBEntities())
            {
                db.DrinkType.Add(model);
                return db.SaveChanges() > 0;
            }
        }
        public static bool Update(DrinkType model)
        {
            using (DrinkDBEntities db = new DrinkDBEntities())
            {
                db.Entry(model).State = System.Data.Entity.EntityState.Modified;
                return db.SaveChanges() > 0;
            }
        }
        public static bool Delete(int TypeID)
        {
            using (DrinkDBEntities db = new DrinkDBEntities())
            {
                var a = db.DrinkType.Find(TypeID);
                db.DrinkType.Remove(a);
                return db.SaveChanges() > 0;
            }
        }
        public static DrinkType GetDrinkType(int TypeID)
        {
            using (DrinkDBEntities db = new DrinkDBEntities())
            {
                return db.DrinkType.Find(TypeID);
            }
        }
        public static List<DrinkType> GetList1(DrinkType modelwhere)
        {
            using (DrinkDBEntities db = new DrinkDBEntities())
            {
                var lists = db.DrinkType;
                lists.Where(o => string.IsNullOrEmpty(modelwhere.TypeName) || o.TypeName.Contains(modelwhere.TypeName));
                return lists.ToList();
            }
        }
        public static List<DrinkType> GetList(DrinkType modelwhere, int pageize, int curindex, out int num)
        {
            using (DrinkDBEntities db = new DrinkDBEntities())
            {
                var lists = db.DrinkType.Where(o => string.IsNullOrEmpty(modelwhere.TypeName) || o.TypeName.Contains(modelwhere.TypeName));
                num = lists.Count();
                //分页先排序
                var pages = lists.OrderBy(m => m.TypeID).Skip(pageize * (curindex - 1)).Take(pageize);
                return pages.ToList();
            }
        }

    }
}
