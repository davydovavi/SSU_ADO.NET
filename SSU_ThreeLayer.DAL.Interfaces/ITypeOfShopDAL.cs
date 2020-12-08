using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SSU_ThreeLayer.Entities;

namespace SSU_ThreeLayer.DAL.Interfaces
{
    public interface ITypeOfShopDAL
    {
        void AddTypeOfShop(TypeOfShop typeOfShop);

        void DeleteTypeOfShop(TypeOfShop typeOfShop);

        void UpdateTypeOfShop(TypeOfShop typeOfShop);

        IEnumerable<TypeOfShop> GetAllTypeOfShops();

        TypeOfShop GetTypeOfShopById(int idTypeOfShop);
    }
}
