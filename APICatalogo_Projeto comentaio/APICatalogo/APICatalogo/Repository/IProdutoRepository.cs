using APICatalogo.Models;
using System.Collections.Generic;

namespace ApiCatalogo.Repository
{
    public interface IProdutoRepository : IRepository<Produto>
    {
        //lista o produto por preço 
        IEnumerable<Produto> GetProdutosPorPreco();
    }
}
