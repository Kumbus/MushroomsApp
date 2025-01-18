using Application.DTOs.AuthDTOs;
using Application.DTOs.UserDTOs;
using Application.ServicesInterfaces;
using AutoMapper;
using Domain.Entities;
using Domain.RepositoriesInterfaces;

namespace Application.Services
{
    public class UserService : BaseService<User, UserDto, RegisterUserDto, UpdateUserDto>, IUserService
    {
        public UserService(IRepositoryBase<User> repository, IMapper mapper) : base(repository, mapper)
        {
        }
    }
}
