using CapFive.Data.Model;

namespace CapFive.Data.Repositories
{
    public interface IPlayerRepository : IRepositoryBase
    {
        Task<IEnumerable<Player>> GetPlayers();
        Task<Player?> GetPlayerById(int id);
        void Update(Player player);
        void Add(Player player);
    }
}
