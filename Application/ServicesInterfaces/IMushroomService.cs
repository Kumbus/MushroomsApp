using Application.DTOs.MushroomDTOs;
using Domain.Helpers.Extensions;
using Domain.Helpers.Responses;

namespace Application.ServicesInterfaces
{
    public interface IMushroomService
    {
        Task<ServiceResponse<MushroomDto?>> GetMushroomByIdAsync(Guid id);
        Task<ServiceResponse<PagedResult<MushroomDto>>> GetAllMushroomsAsync(QueryParameters parameters);
        Task<ServiceResponse<MushroomDto>> CreateMushroomAsync(CreateMushroomDto dto);
        Task<ServiceResponse<MushroomDto>> UpdateMushroomAsync(Guid id, UpdateMushroomDto dto);
        Task<ServiceResponse<bool>> DeleteMushroomAsync(Guid id);
    }
}
