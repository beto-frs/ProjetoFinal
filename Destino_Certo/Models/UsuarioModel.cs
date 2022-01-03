using System.ComponentModel.DataAnnotations;

namespace Destino_Certo.Models
{
    public class UsuarioModel
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo Login é obrigatório")]
        public string Login { get; set; }

        [Required(ErrorMessage = "O campo Senha é obrigatório")]
        public string Senha { get; set; }

        public string TipoConta { get; set; }

        public virtual PessoaModel Pessoa { get; set; }

        public virtual ColaboradorModel Colaborador { get; set; }



    }
}
