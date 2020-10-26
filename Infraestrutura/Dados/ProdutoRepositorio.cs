using System.Collections.Generic;
using System.Linq;
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

        public async Task<IReadOnlyList<CategoriaProduto>> GetCategoriaProdutosAsync()
        {
            return await _contexto.CategoriaProduto.ToListAsync();
        }

        public async Task<Produto> GetProdutoPorIdAsync(int id)
        {
            return await _contexto.Produtos
            .Include(p => p.Tipo)
            .Include(p => p.Categoria)
            .FirstOrDefaultAsync(p => p.Id == id);
        }
        public async Task<IReadOnlyList<Produto>> GetProdutosAsync()
        {
            var typeId = 1;

            var products = _contexto.Produtos
            .Where(x => x.IdTipoDeProduto == typeId)
            .Include(x => x.Tipo)
            .ToListAsync();
            
            return await _contexto.Produtos
            .Include(p => p.Tipo)
            .Include(p => p.Categoria)
            .ToListAsync();
        }

        public async Task<IReadOnlyList<TipoProduto>> GetTiposProdutosAsync()
        {
            return await _contexto.TipoProdutos.ToListAsync();
        }
    }
}