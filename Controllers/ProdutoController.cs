using ControleProdutos.Data;
using ControleProdutos.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ControleProdutos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        private readonly ControleProdutosContext _context;

        public ProdutoController(ControleProdutosContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<List<Produto>> GetProdutos()
        {
            var lista = new List<Produto>();
            try
            {
                lista = await _context.Produto.ToListAsync();
            }catch (Exception ex)
            {
                Console.WriteLine($"[GetProduto] Erro ao consultar produto {ex.Message}");
            }
            return lista;
        }

        //[HttpPost]

        //[HttpPut]

        //[HttpDelete]

    }
}
