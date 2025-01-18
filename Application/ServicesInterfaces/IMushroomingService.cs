using Application.DTOs.MushroomingDTOs;
using Domain.Entities;

namespace Application.ServicesInterfaces
{
    public interface IMushroomingService : IBaseService<Mushrooming, MushroomingDto, CreateMushroomingDto, UpdateMushroomingDto>
    {
    }
}
