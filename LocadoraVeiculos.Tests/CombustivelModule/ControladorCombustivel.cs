using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using LocadoraVeiculos.Controladores.CombustivelModule;
using LocadoraVeiculos.Dominio.CombustivelModule;

namespace LocadoraVeiculos.Tests.CombustivelModule
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
            Combustivel combustivel = new Combustivel(2.3, 3.4, 5, 7.8);

            // action
            controlador.GravarCombustivel(combustivel);

            // assert
            var clienteEncontrado = controladorCliente.SelecionarPorId(cliente.Id);
            clienteEncontrado.Should().Be(cliente);
        }
    }
}
