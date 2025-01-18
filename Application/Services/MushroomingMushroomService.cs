using Application.DTOs.MushroomingMushroomDTOs;
using Application.ServicesInterfaces;
using AutoMapper;
using Domain.Entities;
using Domain.RepositoriesInterfaces;

namespace Application.Services
{
    public class MushroomingMushroomService : BaseService<MushroomingMushroom, MushroomingMushroomDto, CreateMushroomingMushroomDto, UpdateMushroomingMushroomDto>, IMushroomingMushroomService
    {
        public MushroomingMushroomService(IRepositoryBase<MushroomingMushroom> repository, IMapper mapper)
            : base(repository, mapper)
        {
        }
    }
}
