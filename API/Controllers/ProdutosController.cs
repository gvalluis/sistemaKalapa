using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entidades;
using Infraestrutura.Dados;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProdutosController : ControllerBase
    {
        private readonly ContextoLoja _contexto;
        public ProdutosController(ContextoLoja contexto)
        {
            _contexto = contexto;

        }

        [HttpGet]
        public async Task<ActionResult<List<Produto>>> GetProdutos()
        {
            var produtos = await _contexto.Produtos.ToListAsync();

            return Ok(produtos);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Produto>> GetProduto(int id)
        {

            return await _contexto.Produtos.FindAsync(id);
        }
    }
}