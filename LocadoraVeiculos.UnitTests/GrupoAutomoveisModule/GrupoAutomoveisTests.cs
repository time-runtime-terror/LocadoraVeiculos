using LocadoraVeiculos.netCore.Dominio.GrupoAutomoveisModule;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FluentAssertions;

namespace LocadoraVeiculos.UnitTests.GrupoAutomoveisModule
{
    [TestClass]
    public class GrupoAutomoveisTests
    {
        [TestMethod]
        public void DeveValidar_GrupoAutomoveis()
        {
            // arrange
            GrupoAutomoveis grupoAutomoveis = new GrupoAutomoveis("Economico", 120, 140, 180,
                200, 100, 90);

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
                200, 100, 90);

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
                200, 100, 90);

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
                200, 100, 90);

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
