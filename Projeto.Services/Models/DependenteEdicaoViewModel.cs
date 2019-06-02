using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using Projeto.Services.Validations;

namespace Projeto.Services.Models
{
    public class DependenteEdicaoViewModel
    {
        [Required(ErrorMessage = "Informe o id do dependente.")]
        public int IdDependente { get; set; }

        [Required(ErrorMessage = "Informe o nome do dependente.")]
        public string Nome { get; set; }

        [DateTimeValidation(ErrorMessage = "Informe a data de nascimentu do dependente válida.")]
        public DateTime DataNascimento { get; set; }
    }
}