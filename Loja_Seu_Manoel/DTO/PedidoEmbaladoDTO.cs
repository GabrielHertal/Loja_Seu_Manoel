using Loja_Seu_Manoel.Models;

namespace Loja_Seu_Manoel.DTO
{
    public class PedidoEmbaladoDTO
    {
        public int Id_Pedido { get; set; }
        public List<CaixaComProdutosDTO> Caixas { get; set; }
    }
}