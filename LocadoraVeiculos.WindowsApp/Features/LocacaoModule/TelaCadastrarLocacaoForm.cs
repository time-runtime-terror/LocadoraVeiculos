using LocadoraVeiculos.Aplicacao.ClienteModule;
using LocadoraVeiculos.Aplicacao.LocacaoModule;
using LocadoraVeiculos.Aplicacao.TaxasServicosModule;
using LocadoraVeiculos.Aplicacao.VeiculosModule;
using LocadoraVeiculos.Infra.InternetServices.LocacaoModule;
using LocadoraVeiculos.Infra.PDF.LocacaoModule;
using LocadoraVeiculos.Infra.SQL.ClienteModule;
using LocadoraVeiculos.Infra.SQL.GrupoAutomoveisModule;
using LocadoraVeiculos.Infra.SQL.LocacaoModule;
using LocadoraVeiculos.Infra.SQL.TaxasServicosModule;
using LocadoraVeiculos.Infra.SQL.VeiculosModule;
using LocadoraVeiculos.netCore.Dominio.ClienteModule;
using LocadoraVeiculos.netCore.Dominio.LocacaoModule;
using LocadoraVeiculos.netCore.Dominio.TaxasServicosModule;
using LocadoraVeiculos.netCore.Dominio.VeiculoModule;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace LocadoraVeiculos.WindowsApp.Features.LocacaoModule
{
    public partial class TelaCadastrarLocacaoForm : Form
    {
        private readonly TaxasServicosAppService taxasService;
        private readonly ClienteAppService clienteService;
        private readonly VeiculoAppService veiculoService;
        private readonly LocacaoAppService locacaoService;

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

                taxasSelecionadas = locacao.Taxas as List<TaxasServicos>;

                if (taxasSelecionadas != null)
                    foreach (var taxa in taxasSelecionadas)
                        if (!listaTaxasServicos.Items.Contains(taxa))
                            listaTaxasServicos.Items.Add(taxa);

                DesabilitarBotoesParaEdicao();

                CarregarCmbVeiculos();

                CalcularValorTotal(taxasSelecionadas);

                btnCalcularTotal.Enabled = true;

                btnGravar.Enabled = true;
            }
        }

        public TelaCadastrarLocacaoForm()
        {
            InitializeComponent();

            ClienteDAO clienteRepository = new ClienteDAO();
            VeiculosDAO veiculoRepository = new VeiculosDAO(new GrupoAutomoveisDAO());
            TaxasServicosDAO taxaRepository = new TaxasServicosDAO();

            clienteService = new ClienteAppService(clienteRepository);
            veiculoService = new VeiculoAppService(veiculoRepository);
            taxasService = new TaxasServicosAppService(taxaRepository);

            LocacaoDAO locacaoRepository = new LocacaoDAO(clienteRepository, veiculoRepository, taxaRepository);

            locacaoService = new LocacaoAppService(locacaoRepository, new GeradorRecibo(), new NotificadorEmail(), new VerificadorConexao());
        }

        #region Eventos
        private void TelaCadastrarLocacaoForm_Load(object sender, EventArgs e)
        {
            dateDataSaida.MaxDate = dateDataDevolucao.Value;

            List<Cliente> clientes = clienteService.SelecionarTodos();

            foreach (var c in clientes)
                cmbCliente.Items.Add(c);

            List<Veiculo> veiculosDisponiveis = ObterVeiculosDisponiveis();

            if (veiculosDisponiveis != null)
                foreach (var v in veiculosDisponiveis)
                    cmbVeiculo.Items.Add(v);

            CarregarCmbClientes();

            //CarregarCmbVeiculos();

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
            List<Cliente> clientes = clienteService.SelecionarTodos();

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

            string localTaxa = "Locação";
            TelaSelecaoTaxasForm tela = new TelaSelecaoTaxasForm(taxasSelecionadas, localTaxa);

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

            foreach (Veiculo v in veiculoService.SelecionarTodos())
                if (!VeiculoEstaAlugado(v) && !veiculosDisponiveis.Contains(v))
                    veiculosDisponiveis.Add(v);

            return veiculosDisponiveis;
        }

        public bool VeiculoEstaAlugado(Veiculo v)
        {
            var locacoesPendentes = locacaoService.SelecionarTodasLocacoesPendentes();

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
            
            foreach (var item in locacaoService.SelecionarTodos())
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
            foreach (var item in locacaoService.SelecionarTodasLocacoesPendentes())
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
            double diasPassados = (dateDataDevolucao.Value - dateDataSaida.Value).TotalDays + 1;

            if (string.IsNullOrEmpty(strCaucao))
                caucao = 0;
            else
                caucao = Convert.ToDouble(strCaucao);

            if (taxasSelecionadas != null)
                foreach (var item in taxasSelecionadas)
                {
                    if (item.OpcaoServico == "Diário")
                        total += item.Taxa * diasPassados;
                    else if (item.OpcaoServico == "Fixo")
                        total += item.Taxa;
                }

            total += caucao;

            total += CalcularValorDoPlano();

            lblValorTotal.Text = total.ToString();
        }

        private double CalcularValorDoPlano()
        {
            double total = 0;

            double diasPassados = (dateDataDevolucao.Value.Date - dateDataSaida.Value.Date).TotalDays + 1;

            string plano = (string)cmbPlano.SelectedItem;

           Veiculo veiculo =  (Veiculo) cmbVeiculo.SelectedItem;

            switch (plano)
            {
                case "Plano Diário":
                    double valorPordia = veiculo.GrupoAutomoveis.PlanoDiarioUm * diasPassados;
                    total = valorPordia;

                    break;

                case "Km Controlado":
                    double valorPorDia = veiculo.GrupoAutomoveis.KmControladoUm * diasPassados;

                    //pagar pelo menos um dia
                    total = valorPorDia;

                    break;

                case "Km Livre":
                    
                    total = veiculo.GrupoAutomoveis.KmLivreUm * diasPassados;
                    break;
            }

            return total;
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
            {
                cmbVeiculo.Items.Add(locacao.Veiculo);
                cmbVeiculo.SelectedItem = locacao.Veiculo;
                
            }
        }


        private void dateDataSaida_ValueChanged(object sender, EventArgs e)
        {
            btnGravar.Enabled = false;
        }

        private void dateDataDevolucao_ValueChanged(object sender, EventArgs e)
        {
            btnGravar.Enabled = false;
            dateDataSaida.MaxDate = dateDataDevolucao.Value;
        }

        private void cmbVeiculo_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnGravar.Enabled = false;
        }

        private void cmbPlano_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnGravar.Enabled = false;
        }
    }
}
