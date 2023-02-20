using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DrinkDBModel;

namespace DrinkDBDAL
{
    public class MessInfoDal
    {
        public static bool Insert(MessInfo model)
        {
            using (DrinkDBEntities db = new DrinkDBEntities())
            {
                db.MessInfo.Add(model);
                return db.SaveChanges() > 0;
            }
        }
        public static bool Update(MessInfo model)
        {
            using (DrinkDBEntities db = new DrinkDBEntities())
            {
                db.Entry(model).State = System.Data.Entity.EntityState.Modified;
                return db.SaveChanges() > 0;
            }
        }
        public static bool Delete(int MessID)
        {
            using (DrinkDBEntities db = new DrinkDBEntities())
            {
                var a = db.MessInfo.Find(MessID);
                db.MessInfo.Remove(a);
                return db.SaveChanges() > 0;
            }
        }
        public static MessInfo GetMessInfo(int MessID)
        {
            using (DrinkDBEntities db = new DrinkDBEntities())
            {
                return db.MessInfo.Find(MessID);
            }
        }
        public static List<MessInfo> GetList(MessInfo modelwhere, string MessNum, int pageize, int curindex, out int num)
        {
            using (DrinkDBEntities db = new DrinkDBEntities())
            {
                var lists = db.MessInfo;
                if (!string.IsNullOrEmpty(MessNum))
                {
                    var a = lists.Where(t => t.MessNum.Contains(MessNum));
                    a= a.OrderBy(m => m.MessID).Skip(pageize * (curindex - 1)).Take(pageize);
                    num = a.Count();
                    return a.ToList();
                }
                var list= lists.Where(o => string.IsNullOrEmpty(modelwhere.MessPwd) || o.MessNum.Contains(modelwhere.MessNum));
                num = list.Count();
                //分页先排序
                var pages = list.OrderBy(m => m.MessID).Skip(pageize * (curindex - 1)).Take(pageize);
                return pages.ToList();
            }
        }
        public static List<MessInfo> GetList(string MessNum)
        {
            using (DrinkDBEntities db = new DrinkDBEntities())
            {
                var lists = db.MessInfo;
                if (!string.IsNullOrEmpty(MessNum))
                {
                    var a = db.MessInfo.Where(t => t.MessNum.Contains(MessNum));
                    return a.ToList();
                }
                return lists.ToList();
            }
        }
        public static MessInfo Login(MessInfo modelwhere)
        {
            using (DrinkDBEntities db = new DrinkDBEntities())
            {
                return db.MessInfo.Where(t => t.MessNum == modelwhere.MessNum && t.MessPwd == modelwhere.MessPwd).FirstOrDefault();
            }
        }
    }
}
