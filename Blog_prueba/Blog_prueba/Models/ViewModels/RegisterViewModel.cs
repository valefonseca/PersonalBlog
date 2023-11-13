using System.ComponentModel.DataAnnotations;

namespace Blog_prueba.Models.ViewModels
{
    public class RegisterViewModel
    {
        [Required]
        public string Username { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [MinLength(6, ErrorMessage = "La contraseña debe tener almenos 6 caracteres")]
        public string Password { get; set; }
    }
}
