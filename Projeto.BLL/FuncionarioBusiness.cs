using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projeto.Entities;
using Projeto.DAL.Repositories;

namespace Projeto.BLL
{
    public class FuncionarioBusiness
    {
        private FuncionarioRepository repository;

        public FuncionarioBusiness()
        {
            repository = new FuncionarioRepository();
        }

        public void Cadastrar(Funcionario funcionario)
        {
            repository.Create(funcionario);
        }

        public void Atualizar(Funcionario funcionario)
        {
            repository.Update(funcionario);
        }

        public void Excluir(int idFuncionario)
        {
            var funcionario = repository.SelectById(idFuncionario);
            repository.Delete(funcionario);
        }

        public List<Funcionario> ConsultarTodos()
        {
            return repository.SelectAll();
        }

        public Funcionario ConsultarPorId(int idFuncionario)
        {
            return repository.SelectById(idFuncionario);
        }

    }
}
