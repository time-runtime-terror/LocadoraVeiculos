using LocadoraVeiculos.Controladores.ClienteModule;
using LocadoraVeiculos.Controladores.TaxasServicosModule;
using LocadoraVeiculos.Controladores.VeiculoModule;
using LocadoraVeiculos.Dominio.ClienteModule;
using LocadoraVeiculos.Dominio.LocacaoModule;
using LocadoraVeiculos.Dominio.TaxasServicosModule;
using LocadoraVeiculos.Dominio.VeiculoModule;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace LocadoraVeiculos.WindowsApp.Features.LocacaoModule
{
    public partial class TelaCadastrarLocacaoForm : Form
    {
        private readonly ControladorTaxasServicos controladorTaxasServicos;
        private readonly ControladorCliente controladorCliente;
        private readonly ControladorVeiculo controladorVeiculo;

        private Locacao locacao;

        public Locacao Locacao
        {
            get => locacao;

            set
            {
                locacao = value;

                txtId.Text = locacao.Id.ToString();

                cmbCliente.SelectedItem = (cmbCliente.Items.Contains(locacao.Cliente)) ?
                    locacao.Cliente : null;

                cmbVeiculo.SelectedItem = (cmbVeiculo.Items.Contains(locacao.Veiculo)) ? locacao.Veiculo : null;

                cmbPlano.SelectedItem = (cmbPlano.Items.Contains(locacao.Plano)) ?
                    locacao.Plano : null;

                txtCaucao.Text = locacao.Caucao.ToString();

                List<TaxasServicos> taxasUtilizdas = controladorTaxasServicos.SelecionarTaxasServicosUsados(locacao.Id);

                foreach (var taxa in taxasUtilizdas)
                    listaTaxasServicos.Items.Add(taxa);
            }
        }

        public TelaCadastrarLocacaoForm()
        {
            InitializeComponent();
            controladorTaxasServicos = new ControladorTaxasServicos();
            controladorCliente = new ControladorCliente();
            controladorVeiculo = new ControladorVeiculo();
        }

        private void TelaCadastrarLocacaoForm_Load(object sender, EventArgs e)
        {
            foreach (var taxa in controladorTaxasServicos.SelecionarTodos())
                listaTaxasServicos.Items.Add(taxa);

            List<Cliente> clientes = controladorCliente.SelecionarTodos();

            foreach (var c in clientes)
                cmbCliente.Items.Add(c);

            List<Veiculo> veiculos = controladorVeiculo.SelecionarTodos();

            foreach (var v in veiculos)
                cmbVeiculo.Items.Add(v);

        }

        private void cmbCliente_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<Cliente> clientes = controladorCliente.SelecionarTodos();

            Cliente cliente = (Cliente)cmbCliente.SelectedItem;

            if (cliente.TipoCadastro == "CNPJ")
            {
                cmbCondutor.Enabled = true;
                foreach (var c in clientes)
                    if (c.TipoCadastro == "CPF" && c.Empresa.Nome == cliente.Nome)
                        cmbCondutor.Items.Add(c);
            }
            else
            {
                cmbCondutor.Enabled = false;
                cmbCondutor.Items.Clear();
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void listaTaxasServicos_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            List<TaxasServicos> taxasSelecionadas = new List<TaxasServicos>();

            foreach (var item in listaTaxasServicos.CheckedItems)
                taxasSelecionadas.Add((TaxasServicos)item);

            if (e.NewValue == CheckState.Checked)
                taxasSelecionadas.Add((TaxasServicos)listaTaxasServicos.Items[e.Index]);

            else
                taxasSelecionadas.Remove((TaxasServicos)listaTaxasServicos.Items[e.Index]);

            CalcularValorTotal(taxasSelecionadas);
        }

        private void CalcularValorTotal(List<TaxasServicos> taxasSelecionadas)
        {
            string strCaucao = txtCaucao.Text;
            double caucao, total = 0;

            if (string.IsNullOrEmpty(strCaucao))
                caucao = 0;
            else
                caucao = Convert.ToDouble(strCaucao);

            foreach (var item in taxasSelecionadas)
                total += item.Taxa;

            total += caucao;

            lblValorTotal.Text = total.ToString();
        }

        private void btnGravar_Click(object sender, EventArgs e)
        {

        }
    }
}
