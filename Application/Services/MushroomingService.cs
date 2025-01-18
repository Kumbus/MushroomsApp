using Application.DTOs.MushroomingDTOs;
using Application.ServicesInterfaces;
using AutoMapper;
using Domain.Entities;
using Domain.Helpers.Extensions;
using Domain.Helpers.Responses;
using Domain.RepositoriesInterfaces;

namespace Application.Services
{
    public class MushroomingService : IMushroomingService
    {
        private readonly IMushroomingRepository _mushroomingRepository;
        private readonly ILocationRepository _locationRepository;
        private readonly IMapper _mapper;

        public MushroomingService(IMushroomingRepository mushroomingRepository, ILocationRepository locationRepository, IMapper mapper)
        {
            _mushroomingRepository = mushroomingRepository;
            _locationRepository = locationRepository;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<MushroomingDto?>> GetMushroomingByIdAsync(Guid id)
        {
            Mushrooming? mushrooming = await _mushroomingRepository.GetByIdWithIncludesAsync(id, m => m.Location);

            if (mushrooming == null)
                return new ServiceResponse<MushroomingDto?>
                {
                    Success = false,
                    Message = $"Mushhroming with Id equals to {id} does not exist."
                };

            MushroomingDto mushroomingDto = _mapper.Map<MushroomingDto>(mushrooming);

            return new ServiceResponse<MushroomingDto?>
            {
                Success = true,
                Data = mushroomingDto,
            };
        }


        public async Task<ServiceResponse<PagedResult<MushroomingDto>>> GetAllMushroomingsAsync(QueryParameters parameters)
        {
            PagedResult<Mushrooming> pagedResult = await _mushroomingRepository.GetPagedAsync(parameters, m => m.Location);

            IEnumerable<MushroomingDto> items = _mapper.Map<IEnumerable<MushroomingDto>>(pagedResult.Items);
            PagedResult<MushroomingDto> pagedResponse = new PagedResult<MushroomingDto>(items, parameters.PageSize, pagedResult.TotalCount, parameters.Page);

            return new ServiceResponse<PagedResult<MushroomingDto>>
            {
                Success = true,
                Message = "Items returned",
                Data = pagedResponse
            };
        }

        public async Task<ServiceResponse<MushroomingDto>> CreateMushroomingAsync(CreateMushroomingDto dto)
        {
            Location location = await _locationRepository.GetByIdAsync(dto.LocationId);
            if (location == null)
                return new ServiceResponse<MushroomingDto>
                {
                    Success = false,
                    Message = $"Location with Id equals to {dto.LocationId} does not exist."
                };

            Mushrooming mushrooming = _mapper.Map<Mushrooming>(dto);
            Mushrooming createdMuhrooming = await _mushroomingRepository.CreateAsync(mushrooming);
            MushroomingDto mushroomingDto = _mapper.Map<MushroomingDto>(createdMuhrooming);

            return new ServiceResponse<MushroomingDto>
            {
                Success = true,
                Message = "Mushrooming created",
                Data = mushroomingDto
            };
        }

        public async Task<ServiceResponse<MushroomingDto>> UpdateMushroomingAsync(Guid id, UpdateMushroomingDto dto)
        {
            Mushrooming mushrooming = await _mushroomingRepository.GetByIdAsync(id);
            if (mushrooming == null)
                return new ServiceResponse<MushroomingDto>
                {
                    Success = false,
                    Message = $"Mushhroming with Id equals to {id} does not exist."
                };

            if (dto.LocationId.HasValue)
            {
                Location location = await _locationRepository.GetByIdAsync(dto.LocationId.Value);
                if (location == null)
                    throw new ArgumentException("Invalid LocationId");

                mushrooming.LocationId = dto.LocationId.Value;
            }

            mushrooming.EndDate = dto.EndDate ?? mushrooming.EndDate;
            mushrooming.Status = dto.Status ?? mushrooming.Status;

            Mushrooming updatedMushroming = await _mushroomingRepository.UpdateAsync(mushrooming);
            MushroomingDto mushroomingDto = _mapper.Map<MushroomingDto>(updatedMushroming);
            return new ServiceResponse<MushroomingDto>
            {
                Success = true,
                Message = $"Mushrooming with id {id} updated",
                Data = mushroomingDto,
            };
        }

        public async Task<ServiceResponse<bool>> DeleteMushroomingAsync(Guid id)
        {
            var mushrooming = await _mushroomingRepository.GetByIdAsync(id);
            if (mushrooming == null)
                return new ServiceResponse<bool>
                {
                    Success = false,
                    Message = $"Mushhroming with Id equals to {id} does not exist."
                };

            await _mushroomingRepository.DeleteAsync(id);
            return new ServiceResponse<bool>
            {
                Success = true,
                Message = "Mushrooming with Id deleted successfully."
            };
        }
    }
}
