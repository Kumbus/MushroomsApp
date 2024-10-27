namespace Domain.Entities
{
    public class UserReview
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid MushroomingId { get; set; }
        public Guid UserId { get; set; } // odwołanie do ApplicationUser

        public int Rating { get; set; } // np. skala 1-5
        public string Comment { get; set; }

        // Relacje
        public Mushrooming Mushrooming { get; set; }
        public User User { get; set; }
    }

}
