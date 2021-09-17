using Microsoft.VisualStudio.TestTools.UnitTesting;
using LocadoraVeiculos.netCore.Dominio.CombustivelModule;
using FluentAssertions;
using LocadoraVeiculos.Infra.Configuration.CombustivelModule;

namespace LocadoraVeiculos.IntegrationTests.CombustivelModule
{
    [TestClass]
    [TestCategory("DAO")]
    public class ControladorCombustivelTests
    {

        private CombustivelConfiguration combustivelConfig;
        public ControladorCombustivelTests()
        {
            combustivelConfig = new CombustivelConfiguration();

        }
        [TestMethod]
        public void DeveGravar_Combustivel()
        {
            // arrange
            Combustivel combustivel = new Combustivel(2, 3.4, 5, 7.8);

            // action
            string resultado = combustivelConfig.GravarCombustivel(combustivel);

            // assert
            resultado.Should().Be("ESTA_VALIDO");
            
        }

        [TestMethod]
        public void DeveSelecionar_Gasolina()
        {
            // arrange
            Combustivel combustivel = new Combustivel(3, 3.4, 5, 7.8);
            combustivelConfig.GravarCombustivel(combustivel);
            // action
            var gasolina = combustivelConfig.PegarValorGasolina();

            // assert
            gasolina.Should().Be("3");

        }

        [TestMethod]
        public void DeveSelecionar_Etanol()
        {
            // arrange
            Combustivel combustivel = new Combustivel(3, 3.4, 5, 7.8);
            combustivelConfig.GravarCombustivel(combustivel);

            // action
            var etanol = combustivelConfig.PegarValorEtanol();

            // assert
            etanol.Should().Be("3,4");

        }

        [TestMethod]
        public void DeveSelecionar_Diesel()
        {
            // arrange
            Combustivel combustivel = new Combustivel(3, 3.4, 5, 7.8);
            combustivelConfig.GravarCombustivel(combustivel);

            // action
            var diesel = combustivelConfig.PegarValorDiesel();

            // assert
            diesel.Should().Be("5");
        }

        [TestMethod]
        public void DeveSelecionar_Gnv()
        {
            // arrange
            Combustivel combustivel = new Combustivel(3, 3.4, 5, 7.8);
            combustivelConfig.GravarCombustivel(combustivel);

            // action
            var gnv = combustivelConfig.PegarValorGnv();

            // assert
            gnv.Should().Be("7,8");

        }
    }
}
