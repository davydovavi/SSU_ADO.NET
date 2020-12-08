using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace SSU_ThreeLayer.ViewModel
{
    public class VisRatingVM
    {
        [Key]
        public int IdRating { get; set; }

        public int IdUser { get; set; }
        public VisUserVM User { get; set; }

        public int IdShop { get; set; }
        public VisShopVM Shop { get; set; }

        public int Rate { get; set; }
    }
}