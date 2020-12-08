using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace SSU_ThreeLayer.ViewModel
{
    public class UserVM
    {
        [Required]
        [MaxLength(32)]
        public string Login { get; set; }
        [Required]
        [MaxLength(32)]
        public string Hashpassword { get; set; }

        
    }
}