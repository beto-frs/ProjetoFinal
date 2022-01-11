namespace Destino_Certo.Models
{
    public class ReservaModel
    {
        public int Id { get; set; }
        public int PessoaId { get; set; }
        public virtual PessoaModel Pessoa { get; set; }

        public DateTime? DataViagem { get; set; }

        public string Pacote { get; set;}

        public int DestinoId { get; set; }

        public virtual DestinoModel Destino { get; set; }

        public bool IsAtted = false;

        public int? AtendimentoId { get; set; }

        public string? NomeAnalista { get; set;}

        public string? IsConfirmed { get; set;}

        public string? FormaPagamento { get; set;}

    }
}
