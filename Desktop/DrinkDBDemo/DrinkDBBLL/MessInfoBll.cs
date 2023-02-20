using DrinkDBDAL;
using DrinkDBModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrinkDBBLL
{
    public class MessInfoBll
    {
        public static bool Insert(MessInfo model)
        {
            return MessInfoDal.Insert(model);
        }
        public static bool Update(MessInfo model)
        {
            return MessInfoDal.Update(model);
        }
        public static bool Delete(int MessID)
        {
            return MessInfoDal.Delete(MessID);
        }
        public static MessInfo GetMessInfo(int MessID)
        {
            return MessInfoDal.GetMessInfo(MessID);
        }
        public static List<MessInfo> GetList(MessInfo modelwhere, string MessNum, int pageize, int curindex, out int num)
        {
            return MessInfoDal.GetList(modelwhere, MessNum, pageize, curindex, out num);
        }

        public static List<MessInfo> GetList(string MessNum) 
        {
            return MessInfoDal.GetList(MessNum);
        }
        public static MessInfo Login(MessInfo modelwhere) 
        {
            return MessInfoDal.Login(modelwhere);
        }
    }
}
