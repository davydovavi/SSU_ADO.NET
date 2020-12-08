using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject.Modules;
using SSU_ThreeLayer.BLL;
using SSU_ThreeLayer.BLL.Interfaces;
using SSU_ThreeLayer.DAL;
using SSU_ThreeLayer.DAL.Interfaces;

namespace SSU_ThreeLayer.DI
{
    class NinjectBind : NinjectModule
    {
        public override void Load()
        {
            Bind<IAddressDAL>().To<AddressDAL>();
            Bind<IAddressLogic>().To<AddressLogic>();

            Bind<ITypeOfShopDAL>().To<TypeOfShopDAL>();
            Bind<ITypeOfShopLogic>().To<TypeOfShopLogic>();

            Bind<IShopDAL>().To<ShopDAL>();
            Bind<IShopLogic>().To<ShopLogic>();

            Bind<IUserDAL>().To<UserDAL>();
            Bind<IUserLogic>().To<UserLogic>();

            Bind<IRatingDAL>().To<RatingDAL>();
            Bind<IRatingLogic>().To<RatingLogic>();
        }
    }
}
