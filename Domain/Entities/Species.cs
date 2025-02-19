﻿namespace Domain.Entities
{
    public class Species
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; }
        public string Description { get; set; }
        public string PreferredHabitat { get; set; }

        public ICollection<Mushroom> Mushrooms { get; set; } = [];
    }
}
