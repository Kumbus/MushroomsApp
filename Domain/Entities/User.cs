using Microsoft.AspNetCore.Identity;

namespace Domain.Entities
{
    public class User : IdentityUser<Guid>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string RefreshToken { get; set; }
        public DateTime? RefreshTokenExpiryTime { get; set; }

        public ICollection<Mushrooming> Mushroomings { get; set; } = [];
        public ICollection<MushroomingMushroom> MushroomingMushrooms { get; set; } = [];
        public ICollection<UserReview> Reviews { get; set; } = [];
    }
}
