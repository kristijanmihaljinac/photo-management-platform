using Autofac;
using Common.Mediator.Core;
using Common.Mediator.Middleware;
using System.Reflection;

namespace PhotoManagementPlatform.IoC.Modules
{
    internal class MediatorModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            var appAssembly = Assembly.Load("PhotoManagementPlatform.Application");
            //var infraAssembly = Assembly.Load("PhotoManagementApp.Infrastructure");
            //var domainAssembly = Assembly.Load("PhotoManagementApp.Domain");

            var assemblies = new List<Assembly> { appAssembly };

            foreach (var assembly in assemblies)
            {
                builder
                    .RegisterAssemblyTypes(assembly)
                    .AsClosedTypesOf(typeof(IMessageHandler<,>))
                    .AsImplementedInterfaces();

                AddMiddleware(assembly, builder);
            }

            builder.Register<ServiceFactoryDelegate>(c =>
            {
                var context = c.Resolve<IComponentContext>();
                return context.Resolve;
            });

            builder.RegisterType<ServiceFactory>()
                        .AsImplementedInterfaces();

            builder.RegisterType<Mediator>()
                        .AsImplementedInterfaces();

            builder.RegisterGeneric(typeof(MessageProcessor<,>))
                        .AsImplementedInterfaces();

            base.Load(builder);
        }

        private void AddMiddleware(Assembly assembly, ContainerBuilder builder)
        {
            var middlewareTypes = assembly.GetTypes().Where(t =>
            {
                return t.GetTypeInfo()
                    .ImplementedInterfaces.Any(
                        i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IMiddleware<,>));
            });

            foreach (var middlewareType in middlewareTypes)
            {
                if (middlewareType.IsGenericType)
                {
                    builder.RegisterGeneric(middlewareType).AsImplementedInterfaces();
                }
                else
                {
                    builder.RegisterType(middlewareType).AsImplementedInterfaces();
                }
            }
        }
    }
}
