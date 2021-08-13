using LocadoraVeiculos.Controladores.ClienteModule;
using LocadoraVeiculos.Dominio.ClienteModule;
using LocadoraVeiculos.WindowsApp.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        public void AgruparRegistros()
        {
            throw new NotImplementedException();
        }

        public void DesagruparRegistros()
        {
            var clientes = controladorCliente.SelecionarTodos();

            tabelaClientes.AtualizarRegistros(clientes);
        }

        public void EditarRegistro()
        {
            int id = tabelaClientes.ObtemIdSelecionado();

            if (id == 0)
            {
                MessageBox.Show("Selecione um cliente para poder editar!", "Edição de Clientes",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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

                //TelaPrincipalForm.Instancia.AtualizarRodape($"Compromisso: [{tela.Compromisso.Assunto}] editado com sucesso");
            }

        }

        public void ExcluirRegistro()
        {
            int id = tabelaClientes.ObtemIdSelecionado();

            if (id == 0)
            {
                MessageBox.Show("Selecione um cliente para poder excluir!", "Exclusão de Clientes",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            Cliente clienteSelecionado = controladorCliente.SelecionarPorId(id);

            if (MessageBox.Show($"Tem certeza que deseja excluir o cliente: [{clienteSelecionado.Nome}] ?",
                "Exclusão de Clientes", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                controladorCliente.Excluir(id);

                List<Cliente> clientes = controladorCliente.SelecionarTodos();

                tabelaClientes.AtualizarRegistros(clientes);

                //TelaPrincipalForm.Instancia.AtualizarRodape($"Compromisso: [{compromissoSelecionado.Assunto}] removido com sucesso");
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
                        clientes = controladorCliente.SelecionarTodos().FindAll(x => x.TipoCadastro == "CPF");
                        break;

                    case FiltroClienteEnum.PessoasJuridicas:
                        clientes = controladorCliente.SelecionarTodos().FindAll(x => x.TipoCadastro == "CNPJ");
                        break;

                    default:
                        break;
                }

                tabelaClientes.AtualizarRegistros(clientes);
            }
        }

        public void InserirNovoRegistro()
        {
            TelaClienteForm tela = new TelaClienteForm();

            if (tela.ShowDialog() == DialogResult.OK)
            {
                controladorCliente.InserirNovo(tela.Cliente);

                List<Cliente> clientes = controladorCliente.SelecionarTodos();

                tabelaClientes.AtualizarRegistros(clientes);
            }
        }

        public UserControl ObterTabela()
        {
            List<Cliente> clientes = controladorCliente.SelecionarTodos();

            tabelaClientes.AtualizarRegistros(clientes);

            return tabelaClientes;
        }
    }
}
