using Domain.Entities;
using Domain.RepositoriesInterfaces;
using Infrastructure.Data;

namespace Infrastructure.Repositories
{
    public class SpeciesRepository : RepositoryBase<Species>, ISpeciesRepository
    {
        public SpeciesRepository(MushroomsDbContext context) : base(context)
        {
        }
    }
}
