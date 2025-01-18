using Application.DTOs.MushroomingDTOs;
using Application.ServicesInterfaces;
using AutoMapper;
using Domain.Entities;
using Domain.RepositoriesInterfaces;

namespace Application.Services
{
    public class MushroomingService : BaseService<Mushrooming, MushroomingDto, CreateMushroomingDto, UpdateMushroomingDto>, IMushroomingService
    {
        public MushroomingService(IRepositoryBase<Mushrooming> repository, IMapper mapper) : base(repository, mapper)
        {
        }
    }
}
