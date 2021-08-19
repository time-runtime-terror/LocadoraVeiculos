using FluentAssertions;
using LocadoraVeiculos.Dominio.TaxasServicosModule;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace LocadoraVeiculos.Tests.TaxasServicosModule
{
    [TestClass]
    [TestCategory("Dominio")]
    public class TaxasServicosTest
    {
        [TestMethod]
        public void DeveValidar_TaxasServicos()
        {
            // arrange
            TaxasServicos taxasServicos = new TaxasServicos("GPS", 200, "Fixo");

            // action
            string validacao = taxasServicos.Validar();

            // assert
            validacao.Should().Be("ESTA_VALIDO");
        }

        [TestMethod]
        public void NaoDeveValidar_ServicoVazio()
        {
            // arrange
            TaxasServicos taxasServicos = new TaxasServicos("", 100, "Fixo");

            // action
            string validacao = taxasServicos.Validar();

            // assert
            validacao.Should().Be("O campo Serviço é obrigatório");
        }

        [TestMethod]
        public void NaoDeveValidar_TaxaVazia()
        {
            // arrange
            TaxasServicos taxasServicos = new TaxasServicos("GPS", 0, "Fixo");

            // action
            string validacao = taxasServicos.Validar();

            // assert
            validacao.Should().Be("O campo Taxa é obrigatório");
        }
    }
}
