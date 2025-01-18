namespace Application.DTOs.UserReviewDTOs
{
    public class CreateUserReviewDto
    {
        public Guid MushroomingId { get; set; }
        public Guid UserId { get; set; }
        public int Rating { get; set; }
        public string Comment { get; set; }
    }
}
