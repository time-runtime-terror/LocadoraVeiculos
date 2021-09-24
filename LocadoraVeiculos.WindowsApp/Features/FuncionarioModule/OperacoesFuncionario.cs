using LocadoraVeiculos.WindowsApp.Shared;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using LocadoraVeiculos.netCore.Dominio.FuncionarioModule;
using LocadoraVeiculos.Aplicacao.FuncionarioModule;
using log4net;
using System.Reflection;

namespace LocadoraVeiculos.WindowsApp.Features.FuncionarioModule
{
    public class OperacoesFuncionario : ICadastravel
    {
        
        private readonly FuncionarioAppService funcionarioAppService = null;
        private readonly TabelaFuncionarioControl tabelaFuncionario = null;
        private static readonly ILog logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

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
                try
                {
                    funcionarioAppService.InserirNovo(tela.Funcionario);

                    List<Funcionario> funcionarios = funcionarioAppService.SelecionarTodos();

                    tabelaFuncionario.AtualizarRegistros(funcionarios);

                    Dashboard.Instancia.AtualizarRodape($"Funcionário: [{tela.Funcionario.Nome}] inserido com sucesso");
                }catch(Exception ex)
                {
                    logger.Error(ex.Message, ex);

                    Dashboard.Instancia.AtualizarRodape(ex.Message);

                    return;
                }
                
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


            Funcionario funcionarioSelecionado;

            try
            {
                funcionarioSelecionado = funcionarioAppService.SelecionarPorId(id);
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message, ex);

                Dashboard.Instancia.AtualizarRodape(ex.Message);

                return;
            }

            TelaCadastrarFuncionario tela = new TelaCadastrarFuncionario();

            tela.Funcionario = funcionarioSelecionado;

            if (tela.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    funcionarioAppService.Editar(id, tela.Funcionario);

                    List<Funcionario> funcionarios = funcionarioAppService.SelecionarTodos();

                    tabelaFuncionario.AtualizarRegistros(funcionarios);

                    Dashboard.Instancia.AtualizarRodape($"Tarefa: [{tela.Funcionario.Nome}] editado com sucesso");
                }catch(Exception ex)
                {
                    logger.Error(ex.Message, ex);

                    Dashboard.Instancia.AtualizarRodape(ex.Message);
                }
                
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
            Funcionario funcionarioSelecionado;
            try
            {
                funcionarioSelecionado = funcionarioAppService.SelecionarPorId(id);
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message, ex);

                Dashboard.Instancia.AtualizarRodape(ex.Message);

                return;
            }

           

            if (MessageBox.Show($"Tem certeza que deseja excluir o funcionário: [{funcionarioSelecionado.Nome}] ?",
                "Exclusão de Funcionários", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {

                try
                {
                    funcionarioAppService.Excluir(id);

                    List<Funcionario> funcionarios = funcionarioAppService.SelecionarTodos();

                    tabelaFuncionario.AtualizarRegistros(funcionarios);

                    Dashboard.Instancia.AtualizarRodape($"Funcionário: [{funcionarioSelecionado.Nome}] removido com sucesso");
                }
                catch(Exception ex)
                {
                    logger.Error(ex.Message, ex);

                    Dashboard.Instancia.AtualizarRodape(ex.Message);
                }
                
            }
        }

        public UserControl ObterTabela()
        {
            try
            {
                List<Funcionario> funcionarios = funcionarioAppService.SelecionarTodos();

                tabelaFuncionario.AtualizarRegistros(funcionarios);
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message, ex);

                Dashboard.Instancia.AtualizarRodape(ex.Message);
            }


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
            try
            {
                List<Funcionario> funcionarios = funcionarioAppService.SelecionarTodos();

                tabelaFuncionario.AtualizarRegistros(funcionarios);
            }catch (Exception ex)
            {
                logger.Error(ex.Message, ex);

                Dashboard.Instancia.AtualizarRodape(ex.Message);
            }


        }

        public void Pesquisar(string text)
        {
            try
            {
                List<Funcionario> clientesSelecionados = funcionarioAppService.Pesquisar(text);

                tabelaFuncionario.AtualizarRegistros(clientesSelecionados);
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message, ex);

                Dashboard.Instancia.AtualizarRodape(ex.Message);
            }
        }
    }
}
