using Application.DTOs.MushroomDTOs;
using Application.DTOs.UserDTOs;

namespace Application.DTOs.MushroomingMushroomDTOs
{
    public class MushroomingMushroomDto
    {
        public Guid Id { get; set; }
        public Guid MushroomingId { get; set; }
        public Guid MushroomId { get; set; }
        public Guid UserId { get; set; }

        public double Weight { get; set; }
        public string PhotoPath { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public DateTime DateCollected { get; set; }
        public string Notes { get; set; }

        public MushroomDto Mushroom { get; set; }
        public UserDto CollectedBy { get; set; }
    }

}
