using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace SSU_ThreeLayer.ViewModel
{
    public class ShopVM
    {
        [Required]
        public string NameShop { get; set; }

        public int IdTypeOfShop { get; set; }

        public int IdAddress { get; set; }
    }
}