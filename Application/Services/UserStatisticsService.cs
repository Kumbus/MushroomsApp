using Application.DTOs.StatisticsDTOs;
using Application.ServicesInterfaces;
using AutoMapper;
using Domain.Helpers.Extensions;
using Domain.Helpers.Responses;
using Domain.RepositoriesInterfaces;

namespace Application.Services
{
    public class UserStatisticsService : IUserStatisticsService
    {
        private readonly IMushroomingMushroomRepository _mushroomingMushroomRepository;
        private readonly IMushroomingRepository _mushroomingRepository;
        private readonly IMapper _mapper;

        public UserStatisticsService(
            IMushroomingMushroomRepository mushroomingMushroomRepository,
            IMushroomingRepository mushroomingRepository,
            IMapper mapper)
        {
            _mushroomingMushroomRepository = mushroomingMushroomRepository;
            _mushroomingRepository = mushroomingRepository;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<PagedResult<UserMushroomStatisticsDto>>> GetMushroomStatisticsAsync(Guid userId, QueryParameters parameters)
        {
            var result = await _mushroomingMushroomRepository.GetMushroomStatisticsPagedAsync(userId, parameters);

            var groupedDto = result.Items.Select(group => new MushroomStatisticsDto
            {
                MushroomName = group.Key,
                TotalWeight = group.Sum(m => m.Weight),
                Count = group.Count()
            });

            return new ServiceResponse<PagedResult<UserMushroomStatisticsDto>>
            {
                Success = true,
                Data = new PagedResult<UserMushroomStatisticsDto>((IEnumerable<UserMushroomStatisticsDto>)groupedDto, result.TotalCount, parameters.PageSize, parameters.Page)
            };
        }

        public async Task<ServiceResponse<PagedResult<UserMushroomingStatisticsDto>>> GetMushroomingStatisticsAsync(Guid userId, QueryParameters parameters)
        {
            var result = await _mushroomingRepository.GetMushroomingStatisticsPagedAsync(userId, parameters);

            var groupedDto = result.Items.Select(group => new MushroomingStatisticsDto
            {
                LocationName = group.Key,
                MushroomingCount = group.Count()
            });

            return new ServiceResponse<PagedResult<UserMushroomingStatisticsDto>>
            {
                Success = true,
                Data = new PagedResult<UserMushroomingStatisticsDto>((IEnumerable<UserMushroomingStatisticsDto>)groupedDto, result.TotalCount, parameters.PageSize, parameters.Page)
            };
        }
    }
}
