using Application.ServicesInterfaces;
using AutoMapper;
using Domain.Helpers.Extensions;
using Domain.Helpers.Responses;
using Domain.RepositoriesInterfaces;
using System.Linq.Expressions;

namespace Application.Services
{
    public class BaseService<TEntity, TDto, TCreateDto, TUpdateDto> : IBaseService<TEntity, TDto, TCreateDto, TUpdateDto> where TEntity : class
    {
        private readonly IRepositoryBase<TEntity> _repository;
        private readonly IMapper _mapper;

        public BaseService(IRepositoryBase<TEntity> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<TDto?>> GetByIdAsync(Guid id, params Expression<Func<TEntity, object>>[] includes)
        {
            var entity = await _repository.GetByIdWithIncludesAsync(id, includes);
            if (entity == null)
            {
                return new ServiceResponse<TDto?>
                {
                    Success = false,
                    Message = $"{typeof(TEntity).Name} with Id {id} does not exist."
                };
            }

            var dto = _mapper.Map<TDto>(entity);
            return new ServiceResponse<TDto?>
            {
                Success = true,
                Data = dto
            };
        }

        public async Task<ServiceResponse<PagedResult<TDto>>> GetMultipleAsync(QueryParameters parameters, params Expression<Func<TEntity, object>>[] includes)
        {
            var pagedResult = await _repository.GetPagedAsync(parameters, includes);
            var items = _mapper.Map<IEnumerable<TDto>>(pagedResult.Items);
            var pagedResponse = new PagedResult<TDto>(items, parameters.PageSize, pagedResult.TotalCount, parameters.Page);

            return new ServiceResponse<PagedResult<TDto>>
            {
                Success = true,
                Message = "Items returned",
                Data = pagedResponse
            };
        }

        public async Task<ServiceResponse<TDto>> CreateAsync(TCreateDto dto)
        {
            var entity = _mapper.Map<TEntity>(dto);
            var createdEntity = await _repository.CreateAsync(entity);
            var createdDto = _mapper.Map<TDto>(createdEntity);

            return new ServiceResponse<TDto>
            {
                Success = true,
                Message = $"{typeof(TEntity).Name} created successfully",
                Data = createdDto
            };
        }

        public async Task<ServiceResponse<TDto>> UpdateAsync(Guid id, TUpdateDto dto)
        {
            var entity = await _repository.GetByIdAsync(id);
            if (entity == null)
            {
                return new ServiceResponse<TDto>
                {
                    Success = false,
                    Message = $"{typeof(TEntity).Name} with Id {id} does not exist."
                };
            }

            _mapper.Map(dto, entity);
            var updatedEntity = await _repository.UpdateAsync(entity);
            var updatedDto = _mapper.Map<TDto>(updatedEntity);

            return new ServiceResponse<TDto>
            {
                Success = true,
                Message = $"{typeof(TEntity).Name} updated successfully",
                Data = updatedDto
            };
        }

        public async Task<ServiceResponse<bool>> DeleteAsync(Guid id)
        {
            var entity = await _repository.GetByIdAsync(id);
            if (entity == null)
            {
                return new ServiceResponse<bool>
                {
                    Success = false,
                    Message = $"{typeof(TEntity).Name} with Id {id} does not exist."
                };
            }

            await _repository.DeleteAsync(id);
            return new ServiceResponse<bool>
            {
                Success = true,
                Message = $"{typeof(TEntity).Name} deleted successfully"
            };
        }
    }

}
