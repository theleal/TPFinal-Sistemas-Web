using System.ComponentModel.DataAnnotations;

namespace Web.Models
{
    public class Usuario
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo Nome é obrigatório.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O campo Senha é obrigatório.")]
        public string Senha { get; set; }

        [Required(ErrorMessage = "O campo Status é obrigatório.")]
        public bool Status { get; set; }
    }
}
