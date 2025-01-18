using Application.DTOs.SpeciesDTOs;
using Domain.Entities;

namespace Application.ServicesInterfaces
{
    public interface ISpeciesService : IBaseService<Species, SpeciesDto, CreateSpeciesDto, UpdateSpeciesDto>
    {
    }

}
