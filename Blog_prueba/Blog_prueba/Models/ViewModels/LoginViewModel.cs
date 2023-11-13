using System.ComponentModel.DataAnnotations;

namespace Blog_prueba.Models.ViewModels
{
    public class LoginViewModel
    {
        [Required]
        public string Username { get; set; }
        [Required]
        [MinLength(6, ErrorMessage = "La contraseña debe tener almenos 6 caracteres, una mayuscula, un caracter especial (@ , . ! /) y un número")]
        public string Password { get; set; }

        public string? ReturnUrl { get; set; }
    }
}
