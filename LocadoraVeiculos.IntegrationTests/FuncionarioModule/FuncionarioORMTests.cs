using FluentAssertions;
using LocadoraVeiculos.Infra.ORM;
using LocadoraVeiculos.Infra.ORM.Modules.FuncionarioModule;
using LocadoraVeiculos.netCore.Dominio.FuncionarioModule;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraVeiculos.IntegrationTests.FuncionarioModule
{
    [TestClass]
    [TestCategory("ORM")]
    public class FuncionarioORMTests
    {

        private IFuncionarioRepository funcionarioRepository;
        private LocadoraDbContext dbContext ;

        public FuncionarioORMTests()
        {
            dbContext = new LocadoraDbContext();

            DeletarLinhasTabela();

            funcionarioRepository = new FuncionarioRepositoryEF(dbContext);
            
        }

        private void DeletarLinhasTabela()
        { 

            var list = dbContext.Funcionarios;
            dbContext.Funcionarios.RemoveRange(list);
           
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
    }
}
