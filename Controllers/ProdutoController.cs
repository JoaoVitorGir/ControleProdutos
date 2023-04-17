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
                Console.WriteLine($"Erro ao consultar produto [GetProduto] {ex.Message}");
            }
            return lista;
        }

        //[HttpPost]

        //[HttpPut]

        [HttpDelete("Delete/{id}")]
        public string deleteProduto(int id)
        {
            string teste = "Produto não excluído!";
            var produto = _context.Produto.Find(id);
            _context.Produto.Remove(produto);
            var valor = _context.SaveChanges();
            if (valor == 1)
            {
                teste = "Produto excluído";
            }
            return teste;
        }

    }
}
