using FluentAssertions;
using LocadoraVeiculos.netCore.Dominio.GrupoAutomoveisModule;
using LocadoraVeiculos.netCore.Dominio.VeiculoModule;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LocadoraVeiculos.netCore.Dominio.CombustivelModule;
using LocadoraVeiculos.netCore.Controladores.CombustivelModule;
using LocadoraVeiculos.netCore.Controladores.VeiculoModule;
using LocadoraVeiculos.netCore.Controladores.GrupoAutomoveisModule;
using LocadoraVeiculos.netCore.Controladores.Shared;

namespace LocadoraVeiculos.Tests.VeiculoModule
{
    [TestClass]
    [TestCategory("Controladores")]

    public class ControladorVeiculoTest
    {
        ControladorCombustivel controladorCombustivel = null;
        

        ControladorVeiculo controlador = null;
        byte[] imagem = new byte[] { 0x20, 0x20, 0x20, 0x20, 0x20, 0x20, 0x20 };

        ControladorGrupoAutomoveis controlodarGrupoAutomoveis = null;
        GrupoAutomoveis grupoAutomoveis = new GrupoAutomoveis("Economico", 32, 64, 65, 82, 95, 90);

         public ControladorVeiculoTest()
         {
            controlador = new ControladorVeiculo();
            controlodarGrupoAutomoveis = new ControladorGrupoAutomoveis();
            controladorCombustivel = new ControladorCombustivel();
            Db.Update("DELETE FROM [TBVEICULO]");
         }

        [TestMethod]
        public void DeveInserir_Veiculo()
        {
            Combustivel combustivel = new Combustivel(3.0, 4.0, 5.0, 6.0);

            controladorCombustivel.GravarCombustivel(combustivel);

            controlodarGrupoAutomoveis.InserirNovo(grupoAutomoveis);

            //arrange
            Veiculo novoVeiculo = new Veiculo(imagem, "ABC-1234", "Vectra", "Chevrolet", "Gasolina", 70, 2000, grupoAutomoveis);

            //action
            controlador.InserirNovo(novoVeiculo);

            //assert
            Veiculo veiculoEncontrado = controlador.SelecionarPorId(novoVeiculo.Id);
            veiculoEncontrado.Should().Be(novoVeiculo);
        }

        [TestMethod]
        public void DeveEditar_UmVeiculo()
        {
            Combustivel combustivel = new Combustivel(3.0, 4.0, 5.0, 6.0);

            controladorCombustivel.GravarCombustivel(combustivel);

            //arrange
            Veiculo veiculo = new Veiculo(imagem, "ABC-1234", "Vectra", "Chevrolet", "Gasolina", 70, 2000, null);
            controlador.InserirNovo(veiculo);

            Veiculo novoVeiculo = new Veiculo(imagem, "ABC-1234", "Gol", "Volkswagen", "Diesel", 70, 2000, null);

            //action
            controlador.Editar(veiculo.Id, novoVeiculo);

            //assert
            Veiculo veiculoEncontrado = controlador.SelecionarPorId(veiculo.Id);
            veiculoEncontrado.Should().Be(novoVeiculo);
        }

        [TestMethod]
        public void DeveExcluir_UmVeiculo()
        {
            Combustivel combustivel = new Combustivel(3.0, 4.0, 5.0, 6.0);

            controladorCombustivel.GravarCombustivel(combustivel);

            //arrange            
            Veiculo veiculo = new Veiculo(imagem, "ABC-1234", "Vectra", "Chevrolet", "Gasolina", 70, 2000, null);
            controlador.InserirNovo(veiculo);

            //action            
            controlador.Excluir(veiculo.Id);

            //assert
            Veiculo veiculoEncontrado = controlador.SelecionarPorId(veiculo.Id);
            veiculoEncontrado.Should().BeNull();
        }

        [TestMethod]
        public void DeveSelecionar_Veiculo_PorId()
        {
            Combustivel combustivel = new Combustivel(3.0, 4.0, 5.0, 6.0);

            controladorCombustivel.GravarCombustivel(combustivel);

            //arrange
            Veiculo veiculo = new Veiculo(imagem, "ABC-1234", "Vectra", "Chevrolet", "Gasolina", 70, 2000, null);
            controlador.InserirNovo(veiculo);

            //action
            Veiculo veiculoEncontrado = controlador.SelecionarPorId(veiculo.Id);

            //assert
            veiculoEncontrado.Should().Be(veiculo);
        }

    }
}
