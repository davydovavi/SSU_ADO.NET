using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SSU_ThreeLayer.Entities;

namespace SSU_ThreeLayer.BLL.Interfaces
{
    public interface IRatingLogic
    {
        void SetRate(int idUser, int idShop, int rate, out string alert);

        int GetShopRateById(int idShop);

        IEnumerable<Shop> GetAllShopsWithRate(int rate);

        User GetUserById(int idUser);

        Shop GetShopById(int idShop);
    }
}
