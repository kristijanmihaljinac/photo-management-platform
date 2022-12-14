using System;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using MediatR;
using Microsoft.Extensions.Configuration;
using PhotoManagementPlatform.Application.Behaviors;

namespace PhotoManagementPlatform.IoC.Modules;

internal class ApplicationModule
{
    internal static void Load(IServiceCollection services, IConfiguration configuration)
    {
        var appAssembly = Assembly.Load("PhotoManagementPlatform.Application");
        //var infraAssembly = Assembly.Load("PhotoManagementApp.Infrastructure");
        //var domainAssembly = Assembly.Load("PhotoManagementApp.Domain");

        services.AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidationPipelineBehavior<,>));
    }
}

