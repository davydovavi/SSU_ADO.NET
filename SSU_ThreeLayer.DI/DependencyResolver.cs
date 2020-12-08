using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject;

namespace SSU_ThreeLayer.DI
{
    public class DependencyResolver
    {
        private static NinjectBind _bind = new NinjectBind();
        public static StandardKernel Kernel = new StandardKernel(_bind);
    }
}
