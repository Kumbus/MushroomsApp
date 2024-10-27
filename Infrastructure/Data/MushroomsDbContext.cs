using Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class MushroomsDbContext : IdentityDbContext<User, IdentityRole<Guid>, Guid>
    {
        public MushroomsDbContext(DbContextOptions<MushroomsDbContext> options) : base(options) { }

        public DbSet<Species> Species { get; set; }
        public DbSet<Mushroom> Mushrooms { get; set; }
        public DbSet<Mushrooming> Mushroomings { get; set; }
        public DbSet<MushroomingMushroom> MushroomingMushrooms { get; set; }
        public DbSet<UserReview> UserReviews { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
