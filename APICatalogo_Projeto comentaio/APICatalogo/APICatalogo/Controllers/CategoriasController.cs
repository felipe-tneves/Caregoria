using ApiCatalogo.Repository;
using APICatalogo.Context;
using APICatalogo.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;

namespace ApiCatalogo.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class CategoriasController : ControllerBase
    {

        private readonly IUnitOfWork _context;

        public CategoriasController(IUnitOfWork contexto)
        {
            _context = contexto;
        }


        ////estanciando tipo configurantion 
        ////leitura das informações dos arquivos de configuração atraves do serviço IConfiguration
        //private readonly IConfiguration _configuration;
        //private readonly AppDbContext _context;
        //private readonly ILogger _logger;

        ////solicitando o serviço IConfiguration 
        //public CategoriasController(AppDbContext contexto, IConfiguration configuration, ILogger<CategoriasController> logger)
        //{
        //    _configuration = configuration;
        //    _context = contexto;
        //    _logger = logger;
        //}


        ////retorna a configuração da string de conexao 
        //[HttpGet("autor")]
        //public string GetAutor()
        //{
        //    var autor = _configuration["autor"];
        //    var conexao = _configuration["ConnectionStrings:DefaultConnection"];
        //    return $"Autor : {autor}  Conexa : {conexao}";
        //}

        ////metodo para retornar categorias com produtos (incluide)
        //[HttpGet("produtos")]
        //public ActionResult<IEnumerable<Categoria>> GetCategoriasProdutos()
        //{
        //    _logger.LogInformation("=======================Get api/categorias/produtos===========================");
        //    return _context.Categorias.Include(x => x.Produtos).ToList();
        //}

        //metodo para retornar categorias com produtos (incluide)
        [HttpGet("produtos")]
        public ActionResult<IEnumerable<Categoria>> GetCategoriasProdutos()
        {
            return _context.CategoriaRepository.GetCategoriasProdutos().ToList();
        }


        ////metodo para listar as categotias
        //[HttpGet]
        //public ActionResult<IEnumerable<Categoria>> Get()
        //{
        //    _logger.LogInformation("=======================Get api/categorias===========================");
        //    return _context.Categorias.AsNoTracking().ToList();


        //metodo para listar as categotias
        [HttpGet]
        public ActionResult<IEnumerable<Categoria>> Get()
        {
            return _context.CategoriaRepository.Get().ToList();
        }


        ////metodo para listar categotia por id 
        //[HttpGet("{id}", Name = "ObterCategoria")]
        //public ActionResult<Categoria> Get(int id)
        //{
        //    _logger.LogInformation($"=======================Get api/categorias/id = {id} ===========================");
        //    var categoria = _context.Categorias.AsNoTracking()
        //        .FirstOrDefault(p => p.CategoriaId == id);

        //    if (categoria == null)
        //    {
        //        _logger.LogInformation($"=======================Get api/categorias/id = {id} NOT FOUND ===========================");
        //        return NotFound();
        //    }
        //    return categoria;
        //}

        //metodo para listar categotia por id 
        [HttpGet("{id}", Name = "ObterCategoria")]
        public ActionResult<Categoria> Get(int id)
        {
            var categoria = _context.CategoriaRepository.GetById(p => p.CategoriaId == id);

            if (categoria == null)
            {
                return NotFound();
            }

            return categoria;
        }



        ////metodo para cadastrar uma categoria
        //[HttpPost]
        //public ActionResult Post([FromBody]Categoria categoria)
        //{
        //    //if(!ModelState.IsValid)
        //    //{
        //    //    return BadRequest(ModelState);
        //    //}

        //    //adicionando um novo produto
        //    _context.Categorias.Add(categoria);
        //    //persistindo os dados adicionado
        //    _context.SaveChanges();

        //    //retornando 201 create
        //    return new CreatedAtRouteResult("ObterCategoria",
        //        new { id = categoria.CategoriaId }, categoria);
        //}


        //metodo para cadastrar uma categoria
        [HttpPost]
        public ActionResult Post([FromBody]Categoria categoria)
        {
            _context.CategoriaRepository.add(categoria);
            _context.Commit();

            return new CreatedAtRouteResult("ObterCategoria",
                new { id = categoria.CategoriaId }, categoria);
        }




        ////metodo para atulizar ou modificar um categoria
        //[HttpPut("{id}")]
        //public ActionResult Put(int id, [FromBody] Categoria categoria)
        //{
        //    //if(!ModelState.IsValid)
        //    //{
        //    //    return BadRequest(ModelState);
        //    //}
        //    if (id != categoria.CategoriaId)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(categoria).State = EntityState.Modified;
        //    _context.SaveChanges();
        //    return Ok();
        //}



        //metodo para atulizar ou modificar um categoria
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Categoria categoria)
        {
            if (id != categoria.CategoriaId)
            {
                return BadRequest();
            }

            _context.CategoriaRepository.Update(categoria);
            _context.Commit();

            return Ok();
            
        }



        ////metodo para excluir uma categoria
        //[HttpDelete("{id}")]
        //public ActionResult<Categoria> Delete(int id)
        //{
        //    var categoria = _context.Categorias.FirstOrDefault(p => p.CategoriaId == id);
        //    //var categoria = _context.Categorias.Find(id);

        //    if (categoria == null)
        //    {
        //        return NotFound();
        //    }
        //    _context.Categorias.Remove(categoria);
        //    _context.SaveChanges();
        //    return categoria;
        //}


        //metodo para excluir uma categoria
        [HttpDelete("{id}")]
        public ActionResult<Categoria> Delete(int id)
        {
            var categoria = _context.CategoriaRepository.GetById(p => p.CategoriaId == id);

            if (categoria == null)
            {
                return NotFound();
            }

            _context.CategoriaRepository.Delete(categoria);
            _context.Commit();

            return categoria;
        }
    }
}

