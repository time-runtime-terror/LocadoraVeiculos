using FluentAssertions;
using LocadoraVeiculos.Infra.SQL.TaxasServicosModule;
using LocadoraVeiculos.netCore.Dominio.TaxasServicosModule;
using LocadoraVeiculos.netCore.Infra.SQL.Shared;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LocadoraVeiculos.IntegrationTests.TaxasServicosModule
{
    [TestClass]
    [TestCategory("DAO")]
    public class TaxasServicosDAOTests
    {
        private TaxasServicosDAO taxasRepository;

        public TaxasServicosDAOTests()
        {
            taxasRepository = new TaxasServicosDAO();
            Db.Update("DELETE FROM [TBTAXASSERVICOS]");
        }

        [TestMethod]
        public void DeveInserir_TaxasServicos()
        {
            //arrange
            var novoTaxaServico = new TaxasServicos("GPS", 200, "Diário", "Locação");

            //action
            taxasRepository.InserirNovo(novoTaxaServico);

            //assert
            var grupoEncontrado = taxasRepository.SelecionarPorId(novoTaxaServico.Id);
            grupoEncontrado.Should().Be(novoTaxaServico);
        }

        [TestMethod]
        public void DeveAtualizar_TaxasServicos()
        {
            //arrange
            var taxasServicos = new TaxasServicos("GPS", 140, "Fixo", "Locação");
            taxasRepository.InserirNovo(taxasServicos);

            var novoTaxasServicos = new TaxasServicos("GPS", 140, "Diário", "Locação");

            //action
            taxasRepository.Editar(taxasServicos.Id, novoTaxasServicos);

            //assert
            TaxasServicos taxasServicosAtualizado = taxasRepository.SelecionarPorId(taxasServicos.Id);
            taxasServicosAtualizado.Should().Be(novoTaxasServicos);
        }

        [TestMethod]
        public void DeveExcluir_TaxasServicos()
        {
            //arrange            
            var taxasServicos = new TaxasServicos("GPS", 130, "Fixo", "Locação");
            taxasRepository.InserirNovo(taxasServicos);

            //action            
            taxasRepository.Excluir(taxasServicos.Id);

            //assert
            TaxasServicos taxasServicosEncontrado = taxasRepository.SelecionarPorId(taxasServicos.Id);
            taxasServicosEncontrado.Should().BeNull();
        }

        [TestMethod]
        public void DeveSelecionar_TaxasServicos_PorId()
        {
            //arrange
            var taxasServicos = new TaxasServicos("GPS", 240, "Diário", "Locação");
            taxasRepository.InserirNovo(taxasServicos);

            //action
            TaxasServicos taxasServicosEncontrado = taxasRepository.SelecionarPorId(taxasServicos.Id);

            //assert
            taxasServicosEncontrado.Should().NotBeNull();
        }
    }
}
