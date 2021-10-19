using Autofac;
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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraVeiculos.WindowsApp.Shared
{
    public static class ServiceLocator
    {
        public static IContainer Container { get; private set; }
        private static ContainerBuilder builder;

        static ServiceLocator()
        {
            builder = new ContainerBuilder();

            builder.RegisterType<LocadoraDbContext>().InstancePerLifetimeScope();

            RegistrarORM();
            RegistrarAppService();
            RegistrarOperacoes();

            Container = builder.Build();
        }

        private static void RegistrarORM()
        {

            builder.RegisterType<GrupoAutomoveisRepositoryEF>().As<IGrupoAutomoveisRepository>().InstancePerDependency();

            builder.RegisterType<VeiculoRepositoryEF>().As<IVeiculoRepository>().InstancePerDependency();

            builder.RegisterType<FuncionarioRepositoryEF>().As<IFuncionarioRepository>().InstancePerDependency();

            builder.RegisterType<ClienteRepositoryEF>().As<IClienteRepository>().InstancePerDependency();

          
            builder.RegisterType<TaxasServicosRepositoryEF>().As<ITaxasServicosRepository>().InstancePerDependency();

   

            builder.RegisterType<LocacaoRepositoryEF>().As<ILocacaoRepository>().InstancePerDependency();

        }

        private static void RegistrarAppService()
        {
            
            builder.RegisterType<GrupoAutomoveisAppService>().InstancePerDependency();

            builder.RegisterType<VeiculoAppService>().InstancePerDependency();

            builder.RegisterType<FuncionarioAppService>().InstancePerDependency();

            builder.RegisterType<ClienteAppService>().InstancePerDependency();

            builder.RegisterType<TaxasServicosAppService>().InstancePerDependency();

         

            builder.RegisterType<NotificadorEmail>().As<INotificadorEmail>().InstancePerDependency();

            builder.RegisterType<VerificadorConexao>().As<IVerificadorConexao>().InstancePerDependency();

            builder.RegisterType<GeradorRecibo>().As<IGeradorRecibo>().InstancePerDependency();

            builder.RegisterType<LocacaoAppService>().InstancePerDependency();
        }

        private static void RegistrarOperacoes()
        {

            builder.RegisterType<OperacoesCliente>().InstancePerDependency();

            builder.RegisterType<OperacoesVeiculos>().InstancePerDependency();

            builder.RegisterType<OperacoesGrupoAutomoveis>().InstancePerDependency();

            builder.RegisterType<OperacoesFuncionario>().InstancePerDependency();

            builder.RegisterType<OperacoesTaxasServicos>().InstancePerDependency();

            builder.RegisterType<OperacoesLocacao>().InstancePerDependency();
        }
    }
}
