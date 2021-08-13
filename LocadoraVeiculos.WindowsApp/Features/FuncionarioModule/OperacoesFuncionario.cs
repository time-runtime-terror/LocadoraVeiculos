using LocadoraVeiculos.WindowsApp.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LocadoraVeiculos.Controladores.FuncionarioModule;
using LocadoraVeiculos.Dominio.FuncionarioModule;

namespace LocadoraVeiculos.WindowsApp.Features.FuncionarioModule
{
    public class OperacoesFuncionario : ICadastravel
    {
        private readonly ControladorFuncionario controlador = null;
        private readonly TabelaFuncionarioControl tabelaFuncionario = null;

        public OperacoesFuncionario(ControladorFuncionario ctrlFuncionario)
        {
            controlador = ctrlFuncionario;
            tabelaFuncionario = new TabelaFuncionarioControl();
        }

        public void InserirNovoRegistro()
        {
            TelaCadastrarFuncionario tela = new TelaCadastrarFuncionario();

            if (tela.ShowDialog() == DialogResult.OK)
            {
                controlador.InserirNovo(tela.Funcionario);

                List<Funcionario> funcionarios = controlador.SelecionarTodos();

                tabelaFuncionario.AtualizarRegistros(funcionarios);

                Dashboard.Instancia.AtualizarRodape($"Funcionário: [{tela.Funcionario.Nome}] inserido com sucesso");
            }
        }

        public void EditarRegistro()
        {
            int id = tabelaFuncionario.ObtemIdSelecionado();

            if (id == 0)
            {
                MessageBox.Show("Selecione um funcionário para poder editar!", "Edição de Funcionário",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            Funcionario funcionarioSelecionado = controlador.SelecionarPorId(id);

            TelaCadastrarFuncionario tela = new TelaCadastrarFuncionario();

            tela.Funcionario = funcionarioSelecionado;

            if (tela.ShowDialog() == DialogResult.OK)
            {
                controlador.Editar(id, tela.Funcionario);

                List<Funcionario> funcionarios = controlador.SelecionarTodos();

                tabelaFuncionario.AtualizarRegistros(funcionarios);

                Dashboard.Instancia.AtualizarRodape($"Tarefa: [{tela.Funcionario.Nome}] editado com sucesso");
            }
        }

        public void ExcluirRegistro()
        {
            int id = tabelaFuncionario.ObtemIdSelecionado();

            if (id == 0)
            {
                MessageBox.Show("Selecione um funcionário para poder excluir!", "Exclusão de Funcionários",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            Funcionario funcionarioSelecionado = controlador.SelecionarPorId(id);

            if (MessageBox.Show($"Tem certeza que deseja excluir o funcionário: [{funcionarioSelecionado.Nome}] ?",
                "Exclusão de Funcionários", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                controlador.Excluir(id);

                List<Funcionario> funcionarios = controlador.SelecionarTodos();

                tabelaFuncionario.AtualizarRegistros(funcionarios);

               Dashboard.Instancia.AtualizarRodape($"Funcionário: [{funcionarioSelecionado.Nome}] removido com sucesso");
            }
        }

        public UserControl ObterTabela()
        {
            List<Funcionario> funcionarios = controlador.SelecionarTodos();

            tabelaFuncionario.AtualizarRegistros(funcionarios);

            return tabelaFuncionario;
        }

        public void FiltrarRegistros()
        {
            
        }

        public void AgruparRegistros()
        {
            
        }

        public void DesagruparRegistros()
        {
            
        }

    }
}
