using LocadoraVeiculos.Infra.Logging;
using LocadoraVeiculos.netCore.Dominio.LocacaoModule;
using Serilog;
using Serilog.Events;
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
            Log.Debug("Registrando nova locação do Cliente: {Cliente}", locacao.Cliente);

            string resultadoValidacao = locacao.Validar();

            if (resultadoValidacao == "ESTA_VALIDO")
            {
                try
                {
                    locacaoRepository.InserirNovo(locacao);
                }
                catch (Exception ex)
                {
                    Log.Error(ex, "Falha ao tentar registrar locação do Cliente: {Cliente}", locacao.Cliente);
                    return false;
                }
            }

            return true;
        }

        public string RegistrarDevolucao(Locacao locacao)
        {
            Log.Debug("Registrando devolução do Cliente: {Cliente}", locacao.Cliente);

            string resultadoValidacao = locacao.Validar();

            if (resultadoValidacao == "ESTA_VALIDO")
            {
                try
                {
                    locacaoRepository.RegistrarDevolucao(locacao);

                    string caminhoRecibo = geradorRecibo.GerarRecibo(locacao);

                    Email emailCliente = new Email
                    { 
                        NomeCliente = locacao.Cliente.Nome,
                        EmailCliente = locacao.Cliente.Email,
                        CaminhoArquivo = caminhoRecibo 
                    };

                    bool temInternet = verificadorConexao.TemConexaoComInternet();

                    if (temInternet)
                    {
                        notificadorEmail.EnviarEmailAsync(emailCliente, caminhoRecibo);
                        resultadoValidacao = $"Devolução concluída com sucesso! O recibo de devolução foi enviado para o email {locacao.Cliente.Email}";
                    }
                    else
                    {
                        notificadorEmail.AgendarEnvioEmailAsync(emailCliente, caminhoRecibo);
                        resultadoValidacao = "Devolução concluída com sucesso! Sem conexão com a internet; o envio do recibo foi agendado para mais tarde";
                    }
                }
                catch (Exception ex)
                {
                    resultadoValidacao = "ERRO_INSERCAO";
                    Log.Error(ex, "Falha ao tentar registrar devolução do Cliente: {Cliente}", locacao.Cliente);
                }
            }

            return resultadoValidacao;
        }

        public bool Editar(int id, Locacao registro)
        {
            Log.Debug("Editando locação Id: {Id}", id);

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
                    Log.Error(ex, "Falha ao tentar editar devolução do Cliente: {Cliente}", registro.Cliente);
                }
            }

            return false;
        }

        public bool Excluir(int id)
        {
            Log.Debug("Excluindo locação Id: {Id}", id);

            try
            {
                if (locacaoRepository.Excluir(id))
                    return true;
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Falha ao tentar excluir locação Id: {Id}", id);
            }

            return false;
        }

        public Locacao SelecionarPorId(int id)
        {
            Log.Debug("Selecionando locação Id: {Id}", id);

            try
            {
                return locacaoRepository.SelecionarPorId(id);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
            }

            return null;
        }

        public List<Locacao> SelecionarTodos()
        {
            Log.Debug("Selecionando todas as locações");

            try
            {
                return locacaoRepository.SelecionarTodos();
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
            }

            return null;
        }

        public List<Locacao> SelecionarTodasLocacoesConcluidas()
        {
            Log.Debug("Selecionando todas as locações concluídas");

            try
            {
                return locacaoRepository.SelecionarTodasLocacoesConcluidas();
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
            }

            return null;
        }

        public List<Locacao> SelecionarTodasLocacoesPendentes()
        {
            Log.Debug("Selecionando todas as locações pendentes");

            try
            {
                return locacaoRepository.SelecionarTodasLocacoesPendentes();
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
            }

            return null;
        }

        public List<Locacao> Pesquisar(string texto)
        {
            throw new NotImplementedException();
        }
    }
}
