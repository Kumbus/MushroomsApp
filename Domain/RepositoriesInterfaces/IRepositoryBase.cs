using Domain.Helpers.Extensions;
using Domain.Helpers.Responses;
using System.Linq.Expressions;

namespace Domain.RepositoriesInterfaces
{
    public interface IRepositoryBase<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T?> GetByIdWithIncludesAsync(Guid id, params Expression<Func<T, object>>[] includes);
        Task<T> GetByIdAsync(Guid? id);
        Task<IEnumerable<T>> FindByConditionAsync(Expression<Func<T, bool>> expression);
        Task<T> CreateAsync(T entity);
        Task<T> UpdateAsync(T entity);
        Task DeleteAsync(Guid? id);
        Task<PagedResult<T>> GetPagedAsync(QueryParameters parameters, params Expression<Func<T, object>>[] includes);
    }
}
