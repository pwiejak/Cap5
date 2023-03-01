using CapFive.Shared.DTO;
using CapFive.Shared.Requests;
using CapFive.Web.Services.Contracts;

namespace CapFive.Web.Services
{
    public class MatchupsService : ServiceBase, IMatchupsService
    {
        public MatchupsService(HttpClient httpClient) : base(httpClient)
        {
        }

        public async Task<MatchupDTO> SetWinner(int matchupId, int winnerPlayerId)
        {
            return await Post<SetMatchupWinnerRequest, MatchupDTO>(new SetMatchupWinnerRequest { PlayerId = winnerPlayerId }, $"api/matchup/{matchupId}/setWinner");
        }
    }
}
