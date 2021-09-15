using LocadoraVeiculos.Aplicacao.ClienteModule;
using LocadoraVeiculos.Aplicacao.LocacaoModule;
using LocadoraVeiculos.Aplicacao.TaxasServicosModule;
using LocadoraVeiculos.Aplicacao.VeiculosModule;
using LocadoraVeiculos.netCore.Dominio.LocacaoModule;
using LocadoraVeiculos.WindowsApp.Features.DevolucaoModule;
using LocadoraVeiculos.WindowsApp.Shared;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace LocadoraVeiculos.WindowsApp.Features.LocacaoModule
{
    public class OperacoesLocacao : ICadastravel
    {
        //private readonly ControladorLocacao controladorLocacao;
        //private readonly ControladorTaxasServicos controladorTaxasServicos;
        //private readonly ControladorVeiculo controladorVeiculo;
        //private readonly ControladorCliente controladorCliente;
        private readonly TabelaLocacaoControl tabelaLocacoes;

        private readonly LocacaoAppService locacaoService;
        private readonly TaxasServicosAppService taxaService;
        private readonly VeiculosAppService veiculoService;
        private readonly ClienteAppService clienteService;

        public OperacoesLocacao(LocacaoAppService locacaoS, TaxasServicosAppService taxaS, VeiculosAppService veiculoS, ClienteAppService clienteS)
        {
            locacaoService = locacaoS;
            taxaService = taxaS;
            veiculoService = veiculoS;
            clienteService = clienteS;

            //controladorTaxasServicos = new ControladorTaxasServicos();

            //controladorLocacao = new ControladorLocacao(new ControladorCliente(), new ControladorVeiculo(), controladorTaxasServicos);

            tabelaLocacoes = new TabelaLocacaoControl();

            //controladorVeiculo = new ControladorVeiculo();

            //controladorCliente = new ControladorCliente();
        }

        public void InserirNovoRegistro()
        {
            TelaCadastrarLocacaoForm tela = new TelaCadastrarLocacaoForm();

            if (tela.ShowDialog() == DialogResult.OK)
            {
                locacaoService.RegistrarNovaLocacao(tela.Locacao);

                //controladorTaxasServicos.InserirNovaTaxaUsada(tela.Locacao);

                List<Locacao> locacoes = (List<Locacao>)locacaoService.SelecionarTodos();

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

                List<Locacao> locacoes = (List<Locacao>)locacaoService.SelecionarTodos();

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

                List<Locacao> locacoes = (List<Locacao>)locacaoService.SelecionarTodos();

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
                        locacoes = (List<Locacao>)locacaoService.SelecionarTodasLocacoesConcluidas();
                        break;

                    case FiltroLocacaoEnum.LocacoesPendentes:
                        locacoes = (List<Locacao>)locacaoService.SelecionarTodasLocacoesPendentes();
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
            List<Locacao> locacoes = (List<Locacao>)locacaoService.SelecionarTodos();

            tabelaLocacoes.AtualizarRegistros(locacoes);
        }

        public UserControl ObterTabela()
        {
            List<Locacao> locacoes = (List<Locacao>)locacaoService.SelecionarTodos();

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
                locacaoService.RegistrarDevolucao(tela.Locacao);

                //controladorTaxasServicos.ExcluirTaxaUsada(tela.Locacao);

                //controladorTaxasServicos.InserirNovaTaxaUsada(tela.Locacao);

                veiculoService.AtualizarQuilometragem(tela.Locacao.Veiculo);

                tela.Locacao.Veiculo.EstaAlugado = false;

                veiculoService.AtualizarStatusAluguel(tela.Locacao.Veiculo);

                tela.Locacao.Cliente.TemLocacaoAtiva = false;

                clienteService.AtualizarStatusLocacaoAtiva(tela.Locacao.Cliente);

                List<Locacao> locacoes = (List<Locacao>)locacaoService.SelecionarTodos();

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
