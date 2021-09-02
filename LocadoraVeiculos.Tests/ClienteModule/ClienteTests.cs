using Microsoft.VisualStudio.TestTools.UnitTesting;
using FluentAssertions;
using LocadoraVeiculos.Dominio.ClienteModule;
using System;

namespace LocadoraVeiculos.Tests.ClienteModule
{
    [TestClass]
    [TestCategory("Dominio")]
    public class ClienteTests
    {

        [TestMethod]
        public void DeveValidar_Cliente()
        {
            // arrange
            Cliente cliente = new Cliente("Testador 1", "testador@ndd.com", "Maria de Melo Kuster", "(49) 9805-6251", "CPF", "123123124", new DateTime(2025, 06, 30), "41421412412", "41242121412", null);

            // action
            string validacao = cliente.Validar();

            // assert
            validacao.Should().Be("ESTA_VALIDO");
        }

        [TestMethod]
        public void NaoDeveValidar_NomeVazio()
        {
            // arrange
            Cliente cliente = new Cliente("", "testador@ndd.com", "Maria de Melo Kuster", "(49) 9805-6251", "CPF", "123123124", new DateTime(2025, 06, 30), "41421412412", "41242121412", null);

            // action
            string validacao = cliente.Validar();

            // assert
            validacao.Should().Be("O campo Nome é obrigatório");
        }

        [TestMethod]
        public void NaoDeveValidar_EnderecoVazio()
        {
            // arrange
            Cliente cliente = new Cliente("Testador 1", "testador@ndd.com", "", "(49) 9805-6251", "CPF", "123123124", new DateTime(2025, 06, 30), "41421412412", "41242121412", null);

            // action
            string validacao = cliente.Validar();

            // assert
            validacao.Should().Be("O campo Endereço é obrigatório");
        }

        [TestMethod]
        public void NaoDeveValidar_TelefoneVazio()
        {
            // arrange
            Cliente cliente = new Cliente("Testador 1", "testador@ndd.com", "Maria de Melo Kuster", "", "CPF", "123123124", new DateTime(2025, 06, 30), "41421412412", "41242121412", null);

            // action
            string validacao = cliente.Validar();

            // assert
            validacao.Should().Be("O campo Telefone é obrigatório");
        }

        [TestMethod]
        public void NaoDeveValidar_CamposVazios()
        {
            // arrange
            Cliente cliente = new Cliente("", "", "", "", "CPF", "123123124", new DateTime(2025, 06, 30), "41421412412", "41242121412", null);

            // action
            string validacao = cliente.Validar();

            string camposEsperados = "O campo Nome é obrigatório"
                + Environment.NewLine
                + "O campo Endereço é obrigatório"
                + Environment.NewLine
                + "O campo Email está inválido"
                + Environment.NewLine
                + "O campo Telefone é obrigatório";

            // assert
            validacao.Should().Be(camposEsperados);
        }
    }
}
