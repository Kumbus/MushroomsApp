using Application.DTOs.LocationDTOs;
using Domain.Entities;

namespace Application.ServicesInterfaces
{
    public interface ILocationService : IBaseService<Location, LocationDto, CreateLocationDto, UpdateLocationDto>
    {
    }

}
