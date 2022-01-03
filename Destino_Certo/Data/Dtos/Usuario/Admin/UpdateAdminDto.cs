using System.ComponentModel.DataAnnotations;

namespace Destino_Certo.Data.Dtos.Usuario.Admin
{
    public class UpdateAdminDto
    {
        [Required(ErrorMessage = "O campo Login é obrigatório")]
        //[MinLength(6, ErrorMessage = "Deve conter pelo menos 6 caracteres")]
        //[MaxLength(50, ErrorMessage = "Deve conter no máximo 50 caracteres")]
        public string Login { get; set; }

        [Required(ErrorMessage = "O campo Senha é obrigatório")]
        //[MinLength(8, ErrorMessage = "A senha deve conter no minimo 8 caracteres.")]
        //[MaxLength(50, ErrorMessage = "A senha deve conter no máximo 50 caracteres.")]
        public string Senha { get; set; }

        public string TipoConta = "Admin";
    }
}
