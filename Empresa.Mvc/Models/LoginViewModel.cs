using System.ComponentModel.DataAnnotations;

namespace Empresa.Mvc.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "E-mail é obrigatório.")]
        [EmailAddress]
        [Display(Name = "E-mail")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Senha é obrigaória.")]
        [DataType(DataType.Password)]
        public string Senha { get; set; }
    }
}
