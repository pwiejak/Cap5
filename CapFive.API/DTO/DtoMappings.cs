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
                Players = tournament.Players.ToDtos().ToList()
            };
        }
    }
}
