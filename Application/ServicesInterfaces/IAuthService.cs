using Application.DTOs.UserDTOs;
using Domain.Helpers;

namespace Application.ServicesInterfaces
{
    public interface IAuthService
    {
        Task<ServiceResponse<AuthResponseDto>> RegisterAsync(RegisterUserDto dto);
        Task<ServiceResponse<AuthResponseDto>> LoginAsync(LoginUserDto dto);
        Task<ServiceResponse<AuthResponseDto>> GoogleLoginAsync(GoogleLoginDto dto);
    }
}
