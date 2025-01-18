namespace Domain.Entities
{
    public class MushroomingMushroomPhoto
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid MushroomingMushroomId { get; set; }
        public string PhotoPath { get; set; }
        public string Description { get; set; }
        public DateTime UploadedAt { get; set; } = DateTime.UtcNow;

        public MushroomingMushroom MushroomingMushroom { get; set; }
    }

}
