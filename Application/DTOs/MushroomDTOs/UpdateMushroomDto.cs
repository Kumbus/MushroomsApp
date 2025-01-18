namespace Application.DTOs.MushroomDTOs
{
    public class UpdateMushroomDto
    {
        public Guid Id { get; set; } // Id grzyba do aktualizacji
        public string Name { get; set; }
        public string Description { get; set; }
        public string Habitat { get; set; }
        public string Season { get; set; }
        public bool IsEdible { get; set; }
        public string Color { get; set; }
        public string CapShape { get; set; }
        public string StemCharacteristics { get; set; }
        public string PhotoPath { get; set; }
        public Guid SpeciesId { get; set; }
    }
}
