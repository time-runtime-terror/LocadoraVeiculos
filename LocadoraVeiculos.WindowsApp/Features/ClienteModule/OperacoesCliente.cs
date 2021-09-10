using LocadoraVeiculos.netCore.Controladores.ClienteModule;
using LocadoraVeiculos.netCore.Controladores.Shared;
using LocadoraVeiculos.netCore.Dominio.ClienteModule;
using LocadoraVeiculos.WindowsApp.Shared;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace LocadoraVeiculos.WindowsApp.Features.ClienteModule
{
    public class OperacoesCliente : ICadastravel
    {
        private readonly ControladorCliente controladorCliente;
        private readonly TabelaClienteControl tabelaClientes;

        public OperacoesCliente()
        {
            controladorCliente = new ControladorCliente();
            tabelaClientes = new TabelaClienteControl();
        }

        public void InserirNovoRegistro()
        {
            TelaClienteForm tela = new TelaClienteForm();

            if (tela.ShowDialog() == DialogResult.OK)
            {
                controladorCliente.InserirNovo(tela.Cliente);

                List<Cliente> clientes = controladorCliente.SelecionarTodos();

                tabelaClientes.AtualizarRegistros(clientes);

                Dashboard.Instancia.AtualizarRodape($"Cliente: [{tela.Cliente.Nome}] inserido com sucesso!");
            }
        }

        public void EditarRegistro()
        {
            int id = tabelaClientes.ObtemIdSelecionado();

            if (id == 0)
            {
                Dashboard.Instancia.AtualizarRodape("Selecione um cliente para poder editar!");
                return;
            }

            Cliente clienteSelecionado = controladorCliente.SelecionarPorId(id);

            TelaClienteForm tela = new TelaClienteForm();

            tela.Cliente = clienteSelecionado;

            if (tela.ShowDialog() == DialogResult.OK)
            {
                controladorCliente.Editar(id, tela.Cliente);

                List<Cliente> clientes = controladorCliente.SelecionarTodos();

                tabelaClientes.AtualizarRegistros(clientes);

                Dashboard.Instancia.AtualizarRodape($"Cliente: [{tela.Cliente.Nome}] inserido com sucesso");
            }
        }

        public void ExcluirRegistro()
        {
            int id = tabelaClientes.ObtemIdSelecionado();

            if (id == 0)
            {
                Dashboard.Instancia.AtualizarRodape($"Selecione um registro para poder excluir!");
                return;
            }

            Cliente clienteSelecionado = controladorCliente.SelecionarPorId(id);

            if (clienteSelecionado.TemLocacaoAtiva)
            {
                Dashboard.Instancia.AtualizarRodape($"Cliente: [{clienteSelecionado}] não pôde ser excluído pois está em uma locação ativa!");
                return;
            }

            if (MessageBox.Show($"Tem certeza que deseja excluir o cliente: [{clienteSelecionado.Nome}] ?",
                "Exclusão de Clientes", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                controladorCliente.Excluir(id);

                List<Cliente> clientes = controladorCliente.SelecionarTodos();

                tabelaClientes.AtualizarRegistros(clientes);
            }
        }

        public void FiltrarRegistros()
        {
            FiltroClienteForm telaFiltro = new FiltroClienteForm();

            if (telaFiltro.ShowDialog() == DialogResult.OK)
            {
                List<Cliente> clientes = new List<Cliente>();


                switch (telaFiltro.TipoFiltro)
                {
                    case FiltroClienteEnum.PessoasFisicas:
                        clientes = controladorCliente.SelecionarTodasPessoasFisicas();
                        break;

                    case FiltroClienteEnum.PessoasJuridicas:
                        clientes = controladorCliente.SelecionarTodasPessoasJuridicas();
                        break;

                    default:
                        break;
                }

                tabelaClientes.AtualizarRegistros(clientes);
            }
        }

        public void AgruparRegistros()
        {
            throw new NotImplementedException();
        }

        public void DesagruparRegistros()
        {
            var clientes = controladorCliente.SelecionarTodos();

            tabelaClientes.AtualizarRegistros(clientes);
        }

        public UserControl ObterTabela()
        {
            List<Cliente> clientes = controladorCliente.SelecionarTodos();

            tabelaClientes.AtualizarRegistros(clientes);

            return tabelaClientes;
        }

        public void Pesquisar(string text)
        {
            List<Cliente> clientesSelecionados = controladorCliente.Pesquisar(text);

            tabelaClientes.AtualizarRegistros(clientesSelecionados);
        }
    }
}
