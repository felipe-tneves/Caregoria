using APICatalogo.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace APICatalogo.Context
{

    //comunicação da api com o banco - coordenação
    public class AppDbContext : DbContext
    {
        //definindo um contexto
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        { }
        public AppDbContext()
        { }
        //tabelas a ser criadas no banco - mapeamento das entidades 
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Produto> Produtos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                IConfigurationRoot configuration = new ConfigurationBuilder()
                   .SetBasePath(Directory.GetCurrentDirectory())
                   .AddJsonFile("appsettings.json")
                   .Build();
                var connectionString = configuration.
                       GetConnectionString("DefaultConnection");

                optionsBuilder.UseMySql(connectionString);
            }
        }
    }
}
