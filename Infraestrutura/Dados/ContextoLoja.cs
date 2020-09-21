
using System.Reflection;
using Core.Entidades;
using Microsoft.EntityFrameworkCore;

namespace Infraestrutura.Dados
{
    public class ContextoLoja : DbContext
    {
        public ContextoLoja(DbContextOptions<ContextoLoja> options) : base(options)
        {
        }

        public DbSet<Produto> Produtos { get; set; }
        public DbSet<CategoriaProduto> CategoriaProduto { get; set; }
        public DbSet<TipoProduto> TipoProdutos { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
   }
}