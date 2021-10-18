using LocadoraVeiculos.Aplicacao.TaxasServicosModule;
using LocadoraVeiculos.Infra.SQL.TaxasServicosModule;
using LocadoraVeiculos.netCore.Dominio.TaxasServicosModule;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace LocadoraVeiculos.WindowsApp.Features.LocacaoModule
{
    public partial class TelaSelecaoTaxasForm : Form
    {
        private List<TaxasServicos> taxasSelecionadas;
        private List<TaxasServicos> taxasVindas;
        private string localTaxa;

        private readonly TaxasServicosAppService taxaService;

        public List<TaxasServicos> TaxasSelecionadas
        {
            get => taxasSelecionadas;

            set
            {
                taxasSelecionadas = value;

            }
        }


        public TelaSelecaoTaxasForm(TaxasServicosAppService taxasSrv)
        {
            InitializeComponent();
            taxaService = taxasSrv;
        }

        public TelaSelecaoTaxasForm(TaxasServicosAppService taxasSrv, List<TaxasServicos> taxasVindas, string localTaxa)
        {
            InitializeComponent();

            taxaService = taxasSrv;

            this.taxasVindas = taxasVindas;

            this.localTaxa = localTaxa;
        }

        private void VerificarLocalTaxa()
        {
            //if (localTaxa == "Locação")
            //{
            //    for (int i = 0; i < controladorTaxasServicos.SelecionarTodos().Count; i++)
            //    {
            //        if (controladorTaxasServicos.SelecionarTodos().Contains(((TaxasServicos)listaTaxasServicos.Items[i])))
            //        {
            //            if (controladorTaxasServicos.SelecionarTodos()[i].LocalServico == "Devolução")
            //            {
            //                listaTaxasServicos.Items.Remove(listaTaxasServicos.Items[i]);
                           
            //            }
            //        }
            //    }
            //}
            
        }

        private void CarregarCheckBoxMarcado()
        {

            for (int count = 0; count < listaTaxasServicos.Items.Count; count++)
            {
                if (taxasVindas.Contains(((TaxasServicos)listaTaxasServicos.Items[count])))
                {
                    listaTaxasServicos.SetItemChecked(count, true);
                    
                }
            }

        }

        private void TelaSelecaoTaxasForm_Load(object sender, EventArgs e)
        {
            foreach (var taxa in taxaService.SelecionarTodos())
                listaTaxasServicos.Items.Add(taxa);

            if (taxasVindas != null)
            {
                if (taxasVindas.Count != 0)
                {
                    CarregarCheckBoxMarcado();
                }
            }

            VerificarLocalTaxa();
        }

        private void btnGravarTaxas_Click(object sender, EventArgs e)
        {
            taxasSelecionadas = new List<TaxasServicos>();

            foreach (var item in listaTaxasServicos.CheckedItems)
                taxasSelecionadas.Add((TaxasServicos)item);
        }
    }
}
