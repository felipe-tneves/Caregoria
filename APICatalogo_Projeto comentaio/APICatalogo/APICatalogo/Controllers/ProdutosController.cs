using ApiCatalogo.Models;
using ApiCatalogo.Repository;
using APICatalogo.Context;
using APICatalogo.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiCatalogo.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class ProdutosController : ControllerBase
    {
        private readonly IUnitOfWork _uof;

        public ProdutosController(IUnitOfWork contexto)
        {
            _uof = contexto;
        }


        //retorna os produtodos pelo preço 
        [HttpGet("menorpreco")]
        public ActionResult<IEnumerable<Produto>> GetProdutosPrecos()
        {
            return _uof.ProdutoRepository.GetProdutosPorPreco().ToList();
        }


        ////injeção dependecia nativa 
        //private readonly AppDbContext _context;
        //public ProdutosController(AppDbContext contexto) 
        //{
        //    _context = contexto;
        //}


        // usando metodo assincrono para poder listar 
        [HttpGet]
        public ActionResult<IEnumerable<Produto>> Get()
        {
            return _uof.ProdutoRepository.Get().ToList();
        }


        [HttpGet("{id}", Name = "ObterProduto")]
        public ActionResult<Produto> Get([FromQuery]int id)
        {

            var produto = _uof.ProdutoRepository.GetById(p => p.ProdutoId == id);

            if (produto == null)
            {
                return NotFound();
            }
            return produto;
        }










        //// usando metodo assincrono para poder listar 
        //[HttpGet]
        ////usando o filtro 
        //[ServiceFilter(typeof(ApiLoggingFilter))]
        //public async Task<ActionResult<IEnumerable<Produto>>> Get()
        //{
        //    return await _context.Produtos.AsNoTracking().ToListAsync();
        //}





        //[HttpGet("{id}", Name = "ObterProduto")]
        //public async Task<ActionResult<Produto>> Get([FromQuery]int id)
        //{
        //    //teste de tratamento de erros 
        //    //throw new Exception("Exception ao retornar produto pelo id");

        //    //string[] teste = null;
        //    //if (teste.Length > 0)
        //    //{ }

        //    var produto = await _context.Produtos.FirstOrDefaultAsync(p => p.ProdutoId == id);

        //    if (produto == null)
        //    {
        //        return NotFound();
        //    }
        //    return produto;
        //}








        //BindRequired e obrigatorio colocar o nome 
        //[HttpGet("{id}", Name = "ObterProduto")]
        //public async Task<ActionResult<Produto>> Get(int id,[BindRequired] string nome )
        //{
        //    var nomeProduto = nome;
        //    var produto = await _context.Produtos.FirstOrDefaultAsync(p => p.ProdutoId == id);

        //    if (produto == null)
        //    {
        //        return NotFound();
        //    }
        //    return produto;
        //}



        //barra invertida /  - iguinora a rota padrao api/produtos 
        //metodo para listar o primeiro produtio 
        //[HttpGet("primeiro")]
        //[HttpGet("/primeiro")]
        //retrição alphanumerico 
        //[HttpGet("{valor:alpha}")]
        //public ActionResult<Produto> Get2()
        //{            
        //    return _context.Produtos.FirstOrDefault();
        //}




        //  // api/produtos
        //  //metodo para listar os produtos 
        // [HttpGet]
        // public ActionResult<IEnumerable<Produto>> Get3()
        //{
        //      //AsNoTracking desabilita o gerenciamento do estado das entidades
        //      //so deve ser usado em consultas sem alteração
        //      //return _context.Produtos.AsNoTracking().ToList();
        //     return _context.Produtos.ToList();
        // }




        //passando o segundo parametro na url - ?- deixa ele opisional 
        //param2 = prod - deixa um valor padrao /{param2} , string param2
        // api/produtos/1
        //metodo para listar produto por id 
        //[HttpGet("{id:int:min(1)}", Name = "ObterProduto")]
        //public ActionResult<Produto> Get(int id)
        //{
        //    //var meuParametro = param2;

        //    //AsNoTracking desabilita o gerenciamento do estado das entidades
        //    //so deve ser usado em consultas sem alteração
        //    //var produto = _context.Produtos.AsNoTracking()
        //    //    .FirstOrDefault(p => p.ProdutoId == id);
        //    var produto = _context.Produtos.FirstOrDefault(p => p.ProdutoId == id);

        //    if (produto == null)
        //    {
        //        return NotFound();
        //    }
        //    return produto;
        //}




        //  api/produtos
        //metodo para cadastrar um produto
        //[HttpPost]
        //public ActionResult Post([FromBody]Produto produto)
        //{
        //    //a validação do ModelState é feito automaticamente
        //    //quando aplicamos o atributo [ApiController]
        //    //verificando se os dados do produto são validos(usando o atributo [apicontroller] ja faz isso automaticamente
        //    //if (!ModelState.IsValid)
        //    //{
        //    //    return BadRequest(ModelState);
        //    //}

        //    //adicionando um novo produto
        //    _context.Produtos.Add(produto);
        //    //persistindo os dados adicionado
        //    _context.SaveChanges();

        //    //retornando 201 create
        //    return new CreatedAtRouteResult("ObterProduto",
        //        new { id = produto.ProdutoId }, produto);
        //}



        [HttpPost]
        public ActionResult Post([FromBody]Produto produto)
        {
            _uof.ProdutoRepository.add(produto);
            _uof.Commit();

            return new CreatedAtRouteResult("ObeterProduto", new { id = produto.ProdutoId }, produto);
        }







        ////metodo para atulizar ou modificar um produto
        //// api/produtos/1
        //[HttpPut("{id}")]
        //public ActionResult Put(int id, [FromBody] Produto produto)
        //{
        //    //a validação do ModelState é feito automaticamente
        //    //quando aplicamos o atributo [ApiController]
        //    //if(!ModelState.IsValid)
        //    //{
        //    //    return BadRequest(ModelState);
        //    //}
        //    //verificando se id passado na url e igual a do produto 
        //    if (id != produto.ProdutoId)
        //    {
        //        return BadRequest();
        //    }

        //    //alterando o estado do produto 
        //    _context.Entry(produto).State = EntityState.Modified;
        //    //persistindo as informações 
        //    _context.SaveChanges();
        //    return Ok();
        //}



        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Produto produto)
        {
            if (id != produto.ProdutoId)
            {
                return BadRequest();
            }

            _uof.ProdutoRepository.Update(produto);
            _uof.Commit();

            return Ok();
        }





        ////  api/produtos/1
        ////metodo para excluir um produto 
        //[HttpDelete("{id}")]
        //public ActionResult<Produto> Delete(int id)
        //{
        //    // Usar o método Find é uma opção para localizar 
        //    // o produto pelo id (não suporta AsNoTracking)
        //    //var produto = _context.Produtos.Find(id);
        //    var produto = _context.Produtos.FirstOrDefault(p => p.ProdutoId == id);
        //    //procura primeiro na memoria usar se id for chave primaria da tabe 
        //    // var produto = _context.Produtos.Find(id);

        //    if (produto == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.Produtos.Remove(produto);
        //    _context.SaveChanges();
        //    return produto;
        //}

        [HttpDelete("{id}")]
        public ActionResult<Produto> Delete(int id)
        {
            var produto = _uof.ProdutoRepository.GetById(p => p.ProdutoId == id);

            if (produto == null)
            {
                return NotFound();
            }

            _uof.ProdutoRepository.Delete(produto);
            _uof.Commit();
            return produto;
        }

    }
}