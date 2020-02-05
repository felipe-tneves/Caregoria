using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ApiCatalogo.Repository
{
    //interfave generica 
   public  interface IRepository<T>
   {
        // retorna uma lista do tipo 
        IQueryable<T> Get();

        //buscar por id 
        T GetById(Expression<Func<T, bool>> predicate);

        //cadastra 
        void add(T entity);

        //atualiza 
        void Update(T entity);

        //deleta 
        void Delete(T entity);
   }
}
