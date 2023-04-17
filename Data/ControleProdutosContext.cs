using Microsoft.EntityFrameworkCore;
using ControleProdutos.Models;
namespace ControleProdutos.Data
{
    public class ControleProdutosContext : DbContext
    {

        public ControleProdutosContext(DbContextOptions<ControleProdutosContext> options): base(options) {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("ControleProdutos");
        }

        //Cria as tabelas nas migration e para usar nos conrollers 
        public DbSet<Produto> Produto { get; set; }
        public DbSet<Unidade> Unidade { get; set; }
        public DbSet<Cliente> Cliente { get; set; }


    }
}
