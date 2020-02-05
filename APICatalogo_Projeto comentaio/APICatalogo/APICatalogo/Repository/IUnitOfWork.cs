using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiCatalogo.Repository
{
    public interface IUnitOfWork
    {
        //istancias do repository
        IProdutoRepository ProdutoRepository { get;  }
        ICategoriaRepository CategoriaRepository { get; }

        //metodo para salvar 
        void Commit();
    }
}
