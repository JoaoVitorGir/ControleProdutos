using ControleProdutos.Data;
using ControleProdutos.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ControleProdutos.Generic;

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


        [HttpPost]
        public async Task<string> postProduto(Produto newProduto)
        {
            string res = "Erro ao incluir produto";
            try
            {
                await _context.Produto.AddAsync(newProduto);
                var valor = await _context.SaveChangesAsync();

                if (valor == 1)
                {
                    res = "Estado incluido!";
                }
            }
            catch(Exception ex)
            {
                
            }

            return res;
        }


        [HttpPut]
        public async Task<string> putProduto(Produto newProduto)
        {
            string res = "Erro ao alterar produto não alterado!";
            try
            {
                _context.Produto.Update(newProduto);
                var valor = _context.SaveChanges();
                if (valor == 1)
                {
                    res = "Produto alterado!";
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao alterar um produto. Exceção: {ex.Message}");
            }
            return res;
        }


        [HttpDelete("Delete/{id}")]
        public string deleteProduto(int id)
        {
            string res = "Produto não excluído!";
            try
            {
                // zero produto ainda não foi excluido
                var valor = 0;
                var produto = _context.Produto.Find(id);
                if (produto != null)
                {
                    _context.Produto.Remove(produto);
                    valor = _context.SaveChanges();
                }
                
                if (valor == 1)
                {
                    res = "Produto excluído";
                }
            }
            catch(Exception ex) {
                new LogUtils().AddLogErro(_context, "Teste", "Teste");
                Console.WriteLine($"Erro ao alterar um estado. Exceção: {ex.Message}");
            }
            return res;
        }

    }
}
