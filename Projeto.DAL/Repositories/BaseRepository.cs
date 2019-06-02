using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity; //importando
using Projeto.DAL.Context; //importando

namespace Projeto.DAL.Repositories
{
    //<T> tipo de dado genérico
    public abstract class BaseRepository<T>
        where T : class
    {
        //método genérico para cadastrar uma entidade
        public virtual void Create(T objeto)
        {
            using (DataContext ctx = new DataContext())
            {
                ctx.Entry(objeto).State = EntityState.Added;
                ctx.SaveChanges(); //executando
            }
        }

        //método genérico para atualizar uma entidade
        public virtual void Update(T objeto)
        {
            using (DataContext ctx = new DataContext())
            {
                ctx.Entry(objeto).State = EntityState.Modified;
                ctx.SaveChanges(); //executando
            }
        }

        //método genérico para excluir uma entidade
        public virtual void Delete(T objeto)
        {
            using (DataContext ctx = new DataContext())
            {
                ctx.Entry(objeto).State = EntityState.Deleted;
                ctx.SaveChanges(); //executando
            }
        }

        //método para listar todos os registros de uma entidade
        public virtual List<T> SelectAll()
        {
            using (DataContext ctx = new DataContext())
            {
                return ctx.Set<T>().ToList();
            }
        }

        //método para retornar 1 registro de uma entidade baseado no id
        public virtual T SelectById(int id)
        {
            using (DataContext ctx = new DataContext())
            {
                return ctx.Set<T>().Find(id);
            }
        }
    }    
}
