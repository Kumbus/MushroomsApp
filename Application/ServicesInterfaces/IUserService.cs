using Application.DTOs.AuthDTOs;
using Application.DTOs.UserDTOs;
using Domain.Entities;

namespace Application.ServicesInterfaces
{
    public interface IUserService : IBaseService<User, UserDto, RegisterUserDto, UpdateUserDto>
    {
    }
}
