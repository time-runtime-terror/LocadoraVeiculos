using LocadoraVeiculos.netCore.Dominio.LocacaoModule;
using log4net.Core;
using System;
using System.Collections.Generic;

namespace LocadoraVeiculos.Aplicacao.LocacaoModule
{
    public class LocacaoAppService
    {
        private readonly ILocacaoRepository locacaoRepository;
        private readonly IGeradorRecibo geradorRecibo;
        private readonly INotificadorEmail notificadorEmail;
        private readonly IVerificadorConexao verificadorConexao;
        private static readonly ILogger logger = LoggerManager.GetLogger("", typeof(LocacaoAppService));

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
                locacaoRepository.InserirNovo(locacao);
            else
                logger.Log(null, Level.Warn, "Falha ao registrar devolução!", null);

            return resultadoValidacao;
        }

        public string RegistrarDevolucao(Locacao locacao)
        {
            string resultadoValidacao = locacao.Validar();

            if (resultadoValidacao == "ESTA_VALIDO")
            {
                locacaoRepository.RegistrarDevolucao(locacao);

                string caminhoRecibo = geradorRecibo.GerarRecibo(locacao);

                bool temInternet = verificadorConexao.TemConexaoComInternet();

                if (temInternet)
                {
                    try
                    {
                        notificadorEmail.EnviarEmailAsync(locacao, caminhoRecibo);
                    }
                    catch (Exception ex)
                    {
                        logger.Log(null, Level.Error, "Falha ao tentar se conectar com o serviço de email!", ex);
                    }
                }
                else
                    logger.Log(null, Level.Warn, "Não há conexão com a internet!", null);
            }
            else
                logger.Log(null, Level.Warn, "Falha ao registrar devolução!", null);

            return resultadoValidacao;
        }

        public string Editar(int id, Locacao registro)
        {
            string resultadoValidacao = registro.Validar();

            if (resultadoValidacao == "ESTA_VALIDO")
                locacaoRepository.Editar(id, registro);

            return resultadoValidacao;
        }

        public bool Excluir(int id)
        {
            if (locacaoRepository.Excluir(id))
                return true;

            return false;
        }

        public Locacao SelecionarPorId(int id)
        {
            return locacaoRepository.SelecionarPorId(id);
        }

        public List<Locacao> SelecionarTodos()
        {
            return locacaoRepository.SelecionarTodos();
        }

        public List<Locacao> SelecionarTodasLocacoesConcluidas()
        {
            return locacaoRepository.SelecionarTodasLocacoesConcluidas();
        }

        public List<Locacao> SelecionarTodasLocacoesPendentes()
        {
            return locacaoRepository.SelecionarTodasLocacoesPendentes();
        }

        public List<Locacao> Pesquisar(string texto)
        {
            throw new NotImplementedException();
        }
    }
}
