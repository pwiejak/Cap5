using CapFive.Shared.DTO;

namespace CapFive.Web.Services.Contracts
{
    public interface ITournamentsService
    {
        Task<IEnumerable<TournamentDTO>> GetTournaments();
    }
}
