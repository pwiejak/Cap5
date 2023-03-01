using CapFive.Shared.DTO;

namespace CapFive.Web.Services.Contracts
{
    public interface IMatchupsService
    {
        Task<MatchupDTO> SetWinner(int matchupId, int winnerPlayerId);
    }
}
