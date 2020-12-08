using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace SSU_ThreeLayer.ViewModel
{
    public class VisShopVM
    {
        [Key]
        public int IdShop { get; set; }
        [Required]
        public string NameShop { get; set; }

        public int IdTypeOfShop { get; set; }
        public TypeOfShopVM typeOfShop { get; set; }

        public int IdAddress { get; set; }
        public AddressVM address { get; set; }

        public virtual ICollection<VisUserVM> UserList { get; set; }
        public virtual ICollection<VisRatingVM> Ratings { get; set; }
    }
}