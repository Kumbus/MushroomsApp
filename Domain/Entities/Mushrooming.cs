namespace Domain.Entities
{
    public class Mushrooming
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string Address { get; set; } // np. Puszcza Białowieska
        public string Status { get; set; } // np. "In Progress", "Completed"

        // Relacje
        public ICollection<User> Users { get; set; } = [];
        public ICollection<MushroomingMushroom> CollectedMushrooms { get; set; } = [];
        public ICollection<UserReview> Reviews { get; set; } = [];
    }

}
