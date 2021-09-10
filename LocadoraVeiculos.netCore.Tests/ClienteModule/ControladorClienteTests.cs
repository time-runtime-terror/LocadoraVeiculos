using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using FluentAssertions;
using System.Collections.Generic;
using LocadoraVeiculos.netCore.Controladores.ClienteModule;
using LocadoraVeiculos.netCore.Controladores.Shared;
using LocadoraVeiculos.netCore.Dominio.ClienteModule;

namespace LocadoraVeiculos.Tests.ClienteModule
{
    [TestClass]
    [TestCategory("Controladores")]
    public class ControladorClienteTests
    {
        private ControladorCliente controladorCliente;

        public ControladorClienteTests()
        {
            controladorCliente = new ControladorCliente();

            Db.Update("DELETE FROM [TBCLIENTE]");
            Db.Update("DELETE FROM [TBFUNCIONARIO]");
        }

        [TestMethod]
        public void DeveInserir_Cliente()
        {
            // arrange
            Cliente empresa = new Cliente("Tiago Santini", "testador@ndd.com", "Maria de Melo Kuster", "(49) 9805-6251", "CNPJ", "", null, "41421412412", "", null);
            controladorCliente.InserirNovo(empresa);

            Cliente cliente = new Cliente("Tiago Santini", "testador@ndd.com", "Maria de Melo Kuster", "(49) 9805-6251", "CPF", "123123124", new DateTime(2025, 06, 30), "41421412412", "41242121412", empresa);

            // action
            controladorCliente.InserirNovo(cliente);

            // assert
            var clienteEncontrado = controladorCliente.SelecionarPorId(cliente.Id);
            clienteEncontrado.Should().Be(cliente);
        }

        [TestMethod]
        public void DeveEditar_Cliente()
        {
            // arrange
            Cliente empresa = new Cliente("Tiago Santini", "testador@ndd.com", "Maria de Melo Kuster", "(49) 9805-6251", "CNPJ", "", null, "41421412412", "", null);
            controladorCliente.InserirNovo(empresa);

            Cliente cliente = new Cliente("Tiago Santini", "testador@ndd.com", "Maria de Melo Kuster", "(49) 9805-6251", "CPF", "123123124", new DateTime(2025, 06, 30), "41421412412", "41242121412", empresa);

            controladorCliente.InserirNovo(cliente);

            Cliente novoCliente = new Cliente("Tiago Santini Atualizado", "testadoratt@ndd.com", "Maria de Melo Kuster", "(49) 9805-6251", "CPF", "123123124", new DateTime(2025, 06, 30), "41421412412", "41242121412", null);

            // action
            controladorCliente.Editar(cliente.Id, novoCliente);

            // assert
            var clienteEncontrado = controladorCliente.SelecionarPorId(cliente.Id);
            clienteEncontrado.Should().Be(novoCliente);
        }

        [TestMethod]
        public void DeveExcluir_Cliente()
        {
            // arrange
            Cliente cliente = new Cliente("Tiago Santini", "testador@ndd.com", "Maria de Melo Kuster", "(49) 9805-6251", "CPF", "123123124", new DateTime(2025, 06, 30), "41421412412", "41242121412", null);

            controladorCliente.InserirNovo(cliente);

            // action
            controladorCliente.Excluir(cliente.Id);

            // assert
            Cliente clienteEncontrado = controladorCliente.SelecionarPorId(cliente.Id);
            clienteEncontrado.Should().BeNull();
        }

        [TestMethod]
        public void DeveSelecionar_Cliente_PorId()
        {
            // arrange

            Cliente cliente = new Cliente("Tiago Santini", "testador@ndd.com", "Maria de Melo Kuster", "(49) 9805-6251", "CPF", "123123124", new DateTime(2025, 06, 30), "41421412412", "41242121412", null);

            controladorCliente.InserirNovo(cliente);

            // action
            Cliente clienteEncontrado = controladorCliente.SelecionarPorId(cliente.Id);

            // assert
            clienteEncontrado.Should().NotBeNull();
        }

        [TestMethod]
        public void DeveSelecionar_Todos_Clientes()
        {
            // arrange
            var clientes = new List<Cliente>
            {
                new Cliente("Testador 1", "testador@ndd.com", "Maria de Melo Kuster", "(49) 9805-6251", "CPF", "123123124", new DateTime(2025, 06, 30), "41421412412", "41242121412", null),

                new Cliente("Testador 2", "testador@ndd.com", "Maria de Melo Kuster", "(49) 9805-6251", "CPF", "123123124", new DateTime(2025, 06, 30), "41421412412", "41242121412", null)
            };

            foreach (var c in clientes)
                controladorCliente.InserirNovo(c);

            // action
            var clientesEncontrados = controladorCliente.SelecionarTodos();

            // assert
            clientesEncontrados.Should().HaveCount(2);
        }
    }
}
