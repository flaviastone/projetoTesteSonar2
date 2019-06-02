using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration; //importando
using System.Data.Entity; //importando
using Projeto.Entities; //importando
using Projeto.DAL.Configurations; //importando

namespace Projeto.DAL.Context
{
    //Regra 1) HERDAR DbContext
    public class DataContext : DbContext
    {
        //Regra 2) Criando um construtor que envie para a DbContext
        //o caminho da connectionstring do banco de dados
        public DataContext()
            : base(ConfigurationManager.ConnectionStrings["projeto"].ConnectionString)
        {

        }

        //Regra 3) Sobrescrever o método OnModelCreating
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //adicionar as classes de mapeamento ORM
            modelBuilder.Configurations.Add(new DependenteConfiguration());
            modelBuilder.Configurations.Add(new FuncionarioConfiguration());
        }

        //Regra 4) Declarar set/get do tipo DbSet para cada entidade
        public DbSet<Dependente> Dependente { get; set; }
        public DbSet<Funcionario> Funcionario { get; set; }
    }
}
