using CapFive.Data.Model;
using Microsoft.EntityFrameworkCore;

namespace CapFive.Data
{
    public class CapFiveDbContext : DbContext
    {
        public CapFiveDbContext(DbContextOptions<CapFiveDbContext> options) : base(options)
        {
        }

        public DbSet<Player> Players { get; set; }
        public DbSet<Tournament> Tournaments { get; set; }
        public DbSet<Round> Rounds { get; set; }
        public DbSet<Matchup> Matchups { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Matchup>()
                .HasOne(m => m.Round)
                .WithMany(m => m.Matchups)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
