using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entidades;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infraestrutura.Dados
{
    public class ProdutoRepositorio : IProdutoRepositorio
    {
        private readonly ContextoLoja _contexto;
        public ProdutoRepositorio(ContextoLoja contexto)
        {
            _contexto = contexto;
        }
        public async Task<Produto> GetProdutoPorIdAsync(int id)
        {
            return await _contexto.Produtos.FindAsync(id);
        }
        public async Task<IReadOnlyList<Produto>> GetProdutosAsync()
        {
            return await _contexto.Produtos.ToListAsync();
        }


    }
}