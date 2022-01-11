using System.ComponentModel.DataAnnotations;

namespace Destino_Certo.Data.Dtos.Destino
{
    public class ReadDestinoDto
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo Nome é obrigatório")]
        public string Local { get; set; }

        public byte[] Imagem { get; set; }

        [Required(ErrorMessage = "O campo Descricao é obrigatório")]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "O campo Incluso é obrigatório")]
        public string Incluso { get; set; }
    }
}
