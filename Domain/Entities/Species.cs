namespace Domain.Entities
{
    public class Species
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; } // np. Borowikowate
        public string Description { get; set; } // krótki opis grupy grzybów
        public string PreferredHabitat { get; set; } // np. las iglasty

        // Relacje
        public ICollection<Mushroom> Mushrooms { get; set; } = [];
    }

}
