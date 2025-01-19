using Application.DTOs.StatisticsDTOs;
using Domain.Helpers.Extensions;
using Domain.Helpers.Responses;

namespace Application.ServicesInterfaces
{
    public interface IUserStatisticsService
    {
        Task<ServiceResponse<PagedResult<UserMushroomStatisticsDto>>> GetMushroomStatisticsAsync(Guid userId, QueryParameters parameters);
        Task<ServiceResponse<PagedResult<UserMushroomingStatisticsDto>>> GetMushroomingStatisticsAsync(Guid userId, QueryParameters parameters);
    }
}