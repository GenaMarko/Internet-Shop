using Internet_Shop.Models;

namespace Internet_Shop.Services
{
    public interface IUserService
    {
        Task<IEnumerable<User>> GetAllAsync();
        Task<User?> GetByIdAsync(int id);
        Task<User?> CreateAsync(User user);
        Task<User?> UpdateAsync(int id,User updatedUser);
        Task<bool> DeleteAsync(int id);
        Task<User?> RegisterAsync(RegisterDto dto);
        Task<User?> ValidateUserAsync(string email, string password);
    }
}
