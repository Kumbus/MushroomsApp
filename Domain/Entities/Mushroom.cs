namespace Domain.Entities
{
    public class Mushroom
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; }
        public string Description { get; set; }
        public string Habitat { get; set; } // np. las, łąka
        public string Season { get; set; } // np. wiosna, lato, jesień
        public bool IsEdible { get; set; }
        public Guid SpeciesId { get; set; } // powiązanie z gatunkiem

        public string Color { get; set; } // np. brązowy, biały
        public string CapShape { get; set; } // np. płaski, wypukły
        public string StemCharacteristics { get; set; } // np. pierścień, siateczka
        public string PhotoPath { get; set; } // Ścieżka do zdjęcia grzyba

        // Relacje
        public Species Species { get; set; }
        public ICollection<MushroomingMushroom> MushroomingMushrooms { get; set; } = [];
    }
}
