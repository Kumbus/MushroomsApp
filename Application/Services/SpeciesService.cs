using Application.DTOs.SpeciesDTOs;
using Application.ServicesInterfaces;
using AutoMapper;
using Domain.Entities;
using Domain.RepositoriesInterfaces;

namespace Application.Services
{
    public class SpeciesService : BaseService<Species, SpeciesDto, CreateSpeciesDto, UpdateSpeciesDto>, ISpeciesService
    {
        public SpeciesService(IRepositoryBase<Species> repository, IMapper mapper) : base(repository, mapper)
        {
        }
    }
}
