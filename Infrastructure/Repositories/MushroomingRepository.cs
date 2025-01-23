using Domain.Entities;
using Domain.Helpers.Entities;
using Domain.Helpers.Extensions;
using Domain.Helpers.Responses;
using Domain.RepositoriesInterfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class MushroomingRepository : RepositoryBase<Mushrooming>, IMushroomingRepository
    {
        public MushroomingRepository(MushroomsDbContext context) : base(context) { }

        public async Task<PagedResult<GroupedStatistics<Mushrooming>>> GetMushroomingStatisticsPagedAsync(Guid userId, QueryParameters parameters)
        {
            var groupedQuery = _dbSet
                .Where(m => m.UserId == userId)
                .GroupBy(m => m.Location.Name)
                .Select(g => new GroupedStatistics<Mushrooming>
                {
                    Key = g.Key,
                    Items = g.ToList()
                });

            var groupedData = await groupedQuery.ToListAsync();

            var totalCount = groupedData.Count;

            var pagedItems = groupedData
                .Skip((parameters.Page - 1) * parameters.PageSize)
                .Take(parameters.PageSize)
                .AsEnumerable();

            return new PagedResult<GroupedStatistics<Mushrooming>>(pagedItems, parameters.PageSize, totalCount, parameters.Page);
        }
    }
}
