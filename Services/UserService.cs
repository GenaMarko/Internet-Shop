using Internet_Shop.Models;
using Microsoft.EntityFrameworkCore;

namespace Internet_Shop.Services
{
    public class UserService : IUserService
    {
        private readonly ShopDbContext _context;

        public UserService(ShopDbContext context)
        {
            _context = context;
        }

        public async Task<User?> CreateAsync(User user)
        {
            user.CreatedAt = DateTime.UtcNow;

            _context.Users.Add(user);

            await _context.SaveChangesAsync();

            return user;
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<User?> GetByIdAsync(int id)
        {
            return await _context.Users.FindAsync(id);
        }

        public async Task<User?> UpdateAsync(int id, User updatedUser)
        {
            var existing = await _context.Users.FindAsync(id);

            if (existing == null) return null;

            existing.Username = updatedUser.Username;
            existing.Email = updatedUser.Email;
            existing.Password = updatedUser.Password;

            await _context.SaveChangesAsync();

            return existing;

        }

        public async Task<bool> DeleteAsync(int id)
        {
            var user = await _context.Users.FindAsync(id);

            if (user == null)
            {
                return false;
            }

            _context.Users.Remove(user);

            await _context.SaveChangesAsync();

            return true;
        }
    }
}
