using FluentAssertions;
using LocadoraVeiculos.Infra.SQL.GrupoAutomoveisModule;
using LocadoraVeiculos.netCore.Dominio.GrupoAutomoveisModule;
using LocadoraVeiculos.netCore.Infra.SQL.Shared;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraVeiculos.IntegrationTests.GrupoAutomoveisModule
{
    [TestClass]
    class GrupoAutomoveisDAOTests
    {
        private GrupoAutomoveisDAO grupoAutomoveisRepository;

        public GrupoAutomoveisDAOTests()
        {
            grupoAutomoveisRepository = new GrupoAutomoveisDAO();
            Db.Update("DELETE FROM [TBGRUPOAUTOMOVEIS]");
        }

        [TestMethod]
        public void DeveInserir_GrupoAutomoveis()
        {
            //arrange
            var novoGrupoAutomovel = new GrupoAutomoveis("Econômico", 100, 120, 140, 160, 100, 180);

            //action
            grupoAutomoveisRepository.InserirNovo(novoGrupoAutomovel);

            //assert
            var grupoEncontrado = grupoAutomoveisRepository.SelecionarPorId(novoGrupoAutomovel.Id);
            grupoEncontrado.Should().Be(novoGrupoAutomovel);
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

        [TestMethod]
        public void DeveSelecionar_TodosOsGruposDeAutomoveis()
        {
            //arrange
            var gp1 = new GrupoAutomoveis("Econômico", 110, 130, 150, 170, 100, 190);
            grupoAutomoveisRepository.InserirNovo(gp1);

            var gp2 = new GrupoAutomoveis("SUV", 210, 230, 250, 270, 100, 290);
            grupoAutomoveisRepository.InserirNovo(gp2);

            var gp3 = new GrupoAutomoveis("Utilitário", 90, 100, 100, 120, 100, 130);
            grupoAutomoveisRepository.InserirNovo(gp3);

            //action
            var grupoAutomoveis = grupoAutomoveisRepository.SelecionarTodos();

            //assert
            grupoAutomoveis.Should().HaveCount(3);
            grupoAutomoveis[0].NomeGrupo.Should().Be("Econômico");
            grupoAutomoveis[1].NomeGrupo.Should().Be("SUV");
            grupoAutomoveis[2].NomeGrupo.Should().Be("Utilitário");
        }
    }
}
