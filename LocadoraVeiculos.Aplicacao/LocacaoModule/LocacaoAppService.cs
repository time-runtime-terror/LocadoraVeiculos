using LocadoraVeiculos.netCore.Dominio.LocacaoModule;
using log4net;
using System;
using System.Collections.Generic;
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

        public bool RegistrarNovaLocacao(Locacao locacao)
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
                    logger.Error("Falha ao tentar registrar locação", ex);
                    return false;
                }
            }

            return true;
        }

        public string RegistrarDevolucao(Locacao locacao)
        {
            string resultadoValidacao = locacao.Validar();

            if (resultadoValidacao == "ESTA_VALIDO")
            {
                try
                {
                    locacaoRepository.RegistrarDevolucao(locacao);

                    string caminhoRecibo = geradorRecibo.GerarRecibo(locacao);

                    bool temInternet = verificadorConexao.TemConexaoComInternet();

                    if (temInternet)
                    {
                        notificadorEmail.EnviarEmailAsync(locacao, caminhoRecibo);
                        resultadoValidacao = $"Devolução concluída com sucesso! O recibo de devolução foi enviado para o email {locacao.Cliente.Email}";
                    }
                    else
                        resultadoValidacao = "Devolução concluída com sucesso! Sem conexão com a internet; o recibo de devolução não foi enviado.";
                }
                catch (Exception ex)
                {
                    resultadoValidacao = "ERRO_INSERCAO";
                    logger.Error("Falha ao tentar registrar devolução", ex);
                }
            }

            return resultadoValidacao;
        }

        public bool Editar(int id, Locacao registro)
        {
            string resultadoValidacao = registro.Validar();

            if (resultadoValidacao == "ESTA_VALIDO")
            {
                try
                {
                    locacaoRepository.Editar(id, registro);
                    return true;
                }
                catch (Exception ex)
                {
                    logger.Error("Falha ao tentar editar devolução", ex);
                }
            }

            return false;
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
                logger.Error("Falha ao tentar excluir devolução", ex);
            }

            return false;
        }

        public Locacao SelecionarPorId(int id)
        {
            try
            {
                return locacaoRepository.SelecionarPorId(id);
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message);
            }

            return null;
        }

        public List<Locacao> SelecionarTodos()
        {
            try
            {
                return locacaoRepository.SelecionarTodos();
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message);
            }

            return null;
        }

        public List<Locacao> SelecionarTodasLocacoesConcluidas()
        {
            try
            {
                return locacaoRepository.SelecionarTodasLocacoesConcluidas();
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message);
            }

            return null;
        }

        public List<Locacao> SelecionarTodasLocacoesPendentes()
        {
            try
            {
                return locacaoRepository.SelecionarTodasLocacoesPendentes();
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message);
            }

            return null;
        }

        public List<Locacao> Pesquisar(string texto)
        {
            throw new NotImplementedException();
        }
    }
}
