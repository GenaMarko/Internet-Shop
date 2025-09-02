using Internet_Shop.Models;

namespace Internet_Shop.Services
{
    public interface IProductService
    {
        Task<Product> CreateAsync(Product product);
        Task<IEnumerable<Product>> GetAllAsync();
        Task<Product?> GetByIdAsync(int id);
        Task<Product?> UpdateAsync(int id, Product product);
        Task<bool> DeleteAsync(int id);
    }
}
