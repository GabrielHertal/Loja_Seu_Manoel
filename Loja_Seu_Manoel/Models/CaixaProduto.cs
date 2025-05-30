using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Loja_Seu_Manoel.Models
{
    public class CaixaProduto
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Caixa")]
        public int CaixaId { get; set; }
        public Caixa Caixa { get; set; } = default!;
        [ForeignKey("Produto")]
        public int ProdutoId { get; set; }
        public Produto Produto { get; set; } = default!;
    }
}
