﻿namespace Domain.Entities
{
    public class Location
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string Description { get; set; }

        public ICollection<Mushrooming> Mushroomings { get; set; } = [];
    }
}
