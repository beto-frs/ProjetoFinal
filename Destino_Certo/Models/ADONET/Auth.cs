using Microsoft.Data.SqlClient;
using System.Data;

namespace Destino_Certo.Models.ADONET

{
    public class Auth:IAuth
    {
        private const string endConexao = "Data Source=192.168.64.250,1433;Initial Catalog=ProjetoFinal;User ID=administrador;Password=@@UFN@@user";
        private SqlConnection cn;

        public SqlConnection AbrirConexao()
        {
            try
            {
                Conexao();
                cn.Open();
                return cn;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public void Conexao()
        {
            cn = new SqlConnection(endConexao);
        }

        public void FecharConexao()
        {
            try
            {
                cn.Close();
            }
            catch (Exception)
            {

                return;
            }
        }

        public UsuarioModel Login()
        {
            string Login = "beto-admin";
            string Senha = "5Vy5vpF35RUSEc5OAJS4/Q==";

            AbrirConexao();
            string sqlLogin = "SELECT * FROM Usuarios WHERE login = @login AND senha = @senha" ;
            SqlCommand command = new SqlCommand(sqlLogin, cn);
            command.Parameters.AddWithValue("@login", Login);
            command.Parameters.AddWithValue("@senha", Senha);

            SqlDataReader dados = command.ExecuteReader();

            UsuarioModel us = new();

            if (dados.Read())
            {
                us.Id = dados.GetInt32("Id");
                us.Login = dados.GetString("Login");
                us.Senha = dados.GetString("Senha");
                us.TipoConta = dados.GetString("TipoConta");
                
            }
            FecharConexao();
            return us;

        }


    }
}
