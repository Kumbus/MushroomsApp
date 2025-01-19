using Domain.Entities;
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

        public async Task<PagedResult<IGrouping<string, Mushrooming>>> GetMushroomingStatisticsPagedAsync(Guid userId, QueryParameters parameters)
        {
            var query = _dbSet
                .Where(m => m.Users.Any(u => u.Id == userId))
                .GroupBy(m => m.Location.Name);

            var totalCount = await query.CountAsync();

            var pagedItems = await query
                .Skip((parameters.Page - 1) * parameters.PageSize)
                .Take(parameters.PageSize)
                .ToListAsync();

            return new PagedResult<IGrouping<string, Mushrooming>>(pagedItems, totalCount, parameters.PageSize, parameters.Page);
        }
    }
}
