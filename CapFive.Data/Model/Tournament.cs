using System.ComponentModel.DataAnnotations;

namespace CapFive.Data.Model
{
    public class Tournament
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public DateTime? Date { get; set; }

        public ICollection<Player> Players { get; set; }
    }
}
