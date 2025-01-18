using Application.DTOs.UserReviewDTOs;
using Application.ServicesInterfaces;
using AutoMapper;
using Domain.Entities;
using Domain.RepositoriesInterfaces;

namespace Application.Services
{
    public class UserReviewService : BaseService<UserReview, UserReviewDto, CreateUserReviewDto, UpdateUserReviewDto>, IUserReviewService
    {
        public UserReviewService(IRepositoryBase<UserReview> repository, IMapper mapper) : base(repository, mapper)
        {
        }
    }
}
