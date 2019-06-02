using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration; //ORM
using Projeto.Entities; //entidades

namespace Projeto.DAL.Configurations
{
    public class DependenteConfiguration
        : EntityTypeConfiguration<Dependente>
    {
        public DependenteConfiguration()
        {
            ToTable("DEPENDENTE");

            HasKey(d => new { d.IdDependente });

            Property(d => d.IdDependente)
                .HasColumnName("IDDEPENDENTE");

            Property(d => d.Nome)
                .HasColumnName("NOME")
                .HasMaxLength(150)
                .IsRequired();

            Property(d => d.DataNascimento)
                .HasColumnName("DATANASCIMENTO")
                .IsRequired();

            //mapeamento do relacionamento
            HasRequired(d => d.Funcionario)
                .WithMany(f => f.Dependentes)
                .Map(m => m.MapKey("IDFUNCIONARIO")) //Foreign Key
                .WillCascadeOnDelete(false);
        }
    }
}
