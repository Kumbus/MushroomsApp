using Application.DTOs.MushroomingMushroomPhotoDTOs;
using Application.ServicesInterfaces;
using AutoMapper;
using Domain.Entities;
using Domain.RepositoriesInterfaces;

namespace Application.Services
{
    public class MushroomingMushroomPhotoService : BaseService<MushroomingMushroomPhoto, MushroomingMushroomPhotoDto, CreateMushroomingMushroomPhotoDto, UpdateMushroomingMushroomPhotoDto>, IMushroomingMushroomPhotoService
    {
        public MushroomingMushroomPhotoService(IRepositoryBase<MushroomingMushroomPhoto> repository, IMapper mapper)
            : base(repository, mapper)
        {
        }
    }
}
