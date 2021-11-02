using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CandyShop.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Category>().HasData(
              new Category { Id = 1, Name = "Čokolade" },
              new Category { Id = 2, Name = "Voćni bomboni" },
              new Category { Id = 3, Name = "Gumeni bomboni" },
              new Category { Id = 4, Name = "Halloween bomboni" },
              new Category { Id = 5, Name = "Tvrdi bomboni" }
              );

            modelBuilder.Entity<Product>().HasData(
              new Product
              {
                  Id = 1,
                  CategoryId = 1,
                  Code = "Raznovrsne_čokolade",
                  Name = "Raznovrsne čokolade",
                  Price = (decimal)4.99
              },
              new Product
              {
                  Id = 2,
                  CategoryId = 1,
                  Code = "Čokoladni_mix",
                  Name = "Razni čokoladni bomboni",
                  Price = (decimal)5.99
              },
              new Product
              {
                  Id = 3,
                  CategoryId = 1,
                  Code = "Čokoladni_MMS",
                  Name = "M&M",
                  Price = (decimal)3.75
              },
              new Product
              {
                  Id = 4,
                  CategoryId = 2,
                  Code = "Voćne_žvake",
                  Name = "Voćne žvake",
                  Price = (decimal)6.90
              },
              new Product
              {
                  Id = 5,
                  CategoryId = 2,
                  Code = "Voćne_lizalice",
                  Name = "Voćne lizalice",
                  Price = (decimal)2.90
              },
              new Product
              {
                  Id = 6,
                  CategoryId = 2,
                  Code = "Voćni_kiseli",
                  Name = "Voćni kiseli bomboni",
                  Price = (decimal)4.95
              },
              new Product
              {
                  Id = 7,
                  CategoryId = 3,
                  Code = "Uvezene_žvake",
                  Name = "Voćne uvezene žvake",
                  Price = (decimal)11.90
              },
              new Product
              {
                  Id = 8,
                  CategoryId = 3,
                  Code = "Kisele_žvake",
                  Name = "Kisele žvake",
                  Price = (decimal)1.90
              },
              new Product
              {
                  Id = 9,
                  CategoryId = 4,
                  Code = "Razni_halloween",
                  Name = "Razni halloween bomboni",
                  Price = (decimal)3.50
              },
              new Product
              {
                  Id = 10,
                  CategoryId = 5,
                  Code = "Tvrdi_voćni",
                  Name = "Tvrdi voćni bomboni",
                  Price = (decimal)9.90
              },
              new Product
              {
                  Id = 11,
                  CategoryId = 5,
                  Code = "Razni_tvrdi",
                  Name = "Razni tvrdi bomboni",
                  Price = (decimal)8.97
              },
              new Product
              {
                  Id = 12,
                  CategoryId = 5,
                  Code = "Tvrdi_kiseli",
                  Name = "Tvrdi kiseli bomboni",
                  Price = (decimal)5.55
              });
        }
    }
}
