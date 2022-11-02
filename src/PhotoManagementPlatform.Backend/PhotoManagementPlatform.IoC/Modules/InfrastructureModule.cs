using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PhotoManagementPlatform.Persistence;
using PhotoManagementPlatform.Persistence.Interceptors;

namespace PhotoManagementPlatform.IoC.Modules;

internal static class InfrastructureModule
{
    internal static void Load(IServiceCollection services, IConfiguration configuration)
    {
        string connectionString = configuration.GetConnectionString("Database");

        services
         .Scan(
         selector => selector
             .FromAssemblies(
                 PhotoManagementPlatform.Infrastructure.AssemblyReference.Assembly,
                 PhotoManagementPlatform.Persistence.AssemblyReference.Assembly)
             .AddClasses(false)
             .AsImplementedInterfaces()
             .WithScopedLifetime());

        services.AddSingleton<ConvertDomainEventsToOutboxMessagesInterceptor>();

        services.AddSingleton<UpdateAuditableEntitiesInterceptor>();

        services.AddDbContext<ApplicationDbContext>(
                (sp, optionsBuilder) =>
                {
                    var outboxInterceptor = sp.GetService<ConvertDomainEventsToOutboxMessagesInterceptor>()!;
                    var auditableInterceptor = sp.GetService<UpdateAuditableEntitiesInterceptor>()!;

                    optionsBuilder.UseSqlServer(connectionString)
                        .AddInterceptors(
                            outboxInterceptor,
                            auditableInterceptor
                            );
                });

        services.AddMemoryCache();

    }
}

