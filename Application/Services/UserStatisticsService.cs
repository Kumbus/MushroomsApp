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

        public async Task<ServiceResponse<PagedResult<MushroomStatisticsDto>>> GetMushroomStatisticsAsync(Guid userId, QueryParameters parameters)
        {
            var result = await _mushroomingMushroomRepository.GetMushroomStatisticsPagedAsync(userId, parameters);

            var groupedDto = result.Items.Select(stat => new MushroomStatisticsDto
            {
                MushroomName = stat.Key,
                TotalWeight = stat.Items.Sum(m => m.Weight),
                Count = stat.Items.Count
            });

            return new ServiceResponse<PagedResult<MushroomStatisticsDto>>
            {
                Success = true,
                Data = new PagedResult<MushroomStatisticsDto>(groupedDto, parameters.PageSize, result.TotalCount, parameters.Page)
            };
        }

        public async Task<ServiceResponse<PagedResult<MushroomingStatisticsDto>>> GetMushroomingStatisticsAsync(Guid userId, QueryParameters parameters)
        {
            var result = await _mushroomingRepository.GetMushroomingStatisticsPagedAsync(userId, parameters);

            var groupedDto = result.Items.Select(stat => new MushroomingStatisticsDto
            {
                LocationName = stat.Key,
                MushroomingCount = stat.Items.Count
            });

            return new ServiceResponse<PagedResult<MushroomingStatisticsDto>>
            {
                Success = true,
                Data = new PagedResult<MushroomingStatisticsDto>(groupedDto, parameters.PageSize, result.TotalCount, parameters.Page)
            };
        }
    }
}
