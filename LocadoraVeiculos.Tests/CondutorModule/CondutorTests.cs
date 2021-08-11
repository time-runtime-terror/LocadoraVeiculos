using FluentAssertions;
using LocadoraVeiculos.Dominio.CondutorModule;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace LocadoraVeiculos.Tests.CondutorModule
{
    [TestClass]
    [TestCategory("Dominio")]
    public class CondutorTests
    {
        [TestMethod]
        public void DeveValidar_Condutor()
        {
            // arrange
            Condutor condutor = new Condutor("Tiago Santini", "2321324", "01134954920", "959529390", new DateTime(2025, 06, 30));

            // action
            string resultadoValidacao = condutor.Validar();

            // assert
            resultadoValidacao.Should().Be("ESTA_VALIDO");
        }

        [TestMethod]
        public void NaoDeveValidar_NomeVazio()
        {
            // arrange
            Condutor condutor = new Condutor("", "2321324", "01134954920", "959529390", new DateTime(2025, 06, 30));

            // action
            string resultadoValidacao = condutor.Validar();

            // assert
            resultadoValidacao.Should().Be("O campo Nome é obrigatório");
        }

        [TestMethod]
        public void NaoDeveValidar_CNHVazio()
        {
            // arrange
            Condutor condutor = new Condutor("Tiago Santini", "", "01134954920", "959529390", new DateTime(2025, 06, 30));

            // action
            string resultadoValidacao = condutor.Validar();

            // assert
            resultadoValidacao.Should().Be("O campo CNH é obrigatório");
        }

        [TestMethod]
        public void NaoDeveValidar_CPFVazio()
        {
            // arrange
            Condutor condutor = new Condutor("Tiago Santini", "2321324", "", "959529390", new DateTime(2025, 06, 30));

            // action
            string resultadoValidacao = condutor.Validar();

            // assert
            resultadoValidacao.Should().Be("O campo CPF é obrigatório");
        }

        [TestMethod]
        public void NaoDeveValidar_RGVazio()
        {
            // arrange
            Condutor condutor = new Condutor("Tiago Santini", "2321324", "", "01134954920", new DateTime(2025, 06, 30));

            // action
            string resultadoValidacao = condutor.Validar();

            // assert
            resultadoValidacao.Should().Be("O campo RG é obrigatório");
        }
    }
}
