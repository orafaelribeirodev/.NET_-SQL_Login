using ProjetoLogin.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoLogin.Modelo
{
    public class Controle
    {
        public bool tem;
        public string mensagem = "";

        public bool acessar(string Login, string senha)
        {
            LoginDaoComandos loginDao = new LoginDaoComandos();

            tem = loginDao.VerificarLogin(Login, senha);

            if (!loginDao.mensagem.Equals(""))
            {
                this.mensagem = loginDao.mensagem;
            }
            return tem;

        }

        public string Cadastrar(string email, string senha, string confirSenha)
        {
            LoginDaoComandos loginDao = new LoginDaoComandos();
            this.mensagem = loginDao.Cadastrar(email, senha, confirSenha);
            if(loginDao.tem)
            {
                this.tem = true
            }
            return mensagem;
        }

        internal void Cadastrar(string text1, TextBox textBox2, string text2, TextBox textBox3)
        {
            throw new NotImplementedException();
        }

        //public string Cadastrar(ProjetoLogin.Modelo.Cadastrar cadastro)
        //{
        //    LoginDaoComandos loginDao = new LoginDaoComandos();
        //    loginDao.Cadastrar(cadastro.Email, cadastro.Senha, cadastro.ConfirmaSEnha);
        //    return mensagem;
        //}
    }
}
