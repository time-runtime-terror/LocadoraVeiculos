using LocadoraVeiculos.Aplicacao.FuncionarioModule;
using LocadoraVeiculos.Infra.SQL.FuncionarioModule;
using LocadoraVeiculos.netCore.Controladores.FuncionarioModule;
using System;
using System.Windows.Forms;

namespace LocadoraVeiculos.WindowsApp
{
    public partial class LoginForm : Form
    {
        private readonly FuncionarioAppService funcionarioAppService;
        private readonly FuncionarioDAO funcionarioDAO;
        public LoginForm()
        {
            InitializeComponent();
            funcionarioDAO = new FuncionarioDAO();
            funcionarioAppService = new FuncionarioAppService(funcionarioDAO);
        }

        private void btnEntrar_Click(object sender, EventArgs e)
        {
            string usuario, senha;

            usuario = txbUsuario.Text;
            senha = txbSenha.Text;

            if(string.IsNullOrEmpty(usuario) || string.IsNullOrEmpty(senha))
                MessageBox.Show("Preencha todos os campos");
            else
            {
                bool existeFuncionario = funcionarioAppService.ExisteFuncionario(usuario, senha);

                if (existeFuncionario == true)
                {
                    Dashboard tela = new Dashboard();
                    this.Hide();
                    tela.ShowDialog();
                }
                else
                    MessageBox.Show("Campos inválidos, por favor tente novamente");

                txbUsuario.Text = "";
                txbSenha.Text = "";
            }
        }
    }
}
