using DrinkDBModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrinkDBDAL
{
    public class UserInfoDal
    {
        public static bool Insert(UserInfo model)
        {
            using ( DrinkDBEntities db = new  DrinkDBEntities())
            { 
                db.UserInfo.Add(model);
                return db.SaveChanges() > 0;
            }
        }
        public static bool Update(UserInfo model)
        {
            using ( DrinkDBEntities db = new  DrinkDBEntities())
            {
                db.Entry(model).State = System.Data.Entity.EntityState.Modified;
                return db.SaveChanges() > 0;
            }
        }
        public static bool Delete(int UserID)
        {
            using ( DrinkDBEntities db = new  DrinkDBEntities())
            {
                var a = db.UserInfo.Find(UserID);
                db.UserInfo.Remove(a);
                return db.SaveChanges() > 0;
            }
        }
        public static UserInfo GetUserInfo(int UserID)
        {
            using ( DrinkDBEntities db = new  DrinkDBEntities())
            {
                return db.UserInfo.Find(UserID);
            }
        }
        public static List<UserInfo> GetList(UserInfo modelwhere,string UserNum, int pageize, int curindex, out int num)
        {
            using ( DrinkDBEntities db = new  DrinkDBEntities())
            {
                var lists = db.UserInfo;
                if (!string.IsNullOrEmpty(UserNum))
                {
                    var a = lists.Where(t => t.UserNum.Contains(UserNum));
                    a = a.OrderBy(m => m.UserID).Skip(pageize * (curindex - 1)).Take(pageize);
                    num = a.Count();
                    return a.ToList();
                }
                var list= lists.Where(o => string.IsNullOrEmpty(modelwhere.UserPwd) || o.UserNum.Contains(modelwhere.UserNum));
                num = list.Count();
                //分页先排序
                var pages = list.OrderBy(m => m.UserID).Skip(pageize * (curindex - 1)).Take(pageize);
                return pages.ToList();
            }
        }
        public static List<UserInfo> GetList(UserInfo modelwhere)
        {
            using (DrinkDBEntities db = new DrinkDBEntities())
            {
                var lists = db.UserInfo;
                lists.Where(o => string.IsNullOrEmpty(modelwhere.UserPwd) || o.UserNum.Contains(modelwhere.UserNum));
                return lists.ToList();
            }
        }
        public static UserInfo Login(UserInfo modelwhere)
        {
            using ( DrinkDBEntities db = new  DrinkDBEntities())
            {
                return db.UserInfo.Where(t => t.UserNum == modelwhere.UserNum && t.UserPwd == modelwhere.UserPwd).FirstOrDefault();
            }
        }
    }
}
