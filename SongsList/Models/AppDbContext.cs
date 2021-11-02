using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SongsList.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Song> Songs { get; set; }
        public DbSet<Genre> Genres { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Genre>().HasData(
               new Genre { Id = "M", Name = "Metal" },
               new Genre { Id = "R", Name = "Rap" },
               new Genre { Id = "H", Name = "Hip Hop" },
               new Genre { Id = "RC", Name = "Rock" }
               );


            //dodajemo neke pjesme kod inicijalizacije baze
            builder.Entity<Song>().HasData(
                   new Song
                   {
                       Id = 1,
                       Name = "Pjesma 1",
                       Year = 1980,
                       Rating = 5,
                       GenreId="M"
                   },
                   new Song
                   {
                       Id = 2,
                       Name = "Pjesma 2",
                       Year = 1990,
                       Rating = 4,
                       GenreId = "R"
                   },
                   new Song
                   {
                       Id = 3,
                       Name = "Pjesma 3",
                       Year = 2005,
                       Rating = 1,
                       GenreId = "H"
                   });
        }
    }
}
