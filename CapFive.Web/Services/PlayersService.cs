using CapFive.Shared.DTO;
using CapFive.Web.Services.Contracts;
using System.Diagnostics;
using System.Net.Http.Json;

namespace CapFive.Web.Services
{
    public class PlayersService : IPlayersService
    {
        private readonly HttpClient _httpClient;

        public PlayersService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<PlayerDTO> GetPlayer(int id)
        {
            try
            {
                var response = await _httpClient.GetAsync($"api/Player/{id}");
                if (response.IsSuccessStatusCode)
                {
                    var player = await response.Content.ReadFromJsonAsync<PlayerDTO>();
                    return player;
                }

                var message = await response.Content.ReadAsStringAsync();
                throw new Exception(message);

            }
            catch (Exception e)
            {
                Debugger.Log(1, "exception", e.Message);
                throw;
            }
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

        public async Task<PlayerDTO> SavePlayer(PlayerDTO player)
        {
            try
            {
                var response = await _httpClient.PutAsJsonAsync("api/Player", player);
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadFromJsonAsync<PlayerDTO>();
                }

                var message = await response.Content.ReadAsStringAsync();
                throw new Exception(message);
            }
            catch (Exception e)
            {
                Debugger.Log(1, "exception", e.Message);
                throw;
            }
        }
    }
}
