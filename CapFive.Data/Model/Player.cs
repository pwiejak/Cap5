using System.ComponentModel.DataAnnotations;

namespace CapFive.Data.Model
{
    public class Player
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        public string Surname { get; set; }
        public string Email { get; set; }
    }
}
