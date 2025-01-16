using Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace Domain.RepositoriesInterfaces
{
    public interface IUserRepository
    {
        Task<bool> UserExistsAsync(string email);
        Task<IdentityResult> CreateUserAsync(User user, string password);
        Task<User> GetUserByEmailAsync(string email);
        Task<bool> CheckPasswordAsync(User user, string password);
    }
}
