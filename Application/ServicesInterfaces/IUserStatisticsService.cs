using Application.DTOs.StatisticsDTOs;
using Domain.Helpers.Extensions;
using Domain.Helpers.Responses;

namespace Application.ServicesInterfaces
{
    public interface IUserStatisticsService
    {
        Task<ServiceResponse<PagedResult<MushroomStatisticsDto>>> GetMushroomStatisticsAsync(Guid userId, QueryParameters parameters);
        Task<ServiceResponse<PagedResult<MushroomingStatisticsDto>>> GetMushroomingStatisticsAsync(Guid userId, QueryParameters parameters);
    }
}