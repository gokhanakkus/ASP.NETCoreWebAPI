using App.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Data.Contexts
{
    public class AppDbContext : DbContext
    {
        public DbSet<ProductEntity> Products { get; set; }

        public AppDbContext()
        {

        }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) 
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var products = new List<ProductEntity>()
            {
                new()
                {
                    Id = 1,
                    Name = "Product1",
                    Description = "Description of product 1",
                    Price = 10,
                    Stock = 100,
                },
                new()
                {
                    Id = 2,
                    Name = "Product2",
                    Description = "Description of product 2",
                    Price = 20,
                    Stock = 50,
                },
                new()
                {
                    Id = 3,
                    Name = "Product3",
                    Description = "Description of product 3",
                    Price = 15,
                    Stock = 75,
                }
            };

            modelBuilder.Entity<ProductEntity>().HasData(products);
        }
       
    }
}
