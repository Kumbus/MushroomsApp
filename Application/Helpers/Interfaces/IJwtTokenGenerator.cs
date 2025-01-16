using Domain.Entities;

namespace Domain.Helpers.Interfaces
{
    public interface IJwtTokenGenerator
    {
        string GenerateToken(User user);
    }

}
