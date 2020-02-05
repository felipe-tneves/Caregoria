using System.Collections.Generic;

namespace ApiCatalogo.DTOs
{
    public class CategoriaDTO
    {

        //propriedade a ser exposta para o cliente viewModel
        public int CategoriaId { get; set; }
        public string Nome { get; set; }
        public string ImagemUrl { get; set; }
        public ICollection<ProdutoDTO> Produtos { get; set; }
    }
}
