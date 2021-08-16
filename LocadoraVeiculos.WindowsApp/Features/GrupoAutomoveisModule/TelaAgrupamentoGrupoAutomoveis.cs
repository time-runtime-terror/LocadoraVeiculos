using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LocadoraVeiculos.WindowsApp.Features.GrupoAutomoveisModule
{
    public partial class TelaAgrupamentoGrupoAutomoveis : Form
    {
        public TelaAgrupamentoGrupoAutomoveis()
        {
            InitializeComponent();
        }

        public AgrupamentoGrupoAutomoveisEnum TipoAgrupamento { get; internal set; }

        public void agruparGrupoAutomoveis()
        {
            if (rdbAgrupadosPorNome.Checked)
                TipoAgrupamento = AgrupamentoGrupoAutomoveisEnum.GrupoAutomoveisPorNome;

            else
                TipoAgrupamento = AgrupamentoGrupoAutomoveisEnum.TodosOsGrupoAutomoveis;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            agruparGrupoAutomoveis();
        }
    }
}
