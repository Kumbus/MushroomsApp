namespace Application.DTOs.MushroomingDTOs
{
    public class UpdateMushroomingDto
    {
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public Guid? LocationId { get; set; }
        public string Status { get; set; }
        public Guid UserId { get; set; }
    }
}
