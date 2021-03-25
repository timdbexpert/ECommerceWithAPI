
using E_Commerce_API.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_Commerce_API.Data
{
    public class CommerceDbContext : IdentityDbContext<AppUser, IdentityRole<int>, int>
    {

        public CommerceDbContext(DbContextOptions options) : base(options)
        {

        }

        public virtual DbSet<Menu> Menus { get; set; }
        public virtual DbSet<SubMenu> SubMenu { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        // public virtual DbSet<ProductColor> ProductColors { get; set; }
        public virtual DbSet<RAM> RAMs { get; set; }
        public virtual DbSet<Storage> Storages { get; set; }
        public virtual DbSet<Picture> Pictures { get; set; }
        public virtual DbSet<Brand> Brands { get; set; }
        public virtual DbSet<Color> Colors { get; set; }
        public virtual DbSet<Operation_System> Operation_Systems {get;set;}
        public virtual DbSet<Prosessor> Prosessors { get; set; }
        public virtual DbSet<SSD> SSDs { get; set; }
        public virtual DbSet<Style_Join> Style_Joins { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<ProductColor>().HasKey(x => new { x.ColorId, x.ProductId });
            //modelBuilder.Entity<ProductColor>().HasOne(x => x.Product)
            //                                      .WithMany(x => x.ProductColors);

            //modelBuilder.Entity<ProductColor>().HasOne(x => x.Color)
            //                                      .WithMany(x => x.ProductColors);
            base.OnModelCreating(modelBuilder);
        }
    }
}
