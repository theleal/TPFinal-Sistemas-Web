using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using static API.Enumerators.Padrões;

namespace API.Models
{
    public class Produto
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo Nome é obrigatório.")]
        public string Nome { get; set; } = string.Empty;

        [Required(ErrorMessage = "O campo Preço é obrigatório.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "O preço deve ser maior que zero.")]
        public float Preco { get; set; }

        [Required(ErrorMessage = "O campo Status é obrigatório.")]
        public bool Status { get; set; }



        [ForeignKey("UsuarioCriacao")]
        public int ID_UsuarioCriacao { get; set; }
        public Usuario UsuarioCriacao { get; set; }



        [ForeignKey("UsuarioAlteracao")]
        public int? ID_UsuarioAlteracao { get; set; }
        public Usuario UsuarioAlteracao { get; set; }

    }
}