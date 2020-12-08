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
    public class ShopLogic:IShopLogic
    {
        private IShopDAL _shopDAL;

        public ShopLogic(IShopDAL shopDAL)
        {
            _shopDAL = shopDAL;
        }

        public void AddShop(string nameShop, int idTypeOfShop, int idAddress, out string alert)
        {
            if (nameShop == null)
            {
                alert = "Couldn't add shop! Name shop fields is null.";
                return;
            }
            else
            {
                _shopDAL.AddShop(new Shop()
                {
                    NameShop = nameShop,
                    IdTypeOfShop = idTypeOfShop,
                    IdAddress = idAddress
                });
                alert = "Shop added successfully";
            }
        }

        public void DeleteShop(Shop shop, out string alert)
        {
            _shopDAL.DeleteShop(shop);
            alert = "Shop deleted successfully";
        }

        public void UpdateShop(Shop shop, string nameShop, int IdTypeOfShop, int idAddress, out string alert)
        {
            if (nameShop == null)
            {
                alert = "Couldn't update address! Name shop fields is null.";
                return;
            }
            else
            {
                shop.NameShop = nameShop;
                shop.IdTypeOfShop = IdTypeOfShop;
                shop.IdAddress = idAddress;
                _shopDAL.UpdateShop(shop);
                alert = "Shop update successfully";
            }
        }

        public IEnumerable<Shop> GetAllShops()
        {
            return _shopDAL.GetAllShops();
        }

        public Shop GetShopById(int idShop)
        {
            return _shopDAL.GetShopById(idShop);
        }
    }
}
