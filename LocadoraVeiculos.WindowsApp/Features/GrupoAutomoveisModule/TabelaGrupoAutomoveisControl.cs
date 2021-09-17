using LocadoraVeiculos.Aplicacao.GrupoAutomoveisModule;
using LocadoraVeiculos.netCore.Dominio.GrupoAutomoveisModule;
using LocadoraVeiculos.WindowsApp.Shared;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace LocadoraVeiculos.WindowsApp.Features.GrupoAutomoveisModule
{
    public partial class TabelaGrupoAutomoveisControl : UserControl
    {
        private readonly GrupoAutomoveisAppService GrupoAutomoveisAppService;
        private Subro.Controls.DataGridViewGrouper gridGrupoAutomoveisAgrupados;

        private AgrupamentoGrupoAutomoveisEnum tipoAgrupamento;

        public TabelaGrupoAutomoveisControl(GrupoAutomoveisAppService GrupoAutomoveisAppService)
        {
            InitializeComponent();
            gridGrupoAutomoveis.ConfigurarGridZebrado();
            gridGrupoAutomoveis.ConfigurarGridSomenteLeitura();
            gridGrupoAutomoveis.Columns.AddRange(ObterColunas());

            tipoAgrupamento = AgrupamentoGrupoAutomoveisEnum.TodosOsGrupoAutomoveis;

            this.GrupoAutomoveisAppService = GrupoAutomoveisAppService;
        }

        public DataGridViewColumn[] ObterColunas()
        {
            var colunas = new DataGridViewColumn[]
            {
                new DataGridViewTextBoxColumn { DataPropertyName = "Id", HeaderText = "Id"},

                new DataGridViewTextBoxColumn { DataPropertyName = "nomeGrupo", HeaderText = "Grupo de Automoveis"},

                new DataGridViewTextBoxColumn { DataPropertyName = "planoDiarioUm", HeaderText = "Plano Diario por Dia"},

                new DataGridViewTextBoxColumn { DataPropertyName = "planoDiarioDois", HeaderText = "Plano Diario por Km Rodado"},

                new DataGridViewTextBoxColumn {DataPropertyName = "kmControladoUm", HeaderText = "Km Controlado por Dia"},

                new DataGridViewTextBoxColumn {DataPropertyName = "kmControladoDois", HeaderText = "Km Controlado por Km Rodado"},

                new DataGridViewTextBoxColumn {DataPropertyName = "kmControladoIncluida", HeaderText = "Km Controlado Incluído"},

                new DataGridViewTextBoxColumn {DataPropertyName = "kmLivreUm", HeaderText = "Km Livre por Dia"}
            };

            return colunas;
        }

        public void AtualizarRegistros()
        {
            DesagruparGrupoAutomoveis();

            List<GrupoAutomoveis> grupoAutomoveis = GrupoAutomoveisAppService.SelecionarTodos();

            CarregarTabela(grupoAutomoveis);

            AgruparGrupoAutomoveis();
        }

        private void CarregarTabela(List<GrupoAutomoveis> grupoAutomoveis)
        {
            gridGrupoAutomoveis.DataSource = grupoAutomoveis;

            gridGrupoAutomoveisAgrupados = new Subro.Controls.DataGridViewGrouper(gridGrupoAutomoveis);
        }

        public int ObtemIdSelecionado()
        {
            return gridGrupoAutomoveis.SelecionarId<int>();
        }

        private void AgruparGrupoAutomoveisPor(string campo)
        {
            if (gridGrupoAutomoveisAgrupados == null)
                return;

            gridGrupoAutomoveisAgrupados.RemoveGrouping();
            gridGrupoAutomoveisAgrupados.SetGroupOn(campo);
            gridGrupoAutomoveisAgrupados.Options.ShowGroupName = false;
            gridGrupoAutomoveisAgrupados.Options.GroupSortOrder = SortOrder.None;

            foreach (DataGridViewColumn item in gridGrupoAutomoveis.Columns)
                if (item.DataPropertyName == campo)
                    item.Visible = false;

            gridGrupoAutomoveis.RowHeadersVisible = false;
            gridGrupoAutomoveis.ClearSelection();
        }

        public void AgruparGrupoDeAutomoveis(AgrupamentoGrupoAutomoveisEnum tipoAgrupamento)
        {
            this.tipoAgrupamento = tipoAgrupamento;

            AgruparGrupoAutomoveis();
        }

        public void DesagruparGrupoAutomoveis()
        {
            var campos = new string[] {"NomeGrupo"};

            if (gridGrupoAutomoveisAgrupados == null)
                return;

            gridGrupoAutomoveisAgrupados.RemoveGrouping();
            gridGrupoAutomoveis.RowHeadersVisible = true;

            foreach (var campo in campos)
                foreach (DataGridViewColumn item in gridGrupoAutomoveis.Columns)
                    if (item.DataPropertyName == campo)
                        item.Visible = true;

            gridGrupoAutomoveis.ClearSelection();
            gridGrupoAutomoveis.RowHeadersVisible = false;
        }

        private void AgruparGrupoAutomoveis()
        {
            switch (tipoAgrupamento)
            {
                case AgrupamentoGrupoAutomoveisEnum.GrupoAutomoveisPorNome:
                    AgruparGrupoAutomoveisPor("NomeGrupo");
                    break;

                case AgrupamentoGrupoAutomoveisEnum.TodosOsGrupoAutomoveis:
                    DesagruparGrupoAutomoveis();
                    break;

                default:
                    break;
            }
        }
    }
}
