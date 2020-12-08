using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace SSU_ThreeLayer.ViewModel
{
    public class VisUserVM
    {
        [Key]
        public int IdUser { get; set; }
        [Required]
        [StringLength(255)]
        public string NameUser { get; set; }
        [Required]
        [MaxLength(32)]
        public string Login { get; set; }
        [Required]
        [MaxLength(32)]
        public string Hashpassword { get; set; }
        [Required]
        [DataType(DataType.DateTime)]
        public DateTime DateOfBirth { get; set; }

        public virtual ICollection<VisShopVM> ShopList { get; set; }
        public virtual ICollection<VisRatingVM> Ratings { get; set; }
    }
}