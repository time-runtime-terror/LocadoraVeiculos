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
                    builder.RegisterType<NotificadorEmail>().As<INotificadorEmail>().SingleInstance();
                    builder.RegisterType<VerificadorConexao>().As<IVerificadorConexao>().SingleInstance();
                })
                .UseWindowsService()
                .ConfigureLogging(configure =>
                {
                    configure.AddSerilog();
                })
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddHostedService<EmailWorker>();
                });
    }
}
