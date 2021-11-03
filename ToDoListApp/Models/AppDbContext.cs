using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToDoListApp.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext>options) : base(options)
        {

        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Status> Statuses { get; set; }
        public DbSet<ToDo> ToDos { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Category>().HasData(
                new Category { Id= "work", Name = "Work"},
                new Category { Id = "home", Name = "Home" },
                new Category { Id = "ex", Name = "Exercise" },
                new Category { Id = "shop", Name = "Shopping" },
                new Category { Id = "contact", Name = "Contact" }              
                );

            builder.Entity<Status>().HasData(
                new Status { Id = "open", Name = "Open" },
                new Status { Id = "completed", Name = "Completed" }
                );
        }
    }
}
