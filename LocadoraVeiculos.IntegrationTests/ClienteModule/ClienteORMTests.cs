using FluentAssertions;
using LocadoraVeiculos.Infra.ORM;
using LocadoraVeiculos.Infra.ORM.Modules.ClienteModule;
using LocadoraVeiculos.netCore.Dominio.ClienteModule;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace LocadoraVeiculos.IntegrationTests.ClienteModule
{
    [TestClass]
    [TestCategory("ORM")]

    public class ClienteORMTests
    {

        private readonly IClienteRepository clienteRepository;
        private readonly LocadoraDbContext dbContext;

        public ClienteORMTests()
        {
            dbContext = new LocadoraDbContext();
            clienteRepository = new ClienteRepositoryEF(dbContext);
            DeletarLinhasTabela();
        }

        public void DeletarLinhasTabela()
        {
            var list = dbContext.Clientes;
            dbContext.Clientes.RemoveRange(list);
        }

        [TestMethod]
        public void DeveInserir_Cliente()
        {
            // arrange
            Cliente empresa = new Cliente("Tiago Santini", "testador@ndd.com", "Maria de Melo Kuster", "(49) 9805-6251", "CNPJ", "", null, "41421412412", "", null);
            clienteRepository.InserirNovo(empresa);

            Cliente cliente = new Cliente("Tiago Santini", "testador@ndd.com", "Maria de Melo Kuster", "(49) 9805-6251", "CPF", "123123124", new DateTime(2025, 06, 30), "41421412412", "41242121412", empresa);

            // action
            clienteRepository.InserirNovo(cliente);

            // assert
            var clienteEncontrado = clienteRepository.SelecionarPorId(cliente.Id);
            clienteEncontrado.Should().Be(cliente);
        }

        [TestMethod]
        public void DeveEditar_Cliente()
        {
            // arrange
            Cliente empresa = new Cliente("Tiago Santini", "testador@ndd.com", "Maria de Melo Kuster", "(49) 9805-6251", "CNPJ", "", null, "41421412412", "", null);
            clienteRepository.InserirNovo(empresa);

            Cliente cliente = new Cliente("Tiago Santini", "testador@ndd.com", "Maria de Melo Kuster", "(49) 9805-6251", "CPF", "123123124", new DateTime(2025, 06, 30), "41421412412", "41242121412", empresa);

            clienteRepository.InserirNovo(cliente);

            Cliente novoCliente = new Cliente("Tiago Santini Atualizado", "testadoratt@ndd.com", "Maria de Melo Kuster", "(49) 9805-6251", "CPF", "123123124", new DateTime(2025, 06, 30), "41421412412", "41242121412", null);

            // action
            clienteRepository.Editar(cliente.Id, novoCliente);

            // assert
            var clienteEncontrado = clienteRepository.SelecionarPorId(cliente.Id);
            clienteEncontrado.Should().Be(novoCliente);
        }

        [TestMethod]
        public void DeveExcluir_Cliente()
        {
            // arrange
            Cliente cliente = new Cliente("Tiago Santini", "testador@ndd.com", "Maria de Melo Kuster", "(49) 9805-6251", "CPF", "123123124", new DateTime(2025, 06, 30), "41421412412", "41242121412", null);

            clienteRepository.InserirNovo(cliente);

            // action
            clienteRepository.Excluir(cliente.Id);

            // assert
            Cliente clienteEncontrado = clienteRepository.SelecionarPorId(cliente.Id);
            clienteEncontrado.Should().BeNull();
        }

        [TestMethod]
        public void DeveSelecionar_Cliente_PorId()
        {
            // arrange

            Cliente cliente = new Cliente("Tiago Santini", "testador@ndd.com", "Maria de Melo Kuster", "(49) 9805-6251", "CPF", "123123124", new DateTime(2025, 06, 30), "41421412412", "41242121412", null);

            clienteRepository.InserirNovo(cliente);

            // action
            Cliente clienteEncontrado = clienteRepository.SelecionarPorId(cliente.Id);

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
                clienteRepository.InserirNovo(c);

            // action
            var clientesEncontrados = clienteRepository.SelecionarTodos();

            // assert
            clientesEncontrados.Should().HaveCount(2);
        }
    }
}
