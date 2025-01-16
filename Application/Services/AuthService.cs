using Application.DTOs.UserDTOs;
using Application.ServicesInterfaces;
using Domain.Entities;
using Domain.Helpers;
using Domain.Helpers.Interfaces;
using Domain.RepositoriesInterfaces;

namespace Application.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepository;
        private readonly IJwtTokenGenerator _jwtTokenGenerator;
        private readonly IGoogleTokenValidator _googleTokenValidator;

        public AuthService(IUserRepository userRepository, IJwtTokenGenerator jwtTokenGenerator, IGoogleTokenValidator googleTokenValidator)
        {
            _userRepository = userRepository;
            _jwtTokenGenerator = jwtTokenGenerator;
            _googleTokenValidator = googleTokenValidator;
        }

        public async Task<ServiceResponse<AuthResponseDto>> RegisterAsync(RegisterUserDto dto)
        {
            if (await _userRepository.UserExistsAsync(dto.Email))
                return new ServiceResponse<AuthResponseDto> { Success = false, Message = "User already exists." };

            var user = new User
            {
                UserName = dto.Email,
                Email = dto.Email,
                FirstName = dto.FirstName,
                LastName = dto.LastName
            };

            var result = await _userRepository.CreateUserAsync(user, dto.Password);
            if (!result.Succeeded)
                return new ServiceResponse<AuthResponseDto> { Success = false, Message = "Registration failed." };

            return new ServiceResponse<AuthResponseDto> { Success = true };
        }

        public async Task<ServiceResponse<AuthResponseDto>> LoginAsync(LoginUserDto dto)
        {
            var user = await _userRepository.GetUserByEmailAsync(dto.Email);
            if (user == null || !await _userRepository.CheckPasswordAsync(user, dto.Password))
                return new ServiceResponse<AuthResponseDto> { Success = false, Message = "Invalid credentials." };

            var token = _jwtTokenGenerator.GenerateToken(user);
            return new ServiceResponse<AuthResponseDto>
            {
                Success = true,
                Data = new AuthResponseDto { Token = token }
            };
        }

        public async Task<ServiceResponse<AuthResponseDto>> GoogleLoginAsync(GoogleLoginDto dto)
        {
            var googleUser = await _googleTokenValidator.ValidateAsync(dto.Token);
            if (googleUser == null)
                return new ServiceResponse<AuthResponseDto> { Success = false, Message = "Invalid Google token." };

            var user = await _userRepository.GetUserByEmailAsync(googleUser.Email);
            if (user == null)
            {
                user = new User
                {
                    UserName = googleUser.Email,
                    Email = googleUser.Email,
                    FirstName = googleUser.GivenName,
                    LastName = googleUser.FamilyName
                };
                await _userRepository.CreateUserAsync(user, null);
            }

            var token = _jwtTokenGenerator.GenerateToken(user);
            return new ServiceResponse<AuthResponseDto>
            {
                Success = true,
                Data = new AuthResponseDto { Token = token }
            };
        }
    }

}
