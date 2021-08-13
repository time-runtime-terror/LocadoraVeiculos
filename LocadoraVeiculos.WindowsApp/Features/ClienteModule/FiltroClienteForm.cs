using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LocadoraVeiculos.WindowsApp.Features.ClienteModule
{
    public partial class FiltroClienteForm : Form
    {
        public FiltroClienteEnum TipoFiltro { get; internal set; }

        public FiltroClienteForm()
        {
            InitializeComponent();
        }

        private void rdbFiltroPessoasFisicas_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbFiltroPessoasFisicas.Checked)
                TipoFiltro = FiltroClienteEnum.PessoasFisicas;

            else if (rdbFiltroPessoasJuridicas.Checked)
                TipoFiltro = FiltroClienteEnum.PessoasJuridicas;
        }
    }
}
