using Destino_Certo.Models;
using System.ComponentModel.DataAnnotations;

namespace Destino_Certo.Data.Dtos.Hotel
{
    public class ReadHotelDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo Nome é obrigatório")]
        public string Nome { get; set; }

        public string PathImagem { get; set; }

        [Required(ErrorMessage = "O campo Descrição é obrigatório")]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "O campo Incluido no Pacote é obrigatório")]
        public string IncluidoPacote { get; set; }

        public virtual DestinoModel Destino { get; set; }
    }
}
