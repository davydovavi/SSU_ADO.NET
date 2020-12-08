using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SSU_ThreeLayer.Entities
{
    [Table("Rating")]
    public class Rating
    {
        [Key]
        public int IDRating { get; set; }

        public int IdUser { get; set; }
        public User User { get; set; }

        public int IdShop { get; set; }
        public Shop Shop { get; set; }

        public int Rate { get; set; }
    }
}
