using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SSU_ThreeLayer.Entities;

namespace SSU_ThreeLayer.DAL.Interfaces
{
    public interface IShopDAL
    {
        void AddShop(Shop shop);

        void DeleteShop(Shop shop);

        void UpdateShop(Shop shop);

        IEnumerable<Shop> GetAllShops();

        Shop GetShopById(int idShop);

    }
}
