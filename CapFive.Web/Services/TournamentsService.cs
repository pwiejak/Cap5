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

        public async Task<TournamentDTO> StartTournament(int tournamentId)
        {
            return await PostResource<TournamentDTO>(null, $"api/tournament/{tournamentId}/start");
        }

        public async Task<TournamentDTO> AddRound(int tournamentId)
        {
            return await PostResource<TournamentDTO>(null, $"api/tournament/{tournamentId}/addRound");
        }
    }
}
