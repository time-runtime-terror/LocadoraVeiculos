using LocadoraVeiculos.Controladores.GrupoAutomoveisModule;
using LocadoraVeiculos.Dominio.GrupoAutomoveisModule;
using LocadoraVeiculos.WindowsApp.Shared;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace LocadoraVeiculos.WindowsApp.Features.GrupoAutomoveisModule
{
    public partial class TabelaGrupoAutomoveisControl : UserControl
    {
        private readonly ControladorGrupoAutomoveis controladorGrupoAutomoveis;
        private Subro.Controls.DataGridViewGrouper gridGrupoAutomoveisAgrupados;

        private AgrupamentoGrupoAutomoveisEnum tipoAgrupamento;

        public TabelaGrupoAutomoveisControl(ControladorGrupoAutomoveis controladorGrupoAutomoveis)
        {
            InitializeComponent();
            gridGrupoAutomoveis.ConfigurarGridZebrado();
            gridGrupoAutomoveis.ConfigurarGridSomenteLeitura();
            gridGrupoAutomoveis.Columns.AddRange(ObterColunas());

            tipoAgrupamento = AgrupamentoGrupoAutomoveisEnum.TodosOsGrupoAutomoveis;

            this.controladorGrupoAutomoveis = controladorGrupoAutomoveis;
        }

        public DataGridViewColumn[] ObterColunas()
        {
            var colunas = new DataGridViewColumn[]
            {
                new DataGridViewTextBoxColumn { DataPropertyName = "Id", HeaderText = "Id"},

                new DataGridViewTextBoxColumn { DataPropertyName = "Grupo de Automoveis", HeaderText = "Grupo de Automoveis"},

                new DataGridViewTextBoxColumn { DataPropertyName = "Plano Diario", HeaderText = "Plano Diario"},

                new DataGridViewTextBoxColumn { DataPropertyName = "Plano Diario II", HeaderText = "Plano Diario II"},

                new DataGridViewTextBoxColumn {DataPropertyName = "Km Controlado", HeaderText = "Km Controlado"},

                new DataGridViewTextBoxColumn {DataPropertyName = "Km Controlado II", HeaderText = "Km Controlado II"},

                new DataGridViewTextBoxColumn {DataPropertyName = "Km Livre", HeaderText = "Km Livre"},

                new DataGridViewTextBoxColumn {DataPropertyName = "Km Livre II", HeaderText = "Km Livre II"}
            };

            return colunas;
        }

        public void AtualizarRegistros()
        {
            DesagruparGrupoAutomoveis();

            List<GrupoAutomoveis> grupoAutomoveis = controladorGrupoAutomoveis.SelecionarTodos();

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
            var campos = new string[] { "Nome"};

            if (gridGrupoAutomoveisAgrupados == null)
                return;

            gridGrupoAutomoveis.RowHeadersVisible = true;

            foreach (var campo in campos)
                foreach (DataGridViewColumn item in gridGrupoAutomoveis.Columns)
                    if (item.DataPropertyName == campo)
                        item.Visible = true;
        }

        private void AgruparGrupoAutomoveis()
        {
            switch (tipoAgrupamento)
            {
                case AgrupamentoGrupoAutomoveisEnum.GrupoAutomoveisPorNome:
                    AgruparGrupoAutomoveisPor("Nome");
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
