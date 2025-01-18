using Domain.Entities;
using Domain.RepositoriesInterfaces;
using Infrastructure.Data;

namespace Infrastructure.Repositories
{
    public class MushroomRepository : RepositoryBase<Mushroom>, IMushroomRepository
    {
        public MushroomRepository(MushroomsDbContext context) : base(context)
        {
        }
    }

}
