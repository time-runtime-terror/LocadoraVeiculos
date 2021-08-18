using LocadoraVeiculos.WindowsApp;
using LocadoraVeiculos.Dominio.FuncionarioModule;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LocadoraVeiculos.WindowsApp.Features.FuncionarioModule
{
    public partial class TelaCadastrarFuncionario : Form
    {
        private Funcionario funcionario;
        public TelaCadastrarFuncionario()
        {
            InitializeComponent();
        }

        public Funcionario Funcionario
        {
            get { return funcionario; }

            set
            {
                funcionario = value;

                txtId.Text = funcionario.Id.ToString();
                txtNome.Text = funcionario.Nome;
                txtUsuario.Text = funcionario.NomeUsuario;
                txtSenha.Text = funcionario.Senha;
                dtDateAdmissao.Value = funcionario.DataEntrada;
                txtSalario.Text = funcionario.Salario;
               
            }
        }

        private void btnGravar_Click(object sender, EventArgs e)
        {
            string nome = txtNome.Text;
            string nomeUsuario = txtUsuario.Text;
            string senha = txtSenha.Text;
            DateTime dataEntrada = dtDateAdmissao.Value;
            string salario = txtSalario.Text;
            

            funcionario = new Funcionario(nome, nomeUsuario, senha, dataEntrada, salario);

            string resultadoValidacao = funcionario.Validar();

            if (resultadoValidacao != "ESTA_VALIDO")
            {
                string primeiroErro = new StringReader(resultadoValidacao).ReadLine();

                Dashboard.Instancia.AtualizarRodape(primeiroErro);

                DialogResult = DialogResult.None;
            }
        }

        private void TelaCadastrarFuncionario_FormClosing(object sender, FormClosingEventArgs e)
        {
            Dashboard.Instancia.AtualizarRodape("");
        }

        private void txtSalario_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(txtSalario.Text, "[^0-9]"))
            {
                Dashboard.Instancia.AtualizarRodape("Salario: Por favor, digite apenas números");
                txtSalario.Text = txtSalario.Text.Remove(txtSalario.Text.Length - 1);
            }
        }
    }
}
