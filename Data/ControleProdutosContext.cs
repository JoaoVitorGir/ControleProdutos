using Microsoft.EntityFrameworkCore;
using ControleProdutos.Models;
namespace ControleProdutos.Data
{
    public class ControleProdutosContext : DbContext
    {

        public ControleProdutosContext(DbContextOptions<ControleProdutosContext> options): base(options) {
        }

        public DbSet<Produto> Produto { get; set; }

    }
}
