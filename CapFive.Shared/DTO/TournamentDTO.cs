using System.ComponentModel.DataAnnotations;

namespace CapFive.Shared.DTO
{
    public class TournamentDTO
    {
        public TournamentDTO()
        {
            Players = new List<PlayerDTO>();
        }

        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        public DateTime? Date { get; set; }

        public List<PlayerDTO> Players { get; set; }
    }
}
