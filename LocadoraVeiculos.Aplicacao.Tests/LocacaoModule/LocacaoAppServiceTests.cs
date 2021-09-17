using LocadoraVeiculos.Aplicacao.LocacaoModule;
using LocadoraVeiculos.netCore.Dominio.ClienteModule;
using LocadoraVeiculos.netCore.Dominio.LocacaoModule;
using LocadoraVeiculos.netCore.Dominio.VeiculoModule;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;

namespace LocadoraVeiculos.Aplicacao.Tests.LocacaoModule
{
    [TestClass]
    public class LocacaoAppServiceTests
    {
        byte[] foto = new byte[] { 0x20, 0x20, 0x20, 0x20, 0x20, 0x20, 0x20 };

        [TestMethod]
        [TestCategory("Aplicação")]
        public void Deve_Gerar_Recibo_Locacao()
        {
            // arrange
            Cliente cliente = new Cliente("Testador 1", "testador@ndd.com", "Maria de Melo Kuster", "(49) 9805-6251", "CPF", "123123124", new DateTime(2025, 06, 30), "41421412412", "41242121412", null);

            Veiculo veiculo = new Veiculo(foto, "ABC-1234", "Vectra", "Chevrolet", "Gasolina", 70, 2000, null);

            Locacao locacao = new Locacao(cliente, veiculo, null, DateTime.Now, DateTime.Now.AddDays(2), 200, "Diário", null, null);

            Mock<ILocacaoRepository> locacaoDaoMock = new Mock<ILocacaoRepository>();

            Mock<IGeradorRecibo> geradorReciboMock = new Mock<IGeradorRecibo>();

            LocacaoAppService locacaoService = new LocacaoAppService(locacaoDaoMock.Object, geradorReciboMock.Object, Mock.Of<INotificadorEmail>(), Mock.Of<IVerificadorConexao>());

            // action
            locacaoService.RegistrarNovaLocacao(locacao);

            // assert
            geradorReciboMock.Verify(x => x.GerarRecibo(It.IsAny<Locacao>()));
        }

        [TestMethod]
        [TestCategory("Aplicação")]
        public void Deve_Enviar_Email_Locacao()
        {
            // arrange
            Cliente cliente = new Cliente("Testador 1", "testador@ndd.com", "Maria de Melo Kuster", "(49) 9805-6251", "CPF", "123123124", new DateTime(2025, 06, 30), "41421412412", "41242121412", null);

            Veiculo veiculo = new Veiculo(foto, "ABC-1234", "Vectra", "Chevrolet", "Gasolina", 70, 2000, null);

            Locacao locacao = new Locacao(cliente, veiculo, null, DateTime.Now, DateTime.Now.AddDays(2), 200, "Diário", null, null);

            Mock<ILocacaoRepository> locacaoDaoMock = new Mock<ILocacaoRepository>();

            Mock<INotificadorEmail> notificadorEmailMock = new Mock<INotificadorEmail>();

            Mock<IVerificadorConexao> verificadorConexaoInternetMock = new Mock<IVerificadorConexao>();

            verificadorConexaoInternetMock.Setup(x => x.TemConexaoComInternet())
                .Returns(() =>
                {
                    return true;
                });

            LocacaoAppService locacaoService = new LocacaoAppService(locacaoDaoMock.Object, Mock.Of<IGeradorRecibo>(), notificadorEmailMock.Object, verificadorConexaoInternetMock.Object);

            // action
            locacaoService.RegistrarNovaLocacao(locacao);

            // assert
            notificadorEmailMock.Verify(x => x.EnviarEmailAsync(locacao, null));
        }

        [TestMethod]
        [TestCategory("Aplicação")]
        public void Deveria_Verificar_Conexao_Internet()
        {
            // arrange
            Cliente cliente = new Cliente("Testador 1", "testador@ndd.com", "Maria de Melo Kuster", "(49) 9805-6251", "CPF", "123123124", new DateTime(2025, 06, 30), "41421412412", "41242121412", null);

            Veiculo veiculo = new Veiculo(foto, "ABC-1234", "Vectra", "Chevrolet", "Gasolina", 70, 2000, null);

            Locacao locacao = new Locacao(cliente, veiculo, null, DateTime.Now, DateTime.Now.AddDays(2), 200, "Diário", null, null);

            Mock<ILocacaoRepository> locacaoDaoMock = new Mock<ILocacaoRepository>();

            Mock<IVerificadorConexao> verificadorConexaoInternetMock = new Mock<IVerificadorConexao>();

            verificadorConexaoInternetMock.Setup(x => x.TemConexaoComInternet())
                .Returns(() =>
                {
                    return true;
                });

            LocacaoAppService locacaoService = new LocacaoAppService(locacaoDaoMock.Object, Mock.Of<IGeradorRecibo>(), Mock.Of<INotificadorEmail>(), verificadorConexaoInternetMock.Object);

            // action
            locacaoService.RegistrarNovaLocacao(locacao);

            // assert
            verificadorConexaoInternetMock.Verify(x => x.TemConexaoComInternet());
        } 
    }
}
