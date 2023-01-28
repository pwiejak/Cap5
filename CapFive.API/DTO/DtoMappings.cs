using CapFive.Data.Model;
using CapFive.Shared.DTO;

namespace CapFive.API.DTO
{
    public static class DtoMappings
    {
        public static IEnumerable<PlayerDTO> ToDtos(this IEnumerable<Player> players)
        {
            return players.Select(ToDto);
        }

        public static IEnumerable<Player> ToModel(this IEnumerable<PlayerDTO> players)
        {
            return players.Select(ToModel);
        }

        public static PlayerDTO ToDto(this Player player)
        {
            return new PlayerDTO
            {
                Id = player.Id,
                Name = player.Name,
                Email = player.Email,
                Surname = player.Surname
            };
        }

        public static Player ToModel(this PlayerDTO player)
        {
            return new Player
            {
                Id = player.Id,
                Name = player.Name,
                Email = player.Email,
                Surname = player.Surname
            };
        }

        public static IEnumerable<TournamentDTO> ToDtos(this IEnumerable<Tournament> tournaments)
        {
            return tournaments.Select(ToDto);
        }

        public static TournamentDTO ToDto(this Tournament tournament)
        {
            return new TournamentDTO
            {
                Id = tournament.Id,
                Date = tournament.Date,
                Name = tournament.Name,
                Players = tournament.Players.ToDtos().ToList(),
                Status = tournament.Status
            };
        }

        public static Tournament ToModel(this TournamentDTO tournament)
        {
            return new Tournament
            {
                Id = tournament.Id,
                Date = tournament.Date,
                Name = tournament.Name,
                Players = tournament.Players.ToModel().ToList(),
                Status = tournament.Status
            };
        }

        public static void Map(this Tournament tournament, TournamentDTO tournamentDto)
        {
            tournament.Name = tournamentDto.Name;
            tournament.Date = tournamentDto.Date;
            tournament.Status = tournamentDto.Status;
        }
    }
}
