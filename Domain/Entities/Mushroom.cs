namespace Domain.Entities
{
    using System;
    using System.Collections.Generic;

    public class Mushroom
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; }
        public string Description { get; set; }
        public string Habitat { get; set; } // np. las, łąka, itd.
        public string Season { get; set; } // np. wiosna, lato, jesień, itd.
        public bool IsEdible { get; set; }
        public Guid SpeciesId { get; set; } // powiązanie z gatunkiem

        // Relacje
        public Species Species { get; set; }
        public ICollection<MushroomingMushroom> MushroomingMushrooms { get; set; } = [];
    }


}
