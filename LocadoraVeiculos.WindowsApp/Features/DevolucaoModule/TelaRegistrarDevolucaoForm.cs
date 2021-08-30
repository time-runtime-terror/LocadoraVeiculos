using LocadoraVeiculos.Controladores.CombustivelModule;
using LocadoraVeiculos.Dominio.CombustivelModule;
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
        
        private ControladorCombustivel controladorCombustivel;

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

            controladorCombustivel = new ControladorCombustivel();
        }

        private void TelaRegistrarDevolucaoForm_Load(object sender, EventArgs e)
        {
            dateDataDevolucao.MinDate =  DateTime.Today;
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



            if(rdbCheio.Checked  || rdbTresQuartos.Checked || rdbMeio.Checked || rdbUmQuarto.Checked || rdbVazio.Checked)
            {
                pnlMedidasTanque.Enabled = false;
                btHabilitarMedidas.Enabled = true;

                double valorCombustivelAPagar = CalcularCombustivelAPagar();
                double valorTaxas = CalcularValorDasTaxas(taxasSelecionadas);
                double valorPlano = CalcularValorDoPlano();

                double valorTotal = valorTaxas + valorPlano + valorCombustivelAPagar;

                Dashboard.Instancia.AtualizarRodape("Cadastro de Locações");

                lblValorTotal.Text = valorTotal.ToString();

                btnGravar.Enabled = true;
            }
            else
            {
                Dashboard.Instancia.AtualizarRodape("Por favor selecione a quantidade do combustível no carro.");
            }
           
        }

        private void btnSelecionarTaxas_Click(object sender, EventArgs e)
        {
            btnGravar.Enabled = false;
            TelaSelecaoTaxasForm tela = new TelaSelecaoTaxasForm(taxasSelecionadas, "Devolução");

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
            double total =0;

            double diasPassados = (dateDataDevolucao.Value - locacao.DataSaida.Date).TotalDays + 1;

            if (taxasSelecionadas != null)
                if (taxasSelecionadas.Count != 0)
                    foreach (var item in taxasSelecionadas)
                    {
                        if (item.OpcaoServico == "Diário")
                            total += item.Taxa * diasPassados;
                        else if(item.OpcaoServico == "Fixo")
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


        private double CalcularCombustivelAPagar()
        {

            double valorCombustivel = PegarValorCombustivel(), valorAPagar = 0, medidaTanque, tamanhoTanque, litrosQueFaltam;

            if (rdbCheio.Checked)
            {

                valorAPagar = 0;

                

            }
            if (rdbTresQuartos.Checked)
            {
                //pegar o tamanho do tanque
                tamanhoTanque = locacao.Veiculo.CapacidadeTanque;

                //fazer o calculo do de tres quartos pela capacidade do tanque
                medidaTanque = tamanhoTanque * 0.75;

                //diminuir o tres quartos do tanque pela capacidade do tanque
                litrosQueFaltam = tamanhoTanque - medidaTanque;

                //pegar o valor ad subtração feita, e multiplicar pelo tipo de combustivel
                valorAPagar = litrosQueFaltam * valorCombustivel;

               

            }
            if (rdbMeio.Checked)
            {
                //pegar o tamanho do tanque
                tamanhoTanque = locacao.Veiculo.CapacidadeTanque;

                //fazer o calculo do meio pela capacidade do tanque
                medidaTanque = tamanhoTanque * 0.5;

                //diminuir o meio pela capacidade do tanque
                litrosQueFaltam = tamanhoTanque - medidaTanque;

                //pegar o valor ad subtração feita, e multiplicar pelo tipo de combustivel
                valorAPagar = litrosQueFaltam * valorCombustivel;

               

            }
            if (rdbUmQuarto.Checked)
            {
                //pegar o tamanho do tanque
                tamanhoTanque = locacao.Veiculo.CapacidadeTanque;

                //fazer o calculo de 1/4 pela capacidade do tanque
                medidaTanque = tamanhoTanque * 0.25;

                //diminuir o 1/4 pela capacidade do tanque
                litrosQueFaltam = tamanhoTanque - medidaTanque;

                //pegar o valor ad subtração feita, e multiplicar pelo tipo de combustivel
                valorAPagar = litrosQueFaltam * valorCombustivel;

               

            }

            if (rdbVazio.Checked)
            {
                //pegar o tamanho do tanque
                tamanhoTanque = locacao.Veiculo.CapacidadeTanque;
                valorAPagar = tamanhoTanque * valorCombustivel;

                
            }

            

           

            return valorAPagar;
        }



        private double PegarValorCombustivel()
        {
            double valorCombustivel = 0;

            switch (locacao.Veiculo.TipoCombustivel)
            {
                case "Gasolina":
                    valorCombustivel = Convert.ToDouble(controladorCombustivel.PegarValorGasolina());
                    break;
                case "Etanol":
                    valorCombustivel = Convert.ToDouble(controladorCombustivel.PegarValorEtanol());
                    break;
                case "Diesel":
                    valorCombustivel = Convert.ToDouble(controladorCombustivel.PegarValorDiesel());
                    break;
                case "Gnv":
                    valorCombustivel = Convert.ToDouble(controladorCombustivel.PegarValorGnv());
                    break;
            }

            return valorCombustivel;
        }

        private void btHabilitarMedidas_Click(object sender, EventArgs e)
        {
            //hablitar as medidas
            pnlMedidasTanque.Enabled = true;

            //desabilitar o calcularin
            btnGravar.Enabled = false;
        }

       
    }
}
