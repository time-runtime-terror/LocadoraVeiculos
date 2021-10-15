using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using FluentAssertions;
using LocadoraVeiculos.netCore.Dominio.ClienteModule;
using LocadoraVeiculos.netCore.Dominio.LocacaoModule;
using LocadoraVeiculos.netCore.Dominio.GrupoAutomoveisModule;
using LocadoraVeiculos.netCore.Dominio.VeiculoModule;
using LocadoraVeiculos.Infra.SQL.VeiculosModule;
using LocadoraVeiculos.Infra.SQL.GrupoAutomoveisModule;
using LocadoraVeiculos.Infra.ORM;
using LocadoraVeiculos.Infra.ORM.Modules.GrupoAutomoveisModule;
using LocadoraVeiculos.netCore.Dominio.TaxasServicosModule;
using LocadoraVeiculos.Infra.ORM.Modules.LocacaoModule;
using LocadoraVeiculos.Infra.ORM.Modules.ClienteModule;
using LocadoraVeiculos.Infra.ORM.Modules.TaxasServicosModule;
using LocadoraVeiculos.Infra.ORM.Modules.VeiculoModule;

namespace LocadoraVeiculos.IntegrationTests.LocacaoModule
{
    [TestClass]
    [TestCategory("ORM/Locacao")]
    public class LocacaoORMTests
    {
        byte[] foto = new byte[] { 0x20, 0x20, 0x20, 0x20, 0x20, 0x20, 0x20 };

        private IGrupoAutomoveisRepository grupoAutomoveisRepository;
        private IClienteRepository clienteRepository;
        private IVeiculoRepository veiculoRepository;
        private ITaxasServicosRepository taxasServicosRepository;
        private ILocacaoRepository locacaoRepository;


        public LocacaoORMTests()
        {
            LocadoraDbContext db = new();
            grupoAutomoveisRepository = new GrupoAutomoveisRepositoryEF(db);
            clienteRepository = new ClienteRepositoryEF(db);
            veiculoRepository = new VeiculoRepositoryEF(db);
            taxasServicosRepository = new TaxasServicosRepositoryEF(db);
            locacaoRepository = new LocacaoRepositoryEF(db);

            DeletarLinhasTabela();
        }

        public void DeletarLinhasTabela()
        {
            using (LocadoraDbContext _dbContext = new LocadoraDbContext())
            {
                var clientes = _dbContext.Clientes;
                var grupoAutomoveis = _dbContext.GrupoAutomoveis;
                var locacoes = _dbContext.Locacoes;

                _dbContext.Locacoes.RemoveRange(locacoes);
                _dbContext.Clientes.RemoveRange(clientes);
                _dbContext.GrupoAutomoveis.RemoveRange(grupoAutomoveis);

                _dbContext.SaveChanges();
            }
        }

        [TestMethod]
        public void DeveInserir_Locacao()
        {
            // arrange
            Cliente cliente = new Cliente("Tiago Santini", "testador@ndd.com", "Maria de Melo Kuster", "(49) 9805-6251", "CPF", "123123124", new DateTime(2025, 06, 30), "41421412412", "41242121412", null);
            clienteRepository.InserirNovo(cliente);

            GrupoAutomoveis grupoAutomovel = new GrupoAutomoveis("Econômico", 100, 120, 140, 160, 100, 180);
            grupoAutomoveisRepository.InserirNovo(grupoAutomovel);

            Veiculo veiculo = new Veiculo(foto, "ABC-1234", "Vectra", "Chevrolet", "Gasolina", 70, 2000, grupoAutomovel);
            veiculoRepository.InserirNovo(veiculo);

            // action
            Locacao locacao = new Locacao(cliente, veiculo, null, DateTime.Now.Date, DateTime.Now.AddDays(2).Date, 200, "Diário", "", "Pendente");
            locacaoRepository.InserirNovo(locacao);


            // assert
            var locacaoEncontrado = locacaoRepository.SelecionarPorId(locacao.Id);
            locacaoEncontrado.Should().Be(locacao);
        }

        [TestMethod]
        public void DeveEditar_Locacao()
        {
            // arrange
            Cliente cliente = new Cliente("Tiago Santini", "testador@ndd.com", "Maria de Melo Kuster", "(49) 9805-6251", "CPF", "123123124", new DateTime(2025, 06, 30), "41421412412", "41242121412", null);
            clienteRepository.InserirNovo(cliente);

            //GrupoAutomoveis grupoAutomovel = new GrupoAutomoveis("Econômico", 100, 120, 140, 160, 100, 180);
            //grupoAutomoveisRepository.InserirNovo(grupoAutomovel);

            //Veiculo veiculo = new Veiculo(foto, "ABC-1234", "Vectra", "Chevrolet", "Gasolina", 70, 2000, grupoAutomovel);
            //veiculoRepository.InserirNovo(veiculo);

            Locacao locacao = new Locacao(cliente, null, null, DateTime.Now.Date, DateTime.Now.AddDays(2).Date, 200, "Diário", "", "Pendente");
            locacaoRepository.InserirNovo(locacao);

            // action
            Cliente novoCliente = new Cliente("Lucas", "testador@ndd.com", "Teste", "(49) 9805-6251", "CPF", "1212432433", new DateTime(2025, 06, 30), "41421412412", "41242121412", null);
            clienteRepository.InserirNovo(novoCliente);

            //GrupoAutomoveis novoGrupoAutomovel = new GrupoAutomoveis("SUV", 200, 220, 240, 260, 200, 280);
            //grupoAutomoveisRepository.InserirNovo(novoGrupoAutomovel);

            //Veiculo novoVeiculo = new Veiculo(foto, "DEF-5634", "uno", "Chevrolet", "Gasolina", 50, 20000, novoGrupoAutomovel);
            //veiculoRepository.InserirNovo(novoVeiculo);

            Locacao novaLocacao = new Locacao(novoCliente, null, null, DateTime.Now.Date, DateTime.Now.AddDays(2).Date, 200, "Controlado", "", "Pendente");
            locacaoRepository.InserirNovo(novaLocacao);

            locacaoRepository.Editar(locacao.Id, novaLocacao);

            // assert
            var locacaoEncontrado = locacaoRepository.SelecionarPorId(locacao.Id);
            locacaoEncontrado.Should().Be(novaLocacao);
        }

        [TestMethod]
        public void DeveExcluir_Locacao()
        {
            // arrange
            Cliente cliente = new Cliente("Tiago Santini", "testador@ndd.com", "Maria de Melo Kuster", "(49) 9805-6251", "CPF", "123123124", new DateTime(2025, 06, 30), "41421412412", "41242121412", null);
            clienteRepository.InserirNovo(cliente);

            //GrupoAutomoveis grupoAutomovel = new GrupoAutomoveis("Econômico", 100, 120, 140, 160, 100, 180);
            //grupoAutomoveisRepository.InserirNovo(grupoAutomovel);

            //Veiculo veiculo = new Veiculo(foto, "ABC-1234", "Vectra", "Chevrolet", "Gasolina", 70, 2000, grupoAutomovel);
            //veiculoRepository.InserirNovo(veiculo);

            Locacao locacao = new Locacao(cliente, null, null, DateTime.Now.Date, DateTime.Now.AddDays(2).Date, 200, "Diário", null, null);
            locacaoRepository.InserirNovo(locacao);

            // action
            locacaoRepository.Excluir(locacao.Id);

            // assert
            Locacao locacaoEncontrada = locacaoRepository.SelecionarPorId(locacao.Id);
            locacaoEncontrada.Should().BeNull();
        }

        [TestMethod]
        public void DeveSelecionar_Locacao_PorId()
        {
            // arrange
            Cliente cliente = new Cliente("Tiago Santini", "testador@ndd.com", "Maria de Melo Kuster", "(49) 9805-6251", "CPF", "123123124", new DateTime(2025, 06, 30), "41421412412", "41242121412", null);
            clienteRepository.InserirNovo(cliente);

            //GrupoAutomoveis grupoAutomovel = new GrupoAutomoveis("Econômico", 100, 120, 140, 160, 100, 180);
            //grupoAutomoveisRepository.InserirNovo(grupoAutomovel);

            //Veiculo veiculo = new Veiculo(foto, "ABC-1234", "Vectra", "Chevrolet", "Gasolina", 70, 2000, grupoAutomovel);
            //veiculoRepository.InserirNovo(veiculo);

            Locacao locacao = new Locacao(cliente, null, null, DateTime.Now.Date, DateTime.Now.AddDays(2).Date, 200, "Diário", null, null);
            locacaoRepository.InserirNovo(locacao);

            // action
            Locacao locacaoEncontrada = locacaoRepository.SelecionarPorId(locacao.Id);

            // assert
            locacaoEncontrada.Should().NotBeNull();
        }

        [TestMethod]
        public void DeveSelecionar_Todas_Locacoes()
        {
            // arrange
            //locacao 1
            Cliente cliente = new Cliente("Tiago Santini", "testador@ndd.com", "Maria de Melo Kuster", "(49) 9805-6251", "CPF", "123123124", new DateTime(2025, 06, 30), "41421412412", "41242121412", null);
            clienteRepository.InserirNovo(cliente);

            //GrupoAutomoveis grupoAutomovel = new GrupoAutomoveis("Econômico", 100, 120, 140, 160, 100, 180);
            //grupoAutomoveisRepository.InserirNovo(grupoAutomovel);

            //Veiculo veiculo = new Veiculo(foto, "ABC-1234", "Vectra", "Chevrolet", "Gasolina", 70, 2000, grupoAutomovel);
            //veiculoRepository.InserirNovo(veiculo);

            //locacao 2
            Cliente novoCliente = new Cliente("Lucas", "testador@ndd.com", "Teste", "(49) 9805-6251", "CPF", "1212432433", new DateTime(2025, 06, 30), "41421412412", "41242121412", null);
            clienteRepository.InserirNovo(novoCliente);

            //GrupoAutomoveis novoGrupoAutomovel = new GrupoAutomoveis("SUV", 200, 220, 240, 260, 200, 280);
            //grupoAutomoveisRepository.InserirNovo(novoGrupoAutomovel);

            //Veiculo novoVeiculo = new Veiculo(foto, "DEF-5634", "uno", "Chevrolet", "Gasolina", 70, 2000, novoGrupoAutomovel);
            //veiculoRepository.InserirNovo(novoVeiculo);

            var locacaoes = new List<Locacao>
            {
                new Locacao(cliente, null, null, DateTime.Now.Date, DateTime.Now.AddDays(2).Date, 200, "Diário", null, null),

                new Locacao(novoCliente, null, null, DateTime.Now.Date, DateTime.Now.AddDays(2).Date, 200, "Controlado", null, null)
            };

            foreach (var l in locacaoes)
                locacaoRepository.InserirNovo(l);

            // action
            var locacaoesEncontradas = locacaoRepository.SelecionarTodos();

            // assert
            locacaoesEncontradas.Should().HaveCount(2);
        }
    }
}
