using System.ComponentModel.DataAnnotations;

namespace CapFive.Shared.DTO
{
    public class TournamentDTO
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        public DateTime? Date { get; set; }
    }
}
