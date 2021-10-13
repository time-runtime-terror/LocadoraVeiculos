using FluentAssertions;
using LocadoraVeiculos.Infra.ORM;
using LocadoraVeiculos.Infra.ORM.Modules.VeiculoModule;
using LocadoraVeiculos.netCore.Dominio.VeiculoModule;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraVeiculos.IntegrationTests.VeiculoModule
{
    [TestClass]
    [TestCategory("ORM")]

    public class VeiculoORMTests
    {
        private IVeiculoRepository veiculoRepository;
        private LocadoraDbContext dbContext;

        public VeiculoORMTests()
        {
            dbContext = new LocadoraDbContext();

            DeletarLinhasTabela();

            veiculoRepository = new VeiculoRepositoryEF(dbContext);

        }

        private void DeletarLinhasTabela()
        {

            var list = dbContext.Veiculos;
            dbContext.Veiculos.RemoveRange(list);

        }

        [TestMethod]

        public void DeveInserir_Veiculo()
        {
            byte[] foto = new byte[] { 0x20, 0x20, 0x20, 0x20, 0x20, 0x20, 0x20 };

            //arrange
            var novoVeiculo = new Veiculo(foto, "ABC-1234", "Vectra", "Chevrolet", "Gasolina", 70, 2000, null);

            //action
            veiculoRepository.InserirNovo(novoVeiculo);

            //assert
            var veiculoEncontrado = veiculoRepository.SelecionarPorId(novoVeiculo.Id);
            veiculoEncontrado.Should().Be(novoVeiculo);
        }
    }
}
