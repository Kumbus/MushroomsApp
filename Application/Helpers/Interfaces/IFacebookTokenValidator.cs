using Domain.Helpers.Entities;

namespace Application.Helpers.Interfaces
{
    public interface IFacebookTokenValidator
    {
        Task<FacebookUser> ValidateAsync(string token);
    }
}
