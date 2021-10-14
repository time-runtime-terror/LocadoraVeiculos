using FluentAssertions;
using LocadoraVeiculos.Infra.JSON.CombustivelModule;
using LocadoraVeiculos.Infra.ORM;
using LocadoraVeiculos.Infra.ORM.Modules.GrupoAutomoveisModule;
using LocadoraVeiculos.Infra.ORM.Modules.VeiculoModule;
using LocadoraVeiculos.netCore.Dominio.CombustivelModule;
using LocadoraVeiculos.netCore.Dominio.GrupoAutomoveisModule;
using LocadoraVeiculos.netCore.Dominio.VeiculoModule;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraVeiculos.IntegrationTests.VeiculoModule
{
    [TestClass]
    [TestCategory("ORM")]

    public class VeiculoORMTests
    {
        private IVeiculoRepository veiculoRepository;
        private IGrupoAutomoveisRepository grupoAutomoveisRepository;
        private LocadoraDbContext dbContext;

        CombustivelConfiguration configCombustivel = null;

        byte[] foto = new byte[] { 0x20, 0x20, 0x20, 0x20, 0x20, 0x20, 0x20 };

        public VeiculoORMTests()
        {
            dbContext = new LocadoraDbContext();

            DeletarLinhasTabela();

            veiculoRepository = new VeiculoRepositoryEF(dbContext);

            grupoAutomoveisRepository = new GrupoAutomoveisRepositoryEF();

            configCombustivel = new CombustivelConfiguration();

        }

        private void DeletarLinhasTabela()
        {
            using (LocadoraDbContext db = new LocadoraDbContext())
            {
                var list2 = db.GrupoAutomoveis;
                db.GrupoAutomoveis.RemoveRange(list2);

                var list = db.Veiculos;
                db.Veiculos.RemoveRange(list);

                db.SaveChanges();
            }

        }

        [TestMethod]

        public void DeveInserir_Veiculo()
        {

            Combustivel combustivel = new Combustivel(3.0, 4.0, 5.0, 6.0);

            configCombustivel.GravarCombustivel(combustivel);

            var novoGrupo = new GrupoAutomoveis("SUV", 10, 10, 10, 10, 10, 50);

            grupoAutomoveisRepository.InserirNovo(novoGrupo);

            //arrange
            var novoVeiculo = new Veiculo(foto, "ABC-1234", "Vectra", "Chevrolet", "Gasolina", 70, 2000, grupoAutomoveisRepository.SelecionarPorId(novoGrupo.Id));

            //action
            veiculoRepository.InserirNovo(novoVeiculo);

            //assert
            var veiculoEncontrado = veiculoRepository.SelecionarPorId(novoVeiculo.Id);
            veiculoEncontrado.Should().Be(novoVeiculo);
        }

        [TestMethod]
        public void DeveEditar_UmVeiculo()
        {
            Combustivel combustivel = new Combustivel(3.0, 4.0, 5.0, 6.0);

            configCombustivel.GravarCombustivel(combustivel);

            //arrange
            Veiculo veiculo = new Veiculo(foto, "ABC-1234", "Vectra", "Chevrolet", "Gasolina", 70, 2000, null);
            veiculoRepository.InserirNovo(veiculo);

            Veiculo novoVeiculo = new Veiculo(foto, "ABC-1234", "Gol", "Volkswagen", "Diesel", 70, 2000, null);

            //action
            veiculoRepository.Editar(veiculo.Id, novoVeiculo);

            //assert
            Veiculo veiculoEncontrado = veiculoRepository.SelecionarPorId(veiculo.Id);
            veiculoEncontrado.Should().Be(novoVeiculo);
        }

        [TestMethod]
        public void DeveExcluir_UmVeiculo()
        {
            Combustivel combustivel = new Combustivel(3.0, 4.0, 5.0, 6.0);

            configCombustivel.GravarCombustivel(combustivel);

            //arrange            
            Veiculo veiculo = new Veiculo(foto, "ABC-1234", "Vectra", "Chevrolet", "Gasolina", 70, 2000, null);
            veiculoRepository.InserirNovo(veiculo);

            //action            
            veiculoRepository.Excluir(veiculo.Id);

            //assert
            Veiculo veiculoEncontrado = veiculoRepository.SelecionarPorId(veiculo.Id);
            veiculoEncontrado.Should().BeNull();
        }

        [TestMethod]
        public void DeveSelecionar_Veiculo_PorId()
        {
            Combustivel combustivel = new Combustivel(3.0, 4.0, 5.0, 6.0);

            configCombustivel.GravarCombustivel(combustivel);

            //arrange
            Veiculo veiculo = new Veiculo(foto, "ABC-1234", "Vectra", "Chevrolet", "Gasolina", 70, 2000, null);
            veiculoRepository.InserirNovo(veiculo);

            //action
            Veiculo veiculoEncontrado = veiculoRepository.SelecionarPorId(veiculo.Id);

            //assert
            veiculoEncontrado.Should().Be(veiculo);
        }

        [TestMethod]
        public void DeveSelecionar_TodosVeiculos()
        {
            //arrange
            Veiculo v1= new Veiculo(foto, "ABC-1234", "Vectra", "Chevrolet", "Gasolina", 70, 2000, null);
            veiculoRepository.InserirNovo(v1);

            Veiculo v2 = new Veiculo(foto, "CBA-4321", "Celta", "Chevrolet", "Gasolina", 70, 2000, null);
            veiculoRepository.InserirNovo(v2);

            Veiculo v3 = new Veiculo(foto, "DEF-6831", "Corsa", "Chevrolet", "Gasolina", 70, 2000, null);
            veiculoRepository.InserirNovo(v3);

            //action
            var veiculos = veiculoRepository.SelecionarTodos();

            //assert
            veiculos.Should().HaveCount(3);
            veiculos[0].Modelo.Should().Be("Vectra");
            veiculos[1].Modelo.Should().Be("Celta");
            veiculos[2].Modelo.Should().Be("Corsa");
        }

        [TestMethod]
        public void Deve_AtualizarQuilometragem()
        {
            
            //arrange
            Veiculo veiculo = new Veiculo(foto, "ABC-1234", "Vectra", "Chevrolet", "Gasolina", 70, 2000, null);
            veiculoRepository.InserirNovo(veiculo);

            veiculo.Quilometragem = 3000;

            //action
            veiculoRepository.AtualizarQuilometragem(veiculo);

            //assert
            Veiculo veiculoEncontrado = veiculoRepository.SelecionarPorId(veiculo.Id);
            veiculoEncontrado.Quilometragem.Should().Be(3000);
        }

        [TestMethod]
        public void Deve_AtualizarStatusAluguel()
        {

        }
    }
}
