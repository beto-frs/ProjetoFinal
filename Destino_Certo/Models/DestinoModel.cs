using System.ComponentModel.DataAnnotations;

namespace Destino_Certo.Models
{
    public class DestinoModel
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo Nome é obrigatório")]
        public string Local { get; set; }


        [Required(ErrorMessage = "O campo Descricao é obrigatório")]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "O campo Incluso é obrigatório")]
        public string Incluso { get; set; }

        public string NomeArquivo { get; set; }

        public string ExtensaoArquivo { get; set; }

        public byte[] ArrayImagem { get; set; }

        public string InfoArquivo { get; set; }

        public string? CidadeEstado { get; set; }
        

        

    }
}
