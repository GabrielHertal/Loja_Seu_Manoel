using Loja_Seu_Manoel.Models;
using Microsoft.Identity.Client;

namespace Loja_Seu_Manoel.DTO
{
    public class CaixaComProdutosDTO
    {
        public Caixa Caixa { get; set; }
        public List<ProdutoDTO> Produtos { get; set; }
    }
}