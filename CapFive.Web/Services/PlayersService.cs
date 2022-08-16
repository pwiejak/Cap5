using System.Diagnostics;
using System.Net.Http.Json;
using CapFive.Shared.DTO;
using CapFive.Web.Services.Contracts;

namespace CapFive.Web.Services
{
    public class PlayersService : IPlayersService
    {
        private readonly HttpClient _httpClient;

        public PlayersService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<PlayerDTO>> GetPlayers()
        {
            try
            {
                var players = await _httpClient.GetFromJsonAsync<IEnumerable<PlayerDTO>>("api/Player");
                return players;
            }
            catch (Exception e)
            {
                Debugger.Log(1, "exception", e.Message);
                throw;
            }
        }
    }
}
