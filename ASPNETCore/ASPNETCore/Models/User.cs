using System.ComponentModel.DataAnnotations;

namespace ASPNETCore.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }

        public List<Note> Notes { get; set; } = [];
    }
}
