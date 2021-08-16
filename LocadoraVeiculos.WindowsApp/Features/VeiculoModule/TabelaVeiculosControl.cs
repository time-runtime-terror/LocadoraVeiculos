using LocadoraVeiculos.WindowsApp.Shared;
using LocadoraVeiculos.Controladores.VeiculoModule;
using LocadoraVeiculos.Dominio.VeiculoModule;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LocadoraVeiculos.WindowsApp.Feature.VeiculoModule
{
    public partial class TabelaVeiculosControl : UserControl
    {
        private DataGridView gridVeiculos;

        private readonly ControladorVeiculo controladorVeiculo;

        private Subro.Controls.DataGridViewGrouper gridVeiculosAgrupados;

        public TabelaVeiculosControl(ControladorVeiculo controladorVeiculo)
        {
            InitializeComponent();
            gridVeiculos.ConfigurarGridZebrado();
            gridVeiculos.ConfigurarGridSomenteLeitura();
            gridVeiculos.Columns.AddRange(ObterColunas());
            this.controladorVeiculo = controladorVeiculo;
        }

        public DataGridViewColumn[] ObterColunas()
        {
            var colunas = new DataGridViewColumn[]
            {
                new DataGridViewTextBoxColumn { DataPropertyName = "Id", HeaderText = "Id"},

                new DataGridViewTextBoxColumn { DataPropertyName  = "Foto", HeaderText = "Foto"},

                new DataGridViewTextBoxColumn { DataPropertyName = "Placa", HeaderText = "Placa"},

                new DataGridViewTextBoxColumn { DataPropertyName = "Modelo", HeaderText = "Modelo"},

                new DataGridViewTextBoxColumn { DataPropertyName = "Marca", HeaderText = "Marca"},

                new DataGridViewTextBoxColumn {DataPropertyName = "TipoCombustivel", HeaderText = "TipoCombustivel"},

                new DataGridViewTextBoxColumn {DataPropertyName = "CapacidadeTanque", HeaderText = "CapacidadeTanque"},

                new DataGridViewTextBoxColumn {DataPropertyName = "Quilometragem", HeaderText = "Quilometragem"},

                new DataGridViewTextBoxColumn {DataPropertyName = "TipoCombustivel", HeaderText = "TipoCombustivel"}
            };

            return colunas;
        }

        public int ObtemIdSelecionado()
        {
            return gridVeiculos.SelecionarId<int>();
        }

        public void AtualizarRegistros()
        {
            List<Veiculo> veiculos = controladorVeiculo.SelecionarTodos();
            CarregarTabela(veiculos);
        }

        private void CarregarTabela(List<Veiculo> veiculos)
        {
            gridVeiculos.DataSource = veiculos;

            gridVeiculosAgrupados = new Subro.Controls.DataGridViewGrouper(gridVeiculos);
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
