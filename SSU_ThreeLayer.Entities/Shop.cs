using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SSU_ThreeLayer.Entities
{
    [Table("Shop")]
    public class Shop
    {
        public Shop()
        {
            UserList = new HashSet<User>();
            Ratings = new HashSet<Rating>();
        }
        
        [Key]
        public int IdShop { get; set ; }
        [Required]
        public string NameShop { get; set; }

        public int IdTypeOfShop { get; set; }
        public TypeOfShop typeOfShop { get; set; }

        public int IdAddress { get; set; }
        public Address address { get; set; }

        public virtual ICollection<User> UserList { get; set; }
        public virtual ICollection<Rating> Ratings { get; set; }
    }
}
