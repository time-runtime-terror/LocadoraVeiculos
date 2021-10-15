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
            LocadoraDbContext db = new();
            grupoAutomoveisRepository = new GrupoAutomoveisRepositoryEF(db);
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

        [TestMethod]
        public void DeveAtualizar_GrupoAutomoveis()
        {
            //arrange
            var grupoAutomoveis = new GrupoAutomoveis("Econômico", 100, 120, 140, 160, 100, 180);
            grupoAutomoveisRepository.InserirNovo(grupoAutomoveis);

            var novoGrupoAutomoveis = new GrupoAutomoveis("Econômico", 110, 130, 150, 170, 100, 190);

            //action
            grupoAutomoveisRepository.Editar(grupoAutomoveis.Id, novoGrupoAutomoveis);

            //assert
            GrupoAutomoveis grupoAutomoveisAtualizado = grupoAutomoveisRepository.SelecionarPorId(grupoAutomoveis.Id);
            grupoAutomoveisAtualizado.Should().Be(novoGrupoAutomoveis);
        }

        [TestMethod]
        public void DeveExcluir_GrupoAutomoveis()
        {
            //arrange            
            var grupoAutomoveis = new GrupoAutomoveis("Econômico", 110, 130, 150, 170, 100, 190);
            grupoAutomoveisRepository.InserirNovo(grupoAutomoveis);

            //action            
            grupoAutomoveisRepository.Excluir(grupoAutomoveis.Id);

            //assert
            GrupoAutomoveis grupoAutomoveisEncontrado = grupoAutomoveisRepository.SelecionarPorId(grupoAutomoveis.Id);
            grupoAutomoveisEncontrado.Should().BeNull();
        }

        [TestMethod]
        public void DeveSelecionar_GrupoAutomoveis_PorId()
        {
            //arrange
            var grupoAutomoveis = new GrupoAutomoveis("Econômico", 110, 130, 150, 170, 100, 190);
            grupoAutomoveisRepository.InserirNovo(grupoAutomoveis);

            //action
            GrupoAutomoveis grupoAutomoveisEncontrado = grupoAutomoveisRepository.SelecionarPorId(grupoAutomoveis.Id);

            //assert
            grupoAutomoveisEncontrado.Should().NotBeNull();
        }
    }
}
