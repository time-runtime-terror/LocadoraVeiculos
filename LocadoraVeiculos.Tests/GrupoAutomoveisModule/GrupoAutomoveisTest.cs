using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using LocadoraVeiculos.Dominio.GrupoAutomoveisModule;
using FluentAssertions;

namespace LocadoraVeiculos.Tests.GrupoAutomoveisModule
{
    [TestClass]
    [TestCategory("Dominio")]
    public class GrupoAutomoveisTest
    {

        [TestMethod]
        public void DeveValidar_GrupoAutomoveis()
        {
            // arrange
            GrupoAutomoveis grupoAutomoveis = new GrupoAutomoveis("Economico", 120, 140, 180,
                200, 90, 110);

            // action
            string validacao = grupoAutomoveis.Validar();

            // assert
            validacao.Should().Be("ESTA_VALIDO");
        }

        [TestMethod]
        public void NaoDeveValidar_NomeGrupoVazio()
        {
            // arrange
            GrupoAutomoveis grupoAutomoveis = new GrupoAutomoveis("", 120, 140, 180,
                200, 90, 110);

            // action
            string validacao = grupoAutomoveis.Validar();

            // assert
            validacao.Should().Be("O campo Nome do Grupo de Automóveis é obrigatório");
        }

        [TestMethod]
        public void NaoDeveValidar_PlanoDiarioUmVazio()
        {
            // arrange
            GrupoAutomoveis grupoAutomoveis = new GrupoAutomoveis("Suv", 0, 140, 180,
                200, 90, 110);

            // action
            string validacao = grupoAutomoveis.Validar();

            // assert
            validacao.Should().Be("O campo Plano Diário é obrigatório");
        }

        [TestMethod]
        public void NaoDeveValidar_KmControladoUmVazio()
        {
            // arrange
            GrupoAutomoveis grupoAutomoveis = new GrupoAutomoveis("Suv", 120, 140, 0,
                200, 90, 110);

            // action
            string validacao = grupoAutomoveis.Validar();

            // assert
            validacao.Should().Be("O campo Quilometro Controlado é obrigatório");
        }

        [TestMethod]
        public void NaoDeveValidar_KmLivreUmVazio()
        {
            // arrange
            GrupoAutomoveis grupoAutomoveis = new GrupoAutomoveis("Suv", 120, 140, 180,
                200, 0, 110);

            // action
            string validacao = grupoAutomoveis.Validar();

            // assert
            validacao.Should().Be("O campo Quilometro Livre é obrigatório");
        }
    }
}
