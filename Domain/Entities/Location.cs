namespace Domain.Entities
{
    public class Location
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; } // np. Puszcza Białowieska
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string Description { get; set; } // np. las iglasty, często odwiedzany

        // Relacje
        public ICollection<Mushrooming> Mushroomings { get; set; } = [];
    }
}
