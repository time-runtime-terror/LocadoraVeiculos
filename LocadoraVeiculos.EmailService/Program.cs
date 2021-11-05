using System.IO;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using LocadoraVeiculos.netCore.Dominio.LocacaoModule;
using LocadoraVeiculos.EmailService.Workers;
using LocadoraVeiculos.Infra.Logging;
using Autofac.Extensions.DependencyInjection;
using Autofac;
using Serilog;
using LocadoraVeiculos.Infra.InternetServices.LocacaoModule;
using LocadoraVeiculos.Aplicacao.LocacaoModule;
using LocadoraVeiculos.Infra.PDF.LocacaoModule;
using LocadoraVeiculos.Infra.ORM.Modules.LocacaoModule;
using LocadoraVeiculos.Infra.ORM;

namespace LocadoraVeiculos.EmailService
{
    public class Program
    {
        public static void Main(string[] args)
        {
            LocadoraLog.CriarLogger();

            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureAppConfiguration(config =>
                    config.AddJsonFile("appsettings.json")
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .Build()
                )
                .UseServiceProviderFactory(new AutofacServiceProviderFactory())
                .ConfigureContainer<ContainerBuilder>((hostContext, builder) =>
                {
                    builder.RegisterType<NotificadorEmail>().As<INotificadorEmail>();
                    builder.RegisterType<VerificadorConexao>().As<IVerificadorConexao>();
                    builder.RegisterType<GeradorRecibo>().As<IGeradorRecibo>();

                    builder.RegisterType<LocadoraDbContext>().InstancePerLifetimeScope();

                    builder.RegisterType<SolicitacaoEmailRepositoryEF>().As<ISolicitacaoEmailRepository>();
                    builder.RegisterType<LocacaoRepositoryEF>().As<ILocacaoRepository>();

                    builder.RegisterType<LocacaoAppService>();
                })
                .ConfigureLogging(configure =>
                {
                    configure.AddSerilog();
                })
                .UseWindowsService()
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddHostedService<EmailWorker>();
                });
    }
}
