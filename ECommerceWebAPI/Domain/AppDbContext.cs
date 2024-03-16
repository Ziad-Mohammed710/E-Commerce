using ECommerceWebAPI.Domain.Models;
using ECommerceWebAPI.Extensions;
using Microsoft.EntityFrameworkCore;

namespace ECommerceWebAPI.Domain
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //seeding the Products Table
            modelBuilder.SeedProducts();

            // Specify SQL Server column type for the Price property
            modelBuilder.Entity<Product>()
                        .Property(p => p.Price)
                        .HasColumnType("decimal(18,2)");
            

        }


    }
}
