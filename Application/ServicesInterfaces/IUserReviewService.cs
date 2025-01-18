using Application.DTOs.UserReviewDTOs;
using Domain.Entities;

namespace Application.ServicesInterfaces
{
    public interface IUserReviewService : IBaseService<UserReview, UserReviewDto, CreateUserReviewDto, UpdateUserReviewDto>
    {
    }
}
