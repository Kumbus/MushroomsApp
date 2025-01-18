using Application.DTOs.MushroomDTOs;
using Application.ServicesInterfaces;
using AutoMapper;
using Domain.Entities;
using Domain.RepositoriesInterfaces;

namespace Application.Services
{
    public class MushroomService : BaseService<Mushroom, MushroomDto, CreateMushroomDto, UpdateMushroomDto>, IMushroomService
    {
        public MushroomService(IRepositoryBase<Mushroom> repository, IMapper mapper) : base(repository, mapper)
        {
        }
    }

}
