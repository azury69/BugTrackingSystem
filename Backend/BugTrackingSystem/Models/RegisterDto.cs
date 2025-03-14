using System.ComponentModel.DataAnnotations;

namespace BugTrackingSystem.Models
{
    public class RegisterDto
    {
        [Required, MaxLength(100)]
        public string FullName { get; set; }

        [Required, EmailAddress]
        public string Email { get; set; }

        [Required, MinLength(6)]
        public string Password { get; set; }

        [Required, Compare("Password")]
        public string ConfirmPassword { get; set; }
    }

}
