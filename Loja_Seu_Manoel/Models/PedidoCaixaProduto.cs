using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Loja_Seu_Manoel.Models
{
    public class PedidoCaixaProduto
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Pedido")]
        public int PedidoId { get; set; }
        public Pedido Pedido { get; set; } = default!;
        [ForeignKey("CaixaProduto")]
        public int CaixaProdutoId { get; set; }
        public CaixaProduto CaixaProduto { get; set; } = default!;
    }
}
