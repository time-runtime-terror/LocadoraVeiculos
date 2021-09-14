using LocadoraVeiculos.netCore.Dominio.LocacaoModule;
using System.Diagnostics;

namespace LocadoraVeiculos.Aplicacao.LocacaoModule
{
    public class LocacaoAppService
    {
        private readonly ILocacaoRepository locacaoRepository;
        private readonly IGeradorRecibo geradorRecibo;
        private readonly INotificadorEmail notificadorEmail;
        private readonly IVerificadorConexao verificadorConexao;

        public LocacaoAppService(ILocacaoRepository locacaoRepository, 
            IGeradorRecibo geradorRecibo,
            INotificadorEmail notificadorEmail,
            IVerificadorConexao verificadorConexao)
        {
            this.locacaoRepository = locacaoRepository;
            this.geradorRecibo = geradorRecibo;
            this.notificadorEmail = notificadorEmail;
            this.verificadorConexao = verificadorConexao;
        }

        public string RegistrarNovaLocacao(Locacao locacao)
        {
            string resultadoValidacao = locacao.Validar();

            if (resultadoValidacao == "ESTA_VALIDO")
            {
                locacaoRepository.InserirNovo(locacao);

                string caminhoRecibo = geradorRecibo.GerarRecibo(locacao);

                bool temInternet = verificadorConexao.TemConexaoComInternet();

                if (temInternet)
                    notificadorEmail.EnviarEmailAsync(caminhoRecibo);
                else
                {
                    Debug.WriteLine("Não há conexão com a internet!");
                }
            }

            return resultadoValidacao;
        }
    }
}
