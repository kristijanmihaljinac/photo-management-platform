using Autofac;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoManagementPlatform.IoC
{
    public static class DependencyContainer
    {
        public static void RegisterModules(ContainerBuilder builder, IConfiguration configuration)
        {
            string photoManagementDbConnectionString = configuration.GetConnectionString("PhotoManagementDb");

            builder.RegisterModule(new Modules.MediatorModule());

        }
    }
}
