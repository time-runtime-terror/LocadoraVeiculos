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
        private readonly TabelaLocacaoControl tabelaLocacoes;

        public OperacoesLocacao()
        {
            controladorLocacao = new ControladorLocacao(new ControladorCliente(), new ControladorVeiculo(), new ControladorTaxasServicos());
        }

        public void InserirNovoRegistro()
        {
            throw new NotImplementedException();
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

            tabelaLocacoes.AtualizarRegistros(clientes);

            return tabelaLocacoes;
        }

        public void Pesquisar(string text)
        {
            throw new NotImplementedException();
        }
    }
}
