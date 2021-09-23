using LocadoraVeiculos.netCore.Dominio.LocacaoModule;
using log4net;
using System;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using System.Reflection;

namespace LocadoraVeiculos.Aplicacao.LocacaoModule
{
    public class LocacaoAppService
    {
        private readonly ILocacaoRepository locacaoRepository;
        private readonly IGeradorRecibo geradorRecibo;
        private readonly INotificadorEmail notificadorEmail;
        private readonly IVerificadorConexao verificadorConexao;
        private static readonly ILog logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

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
                logger.Warn("Falha ao registrar devolução!");

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
                        throw new Exception(ex.Message);
                    }
                }
                else
                    throw new PingException("Não foi possível estabelecer conexão com a internet");
            }
            else
                throw new ArgumentException("Falha ao validar devolução!");

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
