using Autofac;
using Autofac.Extensions.DependencyInjection;
using LocadoraVeiculos.EmailService.Workers;
using LocadoraVeiculos.Infra.Logging;
using LocadoraVeiculos.netCore.Dominio.LocacaoModule;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;
using System.IO;
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
                    builder.RegisterType<INotificadorEmail>().SingleInstance();
                    builder.RegisterType<IVerificadorConexao>().SingleInstance();
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
