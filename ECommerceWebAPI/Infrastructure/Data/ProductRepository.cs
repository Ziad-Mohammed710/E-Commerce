using ECommerceWebAPI.Domain.Models;
using ECommerceWebAPI.Domain.Repositories;
using ECommerceWebAPI.Domain;
using Microsoft.EntityFrameworkCore;

namespace ECommerceWebAPI.Infrastructure.Data
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext _dbContext;

        public ProductRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        

        public async Task<Product> GetByIdAsync(int id)
        {
            var product = await _dbContext.Products.FindAsync(id);
            if (product == null)
            {
                throw new ArgumentException($"Product with ID '{id}' not found", nameof(id));
            }
            return product;

        }

        public async Task<Product> AddAsync(Product product)
        {
            try
            {
                await _dbContext.Products.AddAsync(product);
                await _dbContext.SaveChangesAsync();
                return product;
            }
            catch (Exception ex)
            {
                // Handle the exception appropriately
                Console.WriteLine($"An error occurred while adding the product: {ex.Message}");
                throw;
            }
        }

        public async Task<Product> UpdateAsync(Product product)
        {
            _dbContext.Entry(product).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
            return product;
        }

        public async Task DeleteAsync(int id)
        {
            var product = await GetByIdAsync(id);
            if (product != null)
            {
                _dbContext.Products.Remove(product);
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Product>> GetProductsAsync(
               string keyword ,
               string sortBy ,
               bool ascending,
               int pageNumber ,
               int pageSize)
        {
            IQueryable<Product> query = _dbContext.Products.AsQueryable();

            // Apply filtering
            if (!string.IsNullOrEmpty(keyword))
            {
                query = query.Where(p => p.Name.Contains(keyword) || p.Description.Contains(keyword));
            }

            // Apply sorting
            switch (sortBy.ToLower())
            {
                case "name":
                    query = ascending ? query.OrderBy(p => p.Name) : query.OrderByDescending(p => p.Name);
                    break;
                case "price":
                    query = ascending ? query.OrderBy(p => p.Price) : query.OrderByDescending(p => p.Price);
                    break;
                default:
                    query = ascending ? query.OrderBy(p => p.Id) : query.OrderByDescending(p => p.Price);
                    break;
            }

            // Apply pagination
            var pagedProducts = await query.Skip((pageNumber - 1) * pageSize)
                                           .Take(pageSize)
                                           .ToListAsync();

            return pagedProducts;
        }

        
    }
}
