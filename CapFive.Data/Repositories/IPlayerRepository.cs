using CapFive.Data.Model;

namespace CapFive.Data.Repositories
{
    public interface IPlayerRepository
    {
        Task<IEnumerable<Player>> GetPlayers();
    }
}
