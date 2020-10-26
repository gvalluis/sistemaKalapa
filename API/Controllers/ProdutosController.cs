using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entidades;
using Core.Interfaces;
using Infraestrutura.Dados;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProdutosController : ControllerBase
    {
        private readonly IGenericRepository<Produto> _repoProduto;
        private readonly IGenericRepository<TipoProduto> _repoTipo;
        private readonly IGenericRepository<CategoriaProduto> _repoCategoria;
        
        public ProdutosController(IGenericRepository<Produto> repoProduto,
        IGenericRepository<TipoProduto> repoTipo,
        IGenericRepository<CategoriaProduto> repoCategoria)
        {
            _repoCategoria = repoCategoria;
            _repoTipo = repoTipo;
            _repoProduto = repoProduto;

        }

        [HttpGet]
        public async Task<ActionResult<List<Produto>>> GetProdutos()
        {
            var produtos = await _repoProduto.ListAllAsync();

            return Ok(produtos);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Produto>> GetProduto(int id)
        {

            return await _repoProduto.GetByIdAsync(id);
        }

        [HttpGet("categorias")]
        public async Task<ActionResult<IReadOnlyList<CategoriaProduto>>> GetCategoriasProduto()
        {
            return Ok(await _repoCategoria.ListAllAsync());
        }

        [HttpGet("tipos")]
        public async Task<ActionResult<IReadOnlyList<TipoProduto>>> GetTiposProduto()
        {
            return Ok(await _repoTipo.ListAllAsync());
        }
    }
}