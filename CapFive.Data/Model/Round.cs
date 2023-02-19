using System.ComponentModel.DataAnnotations;

namespace CapFive.Data.Model
{
    public class Round
    {
        public Round()
        {
            Matchups = new List<Matchup>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public int TournamentId { get; set; }
        public Tournament Tournament { get; set; }

        public List<Matchup> Matchups { get; set; }

        public Matchup AddMatchup(Player homePlayer, Player awayPlayer)
        {
            var matchup = new Matchup()
            {
                HomePlayerId = homePlayer.Id,
                AwayPlayerId = awayPlayer.Id,
                Round = this
            };

            Matchups.Add(matchup);

            return matchup;
        }
    }
}
