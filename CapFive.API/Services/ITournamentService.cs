using CapFive.Shared.DTO;

namespace CapFive.API.Services
{
    public interface ITournamentService
    {
        Task<TournamentDTO> GetTournament(int id);
        Task<IEnumerable<TournamentDTO>> GetTournaments();
        Task<TournamentDTO> SaveTournament(TournamentDTO tournamentDto);
    }
}
