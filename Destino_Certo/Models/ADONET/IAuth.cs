using Microsoft.Data.SqlClient;

namespace Destino_Certo.Models.ADONET
{
    public interface IAuth
    {
        void Conexao();
        SqlConnection AbrirConexao();

        void FecharConexao();

        public UsuarioModel Login();


    }
}
