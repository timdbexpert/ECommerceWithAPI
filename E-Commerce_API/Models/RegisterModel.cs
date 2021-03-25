﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace E_Commerce_API.Models
{
    public class RegisterModel
    {
        [Required]
        [StringLength(maximumLength: 40, MinimumLength = 2)]
        public string Username { get; set; }
        [Required]

        public string Password { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Compare("Password")]
        public string ConfirmPassword { get; set; }
    }
}
