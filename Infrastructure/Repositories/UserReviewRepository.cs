using Domain.Entities;
using Domain.RepositoriesInterfaces;
using Infrastructure.Data;

namespace Infrastructure.Repositories
{
    public class UserReviewRepository : RepositoryBase<UserReview>, IUserReviewRepository
    {
        public UserReviewRepository(MushroomsDbContext context) : base(context)
        {
        }
    }
}
