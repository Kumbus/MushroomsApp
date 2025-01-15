namespace Domain.Entities
{
    public class MushroomingMushroomPhoto
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid MushroomingMushroomId { get; set; }
        public string PhotoPath { get; set; } // Ścieżka do zdjęcia w blob storage
        public string Description { get; set; } // np. "Zdjęcie kapelusza od góry"
        public DateTime UploadedAt { get; set; } = DateTime.UtcNow;

        // Relacje
        public MushroomingMushroom MushroomingMushroom { get; set; }
    }

}
