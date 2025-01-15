namespace Domain.Entities
{
    public class MushroomingMushroom
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid MushroomingId { get; set; }
        public Guid MushroomId { get; set; }
        public Guid UserId { get; set; }

        public double Weight { get; set; } // w gramach
        public string PhotoPath { get; set; } // Ścieżka do zdjęcia w systemie plików lub URL
        public double Latitude { get; set; } // szerokość geograficzna
        public double Longitude { get; set; } // długość geograficzna
        public DateTime DateCollected { get; set; }
        public string Notes { get; set; } // np. znaleziony pod sosną

        // Relacje
        public Mushrooming Mushrooming { get; set; }
        public Mushroom Mushroom { get; set; }
        public User CollectedBy { get; set; }
    }

}
