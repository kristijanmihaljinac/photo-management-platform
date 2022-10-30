using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PhotoManagementPlatform.Persistence;
using PhotoManagementPlatform.Persistence.Interceptors;
using System.Reflection;

namespace PhotoManagementPlatform.IoC.Modules;

internal static class InfrastructureModule
{
    internal static void Load(IServiceCollection services, IConfiguration configuration)
    {
        string connectionString = configuration.GetConnectionString("Database");
        var appAssembly = Assembly.Load("PhotoManagementPlatform.Application");
        //var infraAssembly = Assembly.Load("PhotoManagementApp.Infrastructure");
        //var domainAssembly = Assembly.Load("PhotoManagementApp.Domain");

        services
         .Scan(
         selector => selector
             .FromAssemblies(
                 PhotoManagementPlatform.Infrastructure.AssemblyReference.Assembly,
                 PhotoManagementPlatform.Persistence.AssemblyReference.Assembly)
             .AddClasses(false)
             .AsImplementedInterfaces()
             .WithScopedLifetime());

        services.AddDbContext<ApplicationDbContext>(
                (sp, optionsBuilder) =>
                {
                    var outboxInterceptor = sp.GetService<ConvertDomainEventsToOutboxMessagesInterceptor>()!;


                    optionsBuilder.UseSqlServer(connectionString)
                        .AddInterceptors(
                            outboxInterceptor
                            );
                });

    }
}

