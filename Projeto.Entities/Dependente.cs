using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.Entities
{
    public class Dependente
    {
        public int IdDependente { get; set; }
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }

        //Relacionamento de Associação (TER-1)
        public Funcionario Funcionario { get; set; }
    }
}
