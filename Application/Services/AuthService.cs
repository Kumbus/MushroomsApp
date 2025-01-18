using Application.DTOs.AuthDTOs;
using Application.Helpers.Interfaces;
using Application.ServicesInterfaces;
using Domain.Entities;
using Domain.Helpers.Interfaces;
using Domain.Helpers.Responses;
using Domain.RepositoriesInterfaces;
using System.Security.Claims;
using System.Security.Cryptography;

namespace Application.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepository;
        private readonly IJwtTokenGenerator _jwtTokenGenerator;
        private readonly IGoogleTokenValidator _googleTokenValidator;
        private readonly IFacebookTokenValidator _facebookTokenValidator;

        public AuthService(IUserRepository userRepository, IJwtTokenGenerator jwtTokenGenerator, IGoogleTokenValidator googleTokenValidator, IFacebookTokenValidator facebookTokenValidator)
        {
            _userRepository = userRepository;
            _jwtTokenGenerator = jwtTokenGenerator;
            _googleTokenValidator = googleTokenValidator;
            _facebookTokenValidator = facebookTokenValidator;
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

            var jwtToken = _jwtTokenGenerator.GenerateToken(user);
            var refreshToken = GenerateRefreshToken();
            user.RefreshToken = refreshToken;
            user.RefreshTokenExpiryTime = DateTime.UtcNow.AddDays(7);
            await _userRepository.UpdateAsync(user);

            return new ServiceResponse<AuthResponseDto>
            {
                Success = true,
                Data = new AuthResponseDto { Token = jwtToken, RefreshToken = refreshToken }
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
                await _userRepository.CreateUserWithoutPasswordAsync(user);
            }

            var jwtToken = _jwtTokenGenerator.GenerateToken(user);
            var refreshToken = GenerateRefreshToken();
            user.RefreshToken = refreshToken;
            user.RefreshTokenExpiryTime = DateTime.UtcNow.AddDays(7);
            await _userRepository.UpdateAsync(user);

            return new ServiceResponse<AuthResponseDto>
            {
                Success = true,
                Data = new AuthResponseDto { Token = jwtToken, RefreshToken = refreshToken }
            };
        }

        public async Task<ServiceResponse<AuthResponseDto>> FacebookLoginAsync(string token)
        {
            var facebookUser = await _facebookTokenValidator.ValidateAsync(token);
            if (facebookUser == null)
            {
                return new ServiceResponse<AuthResponseDto> { Success = false, Message = "Invalid Facebook token." };
            }

            var user = await _userRepository.GetUserByEmailAsync(facebookUser.Email);
            if (user == null)
            {
                user = new User
                {
                    UserName = facebookUser.Email,
                    Email = facebookUser.Email,
                    FirstName = facebookUser.FirstName,
                    LastName = facebookUser.LastName
                };

                var result = await _userRepository.CreateUserWithoutPasswordAsync(user);
                if (!result.Succeeded)
                {
                    return new ServiceResponse<AuthResponseDto> { Success = false, Message = "Failed to register user." };
                }
            }

            var jwtToken = _jwtTokenGenerator.GenerateToken(user);
            var refreshToken = GenerateRefreshToken();
            user.RefreshToken = refreshToken;
            user.RefreshTokenExpiryTime = DateTime.UtcNow.AddDays(7);
            await _userRepository.UpdateAsync(user);

            return new ServiceResponse<AuthResponseDto>
            {
                Success = true,
                Data = new AuthResponseDto { Token = jwtToken, RefreshToken = refreshToken }
            };
        }

        public async Task<ServiceResponse<AuthResponseDto>> RefreshTokenAsync(RefreshTokenRequestDto dto)
        {
            var principal = _jwtTokenGenerator.GetPrincipalFromExpiredToken(dto.Token);
            var userId = principal.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            var user = await _userRepository.GetByIdAsync(Guid.Parse(userId));
            if (user == null || user.RefreshToken != dto.RefreshToken || user.RefreshTokenExpiryTime <= DateTime.UtcNow)
            {
                return new ServiceResponse<AuthResponseDto> { Success = false, Message = "Invalid Refresh Token" };
            }

            var newJwtToken = _jwtTokenGenerator.GenerateToken(user);
            var newRefreshToken = GenerateRefreshToken();

            user.RefreshToken = newRefreshToken;
            user.RefreshTokenExpiryTime = DateTime.UtcNow.AddDays(7);
            await _userRepository.UpdateAsync(user);

            return new ServiceResponse<AuthResponseDto>
            {
                Success = true,
                Data = new AuthResponseDto
                {
                    Token = newJwtToken,
                    RefreshToken = newRefreshToken
                }
            };
        }

        private static string GenerateRefreshToken()
        {
            var randomNumber = new byte[32];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(randomNumber);
                return Convert.ToBase64String(randomNumber);
            }
        }
    }
}
