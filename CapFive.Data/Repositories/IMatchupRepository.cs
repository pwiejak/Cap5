using CapFive.Data.Model;

namespace CapFive.Data.Repositories
{
    public interface IMatchupRepository : IRepositoryBase
    {
        IQueryable<Matchup> GetQuerable();
    }
}
