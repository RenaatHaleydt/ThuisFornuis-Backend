using System;
using System.ComponentModel.DataAnnotations;

namespace ThuisFornuis_Backend.DTOs
{
    public class LoginDTO
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
