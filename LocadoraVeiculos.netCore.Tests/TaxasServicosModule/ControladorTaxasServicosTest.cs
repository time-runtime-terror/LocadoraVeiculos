using FluentAssertions;
using LocadoraVeiculos.netCore.Dominio.TaxasServicosModule;
using LocadoraVeiculos.netCore.Controladores.Shared;
using LocadoraVeiculos.netCore.Controladores.TaxasServicosModule;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LocadoraVeiculos.Tests.TaxasServicosModule
{
    [TestClass]
    [TestCategory("Controladores")]
    public class ControladorTaxasServicosTest
    {
        ControladorTaxasServicos controlador = null;

        public ControladorTaxasServicosTest()
        {
            controlador = new ControladorTaxasServicos();
            Db.Update("DELETE FROM [TBTAXASSERVICOS]");
        }

        [TestMethod]
        public void DeveInserir_TaxasServicos()
        {
            //arrange
            var novoTaxaServico = new TaxasServicos("GPS", 200, "Diário", "Locação");

            //action
            controlador.InserirNovo(novoTaxaServico);

            //assert
            var grupoEncontrado = controlador.SelecionarPorId(novoTaxaServico.Id);
            grupoEncontrado.Should().Be(novoTaxaServico);
        }

        [TestMethod]
        public void DeveAtualizar_TaxasServicos()
        {
            //arrange
            var taxasServicos = new TaxasServicos("GPS", 140, "Fixo", "Locação");
            controlador.InserirNovo(taxasServicos);

            var novoTaxasServicos = new TaxasServicos("GPS", 140, "Diário", "Locação");

            //action
            controlador.Editar(taxasServicos.Id, novoTaxasServicos);

            //assert
            TaxasServicos taxasServicosAtualizado = controlador.SelecionarPorId(taxasServicos.Id);
            taxasServicosAtualizado.Should().Be(novoTaxasServicos);
        }

        [TestMethod]
        public void DeveExcluir_TaxasServicos()
        {
            //arrange            
            var taxasServicos = new TaxasServicos("GPS", 130, "Fixo", "Locação");
            controlador.InserirNovo(taxasServicos);

            //action            
            controlador.Excluir(taxasServicos.Id);

            //assert
            TaxasServicos taxasServicosEncontrado = controlador.SelecionarPorId(taxasServicos.Id);
            taxasServicosEncontrado.Should().BeNull();
        }

        [TestMethod]
        public void DeveSelecionar_TaxasServicos_PorId()
        {
            //arrange
            var taxasServicos = new TaxasServicos("GPS", 240, "Diário", "Locação");
            controlador.InserirNovo(taxasServicos);

            //action
            TaxasServicos taxasServicosEncontrado = controlador.SelecionarPorId(taxasServicos.Id);

            //assert
            taxasServicosEncontrado.Should().NotBeNull();
        }
    }
}
