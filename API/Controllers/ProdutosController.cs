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
        private readonly IProdutoRepositorio _repo;
        public ProdutosController(IProdutoRepositorio repo)
        {
            _repo = repo;

        }

        [HttpGet]
        public async Task<ActionResult<List<Produto>>> GetProdutos()
        {
            var produtos = await _repo.GetProdutosAsync();

            return Ok(produtos);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Produto>> GetProduto(int id)
        {

            return await _repo.GetProdutoPorIdAsync(id);
        }
    }
}