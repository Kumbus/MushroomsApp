using Domain.Entities;

namespace Domain.RepositoriesInterfaces
{
    public interface IMushroomingRepository : IRepositoryBase<Mushrooming>
    {
        Task<IEnumerable<Mushrooming>> GetAllWithLocationsAsync();
    }
}
