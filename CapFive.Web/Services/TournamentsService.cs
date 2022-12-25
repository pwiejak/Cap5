using CapFive.Shared.DTO;
using CapFive.Web.Services.Contracts;
using System.Diagnostics;
using System.Net.Http.Json;

namespace CapFive.Web.Services
{
    public class TournamentsService : ITournamentsService
    {
        private readonly HttpClient _httpClient;

        public TournamentsService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<TournamentDTO>> GetTournaments()
        {
            try
            {
                var tournaments = await _httpClient.GetFromJsonAsync<IEnumerable<TournamentDTO>>("api/Tournament");
                return tournaments;
            }
            catch (Exception e)
            {
                Debugger.Log(1, "exception", e.Message);
                throw;
            }
        }
    }
}
