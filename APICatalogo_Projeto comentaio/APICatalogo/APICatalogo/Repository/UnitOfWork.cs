using APICatalogo.Context;

namespace ApiCatalogo.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        //estanciando os repositorios existentes 
        private ProdutoRepository  _produtoRepo;
        private CategoriaRepository  _categoriaRepo;
        //injeção de dependecia 
        public AppDbContext _context;
        //contrutor 
        public UnitOfWork(AppDbContext contexto)
        {
            _context = contexto;
        }


        public IProdutoRepository ProdutoRepository
        {
            get
            {
                //verificando se uma estancia do repositorio e nula se for nula passa o context caso contrario passa produtorepo 
                return _produtoRepo = _produtoRepo ?? new ProdutoRepository(_context);
            }
        }

        public ICategoriaRepository CategoriaRepository
        {
            get
            {
                //verificando se uma estancia do repositorio e nula se for nula passa o context caso contrario passa categoriarepo 
                return _categoriaRepo = _categoriaRepo ?? new CategoriaRepository(_context);
            }
        }

        //salvando as informações 
        public void Commit()
        {
            //persistindo as informações no bando de dados 
            _context.SaveChanges();
        }

        //liberando recursos usados na injeção do context 
        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
