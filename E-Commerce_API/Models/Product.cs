using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace E_Commerce_API.Models
{
    public class Product
    {
        public Product()
        {
            Pictures = new HashSet<Picture>();
          //  ProductColors = new HashSet<ProductColor>();
        }

        public int Id { get; set; }
        [StringLength(maximumLength: 40, MinimumLength = 3)]

        public string Name { get; set; }
        [StringLength(maximumLength: 100, MinimumLength = 3)]

        public string Description { get; set; }

        [DataType("decimal(12 ,2")]
        public decimal Price { get; set; }
        public string MainImage { get; set; }
        public DateTime Created { get; set; }
        public int BrandId { get; set; }
        public Brand Brand { get; set; }
        public int ColorId { get; set; }
        public Color Color { get; set; }
        public int RAMId { get; set; }
        public RAM RAM { get; set; }
        public int StorageId { get; set; }
        public Storage Storage { get; set; }
        public ICollection<Picture> Pictures { get; set; }
     //   public ICollection<ProductColor> ProductColors { get; set; }
    }
}
