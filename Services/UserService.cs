using Internet_Shop.Models;
using Microsoft.EntityFrameworkCore;

namespace Internet_Shop.Services
{
    public class UserService : IUserService
    {
        private readonly ShopDbContext _shopContext;

        public UserService(ShopDbContext context)
        {
            _shopContext = context;
        }

        public async Task<User?> CreateAsync(User user)
        {
            user.CreatedAt = DateTime.UtcNow;

            _shopContext.Users.Add(user);

            await _shopContext.SaveChangesAsync();

            return user;
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            return await _shopContext.Users.ToListAsync();
        }

        public async Task<User?> GetByIdAsync(int id)
        {
            return await _shopContext.Users.FindAsync(id);
        }

        public async Task<User?> UpdateAsync(int id, User updatedUser)
        {
            var existing = await _shopContext.Users.FindAsync(id);

            if (existing == null) return null;

            existing.Username = updatedUser.Username;
            existing.Email = updatedUser.Email;
            existing.Password = updatedUser.Password;

            await _shopContext.SaveChangesAsync();

            return existing;

        }

        public async Task<bool> DeleteAsync(int id)
        {
            var user = await _shopContext.Users.FindAsync(id);

            if (user == null)
            {
                return false;
            }

            _shopContext.Users.Remove(user);

            await _shopContext.SaveChangesAsync();

            return true;
        }
    }
}
