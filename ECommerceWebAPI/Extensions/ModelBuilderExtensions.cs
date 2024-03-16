using ECommerceWebAPI.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace ECommerceWebAPI.Extensions
{
    public static class ModelBuilderExtensions
    {
        public static void SeedProducts(this ModelBuilder modelBuilder)
        {
            var random = new Random();

            var products = Enumerable.Range(1, 20).Select(i => new Product
            {
                Id = i,
                Name = $"Product {i}",
                Price = (decimal)(random.Next(1000, 20001)), // Generate price between 1000 and 20000
                Description = $"Description for Product {i}"
            }).ToArray();

            modelBuilder.Entity<Product>().HasData(products);
        }
    }
}
