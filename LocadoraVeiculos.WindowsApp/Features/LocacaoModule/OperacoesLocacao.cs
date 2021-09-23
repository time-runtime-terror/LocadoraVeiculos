using LocadoraVeiculos.Aplicacao.ClienteModule;
using LocadoraVeiculos.Aplicacao.LocacaoModule;
using LocadoraVeiculos.Aplicacao.TaxasServicosModule;
using LocadoraVeiculos.Aplicacao.VeiculosModule;
using LocadoraVeiculos.netCore.Dominio.LocacaoModule;
using LocadoraVeiculos.WindowsApp.Features.DevolucaoModule;
using LocadoraVeiculos.WindowsApp.Shared;
using log4net;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Windows.Forms;

namespace LocadoraVeiculos.WindowsApp.Features.LocacaoModule
{
    public class OperacoesLocacao : ICadastravel
    {
        private readonly LocacaoAppService locacaoService;
        private readonly TaxasServicosAppService taxaService;
        private readonly VeiculoAppService veiculoService;
        private readonly ClienteAppService clienteService;

        private readonly TabelaLocacaoControl tabelaLocacoes;

        private static readonly ILog logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public OperacoesLocacao(LocacaoAppService locacaoS, TaxasServicosAppService taxaS, VeiculoAppService veiculoS, ClienteAppService clienteS)
        {
            locacaoService = locacaoS;
            taxaService = taxaS;
            veiculoService = veiculoS;
            clienteService = clienteS;

            tabelaLocacoes = new TabelaLocacaoControl();
        }

        public void InserirNovoRegistro()
        {
            TelaCadastrarLocacaoForm tela = new TelaCadastrarLocacaoForm();

            if (tela.ShowDialog() == DialogResult.OK)
            {
                locacaoService.RegistrarNovaLocacao(tela.Locacao);

                List<Locacao> locacoes = locacaoService.SelecionarTodos();

                tela.Locacao.Veiculo.EstaAlugado = true;

                veiculoService.AtualizarStatusAluguel(tela.Locacao.Veiculo);

                tela.Locacao.Cliente.TemLocacaoAtiva = true;

                clienteService.AtualizarStatusLocacaoAtiva(tela.Locacao.Cliente);

                tabelaLocacoes.AtualizarRegistros(locacoes);

                Dashboard.Instancia.AtualizarRodape($"Locação: [{tela.Locacao.Id}] inserida com sucesso!");
            }
        }

        public void EditarRegistro()
        {
            int id = tabelaLocacoes.ObtemIdSelecionado();

            if (id == 0)
            {
                Dashboard.Instancia.AtualizarRodape("Selecione uma locação para poder editar!");
                return;
            }

            Locacao locacaoSelecionada = locacaoService.SelecionarPorId(id);

            TelaCadastrarLocacaoForm tela = new TelaCadastrarLocacaoForm();

            tela.Locacao = locacaoSelecionada;

            if (tela.ShowDialog() == DialogResult.OK)
            {
                locacaoService.Editar(id, tela.Locacao);

                taxaService.ExcluirTaxaUsada(tela.Locacao);

                taxaService.RegistrarTaxaUsada(tela.Locacao);

                List<Locacao> locacoes = locacaoService.SelecionarTodos();

                tabelaLocacoes.AtualizarRegistros(locacoes);

                Dashboard.Instancia.AtualizarRodape($"Locação: [{tela.Locacao.Id}] editada com sucesso!");
            }
        }

        public void ExcluirRegistro()
        {
            int id = tabelaLocacoes.ObtemIdSelecionado();

            if (id == 0)
            {
                Dashboard.Instancia.AtualizarRodape($"Selecione um registro para poder excluir!");
                return;
            }

            Locacao locacaoSelecionada = locacaoService.SelecionarPorId(id);

            if (MessageBox.Show($"Tem certeza que deseja excluir a locação: [{locacaoSelecionada.Id}] ?",
                "Exclusão de Locações", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                locacaoService.Excluir(id);

                taxaService.ExcluirTaxaUsada(locacaoSelecionada);

                List<Locacao> locacoes = locacaoService.SelecionarTodos();

                tabelaLocacoes.AtualizarRegistros(locacoes);

                Dashboard.Instancia.AtualizarRodape($"Locação: [{locacaoSelecionada.Id}] excluída com sucesso!");
            }
        }

        public void FiltrarRegistros()
        {
            FiltroLocacaoForm telaFiltro = new FiltroLocacaoForm();

            if (telaFiltro.ShowDialog() == DialogResult.OK)
            {
                var locacoes = new List<Locacao>();

                switch (telaFiltro.TipoFiltro)
                {
                    case FiltroLocacaoEnum.LocacoesConcluidas:
                        locacoes = locacaoService.SelecionarTodasLocacoesConcluidas();
                        break;

                    case FiltroLocacaoEnum.LocacoesPendentes:
                        locacoes = locacaoService.SelecionarTodasLocacoesPendentes();
                        break;

                    default:
                        break;
                }

                tabelaLocacoes.AtualizarRegistros(locacoes);
            }
        }

        public void AgruparRegistros()
        {
            throw new NotImplementedException();
        }

        public void DesagruparRegistros()
        {
            List<Locacao> locacoes = locacaoService.SelecionarTodos();

            tabelaLocacoes.AtualizarRegistros(locacoes);
        }

        public UserControl ObterTabela()
        {
            List<Locacao> locacoes = locacaoService.SelecionarTodos();

            tabelaLocacoes.AtualizarRegistros(locacoes);

            return tabelaLocacoes;
        }

        public void RegistrarDevolucao()
        {
            int id = tabelaLocacoes.ObtemIdSelecionado();

            if (id == 0)
            {
                Dashboard.Instancia.AtualizarRodape($"Selecione um registro para poder devolver!");
                return;
            }

            Locacao locacaoSelecionada = locacaoService.SelecionarPorId(id);

            TelaRegistrarDevolucaoForm tela = new TelaRegistrarDevolucaoForm();

            tela.Locacao = locacaoSelecionada;

            if (tela.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    string resultadoDevolucao = locacaoService.RegistrarDevolucao(tela.Locacao);

                    if (resultadoDevolucao == "ESTA_VALIDO")
                        Dashboard.Instancia.AtualizarRodape($"O recibo da locação foi enviado ao email {tela.Locacao.Cliente.Email}");
                }
                catch (Exception ex)
                {
                    logger.Error(ex.Message, ex);
                    Dashboard.Instancia.AtualizarRodape(ex.Message);
                    return;
                }

                veiculoService.AtualizarQuilometragem(tela.Locacao.Veiculo);

                tela.Locacao.Veiculo.EstaAlugado = false;

                veiculoService.AtualizarStatusAluguel(tela.Locacao.Veiculo);

                tela.Locacao.Cliente.TemLocacaoAtiva = false;

                clienteService.AtualizarStatusLocacaoAtiva(tela.Locacao.Cliente);

                List<Locacao> locacoes = locacaoService.SelecionarTodos();

                tabelaLocacoes.AtualizarRegistros(locacoes);

                Dashboard.Instancia.AtualizarRodape($"Devolução da Locação: [{tela.Locacao.Id}] feita com sucesso!");
            }
        }

        public void Pesquisar(string text)
        {
            throw new NotImplementedException();
        }
    }
}
