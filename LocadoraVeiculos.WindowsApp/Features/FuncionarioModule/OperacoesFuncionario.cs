using LocadoraVeiculos.WindowsApp.Shared;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using LocadoraVeiculos.netCore.Dominio.FuncionarioModule;
using LocadoraVeiculos.Aplicacao.FuncionarioModule;
using log4net;
using System.Reflection;
using Serilog;
using System.Diagnostics;
using LocadoraVeiculos.Infra.ExtensionMethods;

namespace LocadoraVeiculos.WindowsApp.Features.FuncionarioModule
{
    public class OperacoesFuncionario : ICadastravel
    {
        
        private readonly FuncionarioAppService funcionarioAppService = null;
        private readonly TabelaFuncionarioControl tabelaFuncionario = null;
       

        public OperacoesFuncionario(FuncionarioAppService funcionarioApp)
        {
            
            funcionarioAppService = funcionarioApp;
            tabelaFuncionario = new TabelaFuncionarioControl();
        }

        public void InserirNovoRegistro()
        {
            TelaCadastrarFuncionario tela = new TelaCadastrarFuncionario();

            if (tela.ShowDialog() == DialogResult.OK)
            {
                //Log.Information("Inserindo novo funcionário...");
                Log.Logger.Aqui().FuncionalidadeUsada();
                Stopwatch watch = Stopwatch.StartNew();

                funcionarioAppService.InserirNovo(tela.Funcionario);

                List<Funcionario> funcionarios = funcionarioAppService.SelecionarTodos();

                tabelaFuncionario.AtualizarRegistros(funcionarios);

                Dashboard.Instancia.AtualizarRodape($"Funcionário: [{tela.Funcionario.Nome}] inserido com sucesso");

                watch.Stop();

                Log.Information("Funcionario: [{idFuncionario}] inserido com sucesso! ({Ms}ms)", tela.Funcionario.Id, watch.ElapsedMilliseconds);
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


            Funcionario funcionarioSelecionado = funcionarioAppService.SelecionarPorId(id);

          
            TelaCadastrarFuncionario tela = new TelaCadastrarFuncionario();

            tela.Funcionario = funcionarioSelecionado;

            if (tela.ShowDialog() == DialogResult.OK)
            {
                //Log.Information("Editando um funcionário");
                Log.Logger.Aqui().FuncionalidadeUsada();
                Stopwatch watch = Stopwatch.StartNew();

                funcionarioAppService.Editar(id, tela.Funcionario);

                List<Funcionario> funcionarios = funcionarioAppService.SelecionarTodos();

                tabelaFuncionario.AtualizarRegistros(funcionarios);

                Dashboard.Instancia.AtualizarRodape($"Tarefa: [{tela.Funcionario.Nome}] editado com sucesso");

                watch.Stop();

                Log.Information("Funcionario: [{idFuncionario}] editado com sucesso! ({Ms}ms)", tela.Funcionario.Id, watch.ElapsedMilliseconds);
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
            Funcionario funcionarioSelecionado = funcionarioAppService.SelecionarPorId(id);
            
            if (MessageBox.Show($"Tem certeza que deseja excluir o funcionário: [{funcionarioSelecionado.Nome}] ?",
                "Exclusão de Funcionários", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                //Log.Information("Excluindo locação...");
                Log.Logger.Aqui().FuncionalidadeUsada();
                Stopwatch watch = Stopwatch.StartNew();

                funcionarioAppService.Excluir(id);

                List<Funcionario> funcionarios = funcionarioAppService.SelecionarTodos();

                tabelaFuncionario.AtualizarRegistros(funcionarios);

                Dashboard.Instancia.AtualizarRodape($"Funcionário: [{funcionarioSelecionado.Nome}] removido com sucesso");

                watch.Stop();

                Log.Information("Funcionario: [{idFuncionario}] excluido com sucesso! ({Ms}ms)", id, watch.ElapsedMilliseconds);

            }
        }

        public UserControl ObterTabela()
        {

            List<Funcionario> funcionarios = funcionarioAppService.SelecionarTodos();

            tabelaFuncionario.AtualizarRegistros(funcionarios);


            return tabelaFuncionario;
        }

        public void FiltrarRegistros()
        {
            throw new NotImplementedException();
        }

        public void AgruparRegistros()
        {
            throw new NotImplementedException();
        }

        public void DesagruparRegistros()
        {
            List<Funcionario> funcionarios = funcionarioAppService.SelecionarTodos();

            tabelaFuncionario.AtualizarRegistros(funcionarios);
         
        }

        public void Pesquisar(string text)
        {
            throw new NotImplementedException();
        }
    }
}
