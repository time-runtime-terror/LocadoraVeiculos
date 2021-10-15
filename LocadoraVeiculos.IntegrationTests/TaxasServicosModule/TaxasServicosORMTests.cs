using FluentAssertions;
using LocadoraVeiculos.Infra.ORM;
using LocadoraVeiculos.Infra.ORM.Modules.TaxasServicosModule;
using LocadoraVeiculos.netCore.Dominio.TaxasServicosModule;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LocadoraVeiculos.IntegrationTests.TaxasServicosModule
{
    [TestClass]
    [TestCategory("ORM/TaxasServicos")]
    public class TaxasServicosORMTests
    {
        private ITaxasServicosRepository taxasRepository;

        public TaxasServicosORMTests()
        {
            LocadoraDbContext db = new LocadoraDbContext();
            taxasRepository = new TaxasServicosRepositoryEF(db);
            DeletarLinhasTabela();
        }

        public void DeletarLinhasTabela()
        {
            using (LocadoraDbContext _dbContext = new LocadoraDbContext())
            {
                var list = _dbContext.Taxas;

                _dbContext.Taxas.RemoveRange(list);

                _dbContext.SaveChanges();
            }
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

            var novoTaxasServicos = new TaxasServicos("GPS", 160, "Diário", "Locação");

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
