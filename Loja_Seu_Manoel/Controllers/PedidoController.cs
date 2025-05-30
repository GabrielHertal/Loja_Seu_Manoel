using Loja_Seu_Manoel.DTO;
using Loja_Seu_Manoel.Services;
using Microsoft.AspNetCore.Mvc;

namespace Loja_Seu_Manoel.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PedidoController : ControllerBase
    {
        private readonly IPedidosService _pedidosService;
        public PedidoController(IPedidosService pedidosService)
        {
            _pedidosService = pedidosService;
        }
        [HttpPost("Embalar")]
        public async Task<IActionResult> Embalar([FromBody] EntradaPedidosDTO entrada)
        {
            try
            {
                var pedidos = await _pedidosService.Embalar(entrada.Pedidos);
                return Ok(new { pedidos });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao embalar pedidos: {ex.Message}");
            }
        }
    }
}