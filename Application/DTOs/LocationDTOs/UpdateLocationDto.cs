namespace Application.DTOs.LocationDTOs
{
    public class UpdateLocationDto
    {
        public Guid Id { get; set; } // Id lokacji do aktualizacji
        public string Name { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string Description { get; set; }
    }

}
