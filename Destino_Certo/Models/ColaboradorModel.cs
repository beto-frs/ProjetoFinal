using System.ComponentModel.DataAnnotations;

namespace Destino_Certo.Models
{
    public class ColaboradorModel
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo Nome é obrigatório")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O campo Funcao é obrigatório")]
        public string Funcao { get; set; }

        public int UsuarioId { get; set; }

        public virtual UsuarioModel Usuario { get; set; }
    }
}
