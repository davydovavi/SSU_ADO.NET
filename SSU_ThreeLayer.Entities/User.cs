using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace SSU_ThreeLayer.Entities
{
    [Table("User")]
    public class User
    {
        public User()
        {
            ShopList = new HashSet<Shop>();
            Ratings = new HashSet<Rating>();
        }


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
        
        public virtual ICollection<Shop> ShopList { get; set; }
        public virtual ICollection<Rating> Ratings { get; set; }

    }
}
