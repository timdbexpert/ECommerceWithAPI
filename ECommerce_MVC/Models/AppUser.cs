using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce_MVC.Models
{
    public class AppUser
    {
        public string UserName { get; set; }

        public string Email { get; set; }
    }
}
