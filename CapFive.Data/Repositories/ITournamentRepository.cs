using CapFive.Data.Model;

namespace CapFive.Data.Repositories
{
    public interface ITournamentRepository : IRepositoryBase
    {
        IQueryable<Tournament> GetQuerable();
        Task<IEnumerable<Tournament>> GetTournaments();
        Task<Tournament?> GetTournamentById(int id);
        void Update(Tournament tournament);
        void Add(Tournament tournament);
    }
}
