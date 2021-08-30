using LocadoraVeiculos.Controladores.ClienteModule;
using LocadoraVeiculos.Controladores.LocacaoModule;
using LocadoraVeiculos.Controladores.TaxasServicosModule;
using LocadoraVeiculos.Controladores.VeiculoModule;
using LocadoraVeiculos.Dominio.ClienteModule;
using LocadoraVeiculos.Dominio.LocacaoModule;
using LocadoraVeiculos.Dominio.TaxasServicosModule;
using LocadoraVeiculos.Dominio.VeiculoModule;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace LocadoraVeiculos.WindowsApp.Features.LocacaoModule
{
    public partial class TelaCadastrarLocacaoForm : Form
    {
        private readonly ControladorTaxasServicos controladorTaxasServicos;
        private readonly ControladorCliente controladorCliente;
        private readonly ControladorVeiculo controladorVeiculo;
        private readonly ControladorLocacao controladorLocacao;

        private List<TaxasServicos> taxasSelecionadas;

        private Locacao locacao;
        public Locacao Locacao
        {
            get => locacao;

            set
            {
                locacao = value;

                txtId.Text = locacao.Id.ToString();

                cmbPlano.SelectedItem = (cmbPlano.Items.Contains(locacao.Plano)) ?
                    locacao.Plano : null;

                txtValorEntrada.Text = locacao.Caucao.ToString();

                dateDataSaida.Value = locacao.DataSaida;

                dateDataDevolucao.Value = locacao.DataDevolucao;

                taxasSelecionadas = locacao.Taxas;

                if (taxasSelecionadas != null)
                    foreach (var taxa in taxasSelecionadas)
                        if (!listaTaxasServicos.Items.Contains(taxa))
                            listaTaxasServicos.Items.Add(taxa);

                DesabilitarBotoesParaEdicao();

                CalcularValorTotal(taxasSelecionadas);

                btnGravar.Enabled = true;
            }
        }

        public TelaCadastrarLocacaoForm()
        {
            InitializeComponent();
            controladorTaxasServicos = new ControladorTaxasServicos();
            controladorCliente = new ControladorCliente();
            controladorVeiculo = new ControladorVeiculo();
            controladorLocacao = new ControladorLocacao(controladorCliente, controladorVeiculo, controladorTaxasServicos);
        }

        #region Eventos
        private void TelaCadastrarLocacaoForm_Load(object sender, EventArgs e)
        {
            List<Cliente> clientes = controladorCliente.SelecionarTodos();

            foreach (var c in clientes)
                cmbCliente.Items.Add(c);

            List<Veiculo> veiculosDisponiveis = ObterVeiculosDisponiveis();

            if (veiculosDisponiveis != null)
                foreach (var v in veiculosDisponiveis)
                    cmbVeiculo.Items.Add(v);

            CarregarCmbClientes();

            CarregarCmbVeiculos();

            dateDataDevolucao.MinDate = DateTime.Now;
        }


        private void btnGravar_Click(object sender, EventArgs e)
        {
            VerificarDisponibilidadeDeVeiculo();

            locacao = ObterLocacao();

            string resultadoValidacao = locacao.Validar();

            if (resultadoValidacao != "ESTA_VALIDO")
            {
                string primeiroErro = new StringReader(resultadoValidacao).ReadLine();

                Dashboard.Instancia.AtualizarRodape(primeiroErro);

                DialogResult = DialogResult.None;
            }

        }

        private void btnCalcularTotal_Click(object sender, EventArgs e)
        {
            CalcularValorTotal(taxasSelecionadas);

            btnGravar.Enabled = true;
        }

        private void cmbCliente_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<Cliente> clientes = controladorCliente.SelecionarTodos();

            Cliente cliente = (Cliente)cmbCliente.SelectedItem;

            string condutor = null;

            if (cliente.TipoCadastro == "CNPJ")
            {
                cmbCondutor.Enabled = true;
                foreach (var c in clientes)
                    if (c.Empresa != null && c.TipoCadastro == "CPF" && c.Empresa.Nome == cliente.Nome)
                        condutor = c.Nome;

                cmbCondutor.Items.Add(condutor);
            }
            else
            {
                cmbCondutor.Enabled = false;
                cmbCondutor.Items.Clear();
            }
        }

        private void txtValorEntrada_Enter(object sender, EventArgs e)
        {
            btnGravar.Enabled = false;
        }

        private void txtCaucao_TextChanged(object sender, EventArgs e)
        {
            if (Regex.IsMatch(txtValorEntrada.Text, "[^0-9]"))
            {
                Dashboard.Instancia.AtualizarRodape("Valor de Entrada: Por favor, apenas números.");
                txtValorEntrada.Text = txtValorEntrada.Text.Remove(txtValorEntrada.Text.Length - 1);
            }
        }

        private void btnSelecionarTaxas_Click(object sender, EventArgs e)
        {
            btnGravar.Enabled = false;

            if(listaTaxasServicos.Items.Count!= 0)
                foreach (var item in listaTaxasServicos.Items)
                    taxasSelecionadas.Add((TaxasServicos)item);

            TelaSelecaoTaxasForm tela = new TelaSelecaoTaxasForm(taxasSelecionadas);

            if (tela.ShowDialog() == DialogResult.OK)
            {
                taxasSelecionadas = tela.TaxasSelecionadas;

                listaTaxasServicos.Items.Clear();
                if (taxasSelecionadas != null)
                    foreach (var taxa in taxasSelecionadas)
                        listaTaxasServicos.Items.Add(taxa);
            }
        }
        #endregion

        private List<Veiculo> ObterVeiculosDisponiveis()
        {
            List<Veiculo> veiculosDisponiveis = new List<Veiculo>();

            foreach (Veiculo v in controladorVeiculo.SelecionarTodos())
                if (!VeiculoEstaAlugado(v) && !veiculosDisponiveis.Contains(v))
                    veiculosDisponiveis.Add(v);

            return veiculosDisponiveis;
        }

        public bool VeiculoEstaAlugado(Veiculo v)
        {
            var locacoesPendentes = controladorLocacao.SelecionarTodasLocacoesPendentes();

            foreach (var l in locacoesPendentes)
                if (v.Id == l.Veiculo.Id)
                    return true;

            return false;
        }

        private Locacao ObterLocacao()
        {
            Cliente cliente = (Cliente)cmbCliente.SelectedItem;
            Veiculo veiculo = (Veiculo)cmbVeiculo.SelectedItem;

            string plano = (string)cmbPlano.SelectedItem;

            string condutor = null;
            if ((string)cmbCondutor.SelectedItem != null)
                condutor = (string)cmbCondutor.SelectedItem;

            string caucaoStr = txtValorEntrada.Text;

            double caucao;
            if (string.IsNullOrEmpty(caucaoStr))
                caucao = 0;
            else
                caucao = Convert.ToDouble(caucaoStr);

            DateTime dataSaida = dateDataSaida.Value;
            DateTime dataDevolucao = dateDataDevolucao.Value;

            List<TaxasServicos> taxasSelecionadas = ObterTaxasSelecionadas();

            string devolucao = "Pendente";

            return new Locacao(cliente, veiculo, taxasSelecionadas, dataSaida, dataDevolucao, caucao, plano, condutor, devolucao);
        }

        private List<TaxasServicos> ObterTaxasSelecionadas()
        {
            List<TaxasServicos> taxasSelecionadas = new List<TaxasServicos>();

            foreach (var item in listaTaxasServicos.Items)
                taxasSelecionadas.Add((TaxasServicos)item);

            return taxasSelecionadas;
        }

        private void VerificarDisponibilidadeDeVeiculo()
        {
            if (locacao != null)
                VerificarDisponibilidadeParaEdicao();

            else if ((Veiculo)cmbVeiculo.SelectedItem != null)
                VerificarDisponibilidadeParaCadastro();
        }

        private void VerificarDisponibilidadeParaEdicao()
        {
            
            foreach (var item in controladorLocacao.SelecionarTodos())
            {
                if (item.Id != locacao.Id && item.Devolucao == "Pendente")
                    if (item.Veiculo.Id == locacao.Veiculo.Id)
                    {
                        Dashboard.Instancia.AtualizarRodape($"O Veículo: [{locacao.Veiculo}] não está disponível para locação!");
                        DialogResult = DialogResult.None;
                    }
            }
        }

        private void VerificarDisponibilidadeParaCadastro()
        {
            Veiculo v = (Veiculo)cmbVeiculo.SelectedItem;
            foreach (var item in controladorLocacao.SelecionarTodasLocacoesPendentes())
            {
                if (item.Veiculo.Id == v.Id)
                {
                    Dashboard.Instancia.AtualizarRodape($"O Veículo: [{v}] não está disponível para locação!");
                    DialogResult = DialogResult.None;
                }
            }
        }

        private void CalcularValorTotal(List<TaxasServicos> taxasSelecionadas)
        {
            string strCaucao = txtValorEntrada.Text;
            double caucao, total = 0;

            if (string.IsNullOrEmpty(strCaucao))
                caucao = 0;
            else
                caucao = Convert.ToDouble(strCaucao);

            if (taxasSelecionadas != null)
                foreach (var item in taxasSelecionadas)
                    total += item.Taxa;

            total += caucao;

            lblValorTotal.Text = total.ToString();
        }

        private void DesabilitarBotoesParaEdicao()
        {
            cmbCliente.Enabled = false;
            cmbVeiculo.Enabled = false;
            cmbCondutor.Enabled = false;
            cmbPlano.Enabled = false;
            txtValorEntrada.Enabled = false;
            dateDataSaida.Enabled = false;
            btnSelecionarTaxas.Enabled = false;
            btnCalcularTotal.Enabled = false;
        }

        private void CarregarCmbClientes()
        {
            if (locacao != null)
            {
                cmbCliente.SelectedItem = locacao.Cliente;

                if (locacao.Cliente.TipoCadastro == "CNPJ")
                {
                    cmbCondutor.Enabled = true;
                    cmbCondutor.SelectedItem = locacao.Condutor;
                }
                else
                    cmbCondutor.Enabled = false;
            }
        }

        private void CarregarCmbVeiculos()
        {
            if (locacao != null)
                cmbVeiculo.SelectedItem = locacao.Veiculo;
        }
    }
}
