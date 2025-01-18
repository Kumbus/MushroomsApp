using Application.DTOs.MushroomDTOs;
using Domain.Entities;

namespace Application.ServicesInterfaces
{
    public interface IMushroomService : IBaseService<Mushroom, MushroomDto, CreateMushroomDto, UpdateMushroomDto>
    {
    }
}
