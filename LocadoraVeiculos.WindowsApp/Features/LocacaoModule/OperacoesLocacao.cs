using LocadoraVeiculos.Controladores.ClienteModule;
using LocadoraVeiculos.Controladores.LocacaoModule;
using LocadoraVeiculos.Controladores.TaxasServicosModule;
using LocadoraVeiculos.Controladores.VeiculoModule;
using LocadoraVeiculos.Dominio.LocacaoModule;
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

        public OperacoesLocacao()
        {
            controladorTaxasServicos = new ControladorTaxasServicos();

            controladorLocacao = new ControladorLocacao(new ControladorCliente(), new ControladorVeiculo(), controladorTaxasServicos);

            tabelaLocacoes = new TabelaLocacaoControl();
        }

        public void InserirNovoRegistro()
        {
            TelaCadastrarLocacaoForm tela = new TelaCadastrarLocacaoForm();

            if (tela.ShowDialog() == DialogResult.OK)
            {
                controladorLocacao.InserirNovo(tela.Locacao);

                controladorTaxasServicos.InserirNovaTaxaUsada(tela.Locacao);

                List<Locacao> locacoes = controladorLocacao.SelecionarTodos();

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
            throw new NotImplementedException();
        }

        public void AgruparRegistros()
        {
            throw new NotImplementedException();
        }

        public void DesagruparRegistros()
        {
            throw new NotImplementedException();
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
                //controladorLocacao.Editar(id, tela.Locacao);
                controladorLocacao.RegistrarDevolucao(tela.Locacao);

                controladorTaxasServicos.ExcluirTaxaUsada(tela.Locacao);

                controladorTaxasServicos.InserirNovaTaxaUsada(tela.Locacao);

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
