using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoLogin.DAL
{
    class LoginDaoComandos
    {
        public bool tem;
        public string mensagem = ""; //tudo ok se ela continuar vazia
        SqlCommand cmd = new SqlCommand();
        Coneccao con = new Coneccao();
        SqlDataReader dr;

        public bool VerificarLogin(string login, String senha)
        {
            try
            {
                //comandos sql para verificar se tem no banco 
                cmd.CommandText = "select * from logins where email = @login and senha = @senha";
                cmd.Parameters.AddWithValue("@login", login);
                cmd.Parameters.AddWithValue("@senha", senha);

                cmd.Connection = con.conectar();
                dr = cmd.ExecuteReader();
                if (dr.HasRows) // se foi encontrado
                {
                    tem = true;
                }
            }

            catch (SqlException e)
            {
                this.mensagem = e.Message;
            }

            return tem;
        }

        //public bool VerificarLoginAlternativo(string login, String senha)
        //{
        //    using (var conn = new SqlConnection(@"Data Source=DESKTOP-VCJ9VV1;Initial Catalog=projetoLogin;Integrated Security=True"))
        //    {
        //        try
        //        {
        //            var sql = "select * from logins where email = @login and senha = @senha";
        //            var cmmd = new SqlCommand(sql, conn);
        //            cmmd.Parameters.AddWithValue("@login", login);
        //            cmmd.Parameters.AddWithValue("@senha", senha);
        //            conn.Open();
        //            var read = cmmd.ExecuteReader();
        //            var existe = read.Read();
        //            read.Close();
        //            conn.Close();
        //            return existe;
        //        }
        //        catch (SqlException e)
        //        {
        //            MessageBox.Show(e.Message, "Ocorreu um erro.", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //            return false;//Se ocorrer erro retorna mensagem de erro
        //        }
        //    }
        //}

        public string Cadastrar(string email, string senha, string confirSenha)
        {
            // comandos para inserir 
            if (senha.Equals(confirSenha))
            {
                cmd.CommandText = "insert into logins values(@e,@S);";
                cmd.Parameters.AddWithValue("@e", email);
                cmd.Parameters.AddWithValue("@s", senha);

                try
                {
                    cmd.Connection = con.conectar();
                    cmd.ExecuteNonQueryAsync();
                    con.desconectar();
                    this.mensagem = "Cadastrado com sucesso!";

                }
                catch (SqlException)
                {
                    this.mensagem = "Erro com Banco de Dados";
                }
            }
            else
            {
                this.mensagem = "Senhas nao Correspondem";
            }
            return mensagem;
            
        }
    }
}
