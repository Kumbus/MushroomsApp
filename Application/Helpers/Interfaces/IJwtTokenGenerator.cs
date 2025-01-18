using Domain.Entities;
using System.Security.Claims;

namespace Domain.Helpers.Interfaces
{
    public interface IJwtTokenGenerator
    {
        string GenerateToken(User user);
        ClaimsPrincipal GetPrincipalFromExpiredToken(string token);
    }

}
