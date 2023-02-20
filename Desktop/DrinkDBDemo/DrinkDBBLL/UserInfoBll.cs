using DrinkDBDAL;
using DrinkDBModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrinkDBBLL
{
    public class UserInfoBll
    {

        public static bool Insert(UserInfo model)
        {
            return UserInfoDal.Insert(model);
        }
        public static bool Update(UserInfo model)
        {
            return UserInfoDal.Update(model);
        }
        public static bool Delete(int UserID)
        {
            return UserInfoDal.Delete(UserID);
        }
        public static UserInfo GetUserInfo(int UserID)
        {
            return UserInfoDal.GetUserInfo(UserID);
        }
        public static List<UserInfo> GetList(UserInfo modelwhere,string UserNum, int pageize, int curindex, out int num)
        {
            return UserInfoDal.GetList(modelwhere, UserNum, pageize, curindex, out num);
        }

        public static List<UserInfo> GetList(UserInfo modelwhere)
        {
            return UserInfoDal.GetList(modelwhere);
        }
        public static UserInfo Login(UserInfo modelwhere)
        {
            return UserInfoDal.Login(modelwhere);
        }
    }
}
