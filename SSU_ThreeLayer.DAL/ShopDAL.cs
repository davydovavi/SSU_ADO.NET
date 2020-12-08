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
    public class ShopDAL:IShopDAL
    {
        public void AddShop(Shop shop)
        {
            using (Entities.AppContext appContext = new Entities.AppContext())
            {
                appContext.Shops.Add(shop);
                appContext.SaveChanges();
            }
        }

        public void DeleteShop(Shop shop)
        {
            using (Entities.AppContext appContext = new Entities.AppContext())
            {
                appContext.Entry<Shop>(shop).State = EntityState.Deleted;
                appContext.SaveChanges();
            }
        }

        public void UpdateShop(Shop shop)
        {
            using (Entities.AppContext appContext = new Entities.AppContext())
            {
                appContext.Entry<Shop>(shop).State = EntityState.Modified;
                appContext.SaveChanges();
            }
        }

        public IEnumerable<Shop> GetAllShops()
        {
            using (Entities.AppContext appContext = new Entities.AppContext())
            {
                return appContext.Shops
                    .Include(p => p.NameShop)
                    .Include(p => p.typeOfShop)
                    .Include(p => p.typeOfShop.Description)
                    .Include(p => p.address)
                    .Include(p => p.address.City)
                    .Include(p => p.address.Street)
                    .Include(p => p.address.Build)
                    .Include(p => p.Ratings)
                    .ToList();
            }
        }

        public Shop GetShopById(int idShop)
        {
            using (Entities.AppContext appContext = new Entities.AppContext())
            {
                return appContext.Shops.FirstOrDefault(p => p.IdShop == idShop);
            }
        }
    }
}
