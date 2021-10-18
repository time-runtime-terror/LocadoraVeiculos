using LocadoraVeiculos.Aplicacao.LocacaoModule;
using LocadoraVeiculos.Infra.InternetServices.LocacaoModule;
using LocadoraVeiculos.Infra.PDF.LocacaoModule;
using LocadoraVeiculos.Infra.SQL.ClienteModule;
using LocadoraVeiculos.Infra.SQL.GrupoAutomoveisModule;
using LocadoraVeiculos.Infra.SQL.LocacaoModule;
using LocadoraVeiculos.Infra.SQL.TaxasServicosModule;
using LocadoraVeiculos.Infra.SQL.VeiculosModule;
using LocadoraVeiculos.netCore.Dominio.LocacaoModule;
using LocadoraVeiculos.WindowsApp.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace LocadoraVeiculos.WindowsApp.Features.LocacaoModule
{
    public partial class TabelaLocacaoControl : UserControl
    {
        private readonly LocacaoAppService locacaoService;

        public TabelaLocacaoControl(LocacaoAppService locacaoS)
        {
            InitializeComponent();
            gridLocacoes.ConfigurarGridZebrado();
            gridLocacoes.ConfigurarGridSomenteLeitura();
            gridLocacoes.Columns.AddRange(ObterColunas());

            locacaoService = locacaoS;
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

                new DataGridViewTextBoxColumn {DataPropertyName = "DataDevolucao", HeaderText = "Previsão de Devolução"},

                new DataGridViewTextBoxColumn {DataPropertyName = "Devolucao", HeaderText = "Devolução"}
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
                gridLocacoes.Rows.Add(locacao.Id, locacao.Cliente, locacao.Veiculo, locacao.Plano, locacao.DataSaida.ToShortDateString(), locacao.DataDevolucao.ToShortDateString(), locacao.Devolucao);
            }

            gridLocacoes.Sort(gridLocacoes.Columns[6], ListSortDirection.Descending);

            gridLocacoes.ClearSelection();
        }

        private void gridLocacoes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int id = ObtemIdSelecionado();

            if (id == 0)
                return;

            var locacao = locacaoService.SelecionarPorId(id);

            if (locacao.Devolucao != "Pendente")
                Dashboard.Instancia.DesabilitarBotoesIndisponiveisParaDevolucao();
            else
                Dashboard.Instancia.HabilitarBotoesIndisponiveisParaDevolucao();
        }
    }
}
