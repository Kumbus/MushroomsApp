using Domain.Entities;
using Domain.Helpers.Entities;
using Domain.Helpers.Extensions;
using Domain.Helpers.Responses;

namespace Domain.RepositoriesInterfaces
{
    public interface IMushroomingMushroomRepository : IRepositoryBase<MushroomingMushroom>
    {
        Task<PagedResult<GroupedStatistics<MushroomingMushroom>>> GetMushroomStatisticsPagedAsync(Guid userId, QueryParameters parameters);
    }
}
