using Loja_Seu_Manoel.DTO;

namespace Loja_Seu_Manoel.Services
{
    public interface IPedidosService
    {
        Task<List<PedidoSaidaDTO>> Embalar(List<PedidoDTO> pedidos);
    }
}