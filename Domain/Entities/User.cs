using Microsoft.AspNetCore.Identity;

namespace Domain.Entities
{

    public class User : IdentityUser<Guid>
    {
        // Dodatkowe pola dla użytkowników
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Role { get; set; } // np. Admin, User

        // Relacje
        public ICollection<Mushrooming> Mushroomings { get; set; } = [];
        public ICollection<MushroomingMushroom> MushroomingMushrooms { get; set; } = [];
        public ICollection<UserReview> Reviews { get; set; } = [];
    }

}
