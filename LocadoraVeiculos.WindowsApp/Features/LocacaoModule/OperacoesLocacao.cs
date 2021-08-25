using LocadoraVeiculos.Controladores.ClienteModule;
using LocadoraVeiculos.Controladores.LocacaoModule;
using LocadoraVeiculos.Controladores.TaxasServicosModule;
using LocadoraVeiculos.Controladores.VeiculoModule;
using LocadoraVeiculos.Dominio.LocacaoModule;
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

                Dashboard.Instancia.AtualizarRodape($"Locação: [{tela.Locacao.Id}] inserido com sucesso!");
            }
        }

        public void EditarRegistro()
        {
            throw new NotImplementedException();
        }

        public void ExcluirRegistro()
        {
            throw new NotImplementedException();
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

        public void Pesquisar(string text)
        {
            throw new NotImplementedException();
        }
    }
}
