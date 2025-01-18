using Application.DTOs.LocationDTOs;

namespace Application.DTOs.MushroomingDTOs
{
    public class MushroomingDto
    {
        public Guid Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string Status { get; set; }
        public LocationDto Location { get; set; }
    }
}
