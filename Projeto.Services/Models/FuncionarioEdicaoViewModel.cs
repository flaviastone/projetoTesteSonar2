using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using Projeto.Services.Validations;

namespace Projeto.Services.Models
{
    public class FuncionarioEdicaoViewModel
    {
        [Required(ErrorMessage = "Informe o id do funcionário.")]
        public int IdFuncionario { get; set; }

        [Required(ErrorMessage = "Informe o nome do funcionário.")]
        public string Nome { get; set; }

        [DecimalValidation(ErrorMessage = "Informe o salário do funcionário valido.")]
        public decimal Salario { get; set; }

        [DateTimeValidation(ErrorMessage = "Informe a data de admissão do funcionário válida.")]
        public DateTime DataAdmissao { get; set; }
    }
}