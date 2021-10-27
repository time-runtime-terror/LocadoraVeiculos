using LocadoraVeiculos.Infra.ExtensionMethods;
using LocadoraVeiculos.netCore.Dominio.LocacaoModule;
using LocadoraVeiculos.netCore.Dominio.TaxasServicosModule;
using Serilog;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LocadoraVeiculos.Aplicacao.LocacaoModule
{
    public class LocacaoAppService
    {
        private readonly ILocacaoRepository locacaoRepository;
        private readonly IGeradorRecibo geradorRecibo;
        //private readonly INotificadorEmail notificadorEmail;
        //private readonly IVerificadorConexao verificadorConexao;
        private readonly IArmazenadorEmail armazenadorEmail;

        public LocacaoAppService(ILocacaoRepository locacaoRepository,
            IGeradorRecibo geradorRecibo,
           IArmazenadorEmail armazenadorEmail)
        {
            this.locacaoRepository = locacaoRepository;
            this.geradorRecibo = geradorRecibo;
            //this.notificadorEmail = notificadorEmail;
            //this.verificadorConexao = verificadorConexao;
            this.armazenadorEmail = armazenadorEmail;
        }

        public bool RegistrarNovaLocacao(Locacao locacao)
        {
            Log.Logger.Aqui().Debug("Inserindo nova {TipoRegistro}: {@Locacao}", "Locacao", locacao);

            string resultadoValidacao = locacao.Validar();

            if (resultadoValidacao == "ESTA_VALIDO")
            {
                try
                {
                    locacaoRepository.InserirNovo(locacao);

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

        public string RegistrarDevolucao(Locacao locacao)
        {
            Log.Logger.Aqui().Debug("Registrando devolução da {TipoRegistro} ID: {IdLocacao}", "Locacao", locacao.Id);

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


                    armazenadorEmail.AgendarEnvioEmail(emailCliente, caminhoRecibo);

                    resultadoValidacao = $"Devolução concluída com sucesso! O recibo de devolução foi enviado para o email {locacao.Cliente.Email}";

                    Log.Logger.Aqui().Debug("Devolução concluída com sucesso! Email enviado com sucesso. ID: {IdLocacao}", locacao.Id);

                    //bool temInternet = verificadorConexao.TemConexaoComInternet();

                    //if (temInternet)
                    //{
                    //    notificadorEmail.EnviarEmailAsync(emailCliente, caminhoRecibo);

                    //    resultadoValidacao = $"Devolução concluída com sucesso! O recibo de devolução foi enviado para o email {locacao.Cliente.Email}";

                    //    Log.Logger.Aqui().Debug("Devolução concluída com sucesso! Email enviado com sucesso. ID: {IdLocacao}", locacao.Id);
                    //}
                    //else
                    //{
                    //    notificadorEmail.AgendarEnvioEmailAsync(emailCliente, caminhoRecibo);

                    //    resultadoValidacao = "Devolução concluída com sucesso! Sem conexão com a internet; o envio do recibo foi agendado para mais tarde";

                    //    Log.Logger.Aqui().Debug("Devolução concluída com sucesso! Envio de email agendado... ID: {IdLocacao}", locacao.Id);
                    //}
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
                    locacaoRepository.Editar(id, registro);

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
                if (locacaoRepository.Excluir(locacao.Id))
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
                return locacaoRepository.SelecionarPorId(id);
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
                return locacaoRepository.SelecionarTodos();
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
                return locacaoRepository.SelecionarTodasLocacoesConcluidas();
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
                return locacaoRepository.SelecionarTodasLocacoesPendentes();
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Falha ao tentar selecionar todas as locações pendentes!");
            }

            return null;
        }

        //public async Task<bool> EnviarEmailsAgendados()
        //{
        //    try
        //    {
        //        await notificadorEmail.EnviarEmailsAgendadosAsync();
        //        return true;
        //    }
        //    catch (Exception ex)
        //    {
        //        Log.Error(ex, "Falha ao tentar enviar emails agendados.");
        //    }

        //    return false;
        //}

        public List<Locacao> Pesquisar(string texto)
        {
            throw new NotImplementedException();
        }
    }
}
