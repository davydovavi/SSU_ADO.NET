using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SSU_ThreeLayer.BLL.Interfaces;
using SSU_ThreeLayer.DAL.Interfaces;
using SSU_ThreeLayer.Entities;

namespace SSU_ThreeLayer.BLL
{
    public class RatingLogic:IRatingLogic
    {
        private IRatingDAL _ratingDAL;

        public RatingLogic(IRatingDAL ratingDAL)
        {
            _ratingDAL = ratingDAL;
        }

        public void SetRate(int idUser, int idShop, int rate, out string alert)
        {
            User user = GetUserById(idUser);
            Shop shop = GetShopById(idShop);
            Rating rating;
            rating = new Rating()
            {
                IdUser = idUser,
                User = user,
                IdShop = idShop,
                Shop = shop,
                Rate = rate
            };
            _ratingDAL.SetRate(rating, user, shop, rate);
            alert = "Rating set seccessful!";
        }

       
        public IEnumerable<Shop> GetAllShopsWithRate(int rate)
        {
            return _ratingDAL.GetAllShopsWithRate(rate);
        }

        public int GetShopRateById(int idShop)
        {
            return _ratingDAL.GetShopRateById(idShop);
        }

        public User GetUserById(int idUser)
        {
            return _ratingDAL.GetUserById(idUser);
        }

        public Shop GetShopById(int idShop)
        {
            return _ratingDAL.GetShopById(idShop);
        }
    }
}
