using Application.DTOs.MushroomingMushroomPhotoDTOs;
using Domain.Entities;

namespace Application.ServicesInterfaces
{
    public interface IMushroomingMushroomPhotoService : IBaseService<MushroomingMushroomPhoto, MushroomingMushroomPhotoDto, CreateMushroomingMushroomPhotoDto, UpdateMushroomingMushroomPhotoDto>
    {
    }
}
