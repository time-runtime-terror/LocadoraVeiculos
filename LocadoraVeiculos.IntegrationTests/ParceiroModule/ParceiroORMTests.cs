using FluentAssertions;
using LocadoraVeiculos.Infra.ORM;
using LocadoraVeiculos.Infra.ORM.Modules.ParceiroModule;
using LocadoraVeiculos.netCore.Dominio.ParceiroModule;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraVeiculos.IntegrationTests.ParceiroModule
{
    [TestClass]
    [TestCategory("ORM/Parceiro")]
    public class ParceiroORMTests
    {
        private IParceiroRepository parceiroRepository;

        public ParceiroORMTests()
        {
            LocadoraDbContext db = new();
            parceiroRepository = new ParceiroRepositoryEF(db);
            DeletarLinhasTabela();
        }
        private void DeletarLinhasTabela()
        {
            using (LocadoraDbContext db = new LocadoraDbContext())
            {
                var listaCupons = db.Cupons;
                db.Cupons.RemoveRange(listaCupons);

                var list = db.Parceiros;
                db.Parceiros.RemoveRange(list);

                db.SaveChanges();
            }
        }

        [TestMethod]
        public void DeveInserir_Parceiro()
        {
            //arrange
            var parceiro = new Parceiro("José");

            //action
            parceiroRepository.InserirNovo(parceiro);

            //assert
            var parceiroEncontrado = parceiroRepository.SelecionarPorId(parceiro.Id);
            parceiroEncontrado.Should().Be(parceiro);
        }

        [TestMethod]
        public void DeveAtualizar_Parceiro()
        {
            //arrange
            var parceiro = new Parceiro("José");
            parceiroRepository.InserirNovo(parceiro);

            //action
            var novoParceiro = new Parceiro("Lucas");
            parceiroRepository.Editar(parceiro.Id, novoParceiro);

            //assert
            var parceiroEncontrado = parceiroRepository.SelecionarPorId(parceiro.Id);
            parceiroEncontrado.Should().Be(novoParceiro);

        }

        [TestMethod]
        public void DeveExcluir_Parceiro()
        {
            //arrange
            var parceiro = new Parceiro("José");
            parceiroRepository.InserirNovo(parceiro);

            //action
            parceiroRepository.Excluir(parceiro.Id);

            //assert
            Parceiro parceiroAtualizado = parceiroRepository.SelecionarPorId(parceiro.Id);
            parceiroAtualizado.Should().BeNull();
        }

        [TestMethod]
        public void DeveSelecionar_Parceiro_PorId()
        {
            //arrange
            var parceiro = new Parceiro("José");
            parceiroRepository.InserirNovo(parceiro);

            //action
            Parceiro parceiroAtualizado = parceiroRepository.SelecionarPorId(parceiro.Id);

            //assert
            parceiroAtualizado.Should().NotBeNull();
        }

        [TestMethod]
        public void DeveSelecionar_TodosParceiros()
        {
            //arrange
            var p1 = new Parceiro("José");
            parceiroRepository.InserirNovo(p1);


            var p2 = new Parceiro("Lucas");
            parceiroRepository.InserirNovo(p2); ;

            var p3 = new Parceiro("Maria");
            parceiroRepository.InserirNovo(p3);

            //action
            var parceiros = parceiroRepository.SelecionarTodos();

            //assert
            parceiros.Should().HaveCount(3);
            parceiros[0].Nome.Should().Be("José");
            parceiros[1].Nome.Should().Be("Lucas");
            parceiros[2].Nome.Should().Be("Maria");
        }


    }
}
