using LocadoraVeiculos.WindowsApp.Shared;
using LocadoraVeiculos.netCore.Dominio.VeiculoModule;
using LocadoraVeiculos.WindowsApp.Features.VeiculoModule;
using System.Collections.Generic;
using System.Windows.Forms;
using LocadoraVeiculos.Aplicacao.VeiculosModule;
using log4net;
using System.Reflection;
using System;

namespace LocadoraVeiculos.WindowsApp.Feature.VeiculoModule
{
    public class OperacoesVeiculos : ICadastravel
    {
        private readonly VeiculoAppService veiculosService = null;
        private readonly TabelaVeiculosControl tabelaVeiculo = null;
        private static readonly ILog logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public OperacoesVeiculos(VeiculoAppService veiculosAppService)
        {
            veiculosService = veiculosAppService;
            tabelaVeiculo = new TabelaVeiculosControl(veiculosAppService);
        }

        public void InserirNovoRegistro()
        {
            TelaCadastrarVeiculos tela = new TelaCadastrarVeiculos();

            if (tela.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    veiculosService.InserirNovo(tela.Veiculo);

                    List<Veiculo> veiculos = veiculosService.SelecionarTodos();

                    tabelaVeiculo.AtualizarRegistros();

                    Dashboard.Instancia.AtualizarRodape($"Veículo: [{tela.Veiculo.Modelo}] inserido com sucesso");
                }
                catch (Exception ex)
                {
                    logger.Error(ex.Message);

                    Dashboard.Instancia.AtualizarRodape(ex.Message);
                }
            }
        }

        public void EditarRegistro()
        {
            int id = tabelaVeiculo.ObtemIdSelecionado();

            if (id == 0)
            {
                MessageBox.Show("Selecione um veiculo para poder editar!", "Edição de Veiculos",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            try
            {
                Veiculo veiculoSelecionado = veiculosService.SelecionarPorId(id);

                TelaCadastrarVeiculos tela = new TelaCadastrarVeiculos();

                tela.Veiculo = veiculoSelecionado;

                if (tela.ShowDialog() == DialogResult.OK)
                {
                    veiculosService.Editar(id, tela.Veiculo);

                    tabelaVeiculo.AtualizarRegistros();

                    Dashboard.Instancia.AtualizarRodape($"Veículo: [{tela.Veiculo.Modelo}] editado com sucesso");
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message, ex);

                Dashboard.Instancia.AtualizarRodape(ex.Message);
            }
        }

        public void ExcluirRegistro()
        {
            int id = tabelaVeiculo.ObtemIdSelecionado();

            if (id == 0)
            {
                MessageBox.Show("Selecione um veiculo para poder excluir!", "Exclusão de Veiculos",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            try
            {
                Veiculo veiculoSelecionado = veiculosService.SelecionarPorId(id);

                if (veiculoSelecionado.EstaAlugado)
                {
                    Dashboard.Instancia.AtualizarRodape($"Veículo: [{veiculoSelecionado.Modelo}] não pôde ser excluído pois está alugado!");
                    return;
                }

                if (MessageBox.Show($"Tem certeza que deseja excluir o Veiculo: [{veiculoSelecionado.Id}] ?",
                    "Exclusão de Veiculos", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    veiculosService.Excluir(id);

                    List<Veiculo> veiculos = veiculosService.SelecionarTodos();

                    tabelaVeiculo.AtualizarRegistros();

                    Dashboard.Instancia.AtualizarRodape($"Veículo: [{veiculoSelecionado.Modelo}] removido com sucesso");
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message, ex);

                Dashboard.Instancia.AtualizarRodape(ex.Message);
            }
        }

        public UserControl ObterTabela()
        {
            try
            {
                List<Veiculo> veiculos = veiculosService.SelecionarTodos();

                tabelaVeiculo.AtualizarRegistros();
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message, ex);

                Dashboard.Instancia.AtualizarRodape(ex.Message);
            }

            return tabelaVeiculo;
        }

        public void AgruparRegistros()
        {
            AgrupamentoVeiculosForm telaFiltro = new AgrupamentoVeiculosForm();

            try
            {
                if (telaFiltro.ShowDialog() == DialogResult.OK)
                {
                    tabelaVeiculo.AgruparVeiculos(telaFiltro.TipoAgrupamento);
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message, ex);

                Dashboard.Instancia.AtualizarRodape(ex.Message);
            }
        }

        public void DesagruparRegistros()
        {
            try
            {
                tabelaVeiculo.DesagruparVeiculos();
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message, ex);

                Dashboard.Instancia.AtualizarRodape(ex.Message);
            }
        }

        public void FiltrarRegistros()
        {
            
        }

        public void Pesquisar(string text)
        {
            try
            {
                List<Veiculo> veiculosEncontrados = veiculosService.Pesquisar(text);

                tabelaVeiculo.AtualizarRegistros(veiculosEncontrados);
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message, ex);

                Dashboard.Instancia.AtualizarRodape(ex.Message);
            }
        }
    }
}
