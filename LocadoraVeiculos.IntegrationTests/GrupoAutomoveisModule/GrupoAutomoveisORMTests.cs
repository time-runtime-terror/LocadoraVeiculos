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
    [TestCategory("ORM/GrupoAutomoveis")]
    public class GrupoAutomoveisORMTests
    {
        private IGrupoAutomoveisRepository grupoAutomoveisRepository;

        public GrupoAutomoveisORMTests()
        {
            grupoAutomoveisRepository = new GrupoAutomoveisRepositoryEF();
            DeletarLinhasTabela();
        }

        private void DeletarLinhasTabela()
        {
            using (LocadoraDbContext db = new LocadoraDbContext())
            {
                var list = db.GrupoAutomoveis;
                db.GrupoAutomoveis.RemoveRange(list);

                db.SaveChanges();
            }
        }

        [TestMethod]
        public void DeveInserir_GrupoAutomoveis()
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
