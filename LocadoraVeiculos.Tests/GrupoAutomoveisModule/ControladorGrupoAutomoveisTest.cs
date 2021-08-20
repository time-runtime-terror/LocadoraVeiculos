using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using LocadoraVeiculos.Controladores.GrupoAutomoveisModule;
using LocadoraVeiculos.Controladores.Shared;
using LocadoraVeiculos.Dominio.GrupoAutomoveisModule;
using FluentAssertions;

namespace LocadoraVeiculos.Tests.GrupoAutomoveisModule
{
    [TestClass]
    [TestCategory("Controladores")]
    public class ControladorGrupoAutomoveisTest
    {
        ControladorGrupoAutomoveis controlador = null;

        public ControladorGrupoAutomoveisTest()
        {
            controlador = new ControladorGrupoAutomoveis();
            Db.Update("DELETE FROM [TBGRUPOAUTOMOVEIS]");
        }

        [TestMethod]
        public void DeveInserir_GrupoAutomoveis()
        {
            //arrange
            var novoGrupoAutomovel = new GrupoAutomoveis("Econômico", 100, 120, 140, 160, 100, 180);

            //action
            controlador.InserirNovo(novoGrupoAutomovel);

            //assert
            var grupoEncontrado = controlador.SelecionarPorId(novoGrupoAutomovel.Id);
            grupoEncontrado.Should().Be(novoGrupoAutomovel);
        }

        [TestMethod]
        public void DeveAtualizar_GrupoAutomoveis()
        {
            //arrange
            var grupoAutomoveis = new GrupoAutomoveis("Econômico", 100, 120, 140, 160, 100, 180);
            controlador.InserirNovo(grupoAutomoveis);

            var novoGrupoAutomoveis = new GrupoAutomoveis("Econômico", 110, 130, 150, 170, 100, 190);

            //action
            controlador.Editar(grupoAutomoveis.Id, novoGrupoAutomoveis);

            //assert
            GrupoAutomoveis grupoAutomoveisAtualizado = controlador.SelecionarPorId(grupoAutomoveis.Id);
            grupoAutomoveisAtualizado.Should().Be(novoGrupoAutomoveis);
        }

        [TestMethod]
        public void DeveExcluir_GrupoAutomoveis()
        {
            //arrange            
            var grupoAutomoveis = new GrupoAutomoveis("Econômico", 110, 130, 150, 170, 100, 190);
            controlador.InserirNovo(grupoAutomoveis);

            //action            
            controlador.Excluir(grupoAutomoveis.Id);

            //assert
            GrupoAutomoveis grupoAutomoveisEncontrado = controlador.SelecionarPorId(grupoAutomoveis.Id);
            grupoAutomoveisEncontrado.Should().BeNull();
        }

        [TestMethod]
        public void DeveSelecionar_GrupoAutomoveis_PorId()
        {
            //arrange
            var grupoAutomoveis = new GrupoAutomoveis("Econômico", 110, 130, 150, 170, 100, 190);
            controlador.InserirNovo(grupoAutomoveis);

            //action
            GrupoAutomoveis grupoAutomoveisEncontrado = controlador.SelecionarPorId(grupoAutomoveis.Id);

            //assert
            grupoAutomoveisEncontrado.Should().NotBeNull();
        }

        [TestMethod]
        public void DeveSelecionar_TodosOsGruposDeAutomoveis()
        {
            //arrange
            var gp1 = new GrupoAutomoveis("Econômico", 110, 130, 150, 170, 100, 190);
            controlador.InserirNovo(gp1);

            var gp2 = new GrupoAutomoveis("SUV", 210, 230, 250, 270, 100, 290);
            controlador.InserirNovo(gp2);

            var gp3 = new GrupoAutomoveis("Utilitário", 90, 100, 100, 120, 100, 130);
            controlador.InserirNovo(gp3);

            //action
            var grupoAutomoveis = controlador.SelecionarTodos();

            //assert
            grupoAutomoveis.Should().HaveCount(3);
            grupoAutomoveis[0].NomeGrupo.Should().Be("Econômico");
            grupoAutomoveis[1].NomeGrupo.Should().Be("SUV");
            grupoAutomoveis[2].NomeGrupo.Should().Be("Utilitário");
        }
    }
}
