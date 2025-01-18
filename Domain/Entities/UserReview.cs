namespace Domain.Entities
{
    public class UserReview
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid MushroomingId { get; set; }
        public Guid UserId { get; set; }

        public int Rating { get; set; }
        public string Comment { get; set; }

        public Mushrooming Mushrooming { get; set; }
        public User User { get; set; }
    }
}
