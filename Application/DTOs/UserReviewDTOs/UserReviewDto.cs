using Application.DTOs.MushroomingDTOs;
using Application.DTOs.UserDTOs;

namespace Application.DTOs.UserReviewDTOs
{
    public class UserReviewDto
    {
        public Guid Id { get; set; }
        public Guid MushroomingId { get; set; }
        public Guid UserId { get; set; }
        public int Rating { get; set; }
        public string Comment { get; set; }

        public UserDto User { get; set; }
        public MushroomingDto Mushrooming { get; set; }
    }
}
