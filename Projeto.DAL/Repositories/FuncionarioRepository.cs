using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Projeto.Entities;
using Projeto.DAL.Context;

namespace Projeto.DAL.Repositories
{
    public class FuncionarioRepository
        : BaseRepository<Funcionario>
    {
        //consulta de funcionários por nome
        public List<Funcionario> SelectByNome(string nome)
        {
            using (DataContext ctx = new DataContext())
            {
                return ctx.Funcionario
                        .Where(f => f.Nome.Contains(nome))
                        .OrderBy(f => f.Nome)
                        .ToList();
            }
        }

        //consulta para retornar funcionarios por periodo de datas
        public List<Funcionario> SelectByDataAdmissao
                (DateTime dataInicio, DateTime dataFim)
        {
            using (DataContext ctx = new DataContext())
            {
                return ctx.Funcionario
                        .Where(f => f.DataAdmissao >= dataInicio
                                 && f.DataAdmissao <= dataFim)
                        .OrderByDescending(f => f.DataAdmissao)
                        .ToList();
            }
        }        
    }
}
