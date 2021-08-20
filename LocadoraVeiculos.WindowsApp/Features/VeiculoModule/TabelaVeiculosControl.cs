using LocadoraVeiculos.WindowsApp.Shared;
using LocadoraVeiculos.Controladores.VeiculoModule;
using LocadoraVeiculos.Dominio.VeiculoModule;
using System.Collections.Generic;
using System.Windows.Forms;

namespace LocadoraVeiculos.WindowsApp.Features.VeiculoModule
{
    public partial class TabelaVeiculosControl : UserControl
    {
        private DataGridView gridVeiculos;
        private AgrupamentoVeiculosEnum tipoAgrupamento;

        private readonly ControladorVeiculo controladorVeiculo;

        private Subro.Controls.DataGridViewGrouper gridVeiculosAgrupados;

        public TabelaVeiculosControl(ControladorVeiculo controladorVeiculo)
        {
            InitializeComponent();
            gridVeiculos.ConfigurarGridZebrado();
            gridVeiculos.ConfigurarGridSomenteLeitura();
            gridVeiculos.Columns.AddRange(ObterColunas());

            tipoAgrupamento = AgrupamentoVeiculosEnum.TodosAutomoveis;

            this.controladorVeiculo = controladorVeiculo;
        }

        public DataGridViewColumn[] ObterColunas()
        {
            var colunas = new DataGridViewColumn[]
            {
                new DataGridViewTextBoxColumn { DataPropertyName = "Id", HeaderText = "Id"},

                new DataGridViewImageColumn { DataPropertyName  = "Imagem", HeaderText = "Foto", ImageLayout = DataGridViewImageCellLayout.Zoom},

                new DataGridViewTextBoxColumn { DataPropertyName = "Placa", HeaderText = "Placa"},

                new DataGridViewTextBoxColumn { DataPropertyName = "Modelo", HeaderText = "Modelo"},

                new DataGridViewTextBoxColumn { DataPropertyName = "Marca", HeaderText = "Marca"},

                new DataGridViewTextBoxColumn {DataPropertyName = "TipoCombustivel", HeaderText = "Combustível"},

                new DataGridViewTextBoxColumn {DataPropertyName = "CapacidadeTanque", HeaderText = "Capacidade do Tanque"},

                new DataGridViewTextBoxColumn {DataPropertyName = "Quilometragem", HeaderText = "Km"},

                new DataGridViewTextBoxColumn {DataPropertyName = "NomeGrupo", HeaderText = "Categoria"}
            };

            return colunas;
        }

        public int ObtemIdSelecionado()
        {
            return gridVeiculos.SelecionarId<int>();
        }

        public void AtualizarRegistros()
        {
            DesagruparVeiculos();

            List<Veiculo> veiculos = controladorVeiculo.SelecionarTodos();

            CarregarTabela(veiculos);

            AgruparVeiculos();
        }

        public void AtualizarRegistros(List<Veiculo> veiculos)
        {
            DesagruparVeiculos();

            CarregarTabela(veiculos);

            AgruparVeiculos();
        }

        private void CarregarTabela(List<Veiculo> veiculos)
        {
            gridVeiculos.DataSource = veiculos;

            gridVeiculosAgrupados = new Subro.Controls.DataGridViewGrouper(gridVeiculos);
        }
        public void AgruparVeiculos(AgrupamentoVeiculosEnum tipoAgrupamento)
        {
            DesagruparVeiculos();

            this.tipoAgrupamento = tipoAgrupamento;

            AgruparVeiculos();
        }

        private void AgruparVeiculos()
        {
            switch (tipoAgrupamento)
            {
                case AgrupamentoVeiculosEnum.PorGrupoAutomoveis:
                    AgruparVeiculosPor("NomeGrupo");
                    break;

                case AgrupamentoVeiculosEnum.TodosAutomoveis:
                    DesagruparVeiculos();
                    break;

                default:
                    break;
            }
        }

        private void AgruparVeiculosPor(string campo)
        {
            if (gridVeiculosAgrupados == null)
                return;

            gridVeiculosAgrupados.RemoveGrouping();
            gridVeiculosAgrupados.SetGroupOn(campo);
            gridVeiculosAgrupados.Options.ShowGroupName = false;
            gridVeiculosAgrupados.Options.GroupSortOrder = SortOrder.None;

            foreach (DataGridViewColumn item in gridVeiculos.Columns)
                if (item.DataPropertyName == campo)
                    item.Visible = false;

            gridVeiculos.RowHeadersVisible = false;
            gridVeiculos.ClearSelection();
        }

        public void DesagruparVeiculos()
        {

            var campos = new string[] { "NomeGrupo" };

            if (gridVeiculosAgrupados == null)
                return;

            gridVeiculosAgrupados.RemoveGrouping();
            gridVeiculos.RowHeadersVisible = true;

            foreach (var campo in campos)
                foreach (DataGridViewColumn item in gridVeiculos.Columns)
                    if (item.DataPropertyName == campo)
                        item.Visible = true;
        }

        private void InitializeComponent()
        {
            this.gridVeiculos = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.gridVeiculos)).BeginInit();
            this.SuspendLayout();
            // 
            // gridVeiculos
            // 
            this.gridVeiculos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridVeiculos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridVeiculos.Location = new System.Drawing.Point(0, 0);
            this.gridVeiculos.Name = "gridVeiculos";
            this.gridVeiculos.Size = new System.Drawing.Size(335, 277);
            this.gridVeiculos.TabIndex = 0;
            // 
            // TabelaVeiculosControl
            // 
            this.Controls.Add(this.gridVeiculos);
            this.Name = "TabelaVeiculosControl";
            this.Size = new System.Drawing.Size(335, 277);
            ((System.ComponentModel.ISupportInitialize)(this.gridVeiculos)).EndInit();
            this.ResumeLayout(false);
        }
    }
}
