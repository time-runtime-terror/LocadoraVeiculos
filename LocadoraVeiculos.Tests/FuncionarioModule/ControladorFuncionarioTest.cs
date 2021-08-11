using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using LocadoraVeiculos.Controladores.FuncionarioModule;
using FluentAssertions;
using LocadoraVeiculos.Controladores.Shared;
using LocadoraVeiculos.Dominio.FuncionarioModule;

namespace LocadoraVeiculos.Tests.FuncionarioModule
{
    [TestClass]
    [TestCategory("Controladores")]
    public class ControladorFuncionarioTest
    {
        ControladorFuncionario controlador = null;

        public ControladorFuncionarioTest()
        {
            controlador = new ControladorFuncionario();
            Db.Update("DELETE FROM [TBCLIENTE]");
            Db.Update("DELETE FROM [TBFUNCIONARIO]");
        }

        [TestMethod]
        public void DeveInserir_Funcionario()
        {
            //arrange
            var novoFuncionario = new Funcionario("José", "zé", "12345", new DateTime(2002, 02, 22), "2000");

            //action
            controlador.InserirNovo(novoFuncionario);

            //assert
            var funcionarioEncontrado = controlador.SelecionarPorId(novoFuncionario.Id);
            funcionarioEncontrado.Should().Be(novoFuncionario);
        }
    }
}
