using Domain.Entities;
using Domain.Helpers.Extensions;
using Domain.Helpers.Responses;

namespace Domain.RepositoriesInterfaces
{
    public interface IMushroomingRepository : IRepositoryBase<Mushrooming>
    {
        Task<PagedResult<IGrouping<string, Mushrooming>>> GetMushroomingStatisticsPagedAsync(Guid userId, QueryParameters parameters);
    }
}
