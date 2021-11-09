using Autofac;
using AutoMapper;
using LocadoraVeiculos.Infra.ORM;
using LocadoraVeiculos.Infra.ORM.Modules.CupomModule;
using LocadoraVeiculos.Infra.ORM.Modules.ParceiroModule;
using LocadoraVeiculos.netCore.Dominio.CupomModule;
using LocadoraVeiculos.netCore.Dominio.ParceiroModule;

namespace LocadoraVeiculos.WebApplication.Autofac
{
    public class ContainerModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<LocadoraDbContext>().InstancePerLifetimeScope();

            builder.RegisterType<ParceiroRepositoryEF>().As<IParceiroRepository>();

            builder.RegisterType<CupomRepositoryEF>().As<ICupomRepository>();

            builder.RegisterType<Mapper>().As<IMapper>();
        }
    }
}
