using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PhotoManagementPlatform.IoC.Modules;

namespace PhotoManagementPlatform.IoC
{
    public static class DependencyContainer
    {
        public static void RegisterModules(IServiceCollection services, IConfiguration configuration)
        {
            MediatorModule.Load(services, configuration);
            ApplicationModule.Load(services, configuration);
            InfrastructureModule.Load(services, configuration);
        }
    }
}
