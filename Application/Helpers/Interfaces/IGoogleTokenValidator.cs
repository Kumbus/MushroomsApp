using Domain.Helpers.Domain.Entities;

namespace Domain.Helpers.Interfaces
{
    public interface IGoogleTokenValidator
    {
        Task<GoogleUser> ValidateAsync(string token);
    }

}
