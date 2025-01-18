namespace Application.DTOs.MushroomingMushroomDTOs
{
    public class CreateMushroomingMushroomDto
    {
        public Guid MushroomingId { get; set; }
        public Guid MushroomId { get; set; }
        public Guid UserId { get; set; }

        public double Weight { get; set; }
        public string PhotoPath { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public DateTime DateCollected { get; set; }
        public string Notes { get; set; }
    }

}
