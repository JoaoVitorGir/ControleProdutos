using System.ComponentModel.DataAnnotations;

namespace ControleProdutos.Models
{
    public class Produto
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "O campo Unidade é obrigatorio")]
        public string Nome { get; set; }
        public string Descricao { get; set; }
        [Required(ErrorMessage = "O campo Unidade é obrigatorio")]
        [StringLength(2,MinimumLength = 2, ErrorMessage = "O campo unidade deve conter dois caractes")]
        public string Unidade { get; set; }
    }
}
