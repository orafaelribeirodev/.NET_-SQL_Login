using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoLogin.Modelo
{
    public class Acesso
    {
        public string Login { get; set; }
        public string Senha { get; set; }
    }

    public class Cadastrar
    {
        public string Email { get; set; }
        public string Senha { get; set; }
        public string ConfirmaSEnha { get; set; }
    }
}
