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
    public partial class FiltroLocacaoForm : Form
    {
        public FiltroLocacaoEnum TipoFiltro { get; set; }

        public FiltroLocacaoForm()
        {
            InitializeComponent();
        }

        private void rbLocacoesConcluidas_CheckedChanged(object sender, EventArgs e)
        {
            if (rbLocacoesConcluidas.Checked)
                TipoFiltro = FiltroLocacaoEnum.LocacoesConcluidas;

            else if (rbLocacoesPendentes.Checked)
                TipoFiltro = FiltroLocacaoEnum.LocacoesPendentes;
        }
    }
}
