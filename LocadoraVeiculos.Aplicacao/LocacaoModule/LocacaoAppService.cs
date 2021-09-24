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

        public void RegistrarNovaLocacao(Locacao locacao)
        {
            string resultadoValidacao = locacao.Validar();

            if (resultadoValidacao == "ESTA_VALIDO")
            {
                try
                {
                    locacaoRepository.InserirNovo(locacao);
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
            else
               throw new ArgumentException("Falha ao registrar devolução!");
        }

        public void RegistrarDevolucao(Locacao locacao)
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
        }

        public string Editar(int id, Locacao registro)
        {
            string resultadoValidacao = registro.Validar();

            if (resultadoValidacao == "ESTA_VALIDO")
            {
                try
                {
                    locacaoRepository.Editar(id, registro);
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
            else
                throw new ArgumentException("Falha ao validar registro.");

            return resultadoValidacao;
        }

        public bool Excluir(int id)
        {
            try
            {
                if (locacaoRepository.Excluir(id))
                    return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return false;
        }

        public Locacao SelecionarPorId(int id)
        {
            Locacao locacaoSelecionada;
            try
            {
                locacaoSelecionada = locacaoRepository.SelecionarPorId(id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return locacaoSelecionada;
        }

        public List<Locacao> SelecionarTodos()
        {
            List<Locacao> locacoesSelecionadas;
            try
            {
                locacoesSelecionadas = locacaoRepository.SelecionarTodos();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return locacoesSelecionadas;
        }

        public List<Locacao> SelecionarTodasLocacoesConcluidas()
        {
            List<Locacao> locacoesConcluidas;
            try
            {
                locacoesConcluidas = locacaoRepository.SelecionarTodasLocacoesConcluidas();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return locacoesConcluidas;
        }

        public List<Locacao> SelecionarTodasLocacoesPendentes()
        {
            List<Locacao> locacoesPendentes;
            try
            {
                locacoesPendentes = locacaoRepository.SelecionarTodasLocacoesPendentes();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return locacoesPendentes;
        }

        public List<Locacao> Pesquisar(string texto)
        {
            throw new NotImplementedException();
        }
    }
}
