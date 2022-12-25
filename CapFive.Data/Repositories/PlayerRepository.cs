using CapFive.Data.Model;
using Microsoft.EntityFrameworkCore;

namespace CapFive.Data.Repositories
{
    public class PlayerRepository : RepositoryBase, IPlayerRepository
    {
        public PlayerRepository(CapFiveDbContext db) : base(db)
        {
        }

        public void Add(Player player)
        {
            _db.Players.Add(player);
        }

        public async Task<Player?> GetPlayerById(int id)
        {
            return await _db.Players.FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<IEnumerable<Player>> GetPlayers()
        {
            return await _db.Players.ToListAsync();
        }

        public void Update(Player player)
        {
            _db.Players.Update(player);
        }
    }
}
