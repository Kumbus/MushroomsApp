using Domain.Entities;
using Domain.RepositoriesInterfaces;
using Infrastructure.Data;

namespace Infrastructure.Repositories
{
    public class MushroomingMushroomRepository : RepositoryBase<MushroomingMushroom>, IMushroomingMushroomRepository
    {
        public MushroomingMushroomRepository(MushroomsDbContext context) : base(context)
        {
        }
    }
}
