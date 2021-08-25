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
        private readonly ControladorTaxasServicos controladorTaxasServicos;

        public List<TaxasServicos> TaxasSelecionadas
        {
            get => taxasSelecionadas;

            set
            {
                taxasSelecionadas = value;

                //foreach (var item in taxasSelecionadas)
                //{
                //    item.
                //}
            }
        }

        public TelaSelecaoTaxasForm()
        {
            InitializeComponent();
            controladorTaxasServicos = new ControladorTaxasServicos();
        }

        private void TelaSelecaoTaxasForm_Load(object sender, EventArgs e)
        {
            foreach (var taxa in controladorTaxasServicos.SelecionarTodos())
                listaTaxasServicos.Items.Add(taxa);

            if (taxasSelecionadas != null)
                for (int i = 0; i < listaTaxasServicos.Items.Count; i++)
                {
                    if (listaTaxasServicos.Items[i] == taxasSelecionadas[i])
                        listaTaxasServicos.SetItemChecked(i, true);
                }
        }

        private void listaTaxasServicos_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            //List<TaxasServicos> taxasSelecionadas = new List<TaxasServicos>();


            //if (e.NewValue == CheckState.Checked)
            //    taxasSelecionadas.Add((TaxasServicos)listaTaxasServicos.Items[e.Index]);

            //else
            //    taxasSelecionadas.Remove((TaxasServicos)listaTaxasServicos.Items[e.Index]);
        }

        private void btnGravarTaxas_Click(object sender, EventArgs e)
        {
            taxasSelecionadas = new List<TaxasServicos>();

            foreach (var item in listaTaxasServicos.CheckedItems)
                taxasSelecionadas.Add((TaxasServicos)item);
        }
    }
}
