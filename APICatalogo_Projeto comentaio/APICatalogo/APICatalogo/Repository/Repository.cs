using APICatalogo.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace ApiCatalogo.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        //injeçaõ de dependecia 
        protected AppDbContext _context;

        public Repository(AppDbContext contexto)
        {
            //obtendo uma instancia de um contexto
            _context = contexto;
        }

        //uma lista de entidades 
        public IQueryable<T> Get()
        {
           //aqui o metodo set<t> do contexto retorna uma instancia DbSet<T> para o acesso a entidades de determinado tipo no contexto
           return _context.Set<T>().AsNoTracking();
        }

        //metodo para buscar por id retorna uma entidade 
        //usando um delegate funqtion como paramentro de entrada 
        //usando um função lambda do tipo par para comparar  o id recebido com o que tem
        //predicate para validar o criterio 
        public T GetById(Expression<Func<T, bool>> predicate)
        {
            return _context.Set<T>().SingleOrDefault(predicate);
        }

        //metodo para cadastrar 
        public void add(T entity)
        {
            _context.Set<T>().Add(entity);
        }

        //metodo para apagar 
        public void Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
           
        }

        //metodo para atualizar 
        public void Update(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            _context.Set<T>().Update(entity);
        }

    }
}
