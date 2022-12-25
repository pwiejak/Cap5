using CapFive.API.DTO;
using CapFive.Data.Repositories;
using CapFive.Shared.DTO;

namespace CapFive.API.Services
{
    public class TournamentService : ITournamentService
    {
        private readonly ITournamentRepository _tournamentRepository;

        public TournamentService(ITournamentRepository tournamentRepository)
        {
            _tournamentRepository = tournamentRepository;
        }

        public async Task<IEnumerable<TournamentDTO>> GetTournaments()
        {
            var tournaments = await _tournamentRepository.GetTournaments();
            return tournaments.ToDtos();
        }
    }
}
