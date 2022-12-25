using CapFive.Shared.DTO;

namespace CapFive.API.Services
{
    public interface ITournamentService
    {
        Task<IEnumerable<TournamentDTO>> GetTournaments();
    }
}
