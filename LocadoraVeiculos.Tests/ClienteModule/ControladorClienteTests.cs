using LocadoraVeiculos.Controladores.Shared;
using LocadoraVeiculos.Controladores.ClienteModule;
using LocadoraVeiculos.Controladores.CondutorModule;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using LocadoraVeiculos.Dominio.ClienteModule;
using FluentAssertions;
using LocadoraVeiculos.Dominio.CondutorModule;
using System.Collections.Generic;

namespace LocadoraVeiculos.Tests.ClienteModule
{
    [TestClass]
    [TestCategory("Controladores")]
    public class ControladorClienteTests
    {
        private ControladorCliente controladorCliente;
        private ControladorCondutor controladorCondutor;

        public ControladorClienteTests()
        {
            controladorCondutor = new ControladorCondutor();
            controladorCliente = new ControladorCliente(controladorCondutor);

            Db.Update("DELETE FROM [TBCLIENTE]");
            Db.Update("DELETE FROM [TBCONDUTOR]");
        }

        [TestMethod]
        public void DeveInserir_Cliente()
        {
            // arrange
            Condutor condutor = new Condutor("Tiago Jr.", "99999999", "9999999999", "9999999", new DateTime(2025, 06, 30));
            controladorCondutor.InserirNovo(condutor);

            Cliente cliente = new Cliente("Tiago Santini", "Maria de Melo Kuster 276", "49985056251", "Física", "999999999", new DateTime(2025, 06, 30), "0310231235", "", "66622446", condutor);

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
            Condutor condutor = new Condutor("Tiago Jr.", "99999999", "9999999999", "9999999", new DateTime(2025, 06, 30));
            controladorCondutor.InserirNovo(condutor);

            Cliente cliente = new Cliente("Tiago Santini", "Maria de Melo Kuster 276", "49985056251", "Física", "999999999", new DateTime(2025, 06, 30), "0310231235", "", "66622446", condutor);

            controladorCliente.InserirNovo(cliente);

            Cliente novoCliente = new Cliente("Tiago Santini Att", "Maria de Melo Kuster 276", "49985056251", "Física", "999999999", new DateTime(2025, 06, 30), "0310231235", "", "66622446", condutor);

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
            Condutor condutor = new Condutor("Tiago Jr.", "99999999", "9999999999", "9999999", new DateTime(2025, 06, 30));
            controladorCondutor.InserirNovo(condutor);

            Cliente cliente = new Cliente("Tiago Santini", "Maria de Melo Kuster 276", "49985056251", "Física", "999999999", new DateTime(2025, 06, 30), "0310231235", "", "66622446", condutor);

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
            Condutor condutor = new Condutor("Tiago Jr.", "99999999", "9999999999", "9999999", new DateTime(2025, 06, 30));
            controladorCondutor.InserirNovo(condutor);

            Cliente cliente = new Cliente("Tiago Santini", "Maria de Melo Kuster 276", "49985056251", "Física", "999999999", new DateTime(2025, 06, 30), "0310231235", "", "66622446", condutor);

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
                new Cliente("Testador 1", "Maria de Melo Kuster 276", "49985056251", "Física", "999999999", new DateTime(2025, 06, 30), "0310231235", "", "66622446", null),

                new Cliente("Testador 2", "Maria de Melo Kuster 276", "49985056251", "Física", "999999999", new DateTime(2025, 06, 30), "0310231235", "", "66622446", null)
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
