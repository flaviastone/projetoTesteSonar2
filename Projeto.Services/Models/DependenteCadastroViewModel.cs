using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using Projeto.Services.Validations;

namespace Projeto.Services.Models
{
    public class DependenteCadastroViewModel
    {
        [Required(ErrorMessage = "Informe o nome do dependente.")]
        public string Nome { get; set; }

        [DateTimeValidation(ErrorMessage = "Informe a data de nascimento do dependente válida.")]
        public DateTime DataNascimento { get; set; }
    }
}