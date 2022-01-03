using Destino_Certo.Data.Dtos.Usuario;
using Destino_Certo.Data.Dtos.Usuario.User;
using Destino_Certo.Models;
using System.ComponentModel.DataAnnotations;

namespace Destino_Certo.Data.Dtos.Pessoa
{
    public class CreatePessoaDto
    {
        public string Nome { get; set; }
        public DateTime Nascimento { get; set; }

        public string Ddd { get; set; }

        [Required(ErrorMessage = "O campo Telefone é obrigatório")]
        public string Telefone { get; set; }

        [Required(ErrorMessage = "O campo Email é obrigatório")]
        public string Email { get; set; }

        [Required(ErrorMessage = "O campo Cep é obrigatório")]
        public string Cep { get; set; }

        [Required(ErrorMessage = "O campo Logradouro é obrigatório")]
        public string Logradouro { get; set; }

        public string? Complemento { get; set; }
        public string? Referencia { get; set; }

        [Required(ErrorMessage = "O campo Bairro é obrigatório")]
        public string Bairro { get; set; }

        [Required(ErrorMessage = "O campo Cidade é obrigatório")]
        public string Cidade { get; set; }

        [Required(ErrorMessage = "O campo Uf é obrigatório")]
        public string Uf { get; set; }

        public DateTime Cadastro { get; set; } = DateTime.Now;

        public CreateUserDto Usuario { get; set; }

        public string EnvioMarketing { get; set; }

    }
}
