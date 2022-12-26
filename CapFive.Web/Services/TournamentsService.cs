using CapFive.Shared.DTO;
using CapFive.Web.Services.Contracts;

namespace CapFive.Web.Services
{
    public class TournamentsService : ServiceBase, ITournamentsService
    {
        public TournamentsService(HttpClient httpClient) : base(httpClient)
        {
        }

        public async Task<TournamentDTO> GetTournament(int id)
        {
            return await GetSingleResource<TournamentDTO>($"api/Tournament/{id}");
        }

        public async Task<IEnumerable<TournamentDTO>> GetTournaments()
        {
            return await GetResources<TournamentDTO>("api/Tournament");
        }

        public async Task<TournamentDTO> SaveTournament(TournamentDTO tournament)
        {
            return await SaveResource(tournament, "api/tournament");
        }
    }
}
