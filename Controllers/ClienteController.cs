using ControleProdutos.Data;
using ControleProdutos.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ControleProdutos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        //Variavel controladora da execução da conexao com BD
        private readonly ControleProdutosContext _context;

        public ClienteController(ControleProdutosContext context)
        {
            _context = context;
        }

        [HttpGet]
        public List<Cliente> GetClientes()
        {
            return _context.Cliente.ToList();
        }
    }
}
