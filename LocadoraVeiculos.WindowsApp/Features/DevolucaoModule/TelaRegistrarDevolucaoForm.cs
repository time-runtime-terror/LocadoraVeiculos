using LocadoraVeiculos.Dominio.LocacaoModule;
using LocadoraVeiculos.Dominio.TaxasServicosModule;
using LocadoraVeiculos.WindowsApp.Features.LocacaoModule;
using System;
using System.Collections.Generic;
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

                lblIdLocacao.Text = locacao.Id.ToString();

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
        }

        private void btnSelecionarTaxas_Click(object sender, EventArgs e)
        {
            TelaSelecaoTaxasForm tela = new TelaSelecaoTaxasForm();

            if (tela.ShowDialog() == DialogResult.OK)
            {
                taxasSelecionadas = tela.TaxasSelecionadas;

                listaTaxasServicos.Items.Clear();

                if (taxasSelecionadas != null)
                {
                    foreach (var taxa in taxasSelecionadas)
                        listaTaxasServicos.Items.Add(taxa);

                    CalcularValorTotal(taxasSelecionadas);
                }
            }
        }
        private void CalcularValorTotal(List<TaxasServicos> taxasSelecionadas)
        {
            double total = 0;

            double diasPassados = (dateDataDevolucao.Value - locacao.DataSaida.Date).TotalDays;

            foreach (var item in taxasSelecionadas)
            {
                if (item.OpcaoServico == "Diário")
                    total += item.Taxa * diasPassados;
                else
                    total += item.Taxa;
            }

            if (dateDataDevolucao.Value > locacao.DataDevolucao)
                total += (10 / 100) * total;
                
            lblValorTotal.Text = total.ToString();
        }

        private void btnGravar_Click(object sender, EventArgs e)
        {

        }
    }
}
