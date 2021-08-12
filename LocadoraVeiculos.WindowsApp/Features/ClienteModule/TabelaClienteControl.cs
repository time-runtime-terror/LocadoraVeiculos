using LocadoraVeiculos.Dominio.ClienteModule;
using LocadoraVeiculos.WindowsApp.Shared;
using System.Collections.Generic;
using System.Windows.Forms;

namespace LocadoraVeiculos.WindowsApp.Features.ClienteModule
{
    public partial class TabelaClienteControl : UserControl
    {
        public TabelaClienteControl()
        {
            InitializeComponent();
            gridClientes.ConfigurarGridZebrado();
            gridClientes.ConfigurarGridSomenteLeitura();
            gridClientes.Columns.AddRange(ObterColunas());
        }

        public DataGridViewColumn[] ObterColunas()
        {
            var colunas = new DataGridViewColumn[]
            {
                new DataGridViewTextBoxColumn { DataPropertyName = "Id", HeaderText = "Id"},

                new DataGridViewTextBoxColumn { DataPropertyName = "Assunto", HeaderText = "Nome"},

                new DataGridViewTextBoxColumn { DataPropertyName = "Telefone", HeaderText = "Telefone"},

                new DataGridViewTextBoxColumn { DataPropertyName = "TipoPessoa", HeaderText = "Cadastro"},

                new DataGridViewTextBoxColumn {DataPropertyName = "RG", HeaderText = "RG"},

                new DataGridViewTextBoxColumn {DataPropertyName = "CNH", HeaderText = "CNH"},

                new DataGridViewTextBoxColumn {DataPropertyName = "Condutor", HeaderText = "Condutor"}
            };

            return colunas;
        }

        public int ObtemIdSelecionado()
        {
            return gridClientes.SelecionarId<int>();
        }

        public void AtualizarRegistros(List<Cliente> clientes)
        {
            gridClientes.Rows.Clear();

            foreach (Cliente cliente in clientes)
            {

                var condutor = (cliente.Condutor != null) ? cliente.Condutor.Nome : null;

                gridClientes.Rows.Add(cliente.Id, cliente.Nome, cliente.Telefone, cliente.TipoPessoa, cliente.RG, cliente.CNH, condutor);
            }

        }
    }
}
