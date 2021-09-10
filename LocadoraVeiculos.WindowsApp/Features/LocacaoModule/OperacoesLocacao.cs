using LocadoraVeiculos.netCore.Controladores.ClienteModule;
using LocadoraVeiculos.netCore.Controladores.LocacaoModule;
using LocadoraVeiculos.netCore.Controladores.TaxasServicosModule;
using LocadoraVeiculos.netCore.Controladores.VeiculoModule;
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
        private readonly ControladorLocacao controladorLocacao;
        private readonly ControladorTaxasServicos controladorTaxasServicos;
        private readonly TabelaLocacaoControl tabelaLocacoes;
        private readonly ControladorVeiculo controladorVeiculo;
        private readonly ControladorCliente controladorCliente;

        public OperacoesLocacao()
        {
            controladorTaxasServicos = new ControladorTaxasServicos();

            controladorLocacao = new ControladorLocacao(new ControladorCliente(), new ControladorVeiculo(), controladorTaxasServicos);

            tabelaLocacoes = new TabelaLocacaoControl();

            controladorVeiculo = new ControladorVeiculo();

            controladorCliente = new ControladorCliente();
        }

        public void InserirNovoRegistro()
        {
            TelaCadastrarLocacaoForm tela = new TelaCadastrarLocacaoForm();

            if (tela.ShowDialog() == DialogResult.OK)
            {
                controladorLocacao.InserirNovo(tela.Locacao);

                controladorTaxasServicos.InserirNovaTaxaUsada(tela.Locacao);

                List<Locacao> locacoes = controladorLocacao.SelecionarTodos();

                tela.Locacao.Veiculo.EstaAlugado = true;

                controladorVeiculo.AtualizarStatusAluguel(tela.Locacao.Veiculo);

                tela.Locacao.Cliente.TemLocacaoAtiva = true;

                controladorCliente.AtualizarStatusLocacaoAtiva(tela.Locacao.Cliente);

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

            Locacao locacaoSelecionada = controladorLocacao.SelecionarPorId(id);

            TelaCadastrarLocacaoForm tela = new TelaCadastrarLocacaoForm();

            tela.Locacao = locacaoSelecionada;

            if (tela.ShowDialog() == DialogResult.OK)
            {
                controladorLocacao.Editar(id, tela.Locacao);

                controladorTaxasServicos.ExcluirTaxaUsada(tela.Locacao);

                controladorTaxasServicos.InserirNovaTaxaUsada(tela.Locacao);

                List<Locacao> locacoes = controladorLocacao.SelecionarTodos();

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

            Locacao locacaoSelecionada = controladorLocacao.SelecionarPorId(id);

            if (MessageBox.Show($"Tem certeza que deseja excluir a locação: [{locacaoSelecionada.Id}] ?",
                "Exclusão de Locações", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                controladorLocacao.Excluir(id);

                controladorTaxasServicos.ExcluirTaxaUsada(locacaoSelecionada);

                List<Locacao> locacoes = controladorLocacao.SelecionarTodos();

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
                        locacoes = controladorLocacao.SelecionarTodasLocacoesConcluidas();
                        break;

                    case FiltroLocacaoEnum.LocacoesPendentes:
                        locacoes = controladorLocacao.SelecionarTodasLocacoesPendentes();
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
            var locacoes = controladorLocacao.SelecionarTodos();

            tabelaLocacoes.AtualizarRegistros(locacoes);
        }

        public UserControl ObterTabela()
        {
            List<Locacao> locacoes = controladorLocacao.SelecionarTodos();

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

            Locacao locacaoSelecionada = controladorLocacao.SelecionarPorId(id);

            TelaRegistrarDevolucaoForm tela = new TelaRegistrarDevolucaoForm();

            tela.Locacao = locacaoSelecionada;

            if (tela.ShowDialog() == DialogResult.OK)
            {
                controladorLocacao.RegistrarDevolucao(tela.Locacao);

                controladorTaxasServicos.ExcluirTaxaUsada(tela.Locacao);

                controladorTaxasServicos.InserirNovaTaxaUsada(tela.Locacao);

                controladorVeiculo.AtualizarQuilometragem(tela.Locacao.Veiculo);

                tela.Locacao.Veiculo.EstaAlugado = false;

                controladorVeiculo.AtualizarStatusAluguel(tela.Locacao.Veiculo);

                tela.Locacao.Cliente.TemLocacaoAtiva = false;

                controladorCliente.AtualizarStatusLocacaoAtiva(tela.Locacao.Cliente);

                List<Locacao> locacoes = controladorLocacao.SelecionarTodos();

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
