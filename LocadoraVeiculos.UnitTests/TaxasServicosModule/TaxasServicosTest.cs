using FluentAssertions;
using LocadoraVeiculos.netCore.Dominio.TaxasServicosModule;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace LocadoraVeiculos.UnitTests.TaxasServicosModule
{
    [TestClass]
    [TestCategory("Dominio/TaxasServicos")]
    public class TaxasServicosTest
    {
        [TestMethod]
        public void DeveValidar_TaxasServicos()
        {
            // arrange
            TaxasServicos taxasServicos = new TaxasServicos("GPS", 200, "Fixo", "Locação");

            // action
            string validacao = taxasServicos.Validar();

            // assert
            validacao.Should().Be("ESTA_VALIDO");
        }

        [TestMethod]
        public void NaoDeveValidar_ServicoVazio()
        {
            // arrange
            TaxasServicos taxasServicos = new TaxasServicos("", 100, "Fixo", "Locação");

            // action
            string validacao = taxasServicos.Validar();

            // assert
            validacao.Should().Be("O campo Serviço é obrigatório");
        }

        [TestMethod]
        public void NaoDeveValidar_TaxaVazia()
        {
            // arrange
            TaxasServicos taxasServicos = new TaxasServicos("GPS", 0, "Fixo", "Locação");

            // action
            string validacao = taxasServicos.Validar();

            // assert
            validacao.Should().Be("O campo Taxa é obrigatório");
        }

        [TestMethod]
        public void NaoDeveValidar_TodasAsTaxas()
        {
            // arrange
            TaxasServicos taxasServicos = new TaxasServicos(null, 0, null, null);

            // action
            string validacao = taxasServicos.Validar();

            string resultado = "O campo Serviço é obrigatório"
                + Environment.NewLine
                + "O campo Taxa é obrigatório"
                + Environment.NewLine
                + "O campo tipo do serviço é obrigatório"
                + Environment.NewLine
                + "O local do serviço é obrigatório";

            // assert
            validacao.Should().Be(resultado);
        }
    }
}
