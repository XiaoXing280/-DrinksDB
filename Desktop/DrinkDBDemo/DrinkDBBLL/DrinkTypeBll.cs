using DrinkDBDAL;
using DrinkDBModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrinkDBBLL
{
    public class DrinkTypeBll
    {
        public static bool Insert(DrinkType model)
        {
            return DrinkTypeDal.Insert(model);
        }
        public static bool Update(DrinkType model)
        {
            return DrinkTypeDal.Update(model);
        }
        public static bool Delete(int TypeID)
        {
            return DrinkTypeDal.Delete(TypeID);
        }
        public static DrinkType GetDrinkType(int TypeID)
        {
            return DrinkTypeDal.GetDrinkType(TypeID);
        }
        public static List<DrinkType> GetList1(DrinkType modelwhere)
        {
            return DrinkTypeDal.GetList1(modelwhere);
        }
        public static List<DrinkType> GetList(DrinkType modelwhere, int pageize, int curindex, out int num)
        {
            return DrinkTypeDal.GetList(modelwhere,pageize,curindex,out num);
        }
    }
}
