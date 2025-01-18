using Application.DTOs.MushroomDTOs;
using Application.ServicesInterfaces;
using AutoMapper;
using Domain.Entities;
using Domain.Helpers.Extensions;
using Domain.Helpers.Responses;
using Domain.RepositoriesInterfaces;

namespace Application.Services
{
    public class MushroomService : IMushroomService
    {
        private readonly IMushroomRepository _mushroomRepository;
        private readonly ISpeciesRepository _speciesRepository;
        private readonly IMapper _mapper;

        public MushroomService(IMushroomRepository mushroomRepository, ISpeciesRepository speciesRepository, IMapper mapper)
        {
            _mushroomRepository = mushroomRepository;
            _speciesRepository = speciesRepository;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<MushroomDto?>> GetMushroomByIdAsync(Guid id)
        {
            Mushroom? mushroom = await _mushroomRepository.GetByIdWithIncludesAsync(id, m => m.Species);

            if (mushroom == null)
                return new ServiceResponse<MushroomDto?>
                {
                    Success = false,
                    Message = $"Mushroom with Id {id} does not exist."
                };

            MushroomDto mushroomDto = _mapper.Map<MushroomDto>(mushroom);

            return new ServiceResponse<MushroomDto?>
            {
                Success = true,
                Data = mushroomDto
            };
        }

        public async Task<ServiceResponse<PagedResult<MushroomDto>>> GetAllMushroomsAsync(QueryParameters parameters)
        {
            PagedResult<Mushroom> pagedResult = await _mushroomRepository.GetPagedAsync(parameters, m => m.Species);

            IEnumerable<MushroomDto> items = _mapper.Map<IEnumerable<MushroomDto>>(pagedResult.Items);
            PagedResult<MushroomDto> pagedResponse = new PagedResult<MushroomDto>(items, pagedResult.TotalCount, parameters.PageSize, parameters.Page);

            return new ServiceResponse<PagedResult<MushroomDto>>
            {
                Success = true,
                Message = "Items returned",
                Data = pagedResponse
            };
        }

        public async Task<ServiceResponse<MushroomDto>> CreateMushroomAsync(CreateMushroomDto dto)
        {
            Species? species = await _speciesRepository.GetByIdAsync(dto.SpeciesId);
            if (species == null)
                return new ServiceResponse<MushroomDto>
                {
                    Success = false,
                    Message = $"Species with Id {dto.SpeciesId} does not exist."
                };

            Mushroom mushroom = _mapper.Map<Mushroom>(dto);
            Mushroom createdMushroom = await _mushroomRepository.CreateAsync(mushroom);
            MushroomDto mushroomDto = _mapper.Map<MushroomDto>(createdMushroom);

            return new ServiceResponse<MushroomDto>
            {
                Success = true,
                Message = "Mushroom created successfully",
                Data = mushroomDto
            };
        }

        public async Task<ServiceResponse<MushroomDto>> UpdateMushroomAsync(Guid id, UpdateMushroomDto dto)
        {
            Mushroom? mushroom = await _mushroomRepository.GetByIdAsync(id);
            if (mushroom == null)
                return new ServiceResponse<MushroomDto>
                {
                    Success = false,
                    Message = $"Mushroom with Id {id} does not exist."
                };

            if (dto.SpeciesId != mushroom.SpeciesId)
            {
                Species? species = await _speciesRepository.GetByIdAsync(dto.SpeciesId);
                if (species == null)
                    return new ServiceResponse<MushroomDto>
                    {
                        Success = false,
                        Message = $"Species with Id {dto.SpeciesId} does not exist."
                    };
            }

            _mapper.Map(dto, mushroom);
            Mushroom updatedMushroom = await _mushroomRepository.UpdateAsync(mushroom);
            MushroomDto mushroomDto = _mapper.Map<MushroomDto>(updatedMushroom);

            return new ServiceResponse<MushroomDto>
            {
                Success = true,
                Message = "Mushroom updated successfully",
                Data = mushroomDto
            };
        }

        public async Task<ServiceResponse<bool>> DeleteMushroomAsync(Guid id)
        {
            Mushroom? mushroom = await _mushroomRepository.GetByIdAsync(id);
            if (mushroom == null)
                return new ServiceResponse<bool>
                {
                    Success = false,
                    Message = $"Mushroom with Id {id} does not exist."
                };

            await _mushroomRepository.DeleteAsync(id);

            return new ServiceResponse<bool>
            {
                Success = true,
                Message = "Mushroom deleted successfully."
            };
        }
    }

}
