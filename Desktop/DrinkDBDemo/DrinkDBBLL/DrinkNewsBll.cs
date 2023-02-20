using DrinkDBDAL;
using DrinkDBModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrinkDBBLL
{
    public class DrinkNewsBll
    {
        public static bool Insert(DrinkNews model)
        {
            return DrinkNewsDal.Insert(model);
        }
        public static bool Update(DrinkNews model)
        {
            return DrinkNewsDal.Update(model);
        }
        public static bool Delete(int DrinkID)
        {
            return DrinkNewsDal.Delete(DrinkID);
        }
        public static DrinkNews GetDrinkNews(int DrinkID)
        {
            return DrinkNewsDal.GetDrinkNews(DrinkID);
        }
        public static List<DrinkNews> GetList(DrinkNews modelwhere, string NewsName, int pageize, int curindex, out int num)
        {
            return DrinkNewsDal.GetList(modelwhere,NewsName,pageize,curindex,out num);
        }
    }
}
