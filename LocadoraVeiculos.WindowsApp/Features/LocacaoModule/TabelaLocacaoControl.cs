using LocadoraVeiculos.Dominio.LocacaoModule;
using LocadoraVeiculos.WindowsApp.Shared;
using System.Collections.Generic;
using System.Windows.Forms;

namespace LocadoraVeiculos.WindowsApp.Features.LocacaoModule
{
    public partial class TabelaLocacaoControl : UserControl
    {
        public TabelaLocacaoControl()
        {
            InitializeComponent();
            gridLocacoes.ConfigurarGridZebrado();
            gridLocacoes.ConfigurarGridSomenteLeitura();
            gridLocacoes.Columns.AddRange(ObterColunas());
        }

        public DataGridViewColumn[] ObterColunas()
        {
            var colunas = new DataGridViewColumn[]
            {
                new DataGridViewTextBoxColumn { DataPropertyName = "Id", HeaderText = "Id"},

                new DataGridViewTextBoxColumn { DataPropertyName = "Cliente", HeaderText = "Cliente"},

                new DataGridViewTextBoxColumn { DataPropertyName = "Veiculo", HeaderText = "Veículo"},

                new DataGridViewTextBoxColumn { DataPropertyName = "Plano", HeaderText = "Plano"},

                new DataGridViewTextBoxColumn {DataPropertyName = "DataSaida", HeaderText = "Data de Saída"},

                new DataGridViewTextBoxColumn {DataPropertyName = "DataDevolucao", HeaderText = "Devolução"}
            };

            return colunas;
        }

        public int ObtemIdSelecionado()
        {
            return gridLocacoes.SelecionarId<int>();
        }

        public void AtualizarRegistros(List<Locacao> locacoes)
        {
            gridLocacoes.Rows.Clear();

            foreach (Locacao locacao in locacoes)
            {
                gridLocacoes.Rows.Add(locacao.Id, locacao.Cliente, locacao.Veiculo, locacao.Plano, locacao.DataSaida, locacao.DataDevolucao);
            }

        }
    }
}
