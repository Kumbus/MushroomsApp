using Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace Domain.RepositoriesInterfaces
{
    public interface IUserRepository : IRepositoryBase<User>
    {
        Task<bool> UserExistsAsync(string email);
        Task<IdentityResult> CreateUserAsync(User user, string password);
        Task<IdentityResult> CreateUserWithoutPasswordAsync(User user);
        Task<User> GetUserByEmailAsync(string email);
        Task<bool> CheckPasswordAsync(User user, string password);
    }
}
