using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using FluentAssertions;
using LocadoraVeiculos.netCore.Dominio.ClienteModule;
using LocadoraVeiculos.netCore.Dominio.LocacaoModule;
using LocadoraVeiculos.netCore.Dominio.GrupoAutomoveisModule;
using LocadoraVeiculos.netCore.Dominio.VeiculoModule;
using LocadoraVeiculos.Infra.SQL.LocacaoModule;
using LocadoraVeiculos.Infra.SQL.ClienteModule;
using LocadoraVeiculos.Infra.SQL.VeiculosModule;
using LocadoraVeiculos.netCore.Infra.SQL.Shared;
using LocadoraVeiculos.Infra.SQL.GrupoAutomoveisModule;
using LocadoraVeiculos.Infra.SQL.TaxasServicosModule;

namespace LocadoraVeiculos.IntegrationTests.LocacaoModule
{
    [TestClass]
    [TestCategory("DAO/Locacao")]
    public class LocacaoDAOTests
    {
        byte[] foto = new byte[] { 0x20, 0x20, 0x20, 0x20, 0x20, 0x20, 0x20 };

        private GrupoAutomoveisDAO grupoAutomoveisRepository;
        private ClienteDAO clienteRepository;
        private VeiculosDAO veiculoRepository;
        private TaxasServicosDAO taxasServicosRepository;
        private LocacaoDAO locacaoRepository;

        public LocacaoDAOTests()
        {
            Db.Update("DELETE FROM [TBCLIENTE]");
            Db.Update("DELETE FROM [TBVEICULO]");
            Db.Update("DELETE FROM [TBGRUPOAUTOMOVEIS]");
            Db.Update("DELETE FROM [TBTAXASSERVICOS]");
            Db.Update("DELETE FROM [TBLOCACAO]");

            grupoAutomoveisRepository = new GrupoAutomoveisDAO();
            clienteRepository = new ClienteDAO();
            veiculoRepository = new VeiculosDAO(new GrupoAutomoveisDAO());
            taxasServicosRepository = new TaxasServicosDAO();
            locacaoRepository = new LocacaoDAO(clienteRepository, veiculoRepository, taxasServicosRepository);
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

            GrupoAutomoveis grupoAutomovel = new GrupoAutomoveis("Econômico", 100, 120, 140, 160, 100, 180);
            grupoAutomoveisRepository.InserirNovo(grupoAutomovel);

            Veiculo veiculo = new Veiculo(foto, "ABC-1234", "Vectra", "Chevrolet", "Gasolina", 70, 2000, grupoAutomovel);
            veiculoRepository.InserirNovo(veiculo);

            Locacao locacao = new Locacao(cliente, veiculo, null, DateTime.Now.Date, DateTime.Now.AddDays(2).Date, 200, "Diário", "", "Pendente");
            locacaoRepository.InserirNovo(locacao);

            // action
            Cliente novoCliente = new Cliente("Lucas", "testador@ndd.com", "Teste", "(49) 9805-6251", "CPF", "1212432433", new DateTime(2025, 06, 30), "41421412412", "41242121412", null);
            clienteRepository.InserirNovo(novoCliente);

            GrupoAutomoveis novoGrupoAutomovel = new GrupoAutomoveis("SUV", 200, 220, 240, 260, 200, 280);
            grupoAutomoveisRepository.InserirNovo(novoGrupoAutomovel);

            Veiculo novoVeiculo = new Veiculo(foto, "DEF-5634", "uno", "Chevrolet", "Gasolina", 50, 20000, novoGrupoAutomovel);
            veiculoRepository.InserirNovo(novoVeiculo);

            Locacao novaLocacao = new Locacao(novoCliente, novoVeiculo, null, DateTime.Now.Date, DateTime.Now.AddDays(2).Date, 200, "Controlado", "", "Pendente");
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

            GrupoAutomoveis grupoAutomovel = new GrupoAutomoveis("Econômico", 100, 120, 140, 160, 100, 180);
            grupoAutomoveisRepository.InserirNovo(grupoAutomovel);

            Veiculo veiculo = new Veiculo(foto, "ABC-1234", "Vectra", "Chevrolet", "Gasolina", 70, 2000, grupoAutomovel);
            veiculoRepository.InserirNovo(veiculo);

            Locacao locacao = new Locacao(cliente, veiculo, null, DateTime.Now.Date, DateTime.Now.AddDays(2).Date, 200, "Diário", null, null);
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

            GrupoAutomoveis grupoAutomovel = new GrupoAutomoveis("Econômico", 100, 120, 140, 160, 100, 180);
            grupoAutomoveisRepository.InserirNovo(grupoAutomovel);

            Veiculo veiculo = new Veiculo(foto, "ABC-1234", "Vectra", "Chevrolet", "Gasolina", 70, 2000, grupoAutomovel);
            veiculoRepository.InserirNovo(veiculo);

            Locacao locacao = new Locacao(cliente, veiculo, null, DateTime.Now.Date, DateTime.Now.AddDays(2).Date, 200, "Diário", null, null);
            locacaoRepository.InserirNovo(locacao);

            // action
            Locacao locacaoEncontrada = locacaoRepository.SelecionarPorId(locacao.Id);

            // assert
            locacaoEncontrada.Should().NotBeNull();
        }

        [TestMethod]
        public void DeveSelecionar_Todos_Clientes()
        {
            // arrange
            //locacao 1
            Cliente cliente = new Cliente("Tiago Santini", "testador@ndd.com", "Maria de Melo Kuster", "(49) 9805-6251", "CPF", "123123124", new DateTime(2025, 06, 30), "41421412412", "41242121412", null);
            clienteRepository.InserirNovo(cliente);

            GrupoAutomoveis grupoAutomovel = new GrupoAutomoveis("Econômico", 100, 120, 140, 160, 100, 180);
            grupoAutomoveisRepository.InserirNovo(grupoAutomovel);

            Veiculo veiculo = new Veiculo(foto, "ABC-1234", "Vectra", "Chevrolet", "Gasolina", 70, 2000, grupoAutomovel);
            veiculoRepository.InserirNovo(veiculo);

            //locacao 2
            Cliente novoCliente = new Cliente("Lucas", "testador@ndd.com", "Teste", "(49) 9805-6251", "CPF", "1212432433", new DateTime(2025, 06, 30), "41421412412", "41242121412", null);
            clienteRepository.InserirNovo(novoCliente);

            GrupoAutomoveis novoGrupoAutomovel = new GrupoAutomoveis("SUV", 200, 220, 240, 260, 200, 280);
            grupoAutomoveisRepository.InserirNovo(novoGrupoAutomovel);

            Veiculo novoVeiculo = new Veiculo(foto, "DEF-5634", "uno", "Chevrolet", "Gasolina", 70, 2000, novoGrupoAutomovel);
            veiculoRepository.InserirNovo(novoVeiculo);

            var locacaoes = new List<Locacao>
            {
                new Locacao(cliente, veiculo, null, DateTime.Now.Date, DateTime.Now.AddDays(2).Date, 200, "Diário", null, null),

                new Locacao(novoCliente, novoVeiculo, null, DateTime.Now.Date, DateTime.Now.AddDays(2).Date, 200, "Controlado", null, null)
            };

            foreach (var l in locacaoes)
                locacaoRepository.InserirNovo(l);

            // action
            var locacaoesEncontradas = clienteRepository.SelecionarTodos();

            // assert
            locacaoesEncontradas.Should().HaveCount(2);
        }
    }
}
