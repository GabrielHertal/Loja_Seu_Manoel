using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Loja_Seu_Manoel.Models
{
    public class Produto
    {
        [Key]
        public int Id_Produto { get; set; }
        public string Nome { get; set; } = default!;
        public int Altura { get; set; }
        public int Largura { get; set; }
        public int Comprimento { get; set; }
    }
}