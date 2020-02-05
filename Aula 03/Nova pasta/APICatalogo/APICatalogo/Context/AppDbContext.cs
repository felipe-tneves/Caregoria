using APICatalogo.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APICatalogo.Context
{
    //comunicação da api com o banco - coordenação
    public class AppDbContext : DbContext
    {
        //definido um contexto
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            
        }

        //tabelas a ser criadas no banco - mapeamento das entidades 
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Produto> Produtos { get; set; }
    }
}
