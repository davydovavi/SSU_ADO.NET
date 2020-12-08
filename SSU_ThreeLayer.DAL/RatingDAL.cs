using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using SSU_ThreeLayer.Entities;
using SSU_ThreeLayer.DAL.Interfaces;


namespace SSU_ThreeLayer.DAL
{
    public class RatingDAL:IRatingDAL
    {
        public void SetRate(Rating rating, User user, Shop shop, int rate)
        {
            using (Entities.AppContext appContext = new Entities.AppContext())
            {
                rating.User = user;
                rating.Shop = shop;
                rating.IdUser = user.IdUser;
                rating.IdShop = shop.IdShop;
                rating.Rate = rate;
                appContext.Entry<Rating>(rating).State = EntityState.Modified;
                appContext.SaveChanges();
            }
        }

        public int GetShopRateById(int idShop)
        {
            using (Entities.AppContext appContext = new Entities.AppContext())
            {
                return appContext.Ratings.FirstOrDefault(p => p.IdShop == idShop).Rate;
            }
        }

        public IEnumerable<Shop> GetAllShopsWithRate(int rate)
        {
            using (Entities.AppContext appContext = new Entities.AppContext())
            {
                return appContext.Ratings
                    .Include(p => p.Shop)
                    .Include(p => p.Shop.NameShop)
                    .Include(p => p.Shop.typeOfShop)
                    .Include(p => p.Shop.typeOfShop.Description)
                    .Include(p => p.Shop.address)
                    .Include(p => p.Shop.address.City)
                    .Include(p => p.Shop.address.Street)
                    .Include(p => p.Shop.address.Build)
                    .Where(p => p.Rate == rate)
                    .Select(p => p.Shop);
            }
        }

        public IEnumerable<User> GetAllUsersWithRate(int rate)
        {
            using (Entities.AppContext appContext = new Entities.AppContext())
            {
                return appContext.Ratings
                    .Include(p => p.User)
                    .Include(p => p.User.NameUser)
                    .Include(p => p.User.DateOfBirth)
                    .Where(p => p.Rate == rate)
                    .Select(p => p.User);
            }
        }

        public User GetUserById(int idUser)
        {
            using (Entities.AppContext appContext = new Entities.AppContext())
            {
                return appContext.Ratings.FirstOrDefault(p => p.IdUser == idUser).User;
            }
        }

        public Shop GetShopById(int idShop)
        {
            using (Entities.AppContext appContext = new Entities.AppContext())
            {
                return appContext.Ratings.FirstOrDefault(p => p.IdShop == idShop).Shop;
            }
        }
    }
}
