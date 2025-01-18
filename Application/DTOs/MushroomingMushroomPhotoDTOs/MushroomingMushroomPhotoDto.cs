namespace Application.DTOs.MushroomingMushroomPhotoDTOs
{
    public class MushroomingMushroomPhotoDto
    {
        public Guid Id { get; set; }
        public Guid MushroomingMushroomId { get; set; }
        public string PhotoPath { get; set; }
        public string Description { get; set; }
        public DateTime UploadedAt { get; set; }
    }

}
