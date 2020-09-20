
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
    }
}