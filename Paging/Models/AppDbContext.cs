using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Paging.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Product> Products { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            modelBuilder.Entity<Product>().HasData(
              new Product
              {
                  Id = 1,
                  Name = "Raznovrsne čokolade",
                  Price = (decimal)4.99
              },
              new Product
              {
                  Id = 2,
                  Name = "Razni čokoladni bomboni",
                  Price = (decimal)5.99
              },
              new Product
              {
                  Id = 3,
                  Name = "M&M",
                  Price = (decimal)3.75
              },
              new Product
              {
                  Id = 4,
                  Name = "Voćne žvake",
                  Price = (decimal)6.90
              },
              new Product
              {
                  Id = 5,
                  Name = "Voćne lizalice",
                  Price = (decimal)2.90
              },
              new Product
              {
                  Id = 6,
                  Name = "Voćni kiseli bomboni",
                  Price = (decimal)4.95
              },
              new Product
              {
                  Id = 7,
                  Name = "Voćne uvezene žvake",
                  Price = (decimal)11.90
              },
              new Product
              {
                  Id = 8,
                  Name = "Kisele žvake",
                  Price = (decimal)1.90
              },
              new Product
              {
                  Id = 9,
                  Name = "Razni halloween bomboni",
                  Price = (decimal)3.50
              },
              new Product
              {
                  Id = 10,
                  Name = "Tvrdi voćni bomboni",
                  Price = (decimal)9.90
              },
              new Product
              {
                  Id = 11,
                  Name = "Razni tvrdi bomboni",
                  Price = (decimal)8.97
              },
              new Product
              {
                  Id = 12,
                  Name = "Tvrdi kiseli bomboni",
                  Price = (decimal)5.55
              });
        }
    }
}
