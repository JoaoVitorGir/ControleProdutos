using ControleProdutos.Data;
using ControleProdutos.Models;
using Microsoft.AspNetCore.Mvc;

namespace ControleProdutos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LogErrosController : ControllerBase
    {
        private readonly ControleProdutosContext _context;

        public LogErrosController(ControleProdutosContext context)
        {
            _context = context;
        }

        public async Task GravaLogAsync(string LocalErro, string msgDescricao)
        {
            try
            {
                var logErros = new LogErros
                {
                    Err = LocalErro,
                    ErrDesc = msgDescricao,
                    ErrDate = DateTime.Now
                };

                await _context.LogErros.AddAsync(logErros);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro ao salvar Log. " + ex.Message);
            }

        }
    }
}
