using System;
using System.Collections.Concurrent;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using LocadoraVeiculos.netCore.Dominio.LocacaoModule;
using LocadoraVeiculos.Aplicacao.LocacaoModule;
using System.Collections.Generic;

namespace LocadoraVeiculos.EmailService.Workers
{
    public class EmailWorker : BackgroundService
    {
        private readonly ILogger<EmailWorker> _logger;
        private readonly LocacaoAppService _locacaoService;
        private readonly ISolicitacaoEmailRepository _solicitacaoRepo;

        public EmailWorker(ILogger<EmailWorker> logger,
            LocacaoAppService locacaoService,
            ISolicitacaoEmailRepository solicitacaoRepo)
        {
            _logger = logger;
            _locacaoService = locacaoService;
            _solicitacaoRepo = solicitacaoRepo;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (true)
            {
                List<SolicitacaoEmail> solicitacoesPendentes = _solicitacaoRepo.SelecionarTodasSolicitacoesPendentes();

                if (solicitacoesPendentes.Count == 0)
                {
                    _logger.LogInformation("Não há emails à serem enviados, aguardando 1 minuto...");

                    await Task.Delay(100000, stoppingToken);
                    continue;
                }

                try
                {
                    Parallel.ForEach(solicitacoesPendentes, (email) =>
                    {
                        bool conseguiuEnviar = _locacaoService.EnviarEmail(email);

                        if (conseguiuEnviar)
                            _logger.LogInformation("Email enviado ao endereço {enderecoEmail} com sucesso!", email.Locacao.Cliente.Email);
                        else
                            _logger.LogError("Falha ao enviar email ao endereço {enderecoEmail}!", email.Locacao.Cliente.Email);

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
