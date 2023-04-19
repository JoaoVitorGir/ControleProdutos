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
    public class UnidadeController : ControllerBase
    {
        //cria instancia para conexão com o banco de dados
        private readonly ControleProdutosContext _context;
        public UnidadeController(ControleProdutosContext context)
        {
            _context = context;
        }

        //retorna uma lista de todas as unidades da tabela unidade
        [HttpGet]
        public async Task<List<Unidade>> GetUnidades()
        {
            var lista = new List<Unidade>();
            try
            {
                lista = await _context.Unidade.ToListAsync();
            }catch (Exception ex)
            {
                new Log().GravarErro("Erro ao buscar unidade", ex.InnerException.ToString(), "GetUnidades");
            }
            return lista;
        }

    }
}
