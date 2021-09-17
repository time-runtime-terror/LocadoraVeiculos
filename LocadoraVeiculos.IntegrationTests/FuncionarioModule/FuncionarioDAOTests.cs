using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using FluentAssertions;
using LocadoraVeiculos.netCore.Dominio.FuncionarioModule;
using LocadoraVeiculos.Infra.SQL.ClienteModule;
using LocadoraVeiculos.netCore.Infra.SQL.Shared;
using LocadoraVeiculos.Infra.SQL.FuncionarioModule;

namespace LocadoraVeiculos.IntegrationTests.FuncionarioModule
{
    [TestClass]
    [TestCategory("DAO")]
    public class FuncionarioDAOTests
    {
        private FuncionarioDAO funcionarioRepository;

        public FuncionarioDAOTests()
        {
            funcionarioRepository = new FuncionarioDAO();
            //Db.Update("DELETE FROM [TBCLIENTE]");
            Db.Update("DELETE FROM [TBFUNCIONARIO]");
        }

        [TestMethod]
        
        public void DeveInserir_Funcionario()
        {
            //arrange
            var novoFuncionario = new Funcionario("José", "zé", "12345", new DateTime(2002, 02, 22), "2000");

            //action
            funcionarioRepository.InserirNovo(novoFuncionario);

            //assert
            var funcionarioEncontrado = funcionarioRepository.SelecionarPorId(novoFuncionario.Id);
            funcionarioEncontrado.Should().Be(novoFuncionario);
        }

        [TestMethod]
        public void DeveAtualizar_Funcionario()
        {
            //arrange
            var funcionario = new Funcionario("José", "zé", "12345", new DateTime(2002, 02, 22), "2000");
            funcionarioRepository.InserirNovo(funcionario);

            var novoFuncionario = new Funcionario("Joao", "jo", "12346", new DateTime(2003, 03, 23), "1500");

            //action
            funcionarioRepository.Editar(funcionario.Id, novoFuncionario);

            //assert
            Funcionario funcionarioAtualizado = funcionarioRepository.SelecionarPorId(funcionario.Id);
            funcionarioAtualizado.Should().Be(novoFuncionario);
        }

        [TestMethod]
        public void DeveExcluir_Funcionario()
        {
            //arrange
            var funcionario = new Funcionario("José", "zé", "12345", new DateTime(2002, 02, 22), "2000");
            funcionarioRepository.InserirNovo(funcionario);

            //action
            funcionarioRepository.Excluir(funcionario.Id);

            //assert
            Funcionario funcionarioAtualizado = funcionarioRepository.SelecionarPorId(funcionario.Id);
            funcionarioAtualizado.Should().BeNull();
        }

        [TestMethod]
        public void DeveSelecionar_Funcionario_PorId()
        {
            //arrange
            var funcionario = new Funcionario("José", "zé", "12345", new DateTime(2002, 02, 22), "2000");
            funcionarioRepository.InserirNovo(funcionario);

            //action
            Funcionario funcionarioAtualizado = funcionarioRepository.SelecionarPorId(funcionario.Id);

            //assert
            funcionarioAtualizado.Should().NotBeNull();
        }

        [TestMethod]
        public void DeveSelecionar_TodosFuncionarios()
        {
            //arrange
            var f1 = new Funcionario("José", "zé", "12345", new DateTime(2002, 02, 22), "2000");
            funcionarioRepository.InserirNovo(f1);

            var f2 = new Funcionario("Joao", "jo", "12346", new DateTime(2003, 03, 23), "1500");
            funcionarioRepository.InserirNovo(f2);

            var f3 = new Funcionario("Lucas", "lu", "345653", new DateTime(2005, 03, 08), "2500");
            funcionarioRepository.InserirNovo(f3);

            //action
            var funcionarios = funcionarioRepository.SelecionarTodos();

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
            funcionarioRepository.InserirNovo(f1);

            string usuario = "lucas";
            string senha = "12345";

            //action
            bool existeFuncionario = funcionarioRepository.ExisteFuncionario(usuario, senha);

            //assert
            existeFuncionario.Should().BeTrue();
        }

        [TestMethod]
        public void NaoDeveLogarUsuario_Funcionario()
        {
            //arrange
            var f1 = new Funcionario("Lucas", "lucas", "12345", new DateTime(2002, 02, 22), "2000");
            funcionarioRepository.InserirNovo(f1);

            string usuario = "ucas";
            string senha = "12345";

            //action
            bool existeFuncionario = funcionarioRepository.ExisteFuncionario(usuario, senha);

            //assert
            existeFuncionario.Should().BeFalse();
        }

        [TestMethod]
        public void NaoDeveLogarSenha_Funcionario()
        {
            //arrange
            var f1 = new Funcionario("Lucas", "lucas", "12345", new DateTime(2002, 02, 22), "2000");
            funcionarioRepository.InserirNovo(f1);

            string usuario = "lucas";
            string senha = "123";

            //action
            bool existeFuncionario = funcionarioRepository.ExisteFuncionario(usuario, senha);

            //assert
            existeFuncionario.Should().BeFalse();
        }


    }
}
