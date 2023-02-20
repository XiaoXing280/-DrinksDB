using DrinkDBDAL;
using DrinkDBModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrinkDBBLL
{
    public class DrinkInfoBll
    {
        public static bool Insert(DrinkInfo model)
        {
            return DrinkInfoDal.Insert(model);
        }
        public static bool Update(DrinkInfo model)
        {
            return DrinkInfoDal.Update(model);
        }
        public static bool Delete(int DrinkID)
        {
            return DrinkInfoDal.Delete(DrinkID);
        }
        public static DrinkInfo GetDrinkInfo(int DrinkID)
        {
            return DrinkInfoDal.GetDrinkInfo(DrinkID);
        }
        public static List<DrinkInfo> GetList(DrinkInfo modelwhere,string DrinkName,int pageize, int curindex, out int num,int TypeID)
        {
            return DrinkInfoDal.GetList(modelwhere, DrinkName,pageize, curindex,out num,TypeID);
        }
        public static List<DrinkInfo> GetList(DrinkInfo modelwhere)
        {
            return DrinkInfoDal.GetList(modelwhere);
        }
    }
}
