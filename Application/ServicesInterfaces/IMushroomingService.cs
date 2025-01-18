using Application.DTOs.MushroomingDTOs;
using Domain.Helpers.Extensions;
using Domain.Helpers.Responses;

namespace Application.ServicesInterfaces
{
    public interface IMushroomingService
    {
        Task<ServiceResponse<MushroomingDto?>> GetMushroomingByIdAsync(Guid id);
        Task<ServiceResponse<PagedResult<MushroomingDto>>> GetAllMushroomingsAsync(QueryParameters parameters);
        Task<ServiceResponse<MushroomingDto>> CreateMushroomingAsync(CreateMushroomingDto dto);
        Task<ServiceResponse<MushroomingDto>> UpdateMushroomingAsync(Guid id, UpdateMushroomingDto dto);
        Task<ServiceResponse<bool>> DeleteMushroomingAsync(Guid id);
    }
}
