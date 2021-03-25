using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace E_Commerce_API.Models
{
    public class Operation_System
    {
        public int Id { get; set; }
        [StringLength(maximumLength: 40, MinimumLength = 1)]

        public string Name { get; set; }
    }
}
