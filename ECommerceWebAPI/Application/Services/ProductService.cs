using ECommerceWebAPI.Domain.Models;
using ECommerceWebAPI.Domain.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceWebAPI.Application.Services
{
    public class ProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository ??
                throw new ArgumentNullException(nameof(productRepository));
        }

        

        public async Task<Product> GetProductByIdAsync(int id)
        {
            if (id <= 0)
                throw new ArgumentOutOfRangeException(nameof(id), "Id must be greater than zero.");

            return await _productRepository.GetByIdAsync(id);
        }

        public async Task<Product> AddProductAsync(Product product)
        {
            if (product == null)
                throw new ArgumentNullException(nameof(product));

            return await _productRepository.AddAsync(product);
        }

        public async Task<Product> UpdateProductAsync(Product product)
        {
            if (product == null)
                throw new ArgumentNullException(nameof(product));

            return await _productRepository.UpdateAsync(product);
        }

        public async Task DeleteProductAsync(int id)
        {
            if (id <= 0)
                throw new ArgumentOutOfRangeException(nameof(id), "Id must be greater than zero.");

            await _productRepository.DeleteAsync(id);
        }


        public async Task<IEnumerable<Product>> GetProductsAsync(
               string keyword,
               string sortBy,
               bool ascending,
               int pageNumber,
               int pageSize)
        {
            var products = await _productRepository.GetProductsAsync( keyword,
                                                                sortBy, ascending,
                                                                pageNumber,pageSize);
            return products;
                
        }

        
    }
}
