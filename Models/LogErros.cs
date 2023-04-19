using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ControleProdutos.Models
{
    public class LogErros
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // auto incremento do valor do ID
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo Err é obrigatorio e não pode ser null ou estar vazio")]
        public string Err { get; set; }

        [Required(ErrorMessage = "O campo ErrDesc é obrigatorio e não pode ser null ou estar vazio")]
        public string ErrDesc { get; set; }

        public string LocErro { get; set; }

        [Required(ErrorMessage = "O campo ErrDate é obrigatorio")]
        public DateTime ErrDate { get; set; }  
    }
}
