using LocadoraVeiculos.Controladores.ClienteModule;
using LocadoraVeiculos.Controladores.TaxasServicosModule;
using LocadoraVeiculos.Controladores.VeiculoModule;
using LocadoraVeiculos.Dominio.ClienteModule;
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

        //private List<TaxasServicos> taxasSelecionadas = new List<TaxasServicos>();

        public TelaCadastrarLocacaoForm()
        {
            InitializeComponent();
            controladorTaxasServicos = new ControladorTaxasServicos();
            controladorCliente = new ControladorCliente();
            controladorVeiculo = new ControladorVeiculo();
        }

        private void listaTaxasServicos_SelectedIndexChanged(object sender, EventArgs e)
        {

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
            Cliente cliente = null;
            List<Cliente> clientes = controladorCliente.SelecionarTodos();

            cliente = (Cliente)cmbCliente.SelectedItem;

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

        private void listaTaxasServicos_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            //double total = 0;

            //for (int i = 0; i < listaTaxasServicos.Items.Count; i++)
            //{
            //    if (listaTaxasServicos.GetItemCheckState(i) == CheckState.Checked)
            //    {
            //        taxasSelecionadas.Add((TaxasServicos)listaTaxasServicos.Items[i]);
            //        total += ((TaxasServicos)listaTaxasServicos.Items[i]).Taxa;
            //        lblValorTotal.Text = total.ToString();
            //    }

            //}
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
