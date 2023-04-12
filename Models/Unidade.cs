using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace ControleProdutos.Models
{
    public class Unidade
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "O campo sigla é obrigatorio")]
        [StringLength(2,MinimumLength = 2, ErrorMessage = "A sigla deve conter dois caracteres")]
        public string Sigla { get; set; }
        [Required(ErrorMessage = "O campo descição é obrigatorio")]
        public string Descricao { get; set; }
    }
}
