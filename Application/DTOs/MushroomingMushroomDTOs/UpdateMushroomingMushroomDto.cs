namespace Application.DTOs.MushroomingMushroomDTOs
{
    public class UpdateMushroomingMushroomDto
    {
        public double Weight { get; set; }
        public string PhotoPath { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public DateTime DateCollected { get; set; }
        public string Notes { get; set; }
    }
}
