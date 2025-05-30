using Loja_Seu_Manoel.Models;

namespace Loja_Seu_Manoel.DTO
{
    public class PedidoDTO
    {
        public int Pedido_Id { get; set; }
        public List<ProdutoDTO> Produtos { get; set; }
    }
}