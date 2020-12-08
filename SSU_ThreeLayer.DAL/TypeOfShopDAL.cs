using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SSU_ThreeLayer.Entities;
using SSU_ThreeLayer.DAL.Interfaces;
using System.Data.Entity;

namespace SSU_ThreeLayer.DAL
{
    public class TypeOfShopDAL: ITypeOfShopDAL
    {
        public void AddTypeOfShop(TypeOfShop typeOfShop)
        {
            using (Entities.AppContext appContext = new Entities.AppContext())
            {
                appContext.TypeOfShops.Add(typeOfShop);
                appContext.SaveChanges();
            }
        }

        public void DeleteTypeOfShop(TypeOfShop typeOfShop)
        {
            using (Entities.AppContext appContext = new Entities.AppContext())
            {
                appContext.Entry<TypeOfShop>(typeOfShop).State = EntityState.Deleted;
                appContext.SaveChanges();
            }
        }

        public void UpdateTypeOfShop(TypeOfShop typeOfShop)
        {
            using (Entities.AppContext appContext = new Entities.AppContext())
            {
                appContext.Entry<TypeOfShop>(typeOfShop).State = EntityState.Modified;
                appContext.SaveChanges();
            }
        }

        public IEnumerable<TypeOfShop> GetAllTypeOfShops()
        {
            using (Entities.AppContext appContext = new Entities.AppContext())
            {
                return appContext.TypeOfShops
                    .Include(p => p.Description)
                    .ToList();
            }
        }

        public TypeOfShop GetTypeOfShopById(int idTypeOfShop)
        {
            using (Entities.AppContext appContext = new Entities.AppContext())
            {
                return appContext.TypeOfShops.FirstOrDefault(p => p.Id == idTypeOfShop);
            }
        }
    }
}
