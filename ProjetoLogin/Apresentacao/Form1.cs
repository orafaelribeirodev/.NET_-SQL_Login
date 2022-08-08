using ProjetoLogin.Apresentacao;
using ProjetoLogin.Modelo;

namespace ProjetoLogin
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnCadastrese_Click(object sender, EventArgs e)
        {
            CadastreSe cad = new CadastreSe();
            cad.Show();
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnEntrar_Click(object sender, EventArgs e)
        {
            //var acessar = new ProjetoLogin.DAL.LoginDaoComandos();
            //if (acessar.VerificarLoginAlternativo(txbLogin.Text, txbSenha.Text))
            //{
            //    MessageBox.Show("Logado com sucesso", "Entrando", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    this.Hide();
            //    BemVindo bv = new BemVindo();
            //    bv.ShowDialog();
            //}
            //else
            //{
            //    MessageBox.Show("Usuario ou Senha não Enconstrados, verificar login e senha", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}


            Controle controle = new Controle();
            controle.acessar(txbLogin.Text, txbSenha.Text);

            if (controle.mensagem.Equals(""))
            {
                if (controle.tem)
                {
                    MessageBox.Show("Logado com sucesso", "Entrando", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Hide();
                    BemVindo bv = new BemVindo();
                    bv.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Login não Enconstrado, verificar login e senha", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show(controle.mensagem);
            }
        }
    }
}