using System.ComponentModel.DataAnnotations;

namespace Services.Dtos
{
    public class RegisterDto
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [MinLength(3)]
        public string UserName { get; set; }

        [Required]
        [MinLength(6)]
        public string Password { get; set; }
    }
}
