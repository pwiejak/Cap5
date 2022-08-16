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
    }
}
