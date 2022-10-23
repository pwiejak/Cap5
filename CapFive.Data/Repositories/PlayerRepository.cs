using CapFive.Data.Model;
using Microsoft.EntityFrameworkCore;

namespace CapFive.Data.Repositories
{
    public class PlayerRepository : IPlayerRepository
    {
        private readonly CapFiveDbContext _db;

        public PlayerRepository(CapFiveDbContext db)
        {
            _db = db;
        }

        public async Task<Player?> GetPlayerById(int id)
        {
            return await _db.Players.FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<IEnumerable<Player>> GetPlayers()
        {
            return await _db.Players.ToListAsync();
        }
    }
}
