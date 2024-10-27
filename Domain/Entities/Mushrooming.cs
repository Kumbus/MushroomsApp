namespace Domain.Entities
{
    public class Mushrooming
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string Location { get; set; }

        // Relacje
        public ICollection<User> Users { get; set; } = [];
        public ICollection<MushroomingMushroom> CollectedMushrooms { get; set; } = [];
        public ICollection<UserReview> Reviews { get; set; } = [];
    }

}
