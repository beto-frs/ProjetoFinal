namespace Destino_Certo.Models
{
    public class AdminModelAll
    {
        public virtual List<AtendimentoModel> Atendimentos { get; set; }

        public virtual List<DestinoModel> Destinos { get; set; }

        public virtual List<PessoaModel> Usuarios { get; set; }

        public virtual List<ReservaModel> Reservas { get; set; }

        public AdminModelAll()
        {
            Atendimentos = new List<AtendimentoModel>();
            Destinos = new List<DestinoModel>();
            Usuarios = new List<PessoaModel>();
            Reservas = new List<ReservaModel>();
        }
    }
}
