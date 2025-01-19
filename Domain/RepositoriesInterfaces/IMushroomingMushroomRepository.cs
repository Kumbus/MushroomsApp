using Domain.Entities;
using Domain.Helpers.Extensions;
using Domain.Helpers.Responses;

namespace Domain.RepositoriesInterfaces
{
    public interface IMushroomingMushroomRepository : IRepositoryBase<MushroomingMushroom>
    {
        Task<PagedResult<IGrouping<string, MushroomingMushroom>>> GetMushroomStatisticsPagedAsync(Guid userId, QueryParameters parameters);
    }
}
