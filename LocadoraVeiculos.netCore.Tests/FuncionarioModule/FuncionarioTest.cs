using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using LocadoraVeiculos.netCore.Dominio.FuncionarioModule;
using FluentAssertions;

namespace LocadoraVeiculos.netCore.Tests.FuncionarioModule
{
    [TestClass]
    [TestCategory("Dominio")]
    public class FuncionarioTest
    {
        [TestMethod]
        public void DeveValidarNome()
        {
            //arrange
            var fucionario = new Funcionario("José", "Zé", "12345", DateTime.Now, "1200");

            //action
            var resultadoValidacao = fucionario.Validar();

            //assert
            resultadoValidacao.Should().Be("ESTA_VALIDO");
        }

        [TestMethod]
        public void NaoDeveValidarNome()
        {
            //arrange
            var fucionario = new Funcionario("", "Zé", "12345", DateTime.Now, "1200");

            //action
            var resultadoValidacao = fucionario.Validar();

            //assert
            resultadoValidacao.Should().Be("O campo Nome é obrigatório");
        }

        [TestMethod]
        public void DeveValidarNomeUsuario()
        {
            //arrange
            var fucionario = new Funcionario("José", "Zé", "12345", DateTime.Now, "1200");

            //action
            var resultadoValidacao = fucionario.Validar();

            //assert
            resultadoValidacao.Should().Be("ESTA_VALIDO");
        }

        [TestMethod]
        public void NaoDeveValidarNomeUsario()
        {
            //arrange
            var fucionario = new Funcionario("José", "", "12345", DateTime.Now, "1200");

            //action
            var resultadoValidacao = fucionario.Validar();

            //assert
            resultadoValidacao.Should().Be("O campo Nome de Usuário é obrigatório");
        }

        [TestMethod]
        public void DeveValidarSenha()
        {
            //arrange
            var fucionario = new Funcionario("José", "Zé", "12345", DateTime.Now, "1200");

            //action
            var resultadoValidacao = fucionario.Validar();

            //assert
            resultadoValidacao.Should().Be("ESTA_VALIDO");
        }

        [TestMethod]
        public void NaoDeveValidarSenha()
        {
            //arrange
            var fucionario = new Funcionario("José", "Zé", "12", DateTime.Now, "1200");

            //action
            var resultadoValidacao = fucionario.Validar();

            //assert
            resultadoValidacao.Should().Be("O campo Senha necessita ter ao mínimo 3 caracteres");
        }

        [TestMethod]
        public void DeveValidarDataEntrada()
        {
            //arrange
            var fucionario = new Funcionario("José", "Zé", "12345", DateTime.Now, "1200");

            //action
            var resultadoValidacao = fucionario.Validar();

            //assert
            resultadoValidacao.Should().Be("ESTA_VALIDO");
        }

        [TestMethod]
        public void NaoDeveValidarDataEntrada()
        {
            //arrange
            var fucionario = new Funcionario("José", "Zé", "12345", new DateTime(2025,08, 20), "1200");

            //action
            var resultadoValidacao = fucionario.Validar();

            //assert
            resultadoValidacao.Should().Be("O campo Data de Entrada aceita apenas datas menores que a atual");
        }


        [TestMethod]
        public void DeveValidarSalario()
        {
            //arrange
            var fucionario = new Funcionario("José", "Zé", "12345", DateTime.Now, "1200");

            //action
            var resultadoValidacao = fucionario.Validar();

            //assert
            resultadoValidacao.Should().Be("ESTA_VALIDO");
        }

        [TestMethod]
        public void NaoDeveValidarSalario()
        {
            //arrange
            var fucionario = new Funcionario("José", "Zé", "12345", DateTime.Now, "");

            //action
            var resultadoValidacao = fucionario.Validar();

            //assert
            resultadoValidacao.Should().Be("O campo Salário é obrigatório");
        }

        [TestMethod]
        public void NaoDeveValidarTodosOsCampos(){

            //arrange
            var fucionario = new Funcionario("", "", "12", DateTime.MinValue, "");

            //action
            var resultadoValidacao = fucionario.Validar();

            var resultadoEsperado = "O campo Nome é obrigatório"
                + Environment.NewLine
                + "O campo Nome de Usuário é obrigatório"
                + Environment.NewLine
                + "O campo Senha necessita ter ao mínimo 3 caracteres"
                + Environment.NewLine
                + "O campo Data de Entrada é obrigatório"
                + Environment.NewLine
                + "O campo Salário é obrigatório";

            //assert
            resultadoValidacao.Should().Be(resultadoEsperado);

        }
    }
}
