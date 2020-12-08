using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace SSU_ThreeLayer.ViewModel
{
    public class RatingVM
    {
        public int IdUser { get; set; }

        public int IdShop { get; set; }

        public int Rate { get; set; }
    }
}
