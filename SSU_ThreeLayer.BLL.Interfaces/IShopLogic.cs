using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SSU_ThreeLayer.Entities;

namespace SSU_ThreeLayer.BLL.Interfaces
{
    public interface IShopLogic
    {
        void AddShop(string nameShop, int IdTypeOfShop, int idAddress, out string alert);

        void DeleteShop(Shop shop, out string alert);

        void UpdateShop(Shop shop, string nameShop, int IdTypeOfShop, int idAddress, out string alert);

        IEnumerable<Shop> GetAllShops();

        Shop GetShopById(int idShop);
    }
}
