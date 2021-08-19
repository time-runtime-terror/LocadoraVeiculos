using LocadoraVeiculos.Controladores.FuncionarioModule;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LocadoraVeiculos.WindowsApp
{
    public partial class LoginForm : Form
    {
        private readonly ControladorFuncionario controlador;
        public LoginForm()
        {
            InitializeComponent();
            controlador = new ControladorFuncionario();
        }

        private void btnEntrar_Click(object sender, EventArgs e)
        {
            string usuario, senha;

            usuario = txbUsuario.Text;
            senha = txbSenha.Text;



            if(string.IsNullOrEmpty(usuario) || string.IsNullOrEmpty(senha))
            {
                MessageBox.Show("Preencha todos os campos");

                
            }
            else
            {
                bool existeFuncionario = controlador.ExisteFuncionario(usuario, senha);

                if (existeFuncionario == true)
                {
                    Dashboard tela = new Dashboard();
                    this.Hide();
                    tela.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Campos inválidos, por favor tente novamente");
                }

                txbUsuario.Text = "";
                txbSenha.Text = "";
            }
        }
    }
}
