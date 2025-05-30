using Loja_Seu_Manoel.Data;
using Loja_Seu_Manoel.DTO;
using Loja_Seu_Manoel.Models;
using Microsoft.EntityFrameworkCore;

namespace Loja_Seu_Manoel.Services
{
    public class PedidoService : IPedidosService
    {
        private readonly AppDbContext _context;
        public PedidoService(AppDbContext context)
        {
            _context = context;
        }   
        public async Task<List<PedidoSaidaDTO>> Embalar(List<PedidoDTO> pedidos)
        {
            try
            {
                var caixasDisponiveis = await _context.Caixas.ToListAsync();
                var pedidosSaida = new List<PedidoSaidaDTO>();
                int caixaprodutoID = 0;
                if(pedidos == null)
                {
                    throw new ArgumentException("A lista de pedidos não pode ser nula ou vazia.");
                }
                foreach (var pedido in pedidos)
                {
                    var pedidodb = new Pedido
                    {
                        Id_PedidoJson = pedido.Pedido_Id
                    };
                    await _context.Pedidos.AddAsync(pedidodb);
                    await _context.SaveChangesAsync();
                    var caixasUsadas = new List<CaixaSaidaDTO>();
                    foreach (var produto in pedido.Produtos)
                    {
                        var produtoDb = new Produto
                        {
                            Nome = produto.Produto_id,
                            Altura = produto.Dimensoes.Altura,
                            Largura = produto.Dimensoes.Largura,
                            Comprimento = produto.Dimensoes.Comprimento

                        };
                        await _context.Produtos.AddAsync(produtoDb);
                        await _context.SaveChangesAsync();
                        bool coube = false;
                        foreach (var caixa in caixasUsadas)
                        {
                            var caixaInfo = caixasDisponiveis.FirstOrDefault(c => $"Caixa {c.Id_Caixa}" == caixa.Caixa);
                            if (caixaInfo != null && ProdutoCabeNaCaixa(produto, caixaInfo))
                            {
                                caixa.Produtos.Add(produto.Produto_id);
                                coube = true;
                                break;
                            }
                        }
                        if (!coube)
                        {
                            var caixaSelecionada = caixasDisponiveis.FirstOrDefault(c => ProdutoCabeNaCaixa(produto, c));
                            if (caixaSelecionada != null)
                            {
                                caixasUsadas.Add(new CaixaSaidaDTO
                                {
                                    Caixa = $"Caixa {caixaSelecionada.Id_Caixa}",
                                    Produtos = new List<string> { produto.Produto_id }
                                });
                                var caixaprodutodb = new CaixaProduto
                                {
                                    CaixaId = caixaSelecionada.Id_Caixa,
                                    ProdutoId = produtoDb.Id_Produto
                                };
                                await _context.CaixaProdutos.AddAsync(caixaprodutodb);
                                await _context.SaveChangesAsync();
                                caixaprodutoID = caixaprodutodb.Id;
                            }
                            else
                            {
                                caixasUsadas.Add(new CaixaSaidaDTO
                                {
                                    Caixa = "",
                                    Produtos = new List<string> { produto.Produto_id },
                                    Observacao = "Produto não cabe em nenhuma caixa disponível."
                                });
                            }
                        }
                    }
                    pedidosSaida.Add(new PedidoSaidaDTO
                    {
                        Id_Pedido = pedido.Pedido_Id,
                        Caixas = caixasUsadas
                    });
                    var pedidocaixaprodutosdb = new PedidoCaixaProduto
                    {
                        PedidoId = pedidodb.Id_Pedido,
                        CaixaProdutoId = caixaprodutoID
                    };
                    await _context.pedidoCaixaProdutos.AddAsync(pedidocaixaprodutosdb);
                    await _context.SaveChangesAsync();
                }
                return pedidosSaida;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocorreu um erro:", ex);
            }
        }
        private bool ProdutoCabeNaCaixa(ProdutoDTO produto, Caixa caixa)
        {
            var rotacoes = new List<(int h, int w, int l)>
            {
                (produto.Dimensoes.Altura, produto.Dimensoes.Largura, produto.Dimensoes.Comprimento),
                (produto.Dimensoes.Largura, produto.Dimensoes.Altura, produto.Dimensoes.Comprimento),
                (produto.Dimensoes.Comprimento, produto.Dimensoes.Largura, produto.Dimensoes.Altura),
                (produto.Dimensoes.Comprimento, produto.Dimensoes.Altura, produto.Dimensoes.Largura),
                (produto.Dimensoes.Altura, produto.Dimensoes.Comprimento, produto.Dimensoes.Largura),
                (produto.Dimensoes.Largura, produto.Dimensoes.Comprimento, produto.Dimensoes.Altura)
            };
            foreach (var (h, w, l) in rotacoes)
            {
                if (h <= caixa.Altura && w <= caixa.Largura && l <= caixa.Comprimento)
                    return true;
            }
            return false;
        }
    }
}