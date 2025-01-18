using Application.DTOs.MushroomingMushroomDTOs;
using Domain.Entities;

namespace Application.ServicesInterfaces
{
    public interface IMushroomingMushroomService : IBaseService<MushroomingMushroom, MushroomingMushroomDto, CreateMushroomingMushroomDto, UpdateMushroomingMushroomDto>
    {
    }
}
