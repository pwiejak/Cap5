using CapFive.Shared.DTO;

namespace CapFive.Web.Services.Contracts
{
    public interface ITournamentsService
    {
        Task<IEnumerable<TournamentDTO>> GetTournaments();
        Task<TournamentDTO> GetTournament(int id);
        Task<TournamentDTO> SaveTournament(TournamentDTO tournament);
        Task<TournamentDTO> StartTournament(int tournamentId);
    }
}
