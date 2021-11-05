using System;
using System.Collections.Generic;
using LocadoraVeiculos.Infra.ExtensionMethods;
using LocadoraVeiculos.netCore.Dominio.LocacaoModule;
using Serilog;

namespace LocadoraVeiculos.Aplicacao.LocacaoModule
{
    public class LocacaoAppService
    {
        private readonly ILocacaoRepository _locacaoRepository;
        private readonly IGeradorRecibo _geradorRecibo;
        private readonly IVerificadorConexao _verificadorConexao;
        private readonly INotificadorEmail _notificadorEmail;
        private readonly ISolicitacaoEmailRepository _solicitacaoEmailRepo;

        public LocacaoAppService(ILocacaoRepository locacaoRepository,
            IGeradorRecibo geradorRecibo,
            IVerificadorConexao verificadorConexao,
            INotificadorEmail notificadorEmail,
            ISolicitacaoEmailRepository solicitacaoEmailRepo)
        {
            _locacaoRepository = locacaoRepository;
            _geradorRecibo = geradorRecibo;
            _verificadorConexao = verificadorConexao;
            _notificadorEmail = notificadorEmail;
            _solicitacaoEmailRepo = solicitacaoEmailRepo;
        }

        public bool RegistrarNovaLocacao(Locacao locacao)
        {
            Log.Logger.Aqui().Debug("Inserindo nova {TipoRegistro}: {@Locacao}", "Locacao", locacao.Id);

            string resultadoValidacao = locacao.Validar();

            if (resultadoValidacao == "ESTA_VALIDO")
            {
                try
                {
                    _locacaoRepository.InserirNovo(locacao);

                    Log.Logger.Aqui().Debug("{TipoRegistro} registrada com sucesso! ID: {IdLocacao}", "Locacao", locacao.Id);
                }
                catch (Exception ex)
                {
                    Log.Error(ex, "Falha ao tentar registrar {TipoRegistro}! ID: {IdLocacao}", "Locacao", locacao.Id);
                    return false;
                }
            }

            return true;
        }

        public bool EnviarEmail(SolicitacaoEmail email)
        {
            if (!_verificadorConexao.TemConexaoComInternet())
            {
                Log.Logger.Aqui().Debug("Não foi possível se conectar com a internet!");
                return false;
            }

            try
            {
                return _notificadorEmail.EnviarEmail(email);
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public string RegistrarDevolucao(Locacao locacao)
        {
            Log.Logger.Aqui().Debug("Registrando devolução da {TipoRegistro} ID: {IdLocacao}", "Locacao", locacao.Id);

            string resultadoValidacao = locacao.Validar();

            if (resultadoValidacao == "ESTA_VALIDO")
            {
                try
                {
                    _locacaoRepository.RegistrarDevolucao(locacao);

                    string caminhoRecibo = _geradorRecibo.GerarRecibo(locacao);

                    _solicitacaoEmailRepo.InserirNovo(new SolicitacaoEmail(locacao, caminhoRecibo));

                    resultadoValidacao = $"Devolução concluída com sucesso! O recibo foi encaminhado para envio ao email: {locacao.Cliente.Email}";

                    Log.Logger.Aqui().Debug("Devolução concluída com sucesso! Solicitação de envio de email encaminhada. ID: {IdLocacao}", locacao.Id);
                }
                catch (Exception ex)
                {
                    resultadoValidacao = "ERRO_INSERCAO";
                    Log.Error(ex, "Falha ao tentar registrar devolução de {TipoRegistro}! ID: {IdLocacao}", locacao.Id);
                }
            }

            return resultadoValidacao;
        }

        public bool Editar(int id, Locacao registro)
        {
            Log.Logger.Aqui().Debug("Editando locação: {@Locacao}", registro);

            string resultadoValidacao = registro.Validar();

            if (resultadoValidacao == "ESTA_VALIDO")
            {
                try
                {
                    _locacaoRepository.Editar(id, registro);

                    Log.Logger.Aqui().Debug("Edição concluída com sucesso! ID: {IdLocacao}", id);

                    return true;
                }
                catch (Exception ex)
                {
                    Log.Error(ex, "Falha ao tentar editar devolução do Cliente: {Cliente}", registro.Cliente);
                }
            }

            return false;
        }

        public bool Excluir(Locacao locacao)
        {
            Log.Logger.Aqui().Debug("Excluindo locação: {IdLocacao}", locacao.Id);

            try
            {
                if (_locacaoRepository.Excluir(locacao.Id))
                {
                    Log.Logger.Aqui().Debug("Exclusão concluída com sucesso! ID: {IdLocacao}", locacao.Id);
                    return true;
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Falha ao tentar excluir locação. ID: {IdLocacao}", locacao.Id);
            }

            return false;
        }

        public Locacao SelecionarPorId(int id)
        {
            Log.Logger.Aqui().Debug("Selecionando {TipoRegistro} por ID: {IdLocacao}", "Locacao", id);

            try
            {
                return _locacaoRepository.SelecionarPorId(id);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Falha ao tentar selecionar {TipoRegistro}! ID: {IdLocacao}", "Locacao", id);
            }

            return null;
        }

        public List<Locacao> SelecionarTodos()
        {
            Log.Logger.Aqui().Debug("Selecionando todos os registros de {TipoRegistro}", "Locacao");

            try
            {
                return _locacaoRepository.SelecionarTodos();
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Falha ao tentar selecionar registros de {TipoRegistro}!", "Locacao");
            }

            return null;
        }

        public List<Locacao> SelecionarTodasLocacoesConcluidas()
        {
            Log.Logger.Aqui().Debug("Selecionando todas as locações concluídas");

            try
            {
                return _locacaoRepository.SelecionarTodasLocacoesConcluidas();
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Falha ao tentar selecionar todas as locações concluídas!");
            }

            return null;
        }

        public List<Locacao> SelecionarTodasLocacoesPendentes()
        {
            Log.Logger.Aqui().Debug("Selecionando todas as locações pendentes");

            try
            {
                return _locacaoRepository.SelecionarTodasLocacoesPendentes();
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Falha ao tentar selecionar todas as locações pendentes!");
            }

            return null;
        }

        public List<Locacao> Pesquisar(string texto)
        {
            throw new NotImplementedException();
        }
    }
}
