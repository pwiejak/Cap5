using CapFive.API.DTO;
using CapFive.API.Exceptions;
using CapFive.Data.Model;
using CapFive.Data.Repositories;
using CapFive.Shared.DTO;
using CapFive.Shared.Tournament;
using Microsoft.EntityFrameworkCore;

namespace CapFive.API.Services
{
    public class TournamentService : ITournamentService
    {
        private readonly ITournamentRepository _tournamentRepository;
        private readonly IPlayerRepository _playerRepository;

        public TournamentService(ITournamentRepository tournamentRepository, IPlayerRepository playerRepository)
        {
            _tournamentRepository = tournamentRepository;
            _playerRepository = playerRepository;
        }

        public async Task<TournamentDTO> GetTournament(int id)
        {
            var tournament = await _tournamentRepository.GetTournamentById(id);
            if (tournament == null)
            {
                throw new NotFoundException($"Tournament with id: {id} not found.");
            }

            return tournament.ToDto();
        }

        public async Task<IEnumerable<TournamentDTO>> GetTournaments()
        {
            var tournaments = await _tournamentRepository.GetTournaments();
            return tournaments.ToDtos();
        }

        public async Task<TournamentDTO> SaveTournament(TournamentDTO tournamentDto)
        {
            if (tournamentDto == null)
                throw new ArgumentNullException(nameof(tournamentDto));

            var tournament = tournamentDto.Id > 0
                ? await _tournamentRepository.GetTournamentById(tournamentDto.Id)
                : new Tournament();
            if (tournament == null)
            {
                throw new NotFoundException($"Tournament with id {tournamentDto.Id} not found.");
            }

            tournament.Map(tournamentDto);

            var tournamentPlayers = await _playerRepository.GetPlayers(tournamentDto.Players.Select(p => p.Id));
            tournament.Players.Clear();
            foreach (var player in tournamentPlayers)
            {
                tournament.Players.Add(player);
            }

            if (tournamentDto.Id > 0)
            {
                _tournamentRepository.Update(tournament);
            }
            else
            {
                _tournamentRepository.Add(tournament);
            }

            await _tournamentRepository.SaveAsync();

            return tournament.ToDto();
        }

        public async Task<TournamentDTO> StartTournament(int tournamentId)
        {
            var tournament = await _tournamentRepository.GetQuerable()
                .Include(t => t.Players)
                .FirstOrDefaultAsync(t => t.Id == tournamentId);

            if (tournament == null)
            {
                throw new NotFoundException($"Tournament with id {tournamentId} not found.");
            }

            if (tournament.Status == TournamentStatus.Started)
            {
                throw new BadRequestException($"Tournament with id {tournamentId} is already in status {TournamentStatus.Started}");
            }

            tournament.Status = TournamentStatus.Started;
            var round = new Round() { Name = "1" };

            CreateMatchupsForRound(tournament, round);
            tournament.Rounds.Add(round);

            _tournamentRepository.Update(tournament);
            await _tournamentRepository.SaveAsync();

            return tournament.ToDto();
        }

        public async Task<TournamentDTO> AddRound(int tournamentId)
        {
            var tournament = await _tournamentRepository.GetQuerable()
                            .Include(t => t.Rounds)
                            .Include(t => t.Players)
                            .FirstOrDefaultAsync(t => t.Id == tournamentId);

            if (tournament == null)
            {
                throw new NotFoundException($"Tournament with id {tournamentId} not found.");
            }

            if (tournament.Status != TournamentStatus.Started)
            {
                throw new BadRequestException($"Cannot add round to tournament in status: {tournament.Status}");
            }

            var round = new Round() { Name = (tournament.Rounds.Count + 1).ToString() };

            CreateMatchupsForRound(tournament, round);
            tournament.Rounds.Add(round);

            _tournamentRepository.Update(tournament);
            await _tournamentRepository.SaveAsync();

            return tournament.ToDto();
        }

        private static void CreateMatchupsForRound(Tournament? tournament, Round round)
        {
            foreach (var player in tournament.Players)
            {
                foreach (var versusPlayer in tournament.Players)
                {
                    if (player.Id == versusPlayer.Id || round.Matchups.Any(m => m.IsBetween(player.Id, versusPlayer.Id))) continue;

                    round.AddMatchup(player, versusPlayer);
                }
            }
        }
    }
}
