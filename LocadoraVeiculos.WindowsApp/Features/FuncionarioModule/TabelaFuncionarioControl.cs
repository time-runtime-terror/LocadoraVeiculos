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
using LocadoraVeiculos.Dominio.FuncionarioModule;

namespace LocadoraVeiculos.WindowsApp.Features.FuncionarioModule
{
    public partial class TabelaFuncionarioControl : UserControl
    {
        public TabelaFuncionarioControl()
        {
            InitializeComponent();
            gridFuncionario.ConfigurarGridZebrado();
            gridFuncionario.ConfigurarGridSomenteLeitura();
            gridFuncionario.Columns.AddRange(ObterColunas());
        }

        public DataGridViewColumn[] ObterColunas()
        {
            var colunas = new DataGridViewColumn[]
            {
                new DataGridViewTextBoxColumn { DataPropertyName = "Id", HeaderText = "Id"},

                new DataGridViewTextBoxColumn { DataPropertyName = "Nome", HeaderText = "Nome"},

                new DataGridViewTextBoxColumn { DataPropertyName = "Usuario", HeaderText = "Usuário"},

                new DataGridViewTextBoxColumn { DataPropertyName = "DataEntrada", HeaderText = "Data de Entrada"},

                new DataGridViewTextBoxColumn {DataPropertyName = "Salario", HeaderText = "Salário"},

            };

            return colunas;
        }

        public int ObtemIdSelecionado()
        {
            return gridFuncionario.SelecionarId<int>();
        }

        public void AtualizarRegistros(List<Funcionario> funcionarios)
        {
            gridFuncionario.Rows.Clear();

            foreach (Funcionario f in funcionarios)
            {
                gridFuncionario.Rows.Add(f.Id, f.Nome, f.NomeUsuario,
                    f.DataEntrada.ToString("dd/MM/yyyy"), f.Salario);
            }
        }
    }
}
