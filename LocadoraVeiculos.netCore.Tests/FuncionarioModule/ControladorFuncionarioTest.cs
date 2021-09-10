using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using FluentAssertions;
using LocadoraVeiculos.netCore.Dominio.FuncionarioModule;
using LocadoraVeiculos.netCore.Controladores.FuncionarioModule;
using LocadoraVeiculos.netCore.Controladores.Shared;

namespace LocadoraVeiculos.netCore.Tests.FuncionarioModule
{
    [TestClass]
    [TestCategory("Controladores")]
    public class ControladorFuncionarioTest
    {
        ControladorFuncionario controlador = null;

        public ControladorFuncionarioTest()
        {
            controlador = new ControladorFuncionario();
            //Db.Update("DELETE FROM [TBCLIENTE]");
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

        [TestMethod]
        public void DeveAtualizar_Funcionario()
        {
            //arrange
            var funcionario = new Funcionario("José", "zé", "12345", new DateTime(2002, 02, 22), "2000");
            controlador.InserirNovo(funcionario);

            var novoFuncionario = new Funcionario("Joao", "jo", "12346", new DateTime(2003, 03, 23), "1500");

            //action
            controlador.Editar(funcionario.Id, novoFuncionario);

            //assert
            Funcionario funcionarioAtualizado = controlador.SelecionarPorId(funcionario.Id);
            funcionarioAtualizado.Should().Be(novoFuncionario);
        }

        [TestMethod]
        public void DeveExcluir_Funcionario()
        {
            //arrange
            var funcionario = new Funcionario("José", "zé", "12345", new DateTime(2002, 02, 22), "2000");
            controlador.InserirNovo(funcionario);

            //action
            controlador.Excluir(funcionario.Id);

            //assert
            Funcionario funcionarioAtualizado = controlador.SelecionarPorId(funcionario.Id);
            funcionarioAtualizado.Should().BeNull();
        }

        [TestMethod]
        public void DeveSelecionar_Funcionario_PorId()
        {
            //arrange
            var funcionario = new Funcionario("José", "zé", "12345", new DateTime(2002, 02, 22), "2000");
            controlador.InserirNovo(funcionario);

            //action
            Funcionario funcionarioAtualizado = controlador.SelecionarPorId(funcionario.Id);

            //assert
            funcionarioAtualizado.Should().NotBeNull();
        }

        [TestMethod]
        public void DeveSelecionar_TodosFuncionarios()
        {
            //arrange
            var f1 = new Funcionario("José", "zé", "12345", new DateTime(2002, 02, 22), "2000");
            controlador.InserirNovo(f1);

            var f2 = new Funcionario("Joao", "jo", "12346", new DateTime(2003, 03, 23), "1500");
            controlador.InserirNovo(f2);

            var f3 = new Funcionario("Lucas", "lu", "345653", new DateTime(2005, 03, 08), "2500");
            controlador.InserirNovo(f3);

            //action
            var funcionarios = controlador.SelecionarTodos();

            //assert
            funcionarios.Should().HaveCount(3);
            funcionarios[0].Nome.Should().Be("José");
            funcionarios[1].Nome.Should().Be("Joao");
            funcionarios[2].Nome.Should().Be("Lucas");
        }

        [TestMethod]
        public void DeveLogar_Funcionario()
        {
            //arrange
            var f1 = new Funcionario("Lucas", "lucas", "12345", new DateTime(2002, 02, 22), "2000");
            controlador.InserirNovo(f1);

            string usuario = "lucas";
            string senha = "12345";

            //action
            bool existeFuncionario = controlador.ExisteFuncionario(usuario, senha);

            //assert
            existeFuncionario.Should().BeTrue();
        }

        [TestMethod]
        public void NaoDeveLogarUsuario_Funcionario()
        {
            //arrange
            var f1 = new Funcionario("Lucas", "lucas", "12345", new DateTime(2002, 02, 22), "2000");
            controlador.InserirNovo(f1);

            string usuario = "ucas";
            string senha = "12345";

            //action
            bool existeFuncionario = controlador.ExisteFuncionario(usuario, senha);

            //assert
            existeFuncionario.Should().BeFalse();
        }

        [TestMethod]
        public void NaoDeveLogarSenha_Funcionario()
        {
            //arrange
            var f1 = new Funcionario("Lucas", "lucas", "12345", new DateTime(2002, 02, 22), "2000");
            controlador.InserirNovo(f1);

            string usuario = "lucas";
            string senha = "123";

            //action
            bool existeFuncionario = controlador.ExisteFuncionario(usuario, senha);

            //assert
            existeFuncionario.Should().BeFalse();
        }


    }
}
