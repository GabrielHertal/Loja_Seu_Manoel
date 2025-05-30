using System.ComponentModel.DataAnnotations;

namespace Loja_Seu_Manoel.Models
{
    public class Caixa
    {
        [Key]
        public int Id_Caixa { get; set; }
        public string Nome { get; set; } = default!;
        public int Altura { get; set; } = default!;
        public int Largura { get; set; } = default!;
        public int Comprimento { get; set; } = default!;
        public int Volume => Altura * Largura * Comprimento;
    }
}