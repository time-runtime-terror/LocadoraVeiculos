using LocadoraVeiculos.Dominio.LocacaoModule;
using LocadoraVeiculos.Dominio.TaxasServicosModule;
using LocadoraVeiculos.WindowsApp.Features.LocacaoModule;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace LocadoraVeiculos.WindowsApp.Features.DevolucaoModule
{
    public partial class TelaRegistrarDevolucaoForm : Form
    {
        private List<TaxasServicos> taxasSelecionadas;

        private Locacao locacao;

        public Locacao Locacao
        {
            get => locacao;

            set
            {
                locacao = value;

                txtIdLocacao.Text = locacao.Id.ToString();

                lblNomeCliente.Text = locacao.Cliente.Nome;
                lblModeloVeiculo.Text = locacao.Veiculo.Modelo;
                lblNomePlano.Text = locacao.Plano;
                lblEntrada.Text = locacao.Caucao.ToString();

                taxasSelecionadas = locacao.Taxas;

                if (taxasSelecionadas != null)
                    foreach (var taxa in taxasSelecionadas)
                        if (!listaTaxasServicos.Items.Contains(taxa))
                            listaTaxasServicos.Items.Add(taxa);

                

                
            }
        }

        public TelaRegistrarDevolucaoForm()
        {
            InitializeComponent();
        }

        private void TelaRegistrarDevolucaoForm_Load(object sender, EventArgs e)
        {
            dateDataDevolucao.Value = DateTime.Today;
            txbQuilometragemAtual.Minimum = locacao.Veiculo.Quilometragem;
            
        }

        private void btnGravar_Click(object sender, EventArgs e)
        {
            locacao.Taxas = taxasSelecionadas;
            locacao.Devolucao = dateDataDevolucao.Value.ToShortDateString();
        }

        private void btnCalcularTotal_Click(object sender, EventArgs e)
        {
            lblValorTotal.Text = (CalcularValorDasTaxas(taxasSelecionadas) + CalcularValorDoPlano()).ToString();

            btnGravar.Enabled = true;
        }

        private void btnSelecionarTaxas_Click(object sender, EventArgs e)
        {
            TelaSelecaoTaxasForm tela = new TelaSelecaoTaxasForm();

            if (tela.ShowDialog() == DialogResult.OK)
            {
                taxasSelecionadas = tela.TaxasSelecionadas;

                listaTaxasServicos.Items.Clear();

                if (taxasSelecionadas != null)
                    foreach (var taxa in taxasSelecionadas)
                        listaTaxasServicos.Items.Add(taxa);
            }
        }

        private double CalcularValorDasTaxas(List<TaxasServicos> taxasSelecionadas)
        {
            double total = 0;

            double diasPassados = (dateDataDevolucao.Value - locacao.DataSaida.Date).TotalDays;

            if (taxasSelecionadas != null)
                if (taxasSelecionadas.Count != 0)
                    foreach (var item in taxasSelecionadas)
                    {
                        if (item.OpcaoServico == "Diário")
                            total += item.Taxa * diasPassados;
                        else
                            total += item.Taxa;
                    }

            if (dateDataDevolucao.Value > locacao.DataDevolucao)
                total += (10 / 100) * total;

            return total;
        }

        private double CalcularValorDoPlano()
        {
            double total = 0;

            double diasPassados = (dateDataDevolucao.Value - locacao.DataSaida.Date).TotalDays + 1;

            

            double kmAtual = PegaQuilometragemAtual();

            
            
            switch (locacao.Plano)
            {
                case "Plano Diário":
                    double valorPordia = locacao.Veiculo.GrupoAutomoveis.PlanoDiarioUm * diasPassados ;
                    double kmRodado = (kmAtual - locacao.Veiculo.Quilometragem);
                    double valorPorKm = kmRodado * locacao.Veiculo.GrupoAutomoveis.PlanoDiarioDois;
                    total = valorPordia + valorPorKm;
                    break;

                case "Km Controlado":
                    double valorPorDia = locacao.Veiculo.GrupoAutomoveis.KmControladoUm * diasPassados;
                    double quilometragem = locacao.Veiculo.Quilometragem;
                    double descontoNafaixa = locacao.Veiculo.GrupoAutomoveis.KmControladoIncluida;
                    double valorPorKmRodado = locacao.Veiculo.GrupoAutomoveis.KmControladoDois;
                    double kmVeiculoMaisDeconto = quilometragem + descontoNafaixa;
                    double valorTotalKmRodado = (kmAtual - kmVeiculoMaisDeconto) * valorPorKmRodado;
                    

                    // nao deixar se negativo, quando a soma da quilometragem mais o desconto na faixa, ser maior que a kmatual
                    if (kmVeiculoMaisDeconto > kmAtual)
                    {
                        valorTotalKmRodado = 0;
                    }

                    //pagar pelo menos um dia
                    total = valorTotalKmRodado + valorPorDia;

                    break;

                case "Km Livre":
                    total = locacao.Veiculo.GrupoAutomoveis.KmLivreUm * diasPassados;
                    break;
            }

            return total;
        }

        private double PegaQuilometragemAtual()
        {
            double kmAtual = Convert.ToDouble(txbQuilometragemAtual.Text);

           
            return kmAtual;
        }

        private void txbQuilometragemAtual_TextChanged(object sender, EventArgs e)
        {
            if (Regex.IsMatch(txbQuilometragemAtual.Text, "[^0-9]"))
            {
                Dashboard.Instancia.AtualizarRodape("Quilometragem do veículo: Por favor, apenas números.");
                txbQuilometragemAtual.Text = txbQuilometragemAtual.Text.Remove(txbQuilometragemAtual.Text.Length - 1);
            }
        }
    }
}
