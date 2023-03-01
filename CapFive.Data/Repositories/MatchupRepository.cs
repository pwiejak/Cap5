using CapFive.Data.Model;

namespace CapFive.Data.Repositories
{
    public class MatchupRepository : RepositoryBase, IMatchupRepository
    {
        public MatchupRepository(CapFiveDbContext db) : base(db)
        {
        }

        public IQueryable<Matchup> GetQuerable()
        {
            return _db.Matchups.AsQueryable();
        }
    }
}
