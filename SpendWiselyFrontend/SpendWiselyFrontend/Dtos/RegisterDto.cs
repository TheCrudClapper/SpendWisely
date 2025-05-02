using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SpendWiselyFrontend.Dtos
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
