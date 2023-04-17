using System.ComponentModel.DataAnnotations;

namespace ControleProdutos.Models
{
    public class Cliente
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "O nome é obrigatorio")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "O nome deve conter entre dois e cem caractes")]
        public string nome { get; set; }

        [Required(ErrorMessage = "O cpf ou cnpj é obrigatorio")]
        public string cpfcnpj { get; set; }

        [Required(ErrorMessage = "A data de nascimento é obrigatorio")]
        [StringLength(10, MinimumLength = 10, ErrorMessage = "A data de nascimento precisa ser informada corretamente")]
        public string dtnascimento { get; set; }


    }
}
