using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LocadoraVeiculos.WindowsApp.Features.VeiculoModule
{
    public partial class AgrupamentoVeiculosForm : Form
    {
        public AgrupamentoVeiculosEnum TipoAgrupamento { get; private set; }
        public AgrupamentoVeiculosForm()
        {
            InitializeComponent();
        }

        private void rdbAgrupar_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbAgrupar.Checked)
                TipoAgrupamento = AgrupamentoVeiculosEnum.PorGrupoAutomoveis;
        }
    }
}
