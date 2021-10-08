using FluentAssertions;
using LocadoraVeiculos.Infra.JSON.CombustivelModule;
using LocadoraVeiculos.Infra.SQL.GrupoAutomoveisModule;
using LocadoraVeiculos.Infra.SQL.VeiculosModule;
using LocadoraVeiculos.netCore.Dominio.CombustivelModule;
using LocadoraVeiculos.netCore.Dominio.GrupoAutomoveisModule;
using LocadoraVeiculos.netCore.Dominio.VeiculoModule;
using LocadoraVeiculos.netCore.Infra.SQL.Shared;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LocadoraVeiculos.IntegrationTests.VeiculoModule
{
    [TestClass]
    [TestCategory("DAO/Veiculo")]
    public class VeiculoDAOTests
    {
        CombustivelConfiguration configCombustivel = null;


        VeiculosDAO controlador = null;
        byte[] imagem = new byte[] { 0x20, 0x20, 0x20, 0x20, 0x20, 0x20, 0x20 };

        GrupoAutomoveisDAO grupoAutomoveisRepository = null;
        GrupoAutomoveis grupoAutomoveis = new GrupoAutomoveis("Economico", 32, 64, 65, 82, 95, 90);

        public VeiculoDAOTests()
        {
            grupoAutomoveisRepository = new GrupoAutomoveisDAO();
            controlador = new VeiculosDAO(grupoAutomoveisRepository);         
            
            configCombustivel = new CombustivelConfiguration();
            Db.Update("DELETE FROM [TBVEICULO]");
        }

        [TestMethod]
        public void DeveInserir_Veiculo()
        {
            Combustivel combustivel = new Combustivel(3.0, 4.0, 5.0, 6.0);

            configCombustivel.GravarCombustivel(combustivel);

            grupoAutomoveisRepository.InserirNovo(grupoAutomoveis);

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

            configCombustivel.GravarCombustivel(combustivel);

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

            configCombustivel.GravarCombustivel(combustivel);

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

            configCombustivel.GravarCombustivel(combustivel);

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
