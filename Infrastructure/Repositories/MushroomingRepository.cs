using Domain.Entities;
using Domain.RepositoriesInterfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class MushroomingRepository : RepositoryBase<Mushrooming>, IMushroomingRepository
    {
        public MushroomingRepository(MushroomsDbContext context) : base(context)
        {

        }

        public async Task<IEnumerable<Mushrooming>> GetAllWithLocationsAsync()
        {
            return await _context.Mushroomings
                            .Include(m => m.Location)
                            .ToListAsync();
        }
    }
}
