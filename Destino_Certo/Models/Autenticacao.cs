namespace Destino_Certo.Models
{
    public class Autenticacao
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public string Login { get; set; }

        public string Senha { get; set; }

        public string Email { get; set; }

        public string Telefone { get; set; }

        public string TipoConta { get; set; }

        public string EnvioMarketing { get; set; }


        public Autenticacao GetAutenticacao()
        {
            return this;
        }
    }
}
