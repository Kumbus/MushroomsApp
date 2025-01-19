using Domain.Entities;
using Domain.Helpers.Extensions;
using Domain.Helpers.Responses;
using Domain.RepositoriesInterfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class MushroomingMushroomRepository : RepositoryBase<MushroomingMushroom>, IMushroomingMushroomRepository
    {
        public MushroomingMushroomRepository(MushroomsDbContext context) : base(context) { }

        public async Task<PagedResult<IGrouping<string, MushroomingMushroom>>> GetMushroomStatisticsPagedAsync(Guid userId, QueryParameters parameters)
        {
            var query = _dbSet
                .Where(m => m.UserId == userId)
                .GroupBy(m => m.Mushroom.Name);

            var totalCount = await query.CountAsync();

            var pagedItems = await query
                .Skip((parameters.Page - 1) * parameters.PageSize)
                .Take(parameters.PageSize)
                .ToListAsync();

            return new PagedResult<IGrouping<string, MushroomingMushroom>>(pagedItems, totalCount, parameters.PageSize, parameters.Page);
        }
    }
}
