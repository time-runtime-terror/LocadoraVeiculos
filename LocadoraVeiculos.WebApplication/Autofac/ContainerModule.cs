using Autofac;
using LocadoraVeiculos.Infra.ORM;

namespace LocadoraVeiculos.WebApplication.Autofac
{
    public class ContainerModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<LocadoraDbContext>().InstancePerLifetimeScope();
        }
    }
}
