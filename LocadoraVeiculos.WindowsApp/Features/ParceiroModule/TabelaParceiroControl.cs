using LocadoraVeiculos.netCore.Dominio.ParceiroModule;
using LocadoraVeiculos.WindowsApp.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LocadoraVeiculos.WindowsApp.Features.ParceiroModule
{
    public partial class TabelaParceiroControl : UserControl
    {
        public TabelaParceiroControl()
        {
            InitializeComponent();
            gridParceiro.ConfigurarGridZebrado();
            gridParceiro.ConfigurarGridSomenteLeitura();
            gridParceiro.Columns.AddRange(ObterColunas());
        }

        public DataGridViewColumn[] ObterColunas()
        {
            var colunas = new DataGridViewColumn[]
            {
                new DataGridViewTextBoxColumn { DataPropertyName = "Id", HeaderText = "Id"},

                new DataGridViewTextBoxColumn { DataPropertyName = "Nome", HeaderText = "Nome"}

            };

            return colunas;
        }

        public int ObtemIdSelecionado()
        {
            return gridParceiro.SelecionarId<int>();
        }

        public void AtualizarRegistros(List<Parceiro> parceiros)
        {
            gridParceiro.Rows.Clear();

            if (parceiros != null)
                foreach (Parceiro f in parceiros)
                {
                    gridParceiro.Rows.Add(f.Id, f.Nome);
                }
        }

    }
}
