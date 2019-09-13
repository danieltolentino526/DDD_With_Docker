using Autofac;
using System.Reflection;

namespace Ioc.Modules
{
    public class InfrastructureModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {        
            builder.RegisterAssemblyTypes(Assembly.Load(nameof(Infra)))
                   .Where(x => x.Namespace.Contains("Infra.Repositories") || x.Namespace.Contains("Infra.Context"))
                   .AsImplementedInterfaces()
                   .AsSelf()
                   .InstancePerLifetimeScope();          
        }
    }
}
