using ECommerce_MVC.Attribute;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce_MVC.Models
{
    public class LoginModel
    {
        [Required]
        [EmailAddress]
        
        public string Email { get; set; }

        [Required]
        [StringLength(maximumLength: 30, MinimumLength = 6)]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
