using FluentAssertions;
using LocadoraVeiculos.netCore.Dominio.ParceiroModule;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraVeiculos.UnitTests.ParceiroModule
{
    [TestClass]
    [TestCategory("Dominio/Parceiro")]
    public class ParceiroTests
    {
        [TestMethod]
        public void DeveValidarNome()
        {
            //arrange
            var parceiro = new Parceiro("José");

            //action
            var resultadoValidacao = parceiro.Validar();

            //assert
            resultadoValidacao.Should().Be("ESTA_VALIDO");
        }

        [TestMethod]
        public void NaoDeveValidarNome()
        {
            //arrange
            var fucionario = new Parceiro("");

            //action
            var resultadoValidacao = fucionario.Validar();

            //assert
            resultadoValidacao.Should().Be("O campo Nome é obrigatório");
        }
    }
}
