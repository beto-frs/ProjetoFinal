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

        public Autenticacao Login(string login, string senha)
        {
            AbrirConexao();
            string sqlLogin = "SELECT * FROM Pessoas WHERE login = @login AND senha = @senha" ;
            SqlCommand command = new SqlCommand(sqlLogin, cn);
            command.Parameters.AddWithValue("@login", login);
            command.Parameters.AddWithValue("@senha", senha);

            SqlDataReader dados = command.ExecuteReader();

            Autenticacao us = new();

            if (dados.Read())
            {
                us.Id = dados.GetInt32("Id");
                us.Nome = dados.GetString("Nome");
                us.Login = dados.GetString("Login");
                us.Senha = dados.GetString("Senha");
                us.Email = dados.GetString("Email");
                us.Telefone = dados.GetString("Telefone");
                us.TipoConta = dados.GetString("TipoConta");
                
            }
            FecharConexao();
            return us;

        }


    }
}
