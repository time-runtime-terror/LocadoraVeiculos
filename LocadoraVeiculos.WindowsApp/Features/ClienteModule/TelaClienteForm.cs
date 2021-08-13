using LocadoraVeiculos.Controladores.ClienteModule;
using LocadoraVeiculos.Dominio.ClienteModule;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace LocadoraVeiculos.WindowsApp.Features.ClienteModule
{
    public partial class TelaClienteForm : Form
    {
        private Cliente cliente;
        private readonly ControladorCliente controladorCliente;

        public TelaClienteForm()
        {
            InitializeComponent();
            controladorCliente = new ControladorCliente();
        }

        public Cliente Cliente
        {
            get => cliente;

            set
            {
                cliente = value;

                txtId.Text = cliente.Id.ToString();

                txtNome.Text = cliente.Nome;
                txtEndereco.Text = cliente.Endereco;
                txtTelefone.Text = cliente.Telefone;
                txtDocumento.Text = cliente.NumeroCadastro;
                txtRg.Text = cliente.RG;
                txtCNH.Text = cliente.CNH;
                txtVencimentoCnh.Text = cliente.VencimentoCnh.ToString();

                cmbEmpresa.SelectedItem = (cliente.Empresa != null
                    && cmbEmpresa.Items.Contains(cliente.Empresa.Nome)) ? cliente.Empresa.Nome : null;

                if (cliente.TipoCadastro == "CNPJ")
                    rdbPessoaJuridica.Checked = true;
                else
                    rdbPessoaFisica.Checked = true;
            }
        }

        private void btnGravar_Click(object sender, EventArgs e)
        {
            string tipoPessoa = (rdbPessoaFisica.Checked) ? "CPF" : "CNPJ";

            DateTime? vencimentoCnh = 
                (gbCadastroFisico.Enabled == false) ? DateTime.Now : Convert.ToDateTime(txtVencimentoCnh.Text);

            List<Cliente> listaEmpresas = controladorCliente.SelecionarTodos();

            Cliente empresa = listaEmpresas.Find(x => x.TipoCadastro == "CNPJ" && x.Nome == (string)cmbEmpresa.SelectedItem);

            cliente = new Cliente(txtNome.Text, txtEndereco.Text, txtTelefone.Text, tipoPessoa, txtCNH.Text, vencimentoCnh, txtDocumento.Text, txtRg.Text, empresa);

            string resultadoValidacao = cliente.Validar();

            if (resultadoValidacao != "ESTA_VALIDO")
            {
                MessageBox.Show(resultadoValidacao, "Erro ao Cadastrar", MessageBoxButtons.OK, MessageBoxIcon.Error);

                DialogResult = DialogResult.None;
            }
        }

        private void rdbPessoaJuridica_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void rdbPessoaFisica_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbPessoaFisica.Checked)
                gbCadastroFisico.Enabled = true;
            else
                gbCadastroFisico.Enabled = false;
        }

        private void TelaClienteForm_Load(object sender, EventArgs e)
        {
            var clientes = controladorCliente.SelecionarTodos().FindAll(x => x.TipoCadastro == "CNPJ");

            foreach (var cliente in clientes)
            {
                cmbEmpresa.Items.Add(cliente.Nome);
            }
        }
    }
}
