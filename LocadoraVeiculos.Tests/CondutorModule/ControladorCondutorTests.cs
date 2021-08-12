using FluentAssertions;
using LocadoraVeiculos.Controladores.CondutorModule;
using LocadoraVeiculos.Controladores.Shared;
using LocadoraVeiculos.Dominio.CondutorModule;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace LocadoraVeiculos.Tests.CondutorModule
{
    [TestClass]
    [TestCategory("Controladores")]
    public class ControladorCondutorTests
    {
        private ControladorCondutor controladorCondutor;

        public ControladorCondutorTests()
        {
            controladorCondutor = new ControladorCondutor();

            Db.Update("DELETE FROM [TBCONDUTOR]");
        }

        [TestMethod]
        public void DeveInserir_Condutor()
        {
            // arrange
            Condutor condutor = new Condutor("Tiago Santini", "9999999", "1321355655", "999999999", new DateTime(2025, 06, 30));

            // action
            controladorCondutor.InserirNovo(condutor);

            // assert
            Condutor condutorEncontrado = controladorCondutor.SelecionarPorId(condutor.Id);
            condutorEncontrado.Should().Be(condutor);
        }

        [TestMethod]
        public void DeveEditar_Condutor()
        {
            // arrange
            Condutor condutor = new Condutor("Tiago Santini", "9999999", "1321355655", "999999999", new DateTime(2025, 06, 30));
            controladorCondutor.InserirNovo(condutor);

            Condutor novoCondutor = new Condutor("Tiago Santini Att", "9999999", "1321355655", "999999999", new DateTime(2025, 06, 30));
            // action
            controladorCondutor.Editar(condutor.Id, novoCondutor);

            // assert
            Condutor condutorEncontrado = controladorCondutor.SelecionarPorId(condutor.Id);
            condutorEncontrado.Should().Be(novoCondutor);
        }

        [TestMethod]
        public void DeveExcluir_Condutor()
        {
            // arrange
            Condutor condutor = new Condutor("Tiago Santini", "9999999", "1321355655", "999999999", new DateTime(2025, 06, 30));
            controladorCondutor.InserirNovo(condutor);

            // action
            controladorCondutor.Excluir(condutor.Id);

            // assert
            Condutor condutorEncontrado = controladorCondutor.SelecionarPorId(condutor.Id);
            condutorEncontrado.Should().BeNull();
        }


        [TestMethod]
        public void DeveSelecionar_Condutor_PorId()
        {
            // arrange
            Condutor condutor = new Condutor("Tiago Santini", "9999999", "1321355655", "999999999", new DateTime(2025, 06, 30));
            controladorCondutor.InserirNovo(condutor);

            // action
            Condutor condutorEncontrado = controladorCondutor.SelecionarPorId(condutor.Id);

            // assert
            condutorEncontrado.Should().NotBeNull();
        }

        [TestMethod]
        public void DeveSelecionar_Todos_Condutores()
        {
            // arrange
            var condutores = new List<Condutor>
            {
                new Condutor("Condutor 1", "9999999", "1321355655", "999999999", new DateTime(2025, 06, 30)),

                new Condutor("Condutor 2", "9999999", "1321355655", "999999999", new DateTime(2025, 06, 30))
            };

            foreach (var c in condutores)
                controladorCondutor.InserirNovo(c);

            // action
            var condutoresEncontrados = controladorCondutor.SelecionarTodos();

            // assert
            condutoresEncontrados.Should().HaveCount(2);
        }
    }
}
