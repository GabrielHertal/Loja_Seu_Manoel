using System.ComponentModel.DataAnnotations;

namespace Loja_Seu_Manoel.Models
{
    public class Pedido
    {
        [Key]
        public int Id_Pedido { get; set; }
        public int Id_PedidoJson { get; set; }

    }
}
