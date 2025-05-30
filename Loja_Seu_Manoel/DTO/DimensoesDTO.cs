using System.ComponentModel.DataAnnotations;

namespace Loja_Seu_Manoel.DTO
{
    public class DimensoesDTO
    {
        [Required(ErrorMessage = "O campo Altura é obrigatório.")]
        public int Altura { get; set; }
        [Required(ErrorMessage = "O campo Largura é obrigatório.")]
        public int Largura { get; set; }
        [Required(ErrorMessage = "O campo Comprimento é obrigatório.")]
        public int Comprimento { get; set; }
    }
}