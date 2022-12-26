using CapFive.Shared.DTO;
using CapFive.Web.Services.Contracts;

namespace CapFive.Web.Services
{
    public class PlayersService : ServiceBase, IPlayersService
    {
        public PlayersService(HttpClient httpClient) : base(httpClient)
        {
        }

        public async Task<PlayerDTO> GetPlayer(int id)
        {
            return await GetSingleResource<PlayerDTO>($"api/Player/{id}");
        }

        public async Task<IEnumerable<PlayerDTO>> GetPlayers()
        {
            return await GetResources<PlayerDTO>("api/Player");
        }

        public async Task<PlayerDTO> SavePlayer(PlayerDTO player)
        {
            return await SaveResource<PlayerDTO>(player, "api/Player");
        }
    }
}
