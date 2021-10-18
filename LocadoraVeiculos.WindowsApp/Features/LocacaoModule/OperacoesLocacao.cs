using LocadoraVeiculos.Aplicacao.ClienteModule;
using LocadoraVeiculos.Aplicacao.LocacaoModule;
using LocadoraVeiculos.Aplicacao.TaxasServicosModule;
using LocadoraVeiculos.Aplicacao.VeiculosModule;
using LocadoraVeiculos.Infra.ExtensionMethods;
using LocadoraVeiculos.netCore.Dominio.LocacaoModule;
using LocadoraVeiculos.WindowsApp.Features.DevolucaoModule;
using LocadoraVeiculos.WindowsApp.Shared;
using Serilog;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
            TelaCadastrarLocacaoForm tela = 
                new TelaCadastrarLocacaoForm(locacaoService,
                taxaService,
                clienteService,
                veiculoService);

            if (tela.ShowDialog() == DialogResult.OK)
            {
                Stopwatch watch = Stopwatch.StartNew(); ;

                bool conseguiuRegistrar = locacaoService.RegistrarNovaLocacao(tela.Locacao);

                if (conseguiuRegistrar)
                {
                    List<Locacao> locacoes = locacaoService.SelecionarTodos();

                    veiculoService.AtualizarStatusAluguel(tela.Locacao.Veiculo, true);

                    clienteService.AtualizarStatusLocacaoAtiva(tela.Locacao.Cliente, true);

                    tabelaLocacoes.AtualizarRegistros(locacoes);

                    Dashboard.Instancia.AtualizarRodape($"Locação: [{tela.Locacao.Id}] inserida com sucesso!");

                    watch.Stop();

                    Log.Logger.Aqui().FuncionalidadeUsada(watch.ElapsedMilliseconds);
                }
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

            TelaCadastrarLocacaoForm tela = new TelaCadastrarLocacaoForm(locacaoService, taxaService, clienteService, veiculoService);

            tela.Locacao = locacaoSelecionada;

            if (tela.ShowDialog() == DialogResult.OK)
            {
                Stopwatch watch = Stopwatch.StartNew();

                bool conseguiuEditar = locacaoService.Editar(id, tela.Locacao);

                if (conseguiuEditar)
                {
                    List<Locacao> locacoes = locacaoService.SelecionarTodos();

                    tabelaLocacoes.AtualizarRegistros(locacoes);

                    Dashboard.Instancia.AtualizarRodape($"Locação: [{tela.Locacao.Id}] editada com sucesso!");

                    watch.Stop();

                    Log.Logger.Aqui().FuncionalidadeUsada(watch.ElapsedMilliseconds);
                }
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

            if (MessageBox.Show($"Tem certeza que deseja excluir a locação: [{locacaoSelecionada.Id}]?",
                "Exclusão de Locações", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                Stopwatch watch = Stopwatch.StartNew();

                bool conseguiuExcluir = locacaoService.Excluir(locacaoSelecionada);

                if (conseguiuExcluir)
                {
                    List<Locacao> locacoes = locacaoService.SelecionarTodos();

                    tabelaLocacoes.AtualizarRegistros(locacoes);

                    Dashboard.Instancia.AtualizarRodape($"Locação: [{locacaoSelecionada.Id}] excluída com sucesso!");

                    watch.Stop();

                    Log.Logger.Aqui().FuncionalidadeUsada(watch.ElapsedMilliseconds);
                }
            }
        }

        public void FiltrarRegistros()
        {
            FiltroLocacaoForm telaFiltro = new FiltroLocacaoForm();

            if (telaFiltro.ShowDialog() == DialogResult.OK)
            {
                Stopwatch watch = Stopwatch.StartNew();

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

                watch.Stop();

                Log.Logger.Aqui().FuncionalidadeUsada(watch.ElapsedMilliseconds);
            }
        }

        public void AgruparRegistros()
        {
            throw new NotImplementedException();
        }

        public void DesagruparRegistros()
        {
            Stopwatch watch = Stopwatch.StartNew();

            List<Locacao> locacoes = locacaoService.SelecionarTodos();

            tabelaLocacoes.AtualizarRegistros(locacoes);

            watch.Stop();

            Log.Logger.Aqui().FuncionalidadeUsada(watch.ElapsedMilliseconds);
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

            TelaRegistrarDevolucaoForm tela = new TelaRegistrarDevolucaoForm(taxaService);

            tela.Locacao = locacaoSelecionada;

            if (tela.ShowDialog() == DialogResult.OK)
            {
                Stopwatch watch = Stopwatch.StartNew();

                string resultadoDevolucao = locacaoService.RegistrarDevolucao(tela.Locacao);

                if (resultadoDevolucao != "ERRO_INSERCAO")
                {
                    veiculoService.AtualizarQuilometragem(tela.Locacao.Veiculo);

                    veiculoService.AtualizarStatusAluguel(tela.Locacao.Veiculo, false);

                    clienteService.AtualizarStatusLocacaoAtiva(tela.Locacao.Cliente, false);

                    List<Locacao> locacoes = locacaoService.SelecionarTodos();

                    tabelaLocacoes.AtualizarRegistros(locacoes);

                    Dashboard.Instancia.AtualizarRodape(resultadoDevolucao);

                    watch.Stop();

                    Log.Logger.Aqui().FuncionalidadeUsada(watch.ElapsedMilliseconds);
                }
            }
        }

        public void Pesquisar(string text)
        {
            throw new NotImplementedException();
        }
    }
}
