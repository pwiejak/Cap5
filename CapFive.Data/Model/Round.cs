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
    }
}
