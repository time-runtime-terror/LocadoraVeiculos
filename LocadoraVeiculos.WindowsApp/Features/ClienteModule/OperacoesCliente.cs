using LocadoraVeiculos.Controladores.ClienteModule;
using LocadoraVeiculos.Controladores.CondutorModule;
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
        private readonly ControladorCondutor controladorCondutor;
        private readonly TabelaClienteControl tabelaClientes;

        public OperacoesCliente()
        {
            controladorCondutor = new ControladorCondutor();
            controladorCliente = new ControladorCliente(controladorCondutor);
        }

        public void AgruparRegistros()
        {
            throw new NotImplementedException();
        }

        public void DesagruparRegistros()
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

        public void InserirNovoRegistro()
        {
            TelaClienteForm tela = new TelaClienteForm();

            if (tela.ShowDialog() == DialogResult.OK)
            {

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
