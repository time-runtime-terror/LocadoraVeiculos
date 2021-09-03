using LocadoraVeiculos.Controladores.ClienteModule;
using LocadoraVeiculos.Controladores.GrupoAutomoveisModule;
using LocadoraVeiculos.Controladores.LocacaoModule;
using LocadoraVeiculos.Controladores.Shared;
using LocadoraVeiculos.Controladores.TaxasServicosModule;
using LocadoraVeiculos.Controladores.VeiculoModule;
using LocadoraVeiculos.Dominio.ClienteModule;
using LocadoraVeiculos.Dominio.GrupoAutomoveisModule;
using LocadoraVeiculos.Dominio.LocacaoModule;
using LocadoraVeiculos.Dominio.VeiculoModule;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using FluentAssertions;
using System.Collections.Generic;

namespace LocadoraVeiculos.Tests.LocacaoModule
{
    [TestClass]
    public class ControladorLocacaoTest
    {
        byte[] foto = new byte[] { 0x20, 0x20, 0x20, 0x20, 0x20, 0x20, 0x20 };
        private ControladorCliente controladorCliente;
        private ControladorVeiculo controladorVeiculo;
        private ControladorGrupoAutomoveis controladorGrupoAutomoveis;
        private ControladorTaxasServicos controladorTaxasServicos;
        private ControladorLocacao controladorLocacao;

        public ControladorLocacaoTest()
       {
            Db.Update("DELETE FROM [TBCLIENTE]");
            Db.Update("DELETE FROM [TBVEICULO]");
            Db.Update("DELETE FROM [TBGRUPOAUTOMOVEIS]");
            Db.Update("DELETE FROM [TBTAXASSERVICOS]");
            Db.Update("DELETE FROM [TBLOCACAO]");

            controladorCliente = new ControladorCliente();
            controladorVeiculo = new ControladorVeiculo();
            controladorGrupoAutomoveis = new ControladorGrupoAutomoveis();
            controladorTaxasServicos = new ControladorTaxasServicos();

            controladorLocacao = new ControladorLocacao(controladorCliente, controladorVeiculo, controladorTaxasServicos);
       }

        [TestMethod]
        public void DeveInserir_Locacao()
        {
            // arrange
            Cliente cliente = new Cliente("Tiago Santini", "testador@ndd.com", "Maria de Melo Kuster", "(49) 9805-6251", "CPF", "123123124", new DateTime(2025, 06, 30), "41421412412", "41242121412", null);
            controladorCliente.InserirNovo(cliente);

            GrupoAutomoveis grupoAutomovel = new GrupoAutomoveis("Econômico", 100, 120, 140, 160, 100, 180);
            controladorGrupoAutomoveis.InserirNovo(grupoAutomovel);

            Veiculo veiculo = new Veiculo(foto, "ABC-1234", "Vectra", "Chevrolet", "Gasolina", 70, 2000, grupoAutomovel);
            controladorVeiculo.InserirNovo(veiculo);

            // action
            Locacao locacao = new Locacao(cliente, veiculo, null, DateTime.Now.Date, DateTime.Now.AddDays(2).Date, 200, "Diário", "", "Pendente");
            controladorLocacao.InserirNovo(locacao);


            // assert
            var locacaoEncontrado = controladorLocacao.SelecionarPorId(locacao.Id);
            locacaoEncontrado.Should().Be(locacao);
        }

        [TestMethod]
        public void DeveEditar_Locacao()
        {
            // arrange
            Cliente cliente = new Cliente("Tiago Santini", "testador@ndd.com", "Maria de Melo Kuster", "(49) 9805-6251", "CPF", "123123124", new DateTime(2025, 06, 30), "41421412412", "41242121412", null);
            controladorCliente.InserirNovo(cliente);

            GrupoAutomoveis grupoAutomovel = new GrupoAutomoveis("Econômico", 100, 120, 140, 160, 100, 180);
            controladorGrupoAutomoveis.InserirNovo(grupoAutomovel);

            Veiculo veiculo = new Veiculo(foto, "ABC-1234", "Vectra", "Chevrolet", "Gasolina", 70, 2000, grupoAutomovel);
            controladorVeiculo.InserirNovo(veiculo);

            Locacao locacao = new Locacao(cliente, veiculo, null, DateTime.Now.Date, DateTime.Now.AddDays(2).Date, 200, "Diário", "", "Pendente");
            controladorLocacao.InserirNovo(locacao);

            // action
            Cliente novoCliente = new Cliente("Lucas", "testador@ndd.com", "Teste", "(49) 9805-6251", "CPF", "1212432433", new DateTime(2025, 06, 30), "41421412412", "41242121412", null);
            controladorCliente.InserirNovo(novoCliente);

            GrupoAutomoveis novoGrupoAutomovel = new GrupoAutomoveis("SUV", 200, 220, 240, 260, 200, 280);
            controladorGrupoAutomoveis.InserirNovo(novoGrupoAutomovel);

            Veiculo novoVeiculo = new Veiculo(foto, "DEF-5634", "uno", "Chevrolet", "Gasolina", 50, 20000, novoGrupoAutomovel);
            controladorVeiculo.InserirNovo(novoVeiculo);

            Locacao novaLocacao = new Locacao(novoCliente, novoVeiculo, null, DateTime.Now.Date, DateTime.Now.AddDays(2).Date, 200, "Controlado", "", "Pendente");
            controladorLocacao.InserirNovo(novaLocacao);

            controladorLocacao.Editar(locacao.Id, novaLocacao);



            // assert
            var locacaoEncontrado = controladorLocacao.SelecionarPorId(locacao.Id);
            locacaoEncontrado.Should().Be(novaLocacao);
        }

        [TestMethod]
        public void DeveExcluir_Locacao()
        {
            // arrange
            Cliente cliente = new Cliente("Tiago Santini", "testador@ndd.com", "Maria de Melo Kuster", "(49) 9805-6251", "CPF", "123123124", new DateTime(2025, 06, 30), "41421412412", "41242121412", null);
            controladorCliente.InserirNovo(cliente);

            GrupoAutomoveis grupoAutomovel = new GrupoAutomoveis("Econômico", 100, 120, 140, 160, 100, 180);
            controladorGrupoAutomoveis.InserirNovo(grupoAutomovel);

            Veiculo veiculo = new Veiculo(foto, "ABC-1234", "Vectra", "Chevrolet", "Gasolina", 70, 2000, grupoAutomovel);
            controladorVeiculo.InserirNovo(veiculo);

            Locacao locacao = new Locacao(cliente, veiculo, null, DateTime.Now.Date, DateTime.Now.AddDays(2).Date, 200, "Diário", null, null);
            controladorLocacao.InserirNovo(locacao);

            // action
            controladorLocacao.Excluir(locacao.Id);

            // assert
            Locacao locacaoEncontrada = controladorLocacao.SelecionarPorId(locacao.Id);
            locacaoEncontrada.Should().BeNull();
        }

        [TestMethod]
        public void DeveSelecionar_Locacao_PorId()
        {
            // arrange
            Cliente cliente = new Cliente("Tiago Santini", "testador@ndd.com", "Maria de Melo Kuster", "(49) 9805-6251", "CPF", "123123124", new DateTime(2025, 06, 30), "41421412412", "41242121412", null);
            controladorCliente.InserirNovo(cliente);

            GrupoAutomoveis grupoAutomovel = new GrupoAutomoveis("Econômico", 100, 120, 140, 160, 100, 180);
            controladorGrupoAutomoveis.InserirNovo(grupoAutomovel);

            Veiculo veiculo = new Veiculo(foto, "ABC-1234", "Vectra", "Chevrolet", "Gasolina", 70, 2000, grupoAutomovel);
            controladorVeiculo.InserirNovo(veiculo);

            Locacao locacao = new Locacao(cliente, veiculo, null, DateTime.Now.Date, DateTime.Now.AddDays(2).Date, 200, "Diário", null, null);
            controladorLocacao.InserirNovo(locacao);

            // action
            Locacao locacaoEncontrada = controladorLocacao.SelecionarPorId(locacao.Id);

            // assert
            locacaoEncontrada.Should().NotBeNull();
        }

        [TestMethod]
        public void DeveSelecionar_Todos_Clientes()
        {
            // arrange
            // arrange
            //locacao 1
            Cliente cliente = new Cliente("Tiago Santini", "testador@ndd.com", "Maria de Melo Kuster", "(49) 9805-6251", "CPF", "123123124", new DateTime(2025, 06, 30), "41421412412", "41242121412", null);
            controladorCliente.InserirNovo(cliente);

            GrupoAutomoveis grupoAutomovel = new GrupoAutomoveis("Econômico", 100, 120, 140, 160, 100, 180);
            controladorGrupoAutomoveis.InserirNovo(grupoAutomovel);

            Veiculo veiculo = new Veiculo(foto, "ABC-1234", "Vectra", "Chevrolet", "Gasolina", 70, 2000, grupoAutomovel);
            controladorVeiculo.InserirNovo(veiculo);

            //locacao 2
            Cliente novoCliente = new Cliente("Lucas", "testador@ndd.com", "Teste", "(49) 9805-6251", "CPF", "1212432433", new DateTime(2025, 06, 30), "41421412412", "41242121412", null);
            controladorCliente.InserirNovo(novoCliente);

            GrupoAutomoveis novoGrupoAutomovel = new GrupoAutomoveis("SUV", 200, 220, 240, 260, 200, 280);
            controladorGrupoAutomoveis.InserirNovo(novoGrupoAutomovel);

            Veiculo novoVeiculo = new Veiculo(foto, "DEF-5634", "uno", "Chevrolet", "Gasolina", 70, 2000, novoGrupoAutomovel);
            controladorVeiculo.InserirNovo(novoVeiculo);

            

            var locacaoes = new List<Locacao>
            {
                new Locacao(cliente, veiculo, null, DateTime.Now.Date, DateTime.Now.AddDays(2).Date, 200, "Diário", null, null),

                new Locacao(novoCliente, novoVeiculo, null, DateTime.Now.Date, DateTime.Now.AddDays(2).Date, 200, "Controlado", null, null)
            };

            foreach (var l in locacaoes)
                controladorLocacao.InserirNovo(l);

            // action
            var locacaoesEncontradas = controladorCliente.SelecionarTodos();

            // assert
            locacaoesEncontradas.Should().HaveCount(2);
        }
    }
}
