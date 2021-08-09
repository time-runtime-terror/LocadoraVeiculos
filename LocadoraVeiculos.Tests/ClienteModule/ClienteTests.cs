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
            Cliente cliente = new Cliente("Tiago", "Maria de Melo Kuster, 276", "985056251", "Física",
                "1292132321", new DateTime(2025, 07, 30), "123151567", "", "8242566", null);

            // action
            string validacao = cliente.Validar();

            // assert
            validacao.Should().Be("ESTA_VALIDO");
        }

        [TestMethod]
        public void NaoDeveValidar_NomeVazio()
        {
            // arrange
            Cliente cliente = new Cliente("", "Maria de Melo Kuster, 276", "985056251", "Física",
                "1292132321", new DateTime(2025, 07, 30), "123151567", "", "8242566", null);

            // action
            string validacao = cliente.Validar();

            // assert
            validacao.Should().Be("O campo Nome é obrigatório");
        }

        [TestMethod]
        public void NaoDeveValidar_EnderecoVazio()
        {
            // arrange
            Cliente cliente = new Cliente("Tiago", "", "985056251", "Física",
                "1292132321", new DateTime(2025, 07, 30), "123151567", "", "8242566", null);

            // action
            string validacao = cliente.Validar();

            // assert
            validacao.Should().Be("O campo Endereço é obrigatório");
        }

        [TestMethod]
        public void NaoDeveValidar_TelefoneVazio()
        {
            // arrange
            Cliente cliente = new Cliente("Tiago", "Maria de Melo Kuster, 276", "", "Física",
                "1292132321", new DateTime(2025, 07, 30), "123151567", "", "8242566", null);

            // action
            string validacao = cliente.Validar();

            // assert
            validacao.Should().Be("O campo Telefone é obrigatório");
        }

        [TestMethod]
        public void NaoDeveValidar_CamposVazios()
        {
            // arrange
            Cliente cliente = new Cliente("", "", "", "Física",
                "1292132321", new DateTime(2025, 07, 30), "123151567", "", "8242566", null);

            // action
            string validacao = cliente.Validar();

            string camposEsperados = "O campo Nome é obrigatório"
                + Environment.NewLine
                + "O campo Endereço é obrigatório"
                + Environment.NewLine
                + "O campo Telefone é obrigatório";

            // assert
            validacao.Should().Be(camposEsperados);
        }
    }
}
