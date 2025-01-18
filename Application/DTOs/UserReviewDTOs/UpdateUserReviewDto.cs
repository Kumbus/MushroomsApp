namespace Application.DTOs.UserReviewDTOs
{
    public class UpdateUserReviewDto
    {
        public Guid Id { get; set; }
        public int Rating { get; set; }
        public string Comment { get; set; }
    }
}
