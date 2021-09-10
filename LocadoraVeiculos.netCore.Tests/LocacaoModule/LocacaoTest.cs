using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using FluentAssertions;
using LocadoraVeiculos.Dominio.ClienteModule;
using LocadoraVeiculos.Dominio.VeiculoModule;
using LocadoraVeiculos.Dominio.LocacaoModule;
using LocadoraVeiculos.Dominio.GrupoAutomoveisModule;
using System.IO;

namespace LocadoraVeiculos.netCore.Tests.LocacaoModule
{
    [TestClass]
    [TestCategory("Dominio")]
    public class LocacaoTest
    {
        byte[] foto = new byte[] { 0x20, 0x20, 0x20, 0x20, 0x20, 0x20, 0x20 };

        [TestMethod]
        public void DeveValidar()
        {
            Cliente cliente = new Cliente("Testador 1", "testador@ndd.com", "Maria de Melo Kuster", "(49) 9805-6251", "CPF", "123123124", new DateTime(2025, 06, 30), "41421412412", "41242121412", null);
            Veiculo veiculo = new Veiculo(foto, "ABC-1234", "Vectra", "Chevrolet", "Gasolina", 70, 2000, null);

            Locacao locacao = new Locacao(cliente, veiculo, null, DateTime.Now, DateTime.Now.AddDays(2), 200, "Diário", null, null);

            string resultado = locacao.Validar();

            resultado.Should().Be("ESTA_VALIDO");
        }

        [TestMethod]
        public void NaoDeveValidarCliente()
        {
            
            Veiculo veiculo = new Veiculo(foto, "ABC-1234", "Vectra", "Chevrolet", "Gasolina", 70, 2000, null);

            Locacao locacao = new Locacao(null, veiculo, null, DateTime.Now, DateTime.Now.AddDays(2), 200, "Diário", null, null);

            string resultado = locacao.Validar();

            resultado.Should().Be("O Cliente deve ser inserido!");
        }

        [TestMethod]
        public void NaoDeveValidarVeiculo()
        {
            Cliente cliente = new Cliente("Testador 1", "testador@ndd.com", "Maria de Melo Kuster", "(49) 9805-6251", "CPF", "123123124", new DateTime(2025, 06, 30), "41421412412", "41242121412", null);

            Locacao locacao = new Locacao(cliente, null, null, DateTime.Now, DateTime.Now.AddDays(2), 200, "Diário", null, null);

            string resultado = locacao.Validar();

            resultado.Should().Be("O Veículo deve ser inserido!");
        }

        [TestMethod]
        public void NaoDesValidarDataDevolucao()
        {
            Cliente cliente = new Cliente("Testador 1", "testador@ndd.com", "Maria de Melo Kuster", "(49) 9805-6251", "CPF", "123123124", new DateTime(2025, 06, 30), "41421412412", "41242121412", null);

            Veiculo veiculo = new Veiculo(foto, "ABC-1234", "Vectra", "Chevrolet", "Gasolina", 70, 2000, null);

            Locacao locacao = new Locacao(cliente, veiculo, null, DateTime.MinValue, DateTime.MinValue, 200, "Diário", null, null);

            string resultado = locacao.Validar();

            resultado.Should().Be("O campo Data de Devolução é obrigatório!");
        }

        [TestMethod]
        public void NaoDeveValidarDataDevolucaoMenorQueAtual()
        {
            Cliente cliente = new Cliente("Testador 1", "testador@ndd.com", "Maria de Melo Kuster", "(49) 9805-6251", "CPF", "123123124", new DateTime(2025, 06, 30), "41421412412", "41242121412", null);

            Veiculo veiculo = new Veiculo(foto, "ABC-1234", "Vectra", "Chevrolet", "Gasolina", 70, 2000, null);

            Locacao locacao = new Locacao(cliente, veiculo, null, new DateTime(2021, 09, 20), new DateTime(2021, 09, 15), 200, "Diário", null, null);

            string resultado = locacao.Validar();

            resultado.Should().Be("O campo Data de Devolução necessita ser maior que a de saida do veículo!");
        }

        [TestMethod]
        public void NaoDeveValidarCaucao()
        {
            Cliente cliente = new Cliente("Testador 1", "testador@ndd.com", "Maria de Melo Kuster", "(49) 9805-6251", "CPF", "123123124", new DateTime(2025, 06, 30), "41421412412", "41242121412", null);

            Veiculo veiculo = new Veiculo(foto, "ABC-1234", "Vectra", "Chevrolet", "Gasolina", 70, 2000, null);

            Locacao locacao = new Locacao(cliente, veiculo, null, DateTime.Now, DateTime.Now.AddDays(2), 0, "Diário", null, null);

            string resultado = locacao.Validar();

            resultado.Should().Be("É necessário, colocar um valor de caução!");
        }

        [TestMethod]
        public void NaoDeveValidarPlano()
        {
            Cliente cliente = new Cliente("Testador 1", "testador@ndd.com", "Maria de Melo Kuster", "(49) 9805-6251", "CPF", "123123124", new DateTime(2025, 06, 30), "41421412412", "41242121412", null);
            Veiculo veiculo = new Veiculo(foto, "ABC-1234", "Vectra", "Chevrolet", "Gasolina", 70, 2000, null);

            Locacao locacao = new Locacao(cliente, veiculo, null, DateTime.Now, DateTime.Now.AddDays(2), 200, null, null, null);

            string resultado = locacao.Validar();

            resultado.Should().Be("A escolha de um plano de locação é obrigatória!");
        }

        [TestMethod]
        public void NaoDeveValidarTodosOsCampos()
        {
            
            Locacao locacao = new Locacao(null, null, null, new DateTime(2002, 02, 22), DateTime.MinValue, 0, null, null, null);

            string resultado = locacao.Validar();

            string resultadoEsperado = "O Cliente deve ser inserido!" 
                + Environment.NewLine
                + "O Veículo deve ser inserido!"
                + Environment.NewLine
                + "O campo Data de Devolução é obrigatório!"
                + Environment.NewLine
                + "O campo Data de Devolução necessita ser maior que a de saida do veículo!"
                + Environment.NewLine
                + "É necessário, colocar um valor de caução!"
                + Environment.NewLine
                + "A escolha de um plano de locação é obrigatória!";


            resultado.Should().Be(resultadoEsperado);
        }

        [TestMethod]
        public void DeveGerar_RelatorioLocacao()
        {
            // arrange
            Cliente cliente = new Cliente("Tiago Santini", "tiagosantiniathayde@gmail.com", "Maria de Melo Kuster", "(49) 9805-6251", "CPF", "123123124", new DateTime(2025, 06, 30), "41421412412", "41242121412", null);

            GrupoAutomoveis grupoAutomovel = new GrupoAutomoveis("Econômico", 100, 120, 140, 160, 100, 180);

            Veiculo veiculo = new Veiculo(foto, "ABC-1234", "Vectra", "Chevrolet", "Gasolina", 70, 2000, grupoAutomovel);

            Locacao locacao = new Locacao(cliente, veiculo, null, DateTime.Now.Date, DateTime.Now.AddDays(2).Date, 200, "Diário", "", "Pendente");

            locacao.Total = 100;

            // action
            locacao.GerarRecibo();

            // assert
            string caminhoArquivo = $"{Path.GetTempPath()}relatorioLocacao.pdf";
            File.Exists(caminhoArquivo).Should().BeTrue();
        }
    }
}
