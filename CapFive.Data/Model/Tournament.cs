using CapFive.Shared.Tournament;
using System.ComponentModel.DataAnnotations;

namespace CapFive.Data.Model
{
    public class Tournament
    {
        public Tournament()
        {
            Players = new List<Player>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public DateTime? Date { get; set; }

        public ICollection<Player> Players { get; set; }

        public TournamentStatus Status { get; set; }

        public List<Round> Rounds { get; set; }
    }
}
