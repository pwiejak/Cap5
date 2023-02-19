using System.ComponentModel.DataAnnotations;

namespace CapFive.Data.Model
{
    public class Matchup
    {
        [Key]
        public int Id { get; set; }

        public string? Name { get; set; }

        public int RoundId { get; set; }
        public Round Round { get; set; }

        public int? HomePlayerId { get; set; }
        public Player? HomePlayer { get; set; }

        public int? AwayPlayerId { get; set; }
        public Player? AwayPlayer { get; set; }

        public int? WinnerPlayerId { get; set; }
        public Player? WinnerPlayer { get; set; }

        public bool IsBetween(int playerOneId, int playerTwoId)
        {
            return HomePlayerId == playerOneId && AwayPlayerId == playerTwoId
                || AwayPlayerId == playerOneId && HomePlayerId == playerTwoId;
        }
    }
}
