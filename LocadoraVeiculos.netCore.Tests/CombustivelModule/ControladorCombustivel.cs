using Microsoft.VisualStudio.TestTools.UnitTesting;
using LocadoraVeiculos.netCore.Dominio.CombustivelModule;
using LocadoraVeiculos.netCore.Controladores.CombustivelModule;
using FluentAssertions;

namespace LocadoraVeiculos.netCore.Tests.CombustivelModule
{
    [TestClass]
    [TestCategory("Controladores")]
    public class ControladorCombustivelTests
    {

        private ControladorCombustivel controlador;
        public ControladorCombustivelTests()
        {
            controlador = new ControladorCombustivel();

        }
        [TestMethod]
        public void DeveGravar_Combustivel()
        {
            // arrange
            Combustivel combustivel = new Combustivel(2, 3.4, 5, 7.8);

            // action
            string resultado = controlador.GravarCombustivel(combustivel);

            // assert
            resultado.Should().Be("ESTA_VALIDO");
            
        }

        [TestMethod]
        public void DeveSelecionar_Gasolina()
        {
            // arrange
            Combustivel combustivel = new Combustivel(3, 3.4, 5, 7.8);
            controlador.GravarCombustivel(combustivel);
            // action
            var gasolina = controlador.PegarValorGasolina();

            // assert
            gasolina.Should().Be("3");

        }

        [TestMethod]
        public void DeveSelecionar_Etanol()
        {
            // arrange
            Combustivel combustivel = new Combustivel(3, 3.4, 5, 7.8);
            controlador.GravarCombustivel(combustivel);

            // action
            var etanol = controlador.PegarValorEtanol();

            // assert
            etanol.Should().Be("3,4");

        }

        [TestMethod]
        public void DeveSelecionar_Diesel()
        {
            // arrange
            Combustivel combustivel = new Combustivel(3, 3.4, 5, 7.8);
            controlador.GravarCombustivel(combustivel);

            // action
            var diesel = controlador.PegarValorDiesel();

            // assert
            diesel.Should().Be("5");
        }

        [TestMethod]
        public void DeveSelecionar_Gnv()
        {
            // arrange
            Combustivel combustivel = new Combustivel(3, 3.4, 5, 7.8);
            controlador.GravarCombustivel(combustivel);

            // action
            var gnv = controlador.PegarValorGnv();

            // assert
            gnv.Should().Be("7,8");

        }
    }
}
