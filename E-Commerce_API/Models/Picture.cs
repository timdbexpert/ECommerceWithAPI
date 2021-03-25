using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace E_Commerce_API.Models
{
    public class Picture
    {
        public int Id { get; set; }
        public string Photos { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        
    }
}