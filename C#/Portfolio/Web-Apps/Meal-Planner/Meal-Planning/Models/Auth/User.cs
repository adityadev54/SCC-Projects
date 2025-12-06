using System.ComponentModel.DataAnnotations;

namespace GoldenMenu.Models.Auth
{
    public class User
    {
        [Key]
        public int UserID { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        // Hashed Password
        public string Password { get; set; }

        //public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
