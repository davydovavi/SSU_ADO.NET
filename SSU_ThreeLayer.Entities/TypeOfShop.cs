using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SSU_ThreeLayer.Entities
{
    [Table("TypeOfShop")]
    public class TypeOfShop
    {
        [Key]
        public int Id { get; set ; }
        [Required]
        [StringLength(255)]
        public string Description { get; set ; }
    }
}
