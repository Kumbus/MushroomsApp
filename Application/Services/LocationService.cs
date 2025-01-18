using Application.DTOs.LocationDTOs;
using Application.ServicesInterfaces;
using AutoMapper;
using Domain.Entities;
using Domain.RepositoriesInterfaces;

namespace Application.Services
{
    public class LocationService : BaseService<Location, LocationDto, CreateLocationDto, UpdateLocationDto>, ILocationService
    {
        public LocationService(IRepositoryBase<Location> repository, IMapper mapper) : base(repository, mapper)
        {
        }
    }

}
