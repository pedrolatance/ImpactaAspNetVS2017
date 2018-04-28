using Loja.Mvc.Validators;
using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Loja.Mvc.Models
{
    public class ClienteViewModel
    {
        public int Id { get; set; }

        [Required]
        [MinLength(2, ErrorMessage = "O campo Nome deve conter no mínimo {1} caractéres")]
        [MaxLength(150, ErrorMessage = "O campo Nome deve conter no máximo {1} caractéres")]
        public string Nome { get; set; }

        [Required]
        [Display(Name = "Data de Nascimento")]
        [IdadeMinima(18)]
        public DateTime DataNascimento { get; set; }

        [Required]
        [Display(Name = "E-mail")]
        [Remote("VerificarDisponibilidadeEmail","Clientes", HttpMethod = "POST", ErrorMessage = "E-mail já cadastrado")]
        [MaxLength(100, ErrorMessage = "O campo deve conter no máximo {1} caractéres")]
        [EmailAddress(ErrorMessage = "Preencha com um e-mail válido")]
        //[RegularExpression(@"^[a-zA-Z09.-_]{1,100}@[\w]+\.[a-zA-Z]{2,3}$", ErrorMessage = "Preencha com um e-mail válido")]
        public string Email { get; set; }
    }
}