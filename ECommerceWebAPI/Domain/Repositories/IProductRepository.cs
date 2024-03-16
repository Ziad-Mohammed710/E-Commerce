using ECommerceWebAPI.Domain.Models;

namespace ECommerceWebAPI.Domain.Repositories
{
    public interface IProductRepository
    {
        //Task<IEnumerable<Product>> GetAllAsync();
        Task<Product> GetByIdAsync(int id);
        Task<Product> AddAsync(Product product);
        Task<Product> UpdateAsync(Product product);
        Task DeleteAsync(int id);

        // Additional methods for filtering, sorting, and pagination
        Task<IEnumerable<Product>> GetProductsAsync(string keyword,
                                                    string sortBy,
                                                    bool ascending,
                                                    int pageNumber,
                                                    int pageSize);
        //Task<IEnumerable<Product>> GetFilteredProductsAsync(string keyword);
        //Task<IEnumerable<Product>> GetSortedProductsAsync(string sortBy, bool ascending);
        //Task<IEnumerable<Product>> GetPagedProductsAsync(int pageNumber, int pageSize);
    }
}
