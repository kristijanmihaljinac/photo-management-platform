using System;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using Microsoft.Extensions.Configuration;

namespace PhotoManagementPlatform.IoC.Modules
{
	internal static class InfrastructureModule
	{
        internal static void Load(IServiceCollection services, IConfiguration configuration)
        {
            var appAssembly = Assembly.Load("PhotoManagementPlatform.Application");
            //var infraAssembly = Assembly.Load("PhotoManagementApp.Infrastructure");
            //var domainAssembly = Assembly.Load("PhotoManagementApp.Domain");


        }
    }
}

