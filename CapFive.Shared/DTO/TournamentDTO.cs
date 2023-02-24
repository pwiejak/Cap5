using CapFive.Shared.Tournament;
using System.ComponentModel.DataAnnotations;

namespace CapFive.Shared.DTO
{
    public class TournamentDTO
    {
        public TournamentDTO()
        {
            Players = new List<PlayerDTO>();
            Rounds = new List<RoundDTO>();
        }

        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public DateTime? Date { get; set; }

        public List<PlayerDTO> Players { get; set; }

        public TournamentStatus Status { get; set; }

        public IEnumerable<RoundDTO> Rounds { get; set; }
    }
}
