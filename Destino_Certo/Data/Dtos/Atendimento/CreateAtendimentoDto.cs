using Destino_Certo.Models;
using System.ComponentModel.DataAnnotations;

namespace Destino_Certo.Data.Dtos.Atendimento
{
    public class CreateAtendimentoDto
    {

        [Required(ErrorMessage = "O campo Assunto é obrigatório")]
        public string Assunto { get; set; }

        public int PessoaModelId { get; set; }
        //public virtual PessoaModel Pessoa { get; set; }

        [Required(ErrorMessage = "O campo Mensagem é obrigatório")]
        public string Mensagem { get; set; }

        public DateTime Inicio = DateTime.Now;

        public bool FezContato = false;

        public string Tratativa = "Nenhuma";
    }
}