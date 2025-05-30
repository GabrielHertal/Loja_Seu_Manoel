namespace Loja_Seu_Manoel.DTO
{
    public class PedidoSaidaDTO
    {
        public int Id_Pedido { get; set; }
        public List<CaixaSaidaDTO> Caixas { get; set; }
    }
}