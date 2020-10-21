using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entidades;

namespace Core.Interfaces
{
    public interface IProdutoRepositorio
    {
        Task<Produto> GetProdutoPorIdAsync(int id);
        Task<IReadOnlyList<Produto>> GetProdutosAsync();

        Task<IReadOnlyList<CategoriaProduto>> GetCategoriaProdutosAsync();

        Task<IReadOnlyList<TipoProduto>> GetTiposProdutosAsync();
    }
}