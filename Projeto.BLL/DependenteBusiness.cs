using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projeto.Entities;
using Projeto.DAL.Repositories;
namespace Projeto.BLL
{
    public class DependenteBusiness
    {
        private DependenteRepository repository;


        public DependenteBusiness()
        {
            repository = new DependenteRepository();
        }

        public void Cadastrar(Dependente dependente)
        {
            repository.Create(dependente);
        }

        public void Atualizar(Dependente dependente)
        {
            repository.Update(dependente);
        }

        public void Excluir(int idDependente)
        {
            var dependente = repository.SelectById(idDependente);
            repository.Delete(dependente);
        }

        public List<Dependente> ConsultarTodos()
        {
            return repository.SelectAll();
        }

        public Dependente ConsultarPorId(int idDependente)
        {
            return repository.SelectById(idDependente);
        }
    }
}
