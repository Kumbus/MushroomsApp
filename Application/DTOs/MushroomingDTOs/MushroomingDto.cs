using Application.DTOs.LocationDTOs;
using Application.DTOs.MushroomingMushroomDTOs;
using Application.DTOs.UserDTOs;

namespace Application.DTOs.MushroomingDTOs
{
    public class MushroomingDto
    {
        public Guid Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string Status { get; set; }
        public UserDto User { get; set; }
        public LocationDto Location { get; set; }
        public List<MushroomingMushroomDto> CollectedMushrooms { get; set; }
    }
}
