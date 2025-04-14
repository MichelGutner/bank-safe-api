using System.ComponentModel.DataAnnotations;

namespace BankSafeAPI.Domain.Dto
{
    public class UserDto
    {
        [Required(ErrorMessage = "O nome é obrigatório.")]
        [StringLength(
            100,
            MinimumLength = 3,
            ErrorMessage = "O nome deve ter entre 3 e 100 caracteres"
        )]
        public required string Name { get; set; }

        [Required(ErrorMessage = "O CPF é obrigatório")]
        [RegularExpression(@"^\d{11}$", ErrorMessage = "CPF deve conter 11 dígitos.")]
        public required string CPF { get; set; }

        [Required(ErrorMessage = "O email é obrigatório.")]
        [EmailAddress(ErrorMessage = "Email inválido.")]
        public required string Email { get; set; }

        [Required(ErrorMessage = "A senha é obrigatório.")]
        [MinLength(6, ErrorMessage = "A senha deve ter no mínimo 6 caracteres.")]
        public required string Password { get; set; }

        [Compare("Password", ErrorMessage = "As senhas não coincidem.")]
        public required string ConfirmPassword { get; set; }
    }
}
