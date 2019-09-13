using Autofac;
using System.Reflection;

namespace Ioc.Modules
{
    public class ApplicationModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
              builder.RegisterAssemblyTypes(Assembly.Load(nameof(Application)))
                .Where(x => (x.Namespace??string.Empty).Contains("Application.UseCase") || x.Namespace == "Application.Notification")
                .AsImplementedInterfaces()
                .AsSelf()
                .InstancePerLifetimeScope();
           
            base.Load(builder);
        }
    }
}
