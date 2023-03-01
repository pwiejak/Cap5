using CapFive.API.DTO;
using CapFive.API.Exceptions;
using CapFive.Data.Repositories;
using CapFive.Shared.DTO;
using Microsoft.EntityFrameworkCore;

namespace CapFive.API.Services
{
    public class MatchupService : IMatchupService
    {
        private readonly IMatchupRepository _matchupRepo;

        public MatchupService(IMatchupRepository matchupRepo)
        {
            _matchupRepo = matchupRepo;
        }

        public async Task<MatchupDTO> SetWinner(int matchupId, int winnerPlayerId)
        {
            if (matchupId <= 0 || winnerPlayerId <= 0)
            {
                throw new BadRequestException($"Invalid arguments, matchupId: {matchupId}, playerId: {winnerPlayerId}");
            };

            var matchup = await _matchupRepo
                .GetQuerable()
                .FirstOrDefaultAsync(m => m.Id == matchupId);

            if (matchup == null)
            {
                throw new NotFoundException($"Matchup with id {matchupId} was not found.");
            }

            matchup.WinnerPlayerId = winnerPlayerId;
            await _matchupRepo.SaveAsync();

            return matchup.ToDto();
        }
    }
}
