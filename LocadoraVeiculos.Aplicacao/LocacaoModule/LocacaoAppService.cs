using LocadoraVeiculos.netCore.Dominio.LocacaoModule;
using System;
using System.Collections.Generic;
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
                    notificadorEmail.EnviarEmailAsync(locacao,caminhoRecibo);
                else
                {
                    Debug.WriteLine("Não há conexão com a internet!");
                }
            }

            return resultadoValidacao;
        }

        public string RegistrarDevolucao(Locacao locacao)
        {
            string resultadoValidacao = locacao.Validar();

            if (resultadoValidacao == "ESTA_VALIDO")
                locacaoRepository.RegistrarDevolucao(locacao);
            else
            {
                // Log
            }

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

        public IList<Locacao> SelecionarTodos()
        {
            return locacaoRepository.SelecionarTodos();
        }

        public IList<Locacao> SelecionarTodasLocacoesConcluidas()
        {
            return locacaoRepository.SelecionarTodasLocacoesConcluidas();
        }

        public IList<Locacao> SelecionarTodasLocacoesPendentes()
        {
            return locacaoRepository.SelecionarTodasLocacoesPendentes();
        }

        public IList<Locacao> Pesquisar(string texto)
        {
            throw new NotImplementedException();
        }
    }
}
