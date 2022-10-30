using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace PhotoManagementPlatform.IoC.Modules;

internal static class MediatorModule
{
    internal static void Load(IServiceCollection services, IConfiguration configuration)
    {
        var appAssembly = Assembly.Load("PhotoManagementPlatform.Application");
        //var infraAssembly = Assembly.Load("PhotoManagementApp.Infrastructure");
        //var domainAssembly = Assembly.Load("PhotoManagementApp.Domain");

        services.AddMediatR(Assembly.GetExecutingAssembly(), appAssembly);
    }
}
