using LocadoraVeiculos.Controladores.ClienteModule;
using LocadoraVeiculos.Dominio.ClienteModule;
using System;
using System.Collections.Generic;
using System.IO;
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
                dateVencimentoCnh.Value = (DateTime)cliente.VencimentoCnh;

                if (cliente.TipoCadastro == "CNPJ")
                    rdbPessoaJuridica.Checked = true;
                else
                    rdbPessoaFisica.Checked = true;
            }
        }

        private void btnGravar_Click(object sender, EventArgs e)
        {
            string tipoPessoa = (rdbPessoaFisica.Checked) ? "CPF" : "CNPJ";

            DateTime? vencimentoCnh = dateVencimentoCnh.Value;

            List<Cliente> listaEmpresas = controladorCliente.SelecionarTodos();

            Cliente empresa = listaEmpresas.Find(x => x.TipoCadastro == "CNPJ" && x.Nome == (string)cmbEmpresa.SelectedItem);

            cliente = new Cliente(txtNome.Text, txtEndereco.Text, txtTelefone.Text, tipoPessoa, txtCNH.Text, vencimentoCnh, txtDocumento.Text, txtRg.Text, empresa);

            string resultadoValidacao = cliente.Validar();

            if (resultadoValidacao != "ESTA_VALIDO")
            {
                string primeiroErro = new StringReader(resultadoValidacao).ReadLine();

                Dashboard.Instancia.AtualizarRodape(primeiroErro);

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

            if (cliente != null)
                cmbEmpresa.SelectedItem = (cliente.Empresa != null
                    && cmbEmpresa.Items.Contains(cliente.Empresa.Nome)) ? cliente.Empresa.Nome : null;
        }

        private void txtDocumento_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(txtDocumento.Text, "[^0-9]"))
            {
                Dashboard.Instancia.AtualizarRodape("Documento: Por favor digite apenas números!");
                txtDocumento.Text = txtDocumento.Text.Remove(txtDocumento.Text.Length - 1);
            }
        }

        private void txtRg_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(txtRg.Text, "[^0-9]"))
            {
                Dashboard.Instancia.AtualizarRodape("RG: Por favor digite apenas números!");
                txtRg.Text = txtRg.Text.Remove(txtRg.Text.Length - 1);
            }
        }

        private void txtCNH_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(txtCNH.Text, "[^0-9]"))
            {
                Dashboard.Instancia.AtualizarRodape("CNH: Por favor digite apenas números!");
                txtCNH.Text = txtCNH.Text.Remove(txtCNH.Text.Length - 1);
            }
        }

        private void TelaClienteForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Dashboard.Instancia.AtualizarRodape("Cadastro de Clientes");
        }
    }
}
