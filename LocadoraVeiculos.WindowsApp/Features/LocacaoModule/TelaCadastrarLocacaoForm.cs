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

        private void TelaCadastrarLocacaoForm_Load(object sender, EventArgs e)
        {
            //foreach (var taxa in controladorTaxasServicos.SelecionarTodos())
            //    listaTaxasServicos.Items.Add(taxa);


            List<Cliente> clientes = controladorCliente.SelecionarTodos();

            foreach (var c in clientes)
                cmbCliente.Items.Add(c);

            List<Veiculo> veiculos = controladorVeiculo.SelecionarTodos();

            foreach (var v in veiculos)
                cmbVeiculo.Items.Add(v);

            CarregarCmbClientes();

            CarregarCmbVeiculos();
            
        }

        private void CarregarCmbClientes()
        {
           if(locacao != null)
            {
                cmbCliente.SelectedItem = locacao.Cliente;
                   
                    
            }
        }

        private void CarregarCmbVeiculos()
        {
            if (locacao != null)
            {
                cmbVeiculo.SelectedItem = locacao.Veiculo;

            }
        }

        private void cmbCliente_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<Cliente> clientes = controladorCliente.SelecionarTodos();

            Cliente cliente = (Cliente)cmbCliente.SelectedItem;

            if (cliente.TipoCadastro == "CNPJ")
            {
                cmbCondutor.Enabled = true;
                foreach (var c in clientes)
                    if (c.Empresa != null && c.TipoCadastro == "CPF" && c.Empresa.Nome == cliente.Nome)
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

        //private void listaTaxasServicos_ItemCheck(object sender, ItemCheckEventArgs e)
        //{
        //    List<TaxasServicos> taxasSelecionadas = new List<TaxasServicos>();

        //    foreach (var item in listaTaxasServicos.CheckedItems)
        //        taxasSelecionadas.Add((TaxasServicos)item);

        //    if (e.NewValue == CheckState.Checked)
        //        taxasSelecionadas.Add((TaxasServicos)listaTaxasServicos.Items[e.Index]);

        //    else
        //        taxasSelecionadas.Remove((TaxasServicos)listaTaxasServicos.Items[e.Index]);

        //    CalcularValorTotal(taxasSelecionadas);
        //}


        private void btnGravar_Click(object sender, EventArgs e)
        {
            Cliente cliente = (Cliente)cmbCliente.SelectedItem;
            Veiculo veiculo = (Veiculo)cmbVeiculo.SelectedItem;

            string plano = (string)cmbPlano.SelectedItem;

            string caucaoStr = txtValorEntrada.Text;

            double caucao;
            if (string.IsNullOrEmpty(caucaoStr))
            {
                caucao = 0;
            }
            else
            {
                caucao = Convert.ToDouble(caucaoStr);
            }
            

            DateTime dataSaida = dateDataSaida.Value;
            DateTime dataDevolucao = dateDataDevolucao.Value;

            List<TaxasServicos> taxasSelecionadas = new List<TaxasServicos>();

            foreach (var item in listaTaxasServicos.Items)
                taxasSelecionadas.Add((TaxasServicos)item);

            locacao = new Locacao(cliente, veiculo, taxasSelecionadas, dataSaida, dataDevolucao, caucao, plano);

            string resultadoValidacao = locacao.Validar();

            VeriricarDisponibilidadeDeVeiculo();

            if (resultadoValidacao != "ESTA_VALIDO")
            {
                string primeiroErro = new StringReader(resultadoValidacao).ReadLine();

                Dashboard.Instancia.AtualizarRodape(primeiroErro);

                DialogResult = DialogResult.None;
            }

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
            

            List<TaxasServicos> taxasSelecionadas = new List<TaxasServicos>();

            if(listaTaxasServicos.Items.Count!= 0)
            {
                foreach (var item in listaTaxasServicos.Items)
                    taxasSelecionadas.Add((TaxasServicos)item);
            }

            TelaSelecaoTaxasForm tela = new TelaSelecaoTaxasForm(taxasSelecionadas);

            if (tela.ShowDialog() == DialogResult.OK)
            {
                taxasSelecionadas = tela.TaxasSelecionadas;

                listaTaxasServicos.Items.Clear();
                if (taxasSelecionadas != null)
                    foreach (var taxa in taxasSelecionadas)
                        listaTaxasServicos.Items.Add(taxa);

                CalcularValorTotal(taxasSelecionadas);
            }
        }

        private void VeriricarDisponibilidadeDeVeiculo()
        {
            foreach (var item in controladorLocacao.SelecionarTodos())
            {
                if ((item.Id != locacao.Id && item.Devolucao == "Pendente") && item.Veiculo.Id == locacao.Veiculo.Id)
                {
                    Dashboard.Instancia.AtualizarRodape($"O Veículo: [{locacao.Veiculo}] não está disponível para locação!");
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

            foreach (var item in taxasSelecionadas)
                total += item.Taxa;

            total += caucao;

            lblValorTotal.Text = total.ToString();
        }

    }
}
