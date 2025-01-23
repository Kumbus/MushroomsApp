namespace Application.DTOs.MushroomingDTOs
{
    public class CreateMushroomingDto
    {
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public Guid LocationId { get; set; }
        public string Status { get; set; } = "In Progress";
        public Guid UserId { get; set; }
    }
}
