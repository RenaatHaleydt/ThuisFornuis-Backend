using System;
using System.ComponentModel.DataAnnotations;

namespace ThuisFornuis_Backend.DTOs
{
    public class RegisterDTO
    {
        [Required]
        [StringLength(200)]
        public String FirstName { get; set; }

        [Required]
        [StringLength(250)]
        public String LastName { get; set; }

        [Required]
        [Compare("Password")]
        [RegularExpression("^((?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])|(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[^a-zA-Z0-9])|(?=.*?[A-Z])(?=.*?[0-9])(?=.*?[^a-zA-Z0-9])|(?=.*?[a-z])(?=.*?[0-9])(?=.*?[^a-zA-Z0-9])).{8,}$", ErrorMessage = "Het passwoord moet minstens 8 karakters lang zijn en moet 3 van de 4 volgende criteria bevatten: upper case (A-Z), lower case (a-z), nummer (0-9) en speciaal karakter (e.g. !@#$%^&*)")]
        public String PasswordConfirmation { get; set; }
    }
}
