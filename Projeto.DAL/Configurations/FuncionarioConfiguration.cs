using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration; //ORM
using Projeto.Entities; //classes de entidade

namespace Projeto.DAL.Configurations
{
    //Regra 1) HERDAR EntityTypeConfiguration<Entity>
    public class FuncionarioConfiguration 
        : EntityTypeConfiguration<Funcionario>
    {
        //Regra 2) CONSTRUTOR -> descrever o mapeamento
        public FuncionarioConfiguration()
        {
            //nome da tabela
            ToTable("FUNCIONARIO");

            //chave primária
            HasKey(f => new { f.IdFuncionario });

            //demais propriedades
            Property(f => f.IdFuncionario)
                .HasColumnName("IDFUNCIONARIO");

            Property(f => f.Nome)
                .HasColumnName("NOME")
                .HasMaxLength(150)
                .IsRequired();

            Property(f => f.Salario)
                .HasColumnName("SALARIO")
                .HasPrecision(18,2)
                .IsRequired();

            Property(f => f.DataAdmissao)
                .HasColumnName("DATAADMISSAO")
                .IsRequired();

                
        }
    }
}
