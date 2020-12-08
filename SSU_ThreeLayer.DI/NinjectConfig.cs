using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject;
using SSU_ThreeLayer.DAL.Interfaces;
using SSU_ThreeLayer.DAL;
using SSU_ThreeLayer.BLL;
using SSU_ThreeLayer.BLL.Interfaces;

namespace SSU_ThreeLayer.DI
{
    public static class NinjectConfig
    {
        public static class Config
        {
            /// <summary>
            /// Load your modules or register your services here!
            /// </summary>
            /// <param name="kernel">The kernel.</param>
            public static void RegisterServices(IKernel kernel)
            {
                kernel
                    .Bind<IAddressLogic>()
                    .To<AddressLogic>()
                    .InSingletonScope();
                kernel
                    .Bind<ITypeOfShopLogic>()
                    .To<TypeOfShopLogic>()
                    .InSingletonScope();
                kernel
                    .Bind<IShopLogic>()
                    .To <ShopLogic>()
                    .InSingletonScope();
                kernel
                    .Bind<IUserLogic>()
                    .To<UserLogic>()
                    .InSingletonScope();
                kernel
                    .Bind<IRatingLogic>()
                    .To<RatingLogic>()
                    .InSingletonScope();

                kernel
                    .Bind<IAddressDAL>()
                    .To<AddressDAL>()
                    .InSingletonScope();
                kernel
                    .Bind<ITypeOfShopDAL>()
                    .To<TypeOfShopDAL>()
                    .InSingletonScope();
                kernel
                    .Bind<IShopDAL>()
                    .To<ShopDAL>()
                    .InSingletonScope();
                kernel
                    .Bind<IUserDAL>()
                    .To<UserDAL>()
                    .InSingletonScope();
                kernel
                    .Bind<IRatingDAL>()
                    .To<RatingDAL>()
                    .InSingletonScope();

            }
        }
    }
}
