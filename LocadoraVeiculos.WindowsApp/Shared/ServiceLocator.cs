using LocadoraVeiculos.Aplicacao.ClienteModule;
using LocadoraVeiculos.Aplicacao.FuncionarioModule;
using LocadoraVeiculos.Aplicacao.GrupoAutomoveisModule;
using LocadoraVeiculos.Aplicacao.LocacaoModule;
using LocadoraVeiculos.Aplicacao.TaxasServicosModule;
using LocadoraVeiculos.Aplicacao.VeiculosModule;
using LocadoraVeiculos.Infra.InternetServices.LocacaoModule;
using LocadoraVeiculos.Infra.ORM;
using LocadoraVeiculos.Infra.ORM.Modules.ClienteModule;
using LocadoraVeiculos.Infra.ORM.Modules.FuncionarioModule;
using LocadoraVeiculos.Infra.ORM.Modules.GrupoAutomoveisModule;
using LocadoraVeiculos.Infra.ORM.Modules.LocacaoModule;
using LocadoraVeiculos.Infra.ORM.Modules.TaxasServicosModule;
using LocadoraVeiculos.Infra.ORM.Modules.VeiculoModule;
using LocadoraVeiculos.Infra.PDF.LocacaoModule;
using LocadoraVeiculos.netCore.Dominio.ClienteModule;
using LocadoraVeiculos.netCore.Dominio.FuncionarioModule;
using LocadoraVeiculos.netCore.Dominio.GrupoAutomoveisModule;
using LocadoraVeiculos.netCore.Dominio.LocacaoModule;
using LocadoraVeiculos.netCore.Dominio.TaxasServicosModule;
using LocadoraVeiculos.netCore.Dominio.VeiculoModule;
using LocadoraVeiculos.WindowsApp.Feature.VeiculoModule;
using LocadoraVeiculos.WindowsApp.Features.ClienteModule;
using LocadoraVeiculos.WindowsApp.Features.FuncionarioModule;
using LocadoraVeiculos.WindowsApp.Features.GrupoAutomoveisModule;
using LocadoraVeiculos.WindowsApp.Features.LocacaoModule;
using LocadoraVeiculos.WindowsApp.Features.TaxasServicosModule;
using Autofac;

namespace LocadoraVeiculos.WindowsApp.Shared
{
    public static class ServiceLocator
    {
        public static IContainer Container { get; private set; }
        private static readonly ContainerBuilder builder;

        static ServiceLocator()
        {
            builder = new ContainerBuilder();

            builder.RegisterType<LocadoraDbContext>().InstancePerLifetimeScope();

            Container = builder
                            .RegistrarORM()
                            .RegistrarAppService()
                            .RegistrarOperacoes()
                            .Build();
        }

        private static ContainerBuilder RegistrarORM(this ContainerBuilder builder)
        {
            builder.RegisterType<GrupoAutomoveisRepositoryEF>().As<IGrupoAutomoveisRepository>();

            builder.RegisterType<VeiculoRepositoryEF>().As<IVeiculoRepository>();

            builder.RegisterType<FuncionarioRepositoryEF>().As<IFuncionarioRepository>();

            builder.RegisterType<ClienteRepositoryEF>().As<IClienteRepository>();
          
            builder.RegisterType<TaxasServicosRepositoryEF>().As<ITaxasServicosRepository>();

            builder.RegisterType<SolicitacaoEmailRepositoryEF>().As<ISolicitacaoEmailRepository>();

            builder.RegisterType<LocacaoRepositoryEF>().As<ILocacaoRepository>();

            return builder;
        }

        private static ContainerBuilder RegistrarAppService(this ContainerBuilder builder)
        {
            builder.RegisterType<GrupoAutomoveisAppService>();

            builder.RegisterType<VeiculoAppService>();

            builder.RegisterType<FuncionarioAppService>();

            builder.RegisterType<ClienteAppService>();

            builder.RegisterType<TaxasServicosAppService>();

            builder.RegisterType<GeradorRecibo>().As<IGeradorRecibo>();

            builder.RegisterType<NotificadorEmail>().As<INotificadorEmail>();

            builder.RegisterType<VerificadorConexao>().As<IVerificadorConexao>();

            builder.RegisterType<LocacaoAppService>();

            return builder;
        }

        private static ContainerBuilder RegistrarOperacoes(this ContainerBuilder builder)
        {
            builder.RegisterType<OperacoesCliente>();

            builder.RegisterType<OperacoesVeiculos>();

            builder.RegisterType<OperacoesGrupoAutomoveis>();

            builder.RegisterType<OperacoesFuncionario>();

            builder.RegisterType<OperacoesTaxasServicos>();

            builder.RegisterType<OperacoesLocacao>();

            return builder;
        }
    }
}
