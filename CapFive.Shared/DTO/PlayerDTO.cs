using System.ComponentModel.DataAnnotations;

namespace CapFive.Shared.DTO
{
    public class PlayerDTO
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
    }
}
