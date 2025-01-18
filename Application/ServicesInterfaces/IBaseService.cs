using Domain.Helpers.Extensions;
using Domain.Helpers.Responses;
using System.Linq.Expressions;

namespace Application.ServicesInterfaces
{
    public interface IBaseService<TEntity, TDto, TCreateDto, TUpdateDto>
    {
        Task<ServiceResponse<TDto?>> GetByIdAsync(Guid id, params Expression<Func<TEntity, object>>[] includes);
        Task<ServiceResponse<PagedResult<TDto>>> GetMultipleAsync(QueryParameters parameters, params Expression<Func<TEntity, object>>[] includes);
        Task<ServiceResponse<TDto>> CreateAsync(TCreateDto dto);
        Task<ServiceResponse<TDto>> UpdateAsync(Guid id, TUpdateDto dto);
        Task<ServiceResponse<bool>> DeleteAsync(Guid id);
    }

}
