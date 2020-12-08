using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SSU_ThreeLayer.Entities;

namespace SSU_ThreeLayer.BLL.Interfaces
{
    public interface ITypeOfShopLogic
    {
        void AddTypeOfShop(string description, out string alert);

        void DeleteTypeOfShop(TypeOfShop typeOfShop, out string alert);

        void UpdateTypeOfShop(TypeOfShop typeOfShop, string description, out string alert);

        IEnumerable<TypeOfShop> GetAllTypeOfShops();

        TypeOfShop GetTypeOfShopById(int idTypeOfShop);
    }
}
