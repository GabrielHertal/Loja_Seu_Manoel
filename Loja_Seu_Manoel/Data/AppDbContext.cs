using Loja_Seu_Manoel.Models;
using Microsoft.EntityFrameworkCore;

namespace Loja_Seu_Manoel.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<Caixa> Caixas { get; set; }
        public DbSet<CaixaProduto> CaixaProdutos { get; set; }
        public DbSet<PedidoCaixaProduto> pedidoCaixaProdutos { get; set; }  
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Caixa>().HasData(
            new Caixa
            {
                Id_Caixa = 1,
                Nome = "Caixa 1",
                Altura = 30,
                Largura = 40, 
                Comprimento = 80
            },
            new Caixa
            {
                Id_Caixa = 2,
                Nome = "Caixa 2",
                Altura = 80,
                Largura = 50, 
                Comprimento = 40
            },
            new Caixa
            {
                Id_Caixa = 3,
                Nome = "Caixa 3",
                Altura = 50,
                Largura = 80, 
                Comprimento = 60
            }
            );
        }
    }
}
