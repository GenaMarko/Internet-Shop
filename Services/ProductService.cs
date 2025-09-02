using Internet_Shop.Models;
using Microsoft.EntityFrameworkCore;

namespace Internet_Shop.Services
{
    public class ProductService : IProductService
    {
        private readonly ShopDbContext _context;

        public ProductService(ShopDbContext context)
        {
            _context = context;
        }

        public async Task<Product> CreateAsync(Product product)
        {
            product.CreatedAt = DateTime.UtcNow;

            _context.Products.Add(product);

            await _context.SaveChangesAsync();

            return product;
        }

        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            return await _context.Products.ToListAsync();
        }

        public async Task<Product?> GetByIdAsync(int id)
        {
            return await _context.Products.FindAsync(id);
        }

        public async Task<Product?> UpdateAsync(int id, Product updated)
        {
            var existing = await _context.Products.FindAsync(id);

            if (existing == null) return null;

            existing.Name = updated.Name;
            existing.Description = updated.Description;
            existing.Price = updated.Price;
            existing.Stock = updated.Stock;

            await _context.SaveChangesAsync();

            return existing;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var product = await _context.Products.FindAsync(id);

            if(product == null) return false;

            _context.Products.Remove(product);

            await _context.SaveChangesAsync();

            return true;
        }
    }
}
