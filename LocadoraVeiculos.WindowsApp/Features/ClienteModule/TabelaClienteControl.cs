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

                new DataGridViewTextBoxColumn { DataPropertyName = "Nome", HeaderText = "Nome"},

                new DataGridViewTextBoxColumn { DataPropertyName = "Telefone", HeaderText = "Telefone"},

                new DataGridViewTextBoxColumn { DataPropertyName = "TipoCadastro", HeaderText = "Cadastro"},

                new DataGridViewTextBoxColumn {DataPropertyName = "NumeroCadastro", HeaderText = "Número do Cadastro"},

                new DataGridViewTextBoxColumn {DataPropertyName = "Empresa", HeaderText = "Empresa"}
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
                var empresa = (cliente.Empresa != null) ? cliente.Empresa.Nome : null;

                gridClientes.Rows.Add(cliente.Id, cliente.Nome, cliente.Telefone, cliente.TipoCadastro, cliente.NumeroCadastro, empresa);
            }

        }
    }
}
