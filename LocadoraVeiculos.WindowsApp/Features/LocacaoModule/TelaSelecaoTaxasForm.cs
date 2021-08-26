using LocadoraVeiculos.Controladores.TaxasServicosModule;
using LocadoraVeiculos.Dominio.TaxasServicosModule;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LocadoraVeiculos.WindowsApp.Features.LocacaoModule
{
    public partial class TelaSelecaoTaxasForm : Form
    {
        private List<TaxasServicos> taxasSelecionadas;
        private List<TaxasServicos> taxasVindas;

        private readonly ControladorTaxasServicos controladorTaxasServicos;

        public List<TaxasServicos> TaxasSelecionadas
        {
            get => taxasSelecionadas;

            set
            {
                taxasSelecionadas = value;

                

                
            }
        }

        public TelaSelecaoTaxasForm(List<TaxasServicos> taxasVindas)
        {
            InitializeComponent();
            controladorTaxasServicos = new ControladorTaxasServicos();

            this.taxasVindas = taxasVindas;
            
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
            foreach (var taxa in controladorTaxasServicos.SelecionarTodos())
                listaTaxasServicos.Items.Add(taxa);

            if(taxasVindas.Count != 0)
            {
                CarregarCheckBoxMarcado();
            }
            
        }

        private void btnGravarTaxas_Click(object sender, EventArgs e)
        {
            taxasSelecionadas = new List<TaxasServicos>();

            foreach (var item in listaTaxasServicos.CheckedItems)
                taxasSelecionadas.Add((TaxasServicos)item);
        }
    }
}
