using CapFive.Shared.DTO;

namespace CapFive.API.Services
{
    public interface IMatchupService
    {
        public Task<MatchupDTO> SetWinner(int matchupId, int winnerPlayerId);
    }
}
