using FluentAssertions;
using LocadoraVeiculos.Infra.ORM;
using LocadoraVeiculos.Infra.ORM.Modules.CupomModule;
using LocadoraVeiculos.Infra.ORM.Modules.ParceiroModule;
using LocadoraVeiculos.netCore.Dominio.CupomModule;
using LocadoraVeiculos.netCore.Dominio.ParceiroModule;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraVeiculos.IntegrationTests.CupomModule
{
    [TestClass]
    [TestCategory("ORM/Cupom")]
    public class CupomORMTests
    {
        private readonly CupomRepositoryEF cupomRepository;
        private readonly ParceiroRepositoryEF parceiroRepository;

        public CupomORMTests()
        {
            LocadoraDbContext db = new();
            cupomRepository = new CupomRepositoryEF(db);
            parceiroRepository = new ParceiroRepositoryEF(db);
            DeletarLinhasTabela();
        }

        private void DeletarLinhasTabela()
        {
            using (LocadoraDbContext db = new LocadoraDbContext())
            {
                var list = db.Cupons;
                db.Cupons.RemoveRange(list);

                var listaParceiros = db.Parceiros;
                db.Parceiros.RemoveRange(listaParceiros);

                db.SaveChanges();
            }
        }

        [TestMethod]
        public void DeveInserir_Cupom()
        {
            //arrange
            var parceiro = new Parceiro("José");

            parceiroRepository.InserirNovo(parceiro);

            int parceiroId = parceiro.Id;

            var cupom = new Cupom("Desconto de Natal", 50, new DateTime(2021, 12, 25), parceiroId, 100);

            //action
            cupomRepository.InserirNovo(cupom);

            //assert
            var cupomEncontrado = cupomRepository.SelecionarPorId(cupom.Id);
            cupomEncontrado.Should().Be(cupom);
        }

        [TestMethod]
        public void DeveAtualizar_Cupom()
        {
            //arrange
            var parceiro = new Parceiro("José");
            parceiroRepository.InserirNovo(parceiro);

            var cupom = new Cupom("Desconto de Natal", 50, new DateTime(2021, 12, 25), parceiro.Id, 100);

            cupomRepository.InserirNovo(cupom);

            var cupomAtualizado = new Cupom("Desconto de Natal Atualizado", 50, new DateTime(2021, 12, 25), parceiro.Id, 100);

            //action
            cupomRepository.Editar(cupom.Id, cupomAtualizado);

            //assert
            var cupomEncontrado = cupomRepository.SelecionarPorId(cupom.Id);
            cupomEncontrado.Should().Be(cupomAtualizado);
        }

        [TestMethod]
        public void DeveExcluir_Cupom()
        {
            //arrange
            var parceiro = new Parceiro("José");
            parceiroRepository.InserirNovo(parceiro);

            var cupom = new Cupom("Desconto de Natal", 50, new DateTime(2021, 12, 25), parceiro.Id, 100);

            cupomRepository.InserirNovo(cupom);

            //action
            cupomRepository.Excluir(cupom.Id);

            //assert
            var cupomEncontrado = cupomRepository.SelecionarPorId(cupom.Id);
            cupomEncontrado.Should().BeNull();
        }

        [TestMethod]
        public void DeveSelecionar_Cupom_PorId()
        {
            //arrange
            var parceiro = new Parceiro("José");
            parceiroRepository.InserirNovo(parceiro);

            var cupom = new Cupom("Desconto de Natal", 50, new DateTime(2021, 12, 25), parceiro.Id, 100);

            cupomRepository.InserirNovo(cupom);

            //action
            var cupomEncontrado = cupomRepository.SelecionarPorId(cupom.Id);

            //assert
            cupomEncontrado.Should().NotBeNull();
        }

        [TestMethod]
        public void DeveSelecionar_TodosCupons()
        {
            //arrange
            var parceiro = new Parceiro("Deko");
            parceiroRepository.InserirNovo(parceiro);

            var cupom1 = new Cupom("Desconto de Natal", 100, new DateTime(2021, 12, 25), parceiro.Id, 150);
            cupomRepository.InserirNovo(cupom1);

            var cupom2 = new Cupom("Cupom 50 reais", 50, new DateTime(2021, 12, 25), parceiro.Id, 100);
            cupomRepository.InserirNovo(cupom2);

            var cupom3 = new Cupom("Desconto do Deko", 200, new DateTime(2021, 12, 25), parceiro.Id, 550);
            cupomRepository.InserirNovo(cupom3);

            //action
            var cupons = cupomRepository.SelecionarTodos();

            //assert
            cupons.Should().HaveCount(3);
            cupons[0].Nome.Should().Be("Desconto de Natal");
            cupons[1].Nome.Should().Be("Cupom 50 reais");
            cupons[2].Nome.Should().Be("Desconto do Deko");
        }

    }
}
