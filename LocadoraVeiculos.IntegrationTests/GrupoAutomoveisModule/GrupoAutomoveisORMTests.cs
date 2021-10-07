using FluentAssertions;
using LocadoraVeiculos.Infra.ORM;
using LocadoraVeiculos.Infra.ORM.Modules.GrupoAutomoveisModule;
using LocadoraVeiculos.netCore.Dominio.GrupoAutomoveisModule;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraVeiculos.IntegrationTests.GrupoAutomoveisModule
{
    [TestClass]
    [TestCategory("ORM")]
    public class GrupoAutomoveisORMTests
    {
        private IGrupoAutomoveisRepository grupoAutomoveisRepository;
        private GrupoAutomoveisDbContext dbContext;

        public GrupoAutomoveisORMTests()
        {
            dbContext = new GrupoAutomoveisDbContext();

            DeletarLinhasTabela();

            grupoAutomoveisRepository = new GrupoAutomoveisRepositoryEF(dbContext);

        }

        private void DeletarLinhasTabela()
        {

            var list = dbContext.GrupoAutomoveis;
            dbContext.GrupoAutomoveis.RemoveRange(list);

        }

        [TestMethod]

        public void DeveInserir_Funcionario()
        {
            //arrange
            var novoGrupo = new GrupoAutomoveis("Popular", 10, 10, 10, 10, 10, 50);

            //action
            grupoAutomoveisRepository.InserirNovo(novoGrupo);

            //assert
            var grupoEncontrado = grupoAutomoveisRepository.SelecionarPorId(novoGrupo.Id);
            grupoEncontrado.Should().Be(novoGrupo);
        }
    }
}
