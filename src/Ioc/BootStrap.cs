using Autofac;
using Autofac.Extensions.DependencyInjection;
using Ioc.Modules;
using MediatR;
using MediatR.Extensions.Autofac.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;

namespace Ioc
{
    public static class BootStrap
    {
        public static IContainer ConfigureContainer<T>(this IServiceCollection services) 
        {      

            var builder = new ContainerBuilder();
            
            builder.RegisterModule<ApplicationModule>();
            builder.RegisterModule<InfrastructureModule>();
            builder.AddMediatR(typeof(T).Assembly);

            builder.RegisterType<Mediator>().As<IMediator>().AsImplementedInterfaces();           

            builder.Populate(services);

            var container = builder.Build();

            container.Resolve<IMediator>();

            return container;
        }
    }
}
