using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SSU_ThreeLayer.Entities;

namespace SSU_ThreeLayer.DAL.Interfaces
{
    public interface IRatingDAL
    {
        void SetRate(Rating rating, User user, Shop shop, int rate);

        int GetShopRateById(int idShop);
        
        IEnumerable<Shop> GetAllShopsWithRate(int rate);

        IEnumerable<User> GetAllUsersWithRate(int rate);

        User GetUserById(int idUser);

        Shop GetShopById(int idShop);
    }
}
