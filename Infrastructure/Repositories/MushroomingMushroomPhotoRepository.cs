using Domain.Entities;
using Domain.RepositoriesInterfaces;
using Infrastructure.Data;

namespace Infrastructure.Repositories
{
    public class MushroomingMushroomPhotoRepository : RepositoryBase<MushroomingMushroomPhoto>, IMushroomingMushroomPhotoRepository
    {
        public MushroomingMushroomPhotoRepository(MushroomsDbContext context) : base(context)
        {
        }
    }
}
