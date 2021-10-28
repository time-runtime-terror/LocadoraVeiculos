using System;
using System.Collections.Concurrent;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using LocadoraVeiculos.netCore.Dominio.LocacaoModule;

namespace LocadoraVeiculos.EmailService.Workers
{
    public class EmailWorker : BackgroundService
    {
        private readonly ILogger<EmailWorker> _logger;
        private readonly INotificadorEmail _notificadorEmail;
        private readonly IVerificadorConexao _verificadorConexao;

        public EmailWorker(ILogger<EmailWorker> logger, INotificadorEmail notificadorEmail, IVerificadorConexao verificadorConexao)
        {
            _logger = logger;
            _notificadorEmail = notificadorEmail;
            _verificadorConexao = verificadorConexao;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (true)
            {
                ConcurrentBag<Email> emails = new ConcurrentBag<Email>(_notificadorEmail.ObterEmailsAgendados());

                if (emails.Count == 0)
                {
                    _logger.LogInformation("Não há emails à serem enviados, aguardando 1 minuto...");

                    await Task.Delay(100000, stoppingToken);
                    continue;
                }
                else if (_verificadorConexao.TemConexaoComInternet() == false)
                {
                    _logger.LogInformation("Falha ao se conectar com o serviço de email, não há conexão com a internet..."); ;

                    await Task.Delay(100000, stoppingToken);
                    continue;
                }

                try
                {
                    Parallel.ForEach(emails, (email) =>
                    {
                        bool conseguiuEnviar = _notificadorEmail.EnviarEmailAgendado(email);

                        if (conseguiuEnviar)
                            _logger.LogInformation("Email enviado ao endereço {enderecoEmail} com sucesso!", email.EmailCliente);
                        else
                            _logger.LogError("Falha ao enviar email ao endereço {enderecoEmail}!", email.EmailCliente);

                    });
                }
                catch (Exception)
                {
                    _logger.LogError("Houve um erro inesperado ao tentar enviar o email!");
                }
            }
        }
    }
}
