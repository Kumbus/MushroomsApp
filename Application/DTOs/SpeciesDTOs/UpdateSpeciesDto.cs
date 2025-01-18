namespace Application.DTOs.SpeciesDTOs
{
    public class UpdateSpeciesDto
    {
        public Guid Id { get; set; } // Id gatunku do aktualizacji
        public string Name { get; set; }
        public string Description { get; set; }
        public string PreferredHabitat { get; set; }
    }

}
